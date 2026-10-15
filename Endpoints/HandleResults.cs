using uwap.WebFramework.Responses.DefaultUI;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    [Endpoint("/results")]
    protected async Task<Page> HandleResultsAsync(Request req)
    {
        req.ForceGET();
        var id = req.Query.GetOrThrow("id");
        var tour = await Tournaments.GetByIdAsync(id);
        
        var page = new Page(req, true, Texts.Badminton);
        await page.ReloadOnChangeAsync(tour);
        
        AppendResults(tour, page);
        
        return page;
    }
}