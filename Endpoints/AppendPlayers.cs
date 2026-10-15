using uwap.WebFramework.Responses.Actions;
using uwap.WebFramework.Responses.Base;
using uwap.WebFramework.Responses.DefaultUI;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    private void AppendPlayers(BadmintonTournament tour, Page page)
        => page.Sections.Add(new Section(
            Texts.Badminton,
            [
                new Subsection(
                    Texts.Players,
                    Parsers.ConditionalIteration<AbstractElement>(
                        tour.Players.Length != 0,
                        tour.Players.Select(player => new ServerActionButton(
                            new("bi bi-trash-fill", player.Name),
                            _ => PlayerMenuAction(tour, page, player)
                        )),
                        new Paragraph(Texts.NoPlayers)
                    )
                ),
                new ServerForm(
                    Texts.NewPlayer,
                    [
                        new TextBox(
                            "player-name",
                            Texts.Name + "...",
                            null,
                            TextBoxRole.Normal
                        ) { Autofocus = true }.Save(out var nameInput),
                        new SubmitButton(Texts.Add)
                    ],
                    _ => AddPlayerAction(tour, nameInput)
                ),
                new ServerForm(
                    Texts.Start,
                    [
                        new SubmitButton(Texts.Continue)
                    ],
                    _ => StartTournamentAction(tour)
                )
            ]
        ));
    
    private async Task AddPlayerAction(BadmintonTournament tour, TextBox nameInput)
    {
        if (nameInput.IsEmpty(out var name))
            throw new ForcedActionError(Texts.NameMissing);
        
        name = string.Join(' ', name.Split(' ').Select(n => n[..1].ToUpper() + n[1..].ToLower()));

        await using var t = Tournaments.StartModifying(ref tour);
        
        if (tour.Players.Any(p => p.Name == name))
        {
            t.RequestCancellation();
            throw new ForcedActionError(Texts.NameMissing);
        }
        
        nameInput.SetValueForClient("");
        tour.Players = [..tour.Players, new BadmintonPlayer(name, 0, 0)];
        Array.Sort(tour.Players);
        GenerateCombinationsInTransaction(tour, true);
    }
    
    private void PlayerMenuAction(BadmintonTournament tour, Page page, BadmintonPlayer player)
        => DialogBuilder.Open(
            page,
            player.Name,
            [
                new Paragraph(Texts.ReallyRemovePlayer),
                new Row(
                    new SubmitButton(Texts.Continue),
                    new ServerSubmitButton(
                        Texts.Cancel,
                        _ => DialogBuilder.Close(page)
                    )
                )
            ],
            _ => RemovePlayerAction(tour, player)
        );
    
    private async Task RemovePlayerAction(BadmintonTournament tour, BadmintonPlayer player)
    {
        await using var t = Tournaments.StartModifying(ref tour);
        
        tour.Players = [..tour.Players.Where(p => p != player)];
        GenerateCombinationsInTransaction(tour, false);
        tour.Matches.Clear();
    }
    
    private async Task StartTournamentAction(BadmintonTournament tour)
    {
        if (tour.Players.Length < tour.TeamSize * 2)
            throw new ForcedActionError(Texts.NotEnoughPlayers);
        
        await using var t = Tournaments.StartModifying(ref tour);
        
        tour.ModifyingPlayers = false;
    }
    
    private void GenerateCombinationsInTransaction(BadmintonTournament tour, bool lastRequired)
    {
        BadmintonCombination.Generate(tour, lastRequired);
        var combinations = tour.Combinations.ToArray();
        Random.Shared.Shuffle(combinations);
        tour.Combinations = [..combinations];
    }
}