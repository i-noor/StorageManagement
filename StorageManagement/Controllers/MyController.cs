using System.Web.Mvc;
using System.Web.Routing;
using StorageManagement.Util;

namespace StorageManagement.Controllers
{
    public class MyController : Controller
    {
        public ViewResult Index()
        {            
            return View("~/Views/Home/Contact.cshtml");
        }
        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир!</h2>");
        }
        public string Square(int a, int h)
        {
            double s = a * h / 2.0;
            return "<h2>Площадь треугольника с основанием " + a +
                    " и высотой " + h + " равна " + s + "</h2>";
        }
        public void Execute(RequestContext requestContext)
        {
            string ip = requestContext.HttpContext.Request.UserHostAddress;
            var response = requestContext.HttpContext.Response;
            response.Write("<h2>Ваш IP-адрес: " + ip + "</h2>");
        }
    }
}