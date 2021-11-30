using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAnnouncements.Models
{
    class Authorization
    {
        public bool IsAutorized { get; set; }
        public User User { get; set; }
        public string ErrorMessage { get; set; } = "";

        public static Authorization Login(User user)
        {
            var authorization = new Authorization();

            using (var context = new FindAnnouncementsModel())
            {
                var foundUsers = context.Users.Where(p => p.Login == user.Login).ToArray();

                if (foundUsers.Any())
                {
                    if (user.Password == foundUsers[0].Password)
                    {
                        authorization.User = foundUsers.First();
                        authorization.IsAutorized = true;
                    }
                    else
                    {
                        authorization.IsAutorized = false;
                        authorization.ErrorMessage = "Неверный пароль";
                    }
                }
                else
                {
                    authorization.IsAutorized = false;
                    authorization.ErrorMessage = "Такого пользователя не существует";
                }
                return authorization;
            }
            
        }

        public static Authorization Registrate(User user)
        {
            var authorization = new Authorization();
            using (var context = new FindAnnouncementsModel())
            {
                var foundUsers = context.Users.Where(p => p.Login == user.Login).ToList();
                if (!foundUsers.Any())
                {
                    authorization.User = user;
                    authorization.IsAutorized = true;
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                else
                {
                    authorization.ErrorMessage = "Пользователь с таким логином уже существует";
                    authorization.IsAutorized = false;
                }
            }

            return authorization;
        }


        public static void Journaling(User user, string operation, string description)
        {
            var log = new Log();
            using (var context = new FindAnnouncementsModel())
            {
                log.UserID = user.UserID;
                log.Date = DateTime.Now;
                log.Operation = operation;
                log.Description = description;
                context.Logs.Add(log);
                context.SaveChanges();
            }
        }
    }
}
