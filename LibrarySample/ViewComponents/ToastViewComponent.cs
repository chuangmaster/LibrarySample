using Microsoft.AspNetCore.Mvc;

namespace LibrarySample.ViewComponents
{
    public class ToastViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string message)
        {
            return View("Default", message);
        }
    }
}
