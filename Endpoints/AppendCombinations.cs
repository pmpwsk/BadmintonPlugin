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
                        .ThenBy(player => player.Name)
                        .Select(player => new Paragraph($"{player.Name}: {player.Wins}/{player.Wins + player.Losses} ({Math.Round(player.Ratio * 100, 1, MidpointRounding.AwayFromZero)}%)")
                    )
                ),
                new Subsection(
                    Texts.Actions,
                    [
                        new ServerActionButton(
                            Texts.Players,
                            _ => GoToPlayers(tour)
                        ),
                        new ServerActionButton(
                            Texts.NewCombinations,
                            _ => GenerateNewCombinations(tour)
                        )
                    ]
                ),
                new Subsection(
                    Texts.Combinations,
                    Parsers.ConditionalIteration<AbstractElement>(
                        tour.Combinations.Any(comb => CombinationIsVisible(tour, comb)),
                        tour.Combinations.Where(comb => CombinationIsVisible(tour, comb))
                            .OrderBy(c => c.TeamA.Sum(p => tour.Players[p].Total) + c.TeamB.Sum(p => tour.Players[p].Total))
                            .Select(combination => new BigServerActionButton(
                                $"{Texts.Combination} {number++}",
                                [
                                    "A: " + FormatTeam(tour, combination.TeamA),
                                    "B: " + FormatTeam(tour, combination.TeamB)
                                ],
                                _ => ChooseMatch(tour, combination)
                            )),
                        new Paragraph(Texts.NoCombinations)
                    )
                )
            ]
        ));
    }
    
    private static bool CombinationIsVisible(BadmintonTournament tour, BadmintonCombination combination)
        => combination.TeamA.All(playerId => !tour.Players[playerId].Ignored)
           && combination.TeamB.All(playerId => !tour.Players[playerId].Ignored);

    private static string FormatTeam(BadmintonTournament tour, int[] team)
        => string.Join(", ", team.Select(m => tour.Players[m].Name));
    
    private async Task GoToPlayers(BadmintonTournament tour)
    {
        await using var t = Tournaments.StartModifying(ref tour);
        
        tour.ModifyingPlayers = true;
    }
    
    private async Task GenerateNewCombinations(BadmintonTournament tour)
    {
        await using var t = Tournaments.StartModifying(ref tour);
        
        tour.Combinations.Clear();
        GenerateCombinationsInTransaction(tour, false);
    }
    
    private async Task ChooseMatch(BadmintonTournament tour, BadmintonCombination combination)
    {
        await using var t = Tournaments.StartModifying(ref tour);
        
        tour.Combinations.Remove(combination);
        tour.Matches.Add(new(combination, Random.Shared.Next(2) == 0, [], false, false, false));
    }
}