using FilRouge.DataAccessLayer.AccessLayers;
using FilRouge.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FilRouge.ApiData.Controllers
{
    public class DifficultyLevelController : ApiController
    {
        private readonly DifficultyLevelAccessLayer difficultylevelAccessLayer = new DifficultyLevelAccessLayer();
        // GET api/difficultylevels
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = difficultylevelAccessLayer.GetAll().Select(a => new DifficultyLevel
            {
                Id = a.Id,
                Level = a.Level
            });

            return this.Ok(result);
        }
    }
}