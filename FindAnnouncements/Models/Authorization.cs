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

        // static Login - метод - проверка существования элемента юзера, возвращает IsAutorized

        // static Registrate - метод - новый юзер void

        // Journaling() - добавление в таблицу новый лог о возникновении ошибки
    }
}
