namespace FilRouge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    public class AuthenticationController : Controller
    {
        //CAUTION dev usage only, TO REMOVE
        private static readonly bool securityEnabled = false;

        private static AuthenticationController instance;

        public static AuthenticationController GetInstance()
        {
            if (instance == null)
            {
                instance = new AuthenticationController();
            }
            return instance;
        }

        public async Task<ActionResult> AuthenticationAdminAsync(Func<Task<ActionResult>> func)
        {
            var loginSession = System.Web.HttpContext.Current.Session["Login"];
            var adminSession = System.Web.HttpContext.Current.Session["Admin"];

            if (securityEnabled)
            {
                if (loginSession == null)
                {
                    return RedirectToAction("Login", "Agent");
                }

                if (adminSession == null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return await func.Invoke();
        }

        public ActionResult AuthenticationAgent(Func<ActionResult> func)
        {
            var loginSession = System.Web.HttpContext.Current.Session["Login"];

            if (securityEnabled)
            {
                if (loginSession == null)
                {
                    return RedirectToAction("Login", "Agent");
                }
            }
            return func.Invoke();
        }
    }
}