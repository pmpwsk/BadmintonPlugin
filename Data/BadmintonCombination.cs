namespace uwap.WebFramework.Plugins;

/// <summary>
/// A combination of players split across two teams.
/// </summary>
public class BadmintonCombination(
    int[] teamA,
    int[] teamB
) {
    public static void Generate(BadmintonTournament tour, bool lastRequired)
    {
        switch (tour.TeamSize)
        {
            case 1:
                if (lastRequired)
                    GenerateMissingSingle(tour);
                else
                    GenerateAllSingle(tour);
                break;
            case 2:
                if (lastRequired)
                    GenerateMissingDouble(tour);
                else
                    GenerateAllDouble(tour);
                break;
            default:
                throw new Exception("Invalid team size.");
        }
    }
    
    public static void GenerateAllSingle(BadmintonTournament tour)
    {
        tour.Combinations.Clear();
        for (int player1 = 0; player1 < tour.Players.Length - 1; player1++)
        for (int player2 = player1 + 1; player2 < tour.Players.Length; player2++)
            AddSinglePlayers(tour, player1, player2);
    }
    
    public static void GenerateMissingSingle(BadmintonTournament tour)
    {
        var player1 = tour.Players.Length - 1;
        for (int player2 = 0; player2 < tour.Players.Length - 1; player2++)
            AddSinglePlayers(tour, player1, player2);
    }
    
    public static void AddSinglePlayers(BadmintonTournament tour, int player1, int player2)
    {
        int[] players = [player1, player2];
        Random.Shared.Shuffle(players);
        tour.Combinations.Add(new(
            [players[0]],
            [players[1]]
        ));
    }
    
    public static void GenerateAllDouble(BadmintonTournament tour)
    {
        tour.Combinations.Clear();
        for (int player1 = 0; player1 < tour.Players.Length - 3; player1++)
        for (int player2 = player1 + 1; player2 < tour.Players.Length - 2; player2++)
        for (int player3 = player2 + 1; player3 < tour.Players.Length - 1; player3++)
        for (int player4 = player3 + 1; player4 < tour.Players.Length; player4++)
            AddDoublePlayers(tour, player1, player2, player3, player4);
    }
    
    public static void GenerateMissingDouble(BadmintonTournament tour)
    {
        var player1 = tour.Players.Length - 1;
        for (int player2 = 0; player2 < tour.Players.Length - 3; player2++)
        for (int player3 = player2 + 1; player3 < tour.Players.Length - 2; player3++)
        for (int player4 = player3 + 1; player4 < tour.Players.Length - 1; player4++)
            AddDoublePlayers(tour, player1, player2, player3, player4);
    }
    
    public static void AddDoublePlayers(BadmintonTournament tour, int player1, int player2, int player3, int player4)
    {
        int[] players = [player1, player2, player3, player4];
        Random.Shared.Shuffle(players);
        tour.Combinations.Add(new(
            [players[0], players[1]],
            [players[2], players[3]]
        ));
        tour.Combinations.Add(new(
            [players[0], players[2]],
            [players[1], players[3]]
        ));
        tour.Combinations.Add(new(
            [players[0], players[3]],
            [players[1], players[2]]
        ));
    }
    
    /// <summary>
    /// The members of team A.
    /// </summary>
    public readonly int[] TeamA = teamA;
    
    /// <summary>
    /// The members of team B.
    /// </summary>
    public readonly int[] TeamB = teamB;

    protected bool Equals(BadmintonCombination other)
    {
        return TeamA.SequenceEqual(other.TeamA) && TeamB.SequenceEqual(other.TeamB);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((BadmintonCombination)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(TeamA, TeamB);
    }

    public static bool operator ==(BadmintonCombination? left, BadmintonCombination? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(BadmintonCombination? left, BadmintonCombination? right)
    {
        return !Equals(left, right);
    }
}
