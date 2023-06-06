using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
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
           
            using (var db = new KorfinContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                logger.Debug("Список объектов:");
                foreach (DAL.User u in users)
                {
                    logger.Debug($"{u.Id}.{u.Name} - {u.IdOst}- {u.Email}");
                }
            }
        }

       
    }
}