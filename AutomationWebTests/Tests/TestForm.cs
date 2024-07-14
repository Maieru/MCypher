using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutomationWebTests.PageObjects;

namespace AutomationWebTests.Tests
{
    public class TestForm : Session
    {
        private HomePO homePO;

        [SetUp]
        public void SetupTest()
        {
            homePO = new HomePO(WebDriver);
        }

        [Test]
        public void ValidaTexto()
        {
            homePO.PreencheChave("123");
            homePO.ClicaEnviar();

            if (homePO.ValidaErroTexto("O texto a ser criptografado é obrigatório."))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void ValidaChave()
        {
            homePO.PreencheTexto("teste");
            homePO.ClicaEnviar();

            if (homePO.ValidaErroChave("A chave de criptografia é obrigatória."))
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}
