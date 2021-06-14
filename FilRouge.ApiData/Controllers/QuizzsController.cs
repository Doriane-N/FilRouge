using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilRouge.ApiData.Controllers
{
    using FilRouge.DataAccessLayer.AccessLayers;
    using FilRouge.DataAccessLayer.Models;
    using System.Threading.Tasks;

    public class QuizzsController : ApiController
    {
        private readonly QuizzAccessLayer quizzAccessLayer = new QuizzAccessLayer();
        //private readonly UserAccessLayer userAccessLayer = new UserAccessLayer();



    }
}
