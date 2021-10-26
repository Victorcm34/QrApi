using Microsoft.AspNetCore.Mvc;
using QrApi.Interfaces;

namespace QrApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class QrController : Controller
    {
        private readonly IQrGen _qrServ;

        public QrController(IQrGen qrServ)
        {
            _qrServ = qrServ;
        }

        [HttpGet]
        public IActionResult GetQr(string url)
        {
            if (url.Length > 0)
            {
                byte[] img = _qrServ.GenByteArray(url);
                return File(img, "image/jpg");
            }
            return BadRequest();
        }
    }
}