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
        public string ErrorDescription { get; set; }

        // static Login - метод - проверка существования элемента юзера, возвращает IsAutorized
        public static Authorization Login(User user)
        {
            var authorization = new Authorization();
            using (var context = new FindAnnouncementsModel())
            {
                var foundUsers = context.Users.Where(p => p.Login == user.Login).ToArray();

                authorization.User = foundUsers.First();
                if (foundUsers.Count() == 1)
                {
                    if (authorization.User.Password == foundUsers[0].Password)
                        authorization.IsAutorized = true;
                    else
                    {
                        authorization.OperationType = "Авторизация";
                        authorization.ErrorMassage = "Такого имени пользователя не существует.";
                        authorization.ErrorDescription = "Неверное имя пользователя";
                    }
                }
                else
                {
                    authorization.IsAutorized = false;
                    authorization.OperationType = "Авторизация";
                    authorization.ErrorMassage = "Неверный пароль. Попробуйте снова.";
                    authorization.ErrorDescription = "Неверный пароль";
                }
                return authorization;
            }
            
        }

        // static Registrate - метод - новый юзер void
        public void Registrate(User user)
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
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                    else
                    {
                        authorization.OperationType = "Регистрация";
                        authorization.ErrorMassage = "Введенный пароль слишком короткий";
                        authorization.ErrorDescription = "Ошибка ввода пароля";
                    }
                }
                else
                {
                    authorization.ErrorMassage = "Пользователь с таким логином уже существует";
                    authorization.ErrorDescription = "Ввод уже существующего логина";
                }
            }
        }


        // Journaling() - добавление в таблицу новый лог о возникновении ошибки
        public void Journaling(User user, Authorization authorization)
        {
                if (authorization.ErrorMassage != null)
                {
                    var log = new Log();
                    using (var context = new FindAnnouncementsModel())
                    {
                    log.User = user;
                    log.Date = DateTime.Now;
                    log.Operation = authorization.OperationType;
                    log.Description = authorization.ErrorDescription;
                    context.Logs.Add(log);
                    context.SaveChanges();
                }
            }
        }
    }
}
