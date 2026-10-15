using uwap.WebFramework.Database;

namespace uwap.WebFramework.Plugins;

/// <summary>
/// A badminton tournament.
/// </summary>
public class BadmintonTournament(
    EntryState state,
    int teamSize,
    int rounds,
    BadmintonPlayer[] players,
    bool modifyingPlayers,
    List<BadmintonCombination> combinations,
    List<BadmintonMatch> matches
) : AbstractTableValue(state) {
    /// <summary>
    /// The date when the object was last changed.
    /// </summary>
    public DateTime ModificationDate = DateTime.UtcNow;
    
    /// <summary>
    /// The number of players a team has.
    /// </summary>
    public readonly int TeamSize = teamSize;
    
    /// <summary>
    /// The minimum number of rounds required to win.
    /// </summary>
    public readonly int Rounds = rounds;
    
    /// <summary>
    /// All possible players.
    /// </summary>
    public BadmintonPlayer[] Players = players;
    
    /// <summary>
    /// Whether the players are currently being modified.
    /// </summary>
    public bool ModifyingPlayers = modifyingPlayers;
    
    /// <summary>
    /// The combinations that haven't played yet.
    /// </summary>
    public List<BadmintonCombination> Combinations = combinations;
    
    /// <summary>
    /// The matches that have been played and the ongoing match.
    /// </summary>
    public List<BadmintonMatch> Matches = matches;
}
