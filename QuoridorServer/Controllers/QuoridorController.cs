using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;


using QuoridorServerBL.Models;
using System.IO;
using System.Net.Http;

namespace QuoridorServer.Controllers
{
    [Route("QuoridorAPI")]
    [ApiController]
    public class QuoridorController : ControllerBase
    {
        #region Add connection to the db context using dependency injection
        QuoridorDBContext context;
        public QuoridorController(QuoridorDBContext context)
        {
            this.context = context;
        }
        #endregion
        //public Player SignUpPlayerAsync




        [Route("SignUpPlayer")]
        [HttpPost]
        public Player SignUpPlayer([FromBody] Player newPlayer) // gets a json string of a player
        {
            if (newPlayer == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return null;
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            context.AddPlayer(newPlayer);
            return newPlayer;
        }


        [Route("SignInPlayer")]
        [HttpGet]
        public Player SignInPlayer(string userName, string pass)
        {
            Player player = context.SignIn(userName, pass);

            //Check user name and password
            if (player != null)
            {
                HttpContext.Session.SetObject("CurPlayer", player);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return player;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("UpdateRatingChange")]
        [HttpPost]
        // from body denotes that we get the rating change as a json parameter and not as a parameter in the http line
        public void UpdateRatingChange([FromBody] RatingChange ratingChange) 
        {
            if (ratingChange == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return;
            }
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            context.AddRatingChange(ratingChange);
        }

        

        [Route("GetLastRatingChange")]
        [HttpGet]
        public RatingChange GetLastRatingChange(int playerId)
        {
            RatingChange ratingChange = context.GetLastRatingChange(playerId);
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK; // it's ok even if we didn't find a last rating change
            ratingChange.RatingChangePlayer = context.GetPlayer(playerId);
            return ratingChange; // will return null if doesn't exist

        }


        [Route("GetRatingChanges")]
        [HttpGet]
        public List<RatingChange> GetRatingChanges(int playerId)
        {
            List<RatingChange> ratingChanges = context.GetRatingChanges(playerId);
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return ratingChanges;
        }
        /*
         * [Route("GetPhoneTypes")]
        [HttpGet]
        public List<PhoneType> GetPhoneTypes()
        {
            return context.PhoneTypes.ToList();
        }
        */

    }


    

}
