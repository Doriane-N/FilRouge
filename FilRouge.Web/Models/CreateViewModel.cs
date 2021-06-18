using FilRouge.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilRouge.Web.Models
{
    public class CreateViewModel
    {
        public Quizz Quizz { get; set; }
        public SelectList AvailableLevels { get; set; }
        public SelectList AvailableAgents { get; set; }
    }
}