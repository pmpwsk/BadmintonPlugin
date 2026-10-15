using uwap.WebFramework.Tools;

namespace uwap.WebFramework.Plugins;

/// <summary>
/// Information about a player.
/// </summary>
public class BadmintonPlayer(
    string name,
    bool ignored,
    int wins,
    int losses
) : FunctionalComparable<BadmintonPlayer> {
    /// <summary>
    /// The player's display name.
    /// </summary>
    public string Name = name;
    
    /// <summary>
    /// Whether combinations with this player should be hidden.
    /// </summary>
    public bool Ignored = ignored;
    
    /// <summary>
    /// The number of matches the player won.
    /// </summary>
    public int Wins = wins;
    
    /// <summary>
    /// The number of matches the player lost.
    /// </summary>
    public int Losses = losses;
    
    /// <summary>
    /// The total number of matches played.
    /// </summary>
    public int Total => Wins + Losses;
    
    /// <summary>
    /// The ratio of wins in relation to all matches.
    /// </summary>
    public double Ratio => Total == 0 ? 0 : (double)Wins / Total;

    protected bool Equals(BadmintonPlayer other)
    {
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((BadmintonPlayer)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public static bool operator ==(BadmintonPlayer? left, BadmintonPlayer? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(BadmintonPlayer? left, BadmintonPlayer? right)
    {
        return !Equals(left, right);
    }

    protected override IEnumerable<Func<BadmintonPlayer, IComparable>> EnumerateComparators()
        => [ p => p.Name ];
}
