using AutomationWebTests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationWebTests.Tests
{
    public class VigenereCipher : Session
    {
        private HomePO homePO;

        [SetUp]
        public void SetupTest()
        {
            homePO = new HomePO(WebDriver);
        }

        [Test]
        public void TesteVigenereCipher()
        {
            homePO.PreencheTexto("teste");
            homePO.PreencheChave("abc");
            homePO.SelecionaTipo(1);

            homePO.ClicaEnviar();

            if (homePO.ValidaResultado("tfutf"))
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void ValidaCampos()
        {
            homePO.PreencheTexto("teste");
            homePO.PreencheChave("123");
            homePO.SelecionaTipo(1);
            homePO.ClicaEnviar();

            if (homePO.ValidaErroCriptografia("Para o tipo de criptografia VigenereCipher, a chave deve conter apenas letras."))
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}
