using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ClientAppointments.Web.Controllers
{
   // [Route("[controller]")]
    public class HomeController : Controller
    {
        public HomeController()
        {
            //  _projectRepository = projectRepository;
        }

        public IActionResult Index()
        {
            return View();
        } 

        public IActionResult Details()
        {
            return View();
        }
    }
}