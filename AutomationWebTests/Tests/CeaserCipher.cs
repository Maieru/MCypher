using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationWebTests.PageObjects;
using OpenQA.Selenium;

namespace AutomationWebTests.Tests
{
    public class CeaserCipher : Session
    {

        private HomePO homePO;

        [SetUp]
        public void SetupTest()
        {
            homePO = new HomePO(WebDriver);
        }

        [Test]
        public void TesteCeaserCipher()
        {
            homePO.PreencheTexto("teste");
            homePO.PreencheChave("123");
            homePO.ClicaEnviar();

            if (homePO.ValidaResultado("ÕÆÔÕÆ"))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void ValidaCampos()
        {
            homePO.PreencheTexto("teste");
            homePO.PreencheChave("abc");
            homePO.ClicaEnviar();

            if (homePO.ValidaErroCriptografia("Para o tipo de criptografia CeaserCipher, a chave deve ser um número inteiro."))
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}
