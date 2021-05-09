using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string UsersListed = "Kullanıcılar listelendi";
        public static string UserNameInvalid = "Kullanıcı adı geçersiz";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string CarNotReturned = "Araba teslim edilmedi";
        public static string CarCountError = "En fazla 10 araba olabilir";
        public static string MinDailyPrice = "Günlük ücret min 500 olmalıdır";
    }
}
