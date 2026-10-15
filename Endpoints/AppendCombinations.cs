using uwap.WebFramework.Responses.Base;
using uwap.WebFramework.Responses.DefaultUI;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    private void AppendCombinations(BadmintonTournament tour, Page page)
    {
        var number = 1;
        page.Sections.Add(new Section(
            Texts.Badminton,
            [
                new Subsection(
                    Texts.Results,
                    tour.Players
                        .OrderByDescending(player => player.Ratio)
                        .Select(player => new Paragraph($"{player.Name}: {player.Wins}/{player.Wins + player.Losses} ({Math.Round(player.Ratio * 100, 1, MidpointRounding.AwayFromZero)}%)")
                    )
                ),
                new Subsection(
                    Texts.Actions,
                    [
                        new ServerActionButton(
                            Texts.Players,
                            _ => ModifyPlayersAction(tour)
                        ),
                        new ServerActionButton(
                            Texts.NewCombinations,
                            _ => NewCombinationsAction(tour)
                        )
                    ]
                ),
                new Subsection(
                    Texts.Combinations,
                    Parsers.ConditionalIteration<AbstractElement>(
                        tour.Combinations.Count != 0,
                        tour.Combinations
                            .OrderBy(c => c.TeamA.Sum(p => tour.Players[p].Total) + c.TeamB.Sum(p => tour.Players[p].Total))
                            .Select(combination => new BigServerActionButton(
                                $"{Texts.Combination} {number++}",
                                [
                                    "A: " + FormatTeam(tour, combination.TeamA),
                                    "B: " + FormatTeam(tour, combination.TeamB)
                                ],
                                _ => SelectMatchAction(tour, combination)
                            )),
                        new Paragraph(Texts.NoCombinations)
                    )
                )
            ]
        ));
    }

    private static string FormatTeam(BadmintonTournament tour, int[] team)
        => string.Join(", ", team.Select(m => tour.Players[m].Name));
    
    private async Task ModifyPlayersAction(BadmintonTournament tour)
    {
        await using var t = Tournaments.StartModifying(ref tour);
        
        tour.ModifyingPlayers = true;
    }
    
    private async Task NewCombinationsAction(BadmintonTournament tour)
    {
        await using var t = Tournaments.StartModifying(ref tour);
        
        tour.Combinations.Clear();
        GenerateCombinationsInTransaction(tour, false);
    }
    
    private async Task SelectMatchAction(BadmintonTournament tour, BadmintonCombination combination)
    {
        await using var t = Tournaments.StartModifying(ref tour);
        
        tour.Combinations.Remove(combination);
        tour.Matches.Add(new(combination, Random.Shared.Next(2) == 0, [], false));
    }
}