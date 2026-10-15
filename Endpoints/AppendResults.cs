using uwap.WebFramework.Responses.DefaultUI;

namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    private static void AppendResults(BadmintonTournament tour, Page page)
    {
        page.Sections.Add(new Section(
            Texts.Badminton,
            [
                new Subsection(
                    Texts.Results,
                    [
                        ..tour.Players
                            .OrderByDescending(player => player.Ratio)
                            .ThenBy(player => player.Name)
                            .Select(player => new Paragraph($"{player.Name}: {player.Wins}/{player.Wins + player.Losses} ({Math.Round(player.Ratio * 100, 1, MidpointRounding.AwayFromZero)}%)")),
                        new LinkButton(
                            Texts.Back,
                            $"tournament?id={tour.Id}"
                        )
                    ]
                )
            ]
        ));
    }
}