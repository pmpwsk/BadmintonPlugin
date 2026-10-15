namespace uwap.WebFramework.Plugins;

public partial class BadmintonPlugin
{
    public override async Task WorkAsync()
    {
        foreach (var tour in await Tournaments.ListAllAsync())
            if (tour.ModificationDate + TimeSpan.FromDays(1) <= DateTime.UtcNow)
                await Tournaments.DeleteAsync(tour);
    }
}