namespace BlazorServerSignalRApp.Data;

public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray());
    }


    NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

    public List<DAL.User> GetUsers()
    {
        List<DAL.User> users = new List<DAL.User>();

        using (DAL.UserPortalContext db = new DAL.UserPortalContext())
        {
            // получаем объекты из бд и выводим на консоль
            users = db.Users.ToList();
            logger.Debug("Список объектов:");
            foreach (DAL.User u in users)
            {
                logger.Debug($"{u.Id}.{u.FirstName} - {u.LastName}");
            }
        }
        return users;
    }

}
