using System.Data;
using System.Linq;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project.Data;


public class MembershipController : Controller
{
    private readonly ApplicationDbContext _context;

    public MembershipController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize]
    public IActionResult Index()
    {
        var memberships = _context.Memberships.ToList();
        return View(memberships);
    }


    // GET: /Membership/Create
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Membership/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Membership membership)
    {
        if (ModelState.IsValid)
        {
            _context.Memberships.Add(membership);
            _context.SaveChanges();

            // Redirect to the Index action of the Membership controller
            return RedirectToAction(nameof(Index));
        }

        // If ModelState is not valid, return to the Create view to display validation errors
        return View(membership);
    }

    // GET: /Membership/Edit/{id}
    [Authorize]
    public IActionResult Edit(int id)
    {
        var membership = _context.Memberships.FirstOrDefault(m => m.Id == id);
        if (membership == null)
        {
            // Handle case when the membership with the given id is not found
            return NotFound();
        }
        return View(membership);
    }

    // POST: /Membership/Edit/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Membership updatedMembership)
    {
        var membership = _context.Memberships.FirstOrDefault(m => m.Id == id);
        if (membership == null)
        {
            // Handle case when the membership with the given id is not found
            return NotFound();
        }

        if (ModelState.IsValid)
        {
           
            membership.FullName = updatedMembership.FullName;
            membership.Package = updatedMembership.Package;
            membership.Email = updatedMembership.Email;
           
            // Update other properties as needed

            _context.SaveChanges();
            return RedirectToAction("Index", "Membership");
        }

        // If ModelState is not valid, return to the Edit view to display validation errors
        return View(updatedMembership);
    }

    // GET: /Membership/Details/{id}
    public IActionResult Details(int id)
    {
        var membership = _context.Memberships.FirstOrDefault(m => m.Id == id);
        if (membership == null)
        {
            // Handle case when the membership with the given id is not found
            return NotFound();
        }
        return View(membership);
    }
    [Authorize]
    public IActionResult Delete(int id)
    {
        var membership = _context.Memberships.FirstOrDefault(m => m.Id == id);
        if (membership == null)
        {
            // Handle case when the membership with the given id is not found
            return NotFound();
        }
        return View(membership);
    }


    // POST: /Membership/DeleteConfirmed/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var membership = _context.Memberships.FirstOrDefault(m => m.Id == id);
        if (membership == null)
        {
            // Handle case when the membership with the given id is not found
            return NotFound();
        }

        _context.Memberships.Remove(membership);
        _context.SaveChanges();

        return RedirectToAction("Index", "Membership");
    }

}
