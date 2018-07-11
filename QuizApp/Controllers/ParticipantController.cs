using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Web.Http;

namespace QuizApp.Controllers
{
    public class ParticipantController : ApiController
    {
        [HttpPost]
        [Route("api/InsertParticipant")]
        public Participant Insert(Participant model)
        {
            using (DBModel db = new DBModel())
            {
                db.Participants.Add(model);
                db.SaveChanges();
                return model;
            }
        }

        [HttpPost]
        [Route("api/UpdateOutput")]
        public void UpdateOutput(Participant model)
        {
            using (DBModel db = new DBModel())
            {
                // db.Entry(model).State = System.Data.EntityState.Modified;
                var result = db.Participants.SingleOrDefault(b => b.ParticipantID == model.ParticipantID);
                if(result != null)
                {
                    result.Score = model.Score;
                    result.TimeSpent = model.TimeSpent;
                    db.SaveChanges();
                }
             
            }
        }
    }
}
