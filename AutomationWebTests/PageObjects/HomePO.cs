using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using AutomationWebTests;
using OpenQA.Selenium.Support.UI;

namespace AutomationWebTests.PageObjects
{
    public class HomePO
    {
        private readonly WebDriver _webDriver;
        private const string PageUrl = "https://localhost:7001";

        public HomePO(WebDriver webDriver) 
        {
            _webDriver = webDriver;
        }

        private IWebElement txtTexto => _webDriver.FindElement(By.Id("texto"));
        private IWebElement erroTexto => _webDriver.FindElement(By.XPath("/html/body/div/main/div/form/div[1]/span"));
        private IWebElement txtChave => _webDriver.FindElement(By.Id("chave"));
        private IWebElement erroChave => _webDriver.FindElement(By.XPath("/html/body/div/main/div/form/div[2]/span"));
        private IWebElement dropEncryption => _webDriver.FindElement(By.Id("encryptionType"));
        private IWebElement btnEnviar => _webDriver.FindElement(By.XPath("/html/body/div/main/div/form/button"));
        private IWebElement erroTipoCriptografia => _webDriver.FindElement(By.XPath("/html/body/div/main/div/form/div[2]/span"));

        private IWebElement txtResultado => _webDriver.FindElement(By.Id("resultado"));


        public void PreencheTexto(string texto)
        {
            txtTexto.Clear();
            txtTexto.SendKeys(texto);
        }

        public void PreencheChave(string chave)
        {
            txtChave.Clear();
            txtChave.SendKeys(chave);
        }

        public void ClicaEnviar()
        {
            btnEnviar.Click();
        }
        
        public bool ValidaResultado(string esperado)
        {
            if (txtResultado.Text == esperado)
                return true;
            else
                return false;
        }

        public void SelecionaTipo(int index)
        {
            var selectElement = new SelectElement(dropEncryption);
            selectElement.SelectByIndex(index);
        }

        public bool ValidaErroTexto(string erro)
        {
            if (erroTexto.Text == erro)
                return true;
            else
                return false;
        }

        public bool ValidaErroChave(string erro)
        {
            if (erroChave.Text == erro)
                return true;
            else
                return false;
        }

        public bool ValidaErroCriptografia(string erro)
        {
            if (erroTipoCriptografia.Text == erro)
                return true;
            else
                return false;
        }
    }
}
