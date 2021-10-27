using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuoridorServerBL.Models
{
    public partial class QuoridorDBContext
    {

        /*
        Searches for a player with matching username and password and returns it.
        If no such player exists - returns null.
        */
        public Player SignIn(string username, string password)
        {
            var query = from p in Players where (p.UserName == username && p.PlayerPass == password) select p;
            Player pQuery = query.FirstOrDefault();
            return pQuery;
        }

    }
}
