using uwap.WebFramework.Responses.DefaultUI;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    private void AppendMatch(BadmintonTournament tour, Page page)
    {
        page.Sections.Add(new Section(
            Texts.Badminton,
            [
                new Subsection(
                    Texts.Match,
                    [
                        new Row(
                            MatchSideButton(tour, page, false),
                            MatchSideButton(tour, page, true)
                        ) { Style = "width: min(25rem, 100%);"},
                        new Row(
                            new ServerActionButton(
                                Texts.Undo,
                                _ => UndoAction(tour)
                            ),
                            new ServerActionButton(
                                Texts.CancelWithIcon,
                                _ => CancelQuestionAction(tour, page)
                            )
                        )
                    ]
                )
            ]
        ));
    }
    
    private bool WinnerIsBool(BadmintonTournament tour, bool isB)
    {
        var match = tour.Matches.Last();
        var points = match.RoundsWonByB.Count(r => r == isB);
        var opponent = match.RoundsWonByB.Count(r => r == !isB);
        return points >= tour.Rounds && points >= opponent + 2;
    }
    
    private BigServerActionButton MatchSideButton(BadmintonTournament tour, Page page, bool isB)
    {
        var match = tour.Matches.Last();
        
        bool reversed = false;
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
            $"Team {(isB ? "B" : "A")} ({points})",
            PlayerLines(tour, isB, points, wonLast, reversed, team),
            _ => AddPointAction(tour, page, isB)
        )
        {
            Style = "flex-basis: 0; flex-grow: 1; flex-shrink: 1; display: grid;",
            Submit = { Style = "gap: 0.5rem" }
        };
    }
    
    private IEnumerable<string> PlayerLines(BadmintonTournament tour, bool isB, int points, bool wonLast, bool reversed, int[] team)
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
    
    private string? PlayerLine(BadmintonTournament tour, bool isRight, int points, bool wonLast, bool reversed, int[] team)
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
    
    private async Task AddPointAction(BadmintonTournament tour, Page page, bool isB)
    {
        var match = tour.Matches.Last();
        match.RoundsWonByB.Add(isB);
        
        if (WinnerIsBool(tour, isB))
        {
            DialogBuilder.Open(
                page,
                Texts.MatchOver,
                [
                    new Paragraph($"{Texts.Winners}: {FormatTeam(tour, isB ? tour.Matches.Last().Combination.TeamB : tour.Matches.Last().Combination.TeamA)}"),
                    new Row(
                        new SubmitButton(Texts.Continue),
                        new ServerSubmitButton(
                            Texts.Undo,
                            _ =>
                            {
                                match.RoundsWonByB.RemoveAt(match.RoundsWonByB.Count - 1);
                                DialogBuilder.Close(page);
                            }
                        )
                    )
                ],
                _ => FinishMatchAction(tour, isB)
            );
        }
        else
        {
            await using var t = Tournaments.StartModifying(ref tour);
            
            match = tour.Matches.Last();
            match.RoundsWonByB.Add(isB);
        }
    }
    
    private async Task UndoAction(BadmintonTournament tour)
    {
        await using var t = Tournaments.StartModifying(ref tour);
        
        var match = tour.Matches.Last();
        if (match.RoundsWonByB.Count == 0)
            t.RequestCancellation();
        else
            match.RoundsWonByB.RemoveAt(match.RoundsWonByB.Count - 1);
    }
    
    private void CancelQuestionAction(BadmintonTournament tour, Page page)
        => DialogBuilder.Open(
            page,
            Texts.Cancel,
            [
                new Paragraph(Texts.ReallyCancelMatch),
                new Row(
                    new SubmitButton(Texts.Continue),
                    new ServerSubmitButton(
                        Texts.Cancel,
                        _ => DialogBuilder.Close(page)
                    )
                )
            ],
            _ => CancelAction(tour)
        );
    
    private async Task CancelAction(BadmintonTournament tour)
    {
        await using var t = Tournaments.StartModifying(ref tour);
    
        var match = tour.Matches.Last();
        tour.Combinations.Add(match.Combination);
        tour.Matches.RemoveAt(tour.Matches.Count - 1);
    }
    
    private async Task FinishMatchAction(BadmintonTournament tour, bool isB)
    {
        await using var t = Tournaments.StartModifying(ref tour);
    
        var match = tour.Matches.Last();
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