using uwap.WebFramework.Localization;
using uwap.WebFramework.Responses.Actions;
using uwap.WebFramework.Responses.DefaultUI;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    private void AppendMatch(BadmintonTournament tour, Page page)
    {
        page.Sections.Add(new Section(
            PluginTexts.Badminton,
            [
                new Subsection(
                    PluginTexts.Match,
                    [
                        new Row(
                            MatchSideButton(tour, page, false),
                            MatchSideButton(tour, page, true)
                        ) { Style = "width: min(25rem, 100%);"},
                        new Row(
                            new ServerActionButton(
                                PluginTexts.Actions,
                                _ => OpenMatchDialog(tour, page)
                            ),
                            new LinkButton(
                                PluginTexts.Results,
                                $"results?id={tour.Id}"
                            )
                        )
                    ]
                )
            ]
        ));
    }
    
    private void OpenMatchDialog(BadmintonTournament tour, Page page)
        => DialogBuilder.Open(
            page,
            PluginTexts.Match,
            [
                new BigServerSubmitButton(
                    PluginTexts.Undo,
                    PluginTexts.UndoDescription,
                    _ => UndoLastPoint(tour)
                ),
                new BigServerSubmitButton(
                    CommonTexts.Cancel,
                    PluginTexts.CancelDescription,
                    _ => CancelMatchDialog(tour, page)
                ),
                ..InvertButtons(tour),
                new BigServerSubmitButton(
                    PluginTexts.FastWinA,
                    PluginTexts.FastWinDescription,
                    _ => FinishMatchDialog(tour, page, false, true)
                ),
                new BigServerSubmitButton(
                    PluginTexts.FastWinB,
                    PluginTexts.FastWinDescription,
                    _ => FinishMatchDialog(tour, page, true, true)
                ),
                new DialogBackButton(page)
            ],
            _ => DialogBuilder.Back(page)
        );
    
    private IEnumerable<BigServerSubmitButton> InvertButtons(BadmintonTournament tour)
    {
        if (tour.TeamSize > 1)
        {
            yield return new BigServerSubmitButton(
                PluginTexts.InvertA,
                PluginTexts.InvertDescription,
                _ => InvertTeam(tour, false)
            );
            yield return new BigServerSubmitButton(
                PluginTexts.InvertB,
                PluginTexts.InvertDescription,
                _ => InvertTeam(tour, true)
            );
        }
    }
    
    private static bool WinnerIsBool(BadmintonTournament tour, bool isB)
    {
        var match = tour.Matches.Last();
        var points = match.RoundsWonByB.Count(r => r == isB);
        var opponent = match.RoundsWonByB.Count(r => r == !isB);
        return points >= tour.Rounds && points >= opponent + 2;
    }
    
    private BigServerActionButton MatchSideButton(BadmintonTournament tour, Page page, bool isB)
    {
        var match = tour.Matches.Last();
        
        bool reversed = isB ? match.InvertB : match.InvertA;
        if (tour.TeamSize > 1)
        {
            bool lastFailed = match.FirstIsB != isB;
            foreach (var result in match.RoundsWonByB)
            {
                if (result == isB)
                {
                    //we won
                    if (lastFailed)
                    {
                        lastFailed = false;
                    }
                    else
                    {
                        reversed = !reversed;
                    }
                }
                else
                {
                    //they won
                    lastFailed = true;
                }
            }
        }
        
        var points = match.RoundsWonByB.Count(r => r == isB);
        var lastResult = match.RoundsWonByB.Count == 0 ? match.FirstIsB : match.RoundsWonByB.Last();
        var wonLast = lastResult == isB;
        var team = isB ? match.Combination.TeamB : match.Combination.TeamA;
        return new(
            $"{(isB ? PluginTexts.TeamB : PluginTexts.TeamA)} ({points})",
            PlayerLines(tour, isB, points, wonLast, reversed, team),
            _ => AddPoint(tour, page, isB)
        )
        {
            Style = "flex-basis: 0; flex-grow: 1; flex-shrink: 1; display: grid;",
            Submit = { Style = "gap: 0.5rem" }
        };
    }
    
    private static IEnumerable<string> PlayerLines(BadmintonTournament tour, bool isB, int points, bool wonLast, bool reversed, int[] team)
    {
        var left = PlayerLine(tour, isB, points, wonLast, reversed, team);
        var right = PlayerLine(tour, !isB, points, wonLast, reversed, team);
        if (left == null)
            if (right == null)
                return [];
            else
                return [right];
        else
            if (right == null)
                return [left];
            else
                return [left, right];
    }
    
    private static string? PlayerLine(BadmintonTournament tour, bool isRight, int points, bool wonLast, bool reversed, int[] team)
    {
        string player;
        if (team.Length != 1)
            player = tour.Players[team[isRight == reversed ? 0 : 1]].Name;
        else if (points % 2 == (isRight ? 0 : 1))
            player = tour.Players[team[0]].Name;
        else
            return null;

        string turn = points % 2 == (isRight ? 0 : 1) && wonLast ? "👉 " : "👀 ";
        return turn + player;
    }
    
    private async Task AddPoint(BadmintonTournament tour, Page page, bool isB)
    {
        var match = tour.Matches.Last();
        match.RoundsWonByB.Add(isB);
        
        if (WinnerIsBool(tour, isB))
        {
            FinishMatchDialog(tour, page, isB, false);
        }
        else
        {
            await using var t = Tournaments.StartModifying(ref tour);
            
            match = tour.Matches.Last();
            match.RoundsWonByB.Add(isB);
        }
    }
    
    private async Task UndoLastPoint(BadmintonTournament tour)
    {
        if (tour.Matches.Last().RoundsWonByB.Count == 0)
            throw new ForcedActionError(PluginTexts.NoPointsYet);
        
        await using var t = Tournaments.StartModifying(ref tour);
        
        var match = tour.Matches.Last();
        if (match.RoundsWonByB.Count == 0)
            t.RequestCancellation();
        else
            match.RoundsWonByB.RemoveAt(match.RoundsWonByB.Count - 1);
    }
    
    private void CancelMatchDialog(BadmintonTournament tour, Page page)
        => DialogBuilder.Open(
            page,
            PluginTexts.Match,
            [
                new Paragraph(PluginTexts.ReallyCancelMatch),
                new Row(
                    new ContinueButton(),
                    new DialogBackButton(page)
                )
            ],
            _ => CancelMatch(tour)
        );
    
    private async Task CancelMatch(BadmintonTournament tour)
    {
        await using var t = Tournaments.StartModifying(ref tour);
    
        var match = tour.Matches.Last();
        tour.Combinations.Add(match.Combination);
        tour.Matches.RemoveAt(tour.Matches.Count - 1);
    }
    
    private async Task InvertTeam(BadmintonTournament tour, bool isB)
    {
        await using var t = Tournaments.StartModifying(ref tour);
        
        var match = tour.Matches.Last();
        if (isB)
            match.InvertB = !match.InvertB;
        else
            match.InvertA = !match.InvertA;
    }
    
    private void FinishMatchDialog(BadmintonTournament tour, Page page, bool isB, bool synthetic)
        => DialogBuilder.Open(
            page,
            PluginTexts.MatchOver,
            [
                new Paragraph($"{PluginTexts.Winners}: {FormatTeam(tour, isB ? tour.Matches.Last().Combination.TeamB : tour.Matches.Last().Combination.TeamA)}"),
                new Row(
                    new ContinueButton(),
                    synthetic
                        ? new DialogBackButton(page) 
                        : new ServerSubmitButton(
                            PluginTexts.Undo,
                            _ =>
                            {
                                var match = tour.Matches.Last();
                                match.RoundsWonByB.RemoveAt(match.RoundsWonByB.Count - 1);
                                DialogBuilder.Close(page);
                            }
                        )
                )
            ],
            _ => FinishMatch(tour, isB, synthetic)
        );
    
    private async Task FinishMatch(BadmintonTournament tour, bool isB, bool synthetic)
    {
        await using var t = Tournaments.StartModifying(ref tour);
    
        var match = tour.Matches.Last();
        if (!synthetic)
            match.RoundsWonByB.Add(isB);
        match.Finished = true;
        int[] winners;
        int[] losers;
        if (isB)
        {
            winners = match.Combination.TeamB;
            losers = match.Combination.TeamA;
        }
        else
        {
            winners = match.Combination.TeamA;
            losers = match.Combination.TeamB;
        }
        foreach (var winner in winners)
            tour.Players[winner].Wins++;
        foreach (var loser in losers)
            tour.Players[loser].Losses++;
    }
}