using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var collected = Repository.GetCollected();
        ViewBag.CafeteriaName = "Sakarya Üniversitesi Yemekhanesi";
        ViewBag.CurrentDate = DateTime.Now.ToString("dd.MM.yyyy");
        ViewBag.CollectedCount = collected.Count;
        return View(collected);
    }
}