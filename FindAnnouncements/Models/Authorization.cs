using System;
using System.Linq;

namespace FindAnnouncements.Models
{
    public class Authorization
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
            var log = new Log
            {
                UserID = user.UserID,
                Date = DateTime.Now,
                Operation = operation,
                Description = description
            };

            using (var context = new FindAnnouncementsModel())
            {
                context.Logs.Add(log);
                context.SaveChanges();
            }
        }
    }
}
