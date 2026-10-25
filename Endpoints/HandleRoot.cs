using uwap.WebFramework.Localization;
using uwap.WebFramework.Responses.DefaultUI;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    [Endpoint("/")]
    protected Page HandleRoot(Request req)
    {
        req.ForceGET();
        
        var page = new Page(req, true, PluginTexts.Badminton);
        page.Sections.Add(new Section(
            PluginTexts.Badminton,
            [
                new Subsection(
                    PluginTexts.NewTournament,
                    [
                        NewTournamentButton(page, PluginTexts.Single11, 1, 11),
                        NewTournamentButton(page, PluginTexts.Single21, 1, 21),
                        NewTournamentButton(page, PluginTexts.Double11, 2, 11),
                        NewTournamentButton(page, PluginTexts.Double21, 2, 21)
                    ]
                )
            ]
        ));
        
        return page;
    }
    
    private ServerActionButton NewTournamentButton(Page page, Translation text, int teamSize, int rounds)
        => new(
            text,
            async _ =>
            {
                var value = await Tournaments.CreateAsync(teamSize, rounds);
                page.Navigate("tournament?id=" + value.Id);
            }
        );
}