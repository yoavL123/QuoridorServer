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

            //Player  = HttpContext.Session.GetObject<User>("theUser");
            //Player newPlayer = JsonSerializer.Deserialize<Player>(jsonPlayer);
            //If contact is null the request is bad
            /*
            if ( newPlayer == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return null;
            }
            */

            //Player newPlayer = HttpContext.Session.GetObject<Player>("newUser"); // session of the current signed in user
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            context.AddPlayer(newPlayer);
            return newPlayer;

            //Check if user logged in and its ID is the same as the contact user ID
            //if (newPlayer != null)
           // {
             //   newPlayer.
                /*
                //update contact to the DB by marking all entities that should be modified or added
                if (contact.ContactId > 0)
                {
                    context.Entry(contact).State = EntityState.Modified;
                }
                else
                {
                    context.Entry(contact).State = EntityState.Added;
                }

                foreach (ContactPhone cp in contact.ContactPhones)
                {
                    if (cp.PhoneId > 0)
                    {
                        context.Entry(cp).State = EntityState.Modified;
                    }
                    else
                    {
                        context.Entry(cp).State = EntityState.Added;
                    }
                }
                //Save change into the db
                context.SaveChanges();


                //Now check if an image exist for the contact (photo). If not, set the default image!
                var sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", DEFAULT_PHOTO);
                var targetPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", $"{contact.ContactId}.jpg");
                System.IO.File.Copy(sourcePath, targetPath);

                //return the contact with its new ID if that was a new contact
                return contact;
                */
           /* }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
           */
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
