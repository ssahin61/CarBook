using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILayoutViewComponents
{
	public class FooterCoverUILayoutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			{
				return View();
			}
		}
	}
}
