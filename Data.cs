using uwap.WebFramework.Database;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin(List<ClusterNode> clusterNodes) : Plugin
{   
    public const string TournamentTableName = "BadmintonPlugin.Tournaments";
    private readonly BadmintonTournamentTable Tournaments = new(TournamentTableName, clusterNodes);
}