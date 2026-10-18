using Microsoft.AspNetCore.Mvc;

public class OrdersController : Controller
{
    // GET /Orders/List
    public IActionResult List()
    {
        var all = Repository.GetAll();
        ViewData["Title"] = "All Meal Orders";
        ViewBag.TotalCount = all.Count;
        return View(all);
    }

    // GET /Orders/Details/O005
    public IActionResult Details(string id)
    {
        var order = Repository.GetById(id);
        if (order == null) return NotFound($"Order {id} was not found.");
        ViewData["Title"] = "Collection Information";
        return View(order);
    }

    // GET /Orders/Collect
    [HttpGet]
    public IActionResult Collect()
    {
        ViewData["Title"] = "Collect Meal";
        return View(new CollectViewModel());
    }

    // POST /Orders/Collect  (model binding)
    [HttpPost]
    public IActionResult Collect(CollectViewModel model)
    {
        ViewData["Title"] = "Collect Meal";
        if (!ModelState.IsValid) return View(model);

        var order = Repository.GetById(model.OrderID);
        if (order == null)
        {
            ViewBag.Error = $"No order found with ID {model.OrderID}.";
            return View(model);
        }
        if (order.Collected)
        {
            ViewBag.Error = $"Order {order.OrderID} has already been collected.";
            return View(model);
        }

        Repository.Collect(order.OrderID);
        return RedirectToAction("Details", new { id = order.OrderID });
    }
}   