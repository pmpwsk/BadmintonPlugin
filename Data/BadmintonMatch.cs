namespace uwap.WebFramework.Plugins;

/// <summary>
/// An ongoing or finished match.
/// </summary>
public class BadmintonMatch(
    BadmintonCombination combination,
    bool firstIsB,
    List<bool> roundsWonByB,
    bool finished
) {
    /// <summary>
    /// The player combination for this match.
    /// </summary>
    public BadmintonCombination Combination = combination;
    
    /// <summary>
    /// Whether the side for the first round is team B. 
    /// </summary>
    public bool FirstIsB = firstIsB;
    
    /// <summary>
    /// The list of round results, false if won by A, true if won by B.
    /// </summary>
    public List<bool> RoundsWonByB = roundsWonByB;
    
    /// <summary>
    /// Whether the match has been confirmed as finished.
    /// </summary>
    public bool Finished = finished;
}
