

namespace DAL;

public class UsersService
{
     NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

    public List<User> GetUsers()
    {
        List<DAL.User> users = new List<DAL.User>();
        using (var db = new KorfinContext())
        {
            // получаем объекты из бд и выводим на консоль
            users = db.Users.ToList();
            logger.Debug("Список объектов:");
            foreach (DAL.User u in users)
            {
                logger.Debug($"{u.Id}.{u.Name} - {u.Email}");
            }
        }
        return users;
    }

}