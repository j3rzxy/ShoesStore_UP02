using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Database
{
    internal class Core
    {
        public static DB_Bulatov_ShoesEntities Context = new DB_Bulatov_ShoesEntities();
        public static Users_ currentUser;
    }
}
