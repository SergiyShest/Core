using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_DB_FIRST;
//using NUnit.Framework;

namespace ConsoleDB.Tests
{
    [TestClass()]
  
    public class mainPrTests
    {
        [TestMethod()]
        public void maTest()
        {
             NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
           
            using (UserPortalContext db = new UserPortalContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                logger.Debug("Список объектов:");
                foreach (DAL_DB_FIRST.User u in users)
                {
                    logger.Debug($"{u.Id}.{u.FirstName} - {u.LastName}");
                }
            }
        }

       
    }
}