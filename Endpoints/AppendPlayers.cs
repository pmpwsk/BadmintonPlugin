using uwap.WebFramework.Localization;
using uwap.WebFramework.Responses.Actions;
using uwap.WebFramework.Responses.Base;
using uwap.WebFramework.Responses.DefaultUI;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    private void AppendPlayers(BadmintonTournament tour, Page page)
        => page.Sections.Add(new Section(
            PluginTexts.Badminton,
            [
                new Subsection(
                    PluginTexts.Players,
                    Parsers.ConditionalIteration<AbstractElement>(
                        tour.Players.Length != 0,
                        tour.Players.OrderBy(player => player.Name).Select(player => new ServerActionButton(
                            new(player.Ignored ? "bi bi-ban" : "bi bi-person-fill", player.Name),
                            _ => OpenPlayerDialog(tour, page, player)
                        )),
                        new Paragraph(PluginTexts.NoPlayers)
                    )
                ),
                new ServerForm(
                    PluginTexts.NewPlayer,
                    [
                        new TextBox(
                            "player-name",
                            PluginTexts.NamePlaceholder,
                            null,
                            TextBoxRole.Normal
                        ) { Autofocus = true }.Save(out var nameInput),
                        new SubmitButton(CommonTexts.Add)
                    ],
                    _ => AddPlayer(tour, nameInput)
                ),
                new ServerForm(
                    PluginTexts.Start,
                    [
                        new ContinueButton()
                    ],
                    _ => StartTournament(tour)
                )
            ]
        ));
    
    private async Task AddPlayer(BadmintonTournament tour, TextBox nameInput)
    {
        if (nameInput.IsEmpty(out var name))
            throw new ForcedActionError(CommonTexts.EmptyFields);
        
        name = NormalizeName(name);

        await using var t = Tournaments.StartModifying(ref tour);
        
        if (tour.Players.Any(p => p.Name == name))
        {
            t.RequestCancellation();
            throw new ForcedActionError(PluginTexts.NameExists);
        }
        
        nameInput.SetValueForClient("");
        tour.Players = [..tour.Players, new BadmintonPlayer(name, false, 0, 0)];
        Array.Sort(tour.Players);
        GenerateCombinationsInTransaction(tour, true);
    }
    
    private void OpenPlayerDialog(BadmintonTournament tour, Page page, BadmintonPlayer player)
        => DialogBuilder.Open(
            page,
            player.Name,
            [
                player.Ignored
                    ? new BigServerSubmitButton(
                        PluginTexts.Activate,
                        PluginTexts.ActivatePlayerDescription,
                        _ => TogglePlayerState(tour, player, false)
                    ) : new BigServerSubmitButton(
                        PluginTexts.Deactivate,
                        PluginTexts.DeactivatePlayerDescription,
                        _ => TogglePlayerState(tour, player, true)
                    ),
                new BigServerSubmitButton(
                    CommonTexts.Rename,
                    PluginTexts.RenamePlayerDescription,
                    _ => OpenPlayerRenameDialog(tour, page, player)
                ),
                new BigServerSubmitButton(
                    CommonTexts.Delete,
                    PluginTexts.RemovePlayerDescription,
                    _ => OpenPlayerDeletionDialog(tour, page, player)
                ),
                new DialogBackButton(page)
            ],
            _ => DialogBuilder.Back(page)
        );
    
    private async Task TogglePlayerState(BadmintonTournament tour, BadmintonPlayer player, bool ignored)
    {
        await using var t = Tournaments.StartModifying(ref tour);
        
        var transactionPlayer = tour.Players.FirstOrDefault(p => p == player);
        if (transactionPlayer != null)
            transactionPlayer.Ignored = ignored;
    }
    
    private void OpenPlayerRenameDialog(BadmintonTournament tour, Page page, BadmintonPlayer player)
        => DialogBuilder.Open(
            page,
            player.Name,
            [
                new TextBox(
                    "player-name",
                    PluginTexts.NamePlaceholder,
                    player.Name,
                    TextBoxRole.Normal
                    ) { Autofocus = true }
                    .Save(out var nameInput),
                new Row(
                    new ContinueButton(),
                    new DialogBackButton(page)
                )
            ],
            _ => RenamePlayer(tour, player, nameInput)
        );
    
    private async Task RenamePlayer(BadmintonTournament tour, BadmintonPlayer player, TextBox nameInput)
    {
        if (nameInput.IsEmpty(out var name))
            throw new ForcedActionError(CommonTexts.EmptyFields);
        
        name = NormalizeName(name);
        
        if (player.Name == name)
            throw new ForcedActionError(PluginTexts.NameSame);

        await using var t = Tournaments.StartModifying(ref tour);
        
        if (tour.Players.Any(p => p.Name == name))
        {
            t.RequestCancellation();
            throw new ForcedActionError(PluginTexts.NameExists);
        }
        
        nameInput.SetValueForClient("");
        var transactionPlayer = tour.Players.FirstOrDefault(p => p == player);
        if (transactionPlayer != null)
            transactionPlayer.Name = name;
    }
    
    private void OpenPlayerDeletionDialog(BadmintonTournament tour, Page page, BadmintonPlayer player)
        => DialogBuilder.Open(
            page,
            player.Name,
            [
                new Paragraph(PluginTexts.ReallyRemovePlayer),
                new Row(
                    new ContinueButton(),
                    new DialogBackButton(page)
                )
            ],
            _ => DeletePlayer(tour, player)
        );
    
    private async Task DeletePlayer(BadmintonTournament tour, BadmintonPlayer player)
    {
        await using var t = Tournaments.StartModifying(ref tour);
        
        tour.Players = [..tour.Players.Where(p => p != player)];
        GenerateCombinationsInTransaction(tour, false);
        tour.Matches.Clear();
    }
    
    private async Task StartTournament(BadmintonTournament tour)
    {
        if (tour.Players.Count(player => !player.Ignored) < tour.TeamSize * 2)
            throw new ForcedActionError(PluginTexts.NotEnoughPlayers);
        
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
    
    private static string NormalizeName(string name)
        => string.Join(' ', name.Split(' ').Select(n => n[..1].ToUpper() + n[1..].ToLower()));
}