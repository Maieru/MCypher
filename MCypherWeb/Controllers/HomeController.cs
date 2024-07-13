using Encryption.CeaserCypher;
using Encryption.VigenereCypher;
using MCypherWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MCypherWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Encrypt(EncryptionViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);


            switch (model.EncryptionType)
            {
                case EnumEncryptionType.CeaserCipher:
                    var ceaseCipher = new CeaserCypherEncoder(Convert.ToInt32(model.Key));
                    model.CipherText = ceaseCipher.Encode(model.PlainText);
                    break;
                case EnumEncryptionType.VigenereCipher:
                    var vigenereCipher = new VigenereCypherEncoder(model.Key);
                    model.CipherText = vigenereCipher.Encode(model.PlainText);
                    break;
            }

            return View("Index", model);
        }
    }
}
