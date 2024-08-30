using LibrarySample.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySample.ViewComponents
{
    /// 1. 檢視元件命名+ViewComponent
    /// 2. 繼承 ViewComponent
    /// 3. 檢視元件命名+ViewComponent
    /// 4. 實作 InvokeAsync 方法
    /// <summary>
    /// </summary>
    public class HelloWordViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var authentication = new AuthenticationModel();
            await Task.Run(() =>
            {
                // check session exist
                authentication.Id = HttpContext.Session.GetString("Id") ?? "Guest";
            });
            return View(authentication);
        }
    }
}
