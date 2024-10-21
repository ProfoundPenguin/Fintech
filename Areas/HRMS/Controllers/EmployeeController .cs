using Microsoft.AspNetCore.Mvc;
using HRMS.Areas.HRMS.Models;
using Microsoft.EntityFrameworkCore;


namespace core.Areas.HRMS.Controllers
{
    [Area("HRMS")]
    public class EmployeeController : Controller
    {
        private readonly HRMSContext _context;

        public EmployeeController(HRMSContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Member> members = _context.Members.Include(m => m.Department).ToList();
            return View(members);
        }
    }
}
