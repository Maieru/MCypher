using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationWinFormsTest.PageObjects
{
	public class HomePO : Session
	{
		public HomePO() { }

		private IWebElement txtTexto { get { return Driver.FindElementById("txtPlainText"); } }
		private IWebElement txtChave { get { return Driver.FindElementById("txtKey"); } }
		private IWebElement lblResultado { get { return Driver.FindElementById("txtResult"); } }
		private IWebElement cbTipo { get { return Driver.FindElementById("cbEncryptionType"); } }
		private IWebElement btnEncriptar { get { return Driver.FindElementById("btnEncrypt"); } }


		

		public void PreencheTexto(string texto)
		{
			txtTexto.SendKeys(texto);
		}

		public void PreencheChave(string chave)
		{
			txtChave.SendKeys(chave);
		}

		public void ClicaEncriptar()
		{
			btnEncriptar.Click();
		}

		public string ConfereResultado()
		{
			return lblResultado.Text;
		}

		public void MudaTipo()
		{
			cbTipo.SendKeys(Keys.ArrowDown + Keys.Enter);
		}
	}
}
