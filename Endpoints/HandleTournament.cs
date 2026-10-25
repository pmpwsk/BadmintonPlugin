using uwap.WebFramework.Responses.DefaultUI;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    [Endpoint("/tournament")]
    protected async Task<Page> HandleTournamentAsync(Request req)
    {
        req.ForceGET();
        var id = req.Query.GetOrThrow("id");
        var tour = await Tournaments.GetByIdAsync(id);
        
        var page = new Page(req, true, PluginTexts.Badminton);
        await page.ReloadOnChangeAsync(tour);
        
        if (tour.ModifyingPlayers)
            AppendPlayers(tour, page);
        else if (tour.Matches.All(m => m.Finished))
            AppendCombinations(tour, page);
        else
            AppendMatch(tour, page);
        
        return page;
    }
}