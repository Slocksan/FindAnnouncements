using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FindAnnouncements.Models;

namespace FindAnnouncements.Stores
{
    public class AuthorizationStore
    {
        private Authorization _actualAuthorization;

        public Authorization ActualAuthorization
        {
            get => _actualAuthorization;
            set
            {
                _actualAuthorization = value;

            }
        }
    }
}
