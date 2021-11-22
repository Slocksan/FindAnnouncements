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
        public string ErrorMassage { get; set; }
        public string OperationType { get; set; }
        public string Description { get; set; }

        // static Login - метод - проверка существования элемента юзера, возвращает IsAutorized
        public static Authorization Login(User user)
        {
            var authorization = new Authorization();
            using (var context = new FindAnnouncementsModel())
            {
                var foundUsers = context.Users.Where(p => p.Login == user.Login).ToArray();

                if (foundUsers.Count() == 1)
                {
                    authorization.User = foundUsers.First();
                    if (user.Password == foundUsers[0].Password)
                    {
                        authorization.IsAutorized = true;
                        authorization.OperationType = "Авторизация";
                        authorization.Description = "Вход в систему";
                    }
                    else
                    {
                        authorization.IsAutorized = false;
                        authorization.OperationType = "Авторизация";
                        authorization.ErrorMassage = "Неверный пароль. Попробуйте снова.";
                        authorization.Description = "Неверный пароль";
                    }
                }
                else
                {
                    authorization.IsAutorized = false;
                    authorization.OperationType = "Авторизация";
                    authorization.ErrorMassage = "Такого имени пользователя не существует.";
                    authorization.Description = "Неверное имя пользователя";
                }
                return authorization;
            }
            
        }

        // static Registrate - метод - новый юзер void
        public static Authorization Registrate(User user)
        {
            var authorization = new Authorization();
            using (var context = new FindAnnouncementsModel())
            {
                authorization.OperationType = "Регистрация";
                var foundUsers = context.Users.Where(p => p.Login == user.Login).ToArray();
                if (foundUsers.Count() == 0)
                {
                    if (user.Password.Length >= 6)
                    {
                        authorization.User = user;
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                    else
                    {
                        authorization.ErrorMassage = "Введенный пароль слишком короткий";
                        authorization.Description = "Ошибка ввода пароля";
                    }
                }
                else
                {
                    authorization.ErrorMassage = "Пользователь с таким логином уже существует";
                    authorization.Description = "Ввод уже существующего логина";
                }
            }

            return authorization;
        }


        // Journaling() - добавление в таблицу новый лог о возникновении ошибки
        public static void Journaling(Authorization authorization)
        {
            var log = new Log();
            using (var context = new FindAnnouncementsModel())
            {
                log.UserID = authorization.User.UserID;
                log.Date = DateTime.Now;
                log.Operation = authorization.OperationType;
                log.Description = authorization.Description;
                context.Logs.Add(log);
                context.SaveChanges();
            }
        }
    }
}
