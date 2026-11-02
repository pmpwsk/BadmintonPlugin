using uwap.WebFramework.Database;

namespace uwap.WebFramework.Plugins;

/// <summary>
/// A table containing badminton tournaments.
/// </summary>
public class BadmintonTournamentTable(string name, List<ClusterNode> clusterNodes)
    : Table<BadmintonTournament>(name, clusterNodes)
{
    public override AbstractSerializer Serializer
        => Serializers.Json;

    public override ulong TypeIteration
        => 1;

    public override int MinimumIdLength
        => 8;

    public override ModifyTransactionData StartModifying(ref BadmintonTournament tour)
    {
        var result = base.StartModifying(ref tour);
        tour.ModificationDate = DateTime.UtcNow;
        return result;
    }
    
    public async Task<BadmintonTournament> CreateAsync(int teamSize, int rounds)
    {
        var value = new BadmintonTournament(EntryState.CreateEmpty(), teamSize, rounds, [], true, [], []);
        await CreateAsync(value);
        return value;
    }
}
