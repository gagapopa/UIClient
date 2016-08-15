using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using UIClient.Services;

namespace UIClient.Controllers
{
    public class DataController : Controller
    {
        IDataRepository _dataService;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            _dataService = new DataRepository();
        }

        public async Task<JsonResult> GetUserLinks(string userGuid)
        {
            var result = await _dataService.GetUserLinks(userGuid);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> InsertLinkOrCreateUser(string fullUrl, int? userId)
        {
            var result = await _dataService.InsertLinkOrCreateUser(fullUrl, userId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}