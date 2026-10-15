using uwap.WebFramework.Database;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin : Plugin
{
    public BadmintonPlugin(List<ClusterNode> clusterNodes)
    {
        Tournaments = BadmintonTournamentTable.Import(TournamentTableName, clusterNodes);
    }
}