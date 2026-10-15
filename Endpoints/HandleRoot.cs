using uwap.WebFramework.Responses.DefaultUI;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    [Endpoint("/")]
    protected Page HandleRoot(Request req)
    {
        req.ForceGET();
        
        var page = new Page(req, true, Texts.Badminton);
        page.Sections.Add(new Section(
            Texts.Badminton,
            [
                new Subsection(
                    Texts.NewTournament,
                    [
                        NewTournamentButton(page, Texts.Single11, 1, 11),
                        NewTournamentButton(page, Texts.Single21, 1, 21),
                        NewTournamentButton(page, Texts.Double11, 2, 11),
                        NewTournamentButton(page, Texts.Double21, 2, 21)
                    ]
                )
            ]
        ));
        
        return page;
    }
    
    private ServerActionButton NewTournamentButton(Page page, CustomText text, int teamSize, int rounds)
        => new(
            text,
            async _ =>
            {
                var value = await Tournaments.CreateAsync(teamSize, rounds);
                page.Navigate("tournament?id=" + value.Id);
            }
        );
}