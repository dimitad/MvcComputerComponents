using ComputerComponentsWeb.Helpers;
using EF.ComponentData.Services;
using System.Web.Mvc;

namespace ComputerComponentsWeb.Controllers
{
    public class ComponentSummaryController : Controller
    {
        private UserComponentSummaryService _userComponentSummaryService = new UserComponentSummaryService();

        public SessionHelper CtrlSessionHelper { get; set; } = new SessionHelper();

        public ComponentSummaryController()
        {
        }

        public ComponentSummaryController(UserComponentSummaryService userComponentSummaryService)
        {
            _userComponentSummaryService = userComponentSummaryService;
        }

        /// <summary>
        /// Index action shows the current components selected by the user.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            var userId = CtrlSessionHelper.GetUserId(HttpContext);
            var componentSummary = _userComponentSummaryService.FindComponentItemListByUser(userId);
            
            return View(componentSummary);
        }

        /// <summary>
        /// Add a new component to the configuration summary.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        public RedirectToRouteResult AddComponentSummaryItem(int id, string categoryCode)
        {
            var userId = CtrlSessionHelper.GetUserId(HttpContext);

            var userComponentSummary = _userComponentSummaryService.AddUserComponentSummaryItem(id, userId);

            CtrlSessionHelper.SetUserTotalAmount(HttpContext, userComponentSummary.ComponentItem.Price, (total, current) => total + current);

            TempData["SuccessMessage"] = $"{userComponentSummary.ComponentItem.Name} - {userComponentSummary.ComponentItem.Description} has been added to your configuration!";

            return RedirectToAction("ListComponents", "Home", new { categoryCode });
        }

        /// <summary>
        /// Remove a component from the configuration summary
        /// </summary>
        /// <param name="id"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveComponentSummaryItem(int id, decimal price)
        {
            var userId = CtrlSessionHelper.GetUserId(HttpContext);

            _userComponentSummaryService.RemoveUserComponentSummaryItem(id);

            CtrlSessionHelper.SetUserTotalAmount(HttpContext, price, (total, current) => total - current);

            return RedirectToAction("Index");
        }
    }
}