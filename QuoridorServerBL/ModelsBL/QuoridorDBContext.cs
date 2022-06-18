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


        public void AddPlayer(Player p)
        {
            QuoridorDBContext bl = new QuoridorDBContext();
            bl.Players.Add(p);
            bl.SaveChanges();
        }

        public Player GetPlayer(string userName)
        {
            var query = from p in Players where (p.UserName == userName) select p;
            Player pQuery = query.FirstOrDefault();
            return pQuery;
        }

        public void AddRatingChange(RatingChange ratingChange)
        {
            QuoridorDBContext bl = new QuoridorDBContext();
            bl.RatingChanges.Add(ratingChange);
            bl.SaveChanges();

        }


        public Player GetPlayer(int playerId)
        {
            var query = from p in Players where p.PlayerId == playerId select p;
            return query.FirstOrDefault();
        }

        public RatingChange GetLastRatingChange(int playerId)
        {
            var query = (from r in RatingChanges orderby r.RatingChangeDate ascending where (r.RatingChangePlayerId == playerId) select r);
            //query.OrderBy<RatingChangeDate>
            RatingChange last = query.LastOrDefault();
            return last;
        }

        public List<RatingChange> GetRatingChanges(int playerId)
        {
            var query = (from r in RatingChanges orderby r.RatingChangeDate ascending where (r.RatingChangePlayerId == playerId) select r);
            List<RatingChange> ratingList = new List<RatingChange>();
            foreach(RatingChange r in query)
            {
                ratingList.Add(r);
            }
            return ratingList;
        }

    }
}
