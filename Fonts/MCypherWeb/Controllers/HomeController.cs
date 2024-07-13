using Database.Entities;
using Database.Repository;
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
        private readonly EncryptionResultRepository _encryptionResultRepository;

        public HomeController(ILogger<HomeController> logger, EncryptionResultRepository encryptionResultRepository)
        {
            _logger = logger;
            _encryptionResultRepository = encryptionResultRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Encrypt(EncryptionViewModel model)
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

            await _encryptionResultRepository.AddAsync(new EncryptionResultModel()
            {
                Created = DateTime.Now,
                DecryptedText = model.PlainText,
                EncryptedText = model.CipherText,
                Key = model.Key
            });

            await _encryptionResultRepository.SaveAsync();

            return View("Index", model);
        }
    }
}
