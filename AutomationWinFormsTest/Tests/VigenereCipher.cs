using AutomationWinFormsTest.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AutomationWinFormsTest.Tests
{
	[TestClass]
	public class VigenereCipher : Session
	{
		HomePO homepo = new HomePO();

		[TestMethod]
		public void ValidaEncriptografia()
		{
			Setup();

			homepo.PreencheTexto("teste");
			homepo.PreencheChave("abc");
			homepo.MudaTipo();
			homepo.ClicaEncriptar();
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("tfutf", homepo.ConfereResultado());

			TearDown();
		}


		[TestMethod]
		public void ValidaErro()
		{
			Setup();

			homepo.PreencheTexto("teste");
			homepo.ClicaEncriptar();
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual("tfutf", homepo.ConfereResultado());

			TearDown();
		}
	}
}
