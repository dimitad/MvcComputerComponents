using EF.ComponentData.Services;
using System.Web.Mvc;

namespace ComputerComponentsWeb.Controllers
{
    public class HomeController : Controller
    {
        private IComponentCategoryService _componentCategoryService;
        private IComponentItemService _componentItemService;

        public HomeController()
        {
        }

        public HomeController(IComponentCategoryService componentCategoryService, IComponentItemService componentItemService)
        {
            _componentCategoryService = componentCategoryService;
            _componentItemService = componentItemService;
        }

        /// <summary>
        /// Displays the welcome message to the user.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {            
            return View();
        }

        /// <summary>
        /// Generate the list of component categories for the vertical sidebar.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCategoryList()
        {
            var categories = _componentCategoryService.GetAllComponentCategories();

            return PartialView("Partials/_CategoryList", categories);
        }
        
        /// <summary>
        /// List of components for the selected category.
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <returns></returns>
        public ActionResult ListComponents(string categoryCode)
        {
            var items = _componentItemService.GetComponentItemsByCategoryCode(categoryCode);            
            @ViewBag.CategoryName = _componentCategoryService.GetComponentCategoryByCode(categoryCode)?.Name;            

            return View(items);
        }
    }
}