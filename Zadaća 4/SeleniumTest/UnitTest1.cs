using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadaća_4;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System;
using System.Collections.Generic;

namespace SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driver;
        static IWebElement inputGodiste;
        const string urlStranice = "http://localhost:50942/Grupa3/Create";
        const int kratka_pauza = 100;
        const int duga_pauza = 1000;

        [ClassInitialize]
        public static void Inicijalizacija(TestContext context)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(urlStranice);
            inputGodiste = driver.FindElement(By.Id("godiste"));

        }
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            driver.Close();
        }

        
        static IEnumerable<object[]> GodistaIspod1900 {
            get {
                return new[] 
                    {
                        new object[] {"-456"},
                        new object[] {"0"},
                        new object[] {"1898"}
                    };
            }
        }
        static IEnumerable<object[]> GodistaIspod1945 {
            get {
                return new[]
                    {
                        new object[] { "1900" },
                        new object[] { "1921"},
                        new object[] {"1944" }
                    };
            }
        }
        static IEnumerable<object[]> GodistaIspod1975 {
            get {
                return new[]
                    {
                        new object[] {"1945"},
                        new object[] {"1966"},
                        new object[] {"1974"}
                    };
            }
        }
        static IEnumerable<object[]> GodistaIspod1995 {
            get {
                return new[]
                    {
                        new object[] {"1975"},
                        new object[] {"1984"},
                        new object[] {"1994"}
                    };
            }
        }
        static IEnumerable<object[]> GodistaIznad1995 {
            get {
                return new[]
                    {
                        new object[] {"1995"},
                        new object[] {"2001"},
                        new object[] {DateTime.Now.Year.ToString()},
                        new object[] {DateTime.Now.AddYears(5).Year.ToString()}
                    };
            }
        }

        private void input(string Godiste)
        {
            inputGodiste.Click();
            inputGodiste.Clear();
            inputGodiste.SendKeys(Godiste);
            Thread.Sleep(kratka_pauza);//">Korisnička Grupa
            IWebElement btn = driver.FindElement(By.XPath("//button[.='Korisnička Grupa']"));
            btn.Click();
            Thread.Sleep(duga_pauza);
        }

        [TestMethod]
        [DynamicData("GodistaIspod1900")]
        public void Ispod1900(string Godiste)
        {
            input(Godiste);
            var alert_win = driver.SwitchTo().Alert();
            Assert.AreEqual(alert_win.Text, "Najvjerovatnije niste ispravno unijeli godište - imate više od 120 godina!");
            alert_win.Accept();
        }
        [TestMethod]
        [DynamicData("GodistaIspod1945")]
        public void Ispod1945(string Godiste)
        {
            input(Godiste);
            var alert_win = driver.SwitchTo().Alert();
            Assert.AreEqual(alert_win.Text, "Imate više od 75 godina!");
            alert_win.Accept();
        }
        [TestMethod]
        [DynamicData("GodistaIspod1975")]
        public void Ispod1975(string Godiste)
        {
            input(Godiste);
            var alert_win = driver.SwitchTo().Alert();
            Assert.AreEqual(alert_win.Text, "Imate između 45 i 75 godina!");
            alert_win.Accept();
        }
        [TestMethod]
        [DynamicData("GodistaIspod1995")]
        public void Ispod1995(string Godiste)
        {
            input(Godiste);
            var alert_win = driver.SwitchTo().Alert();
            Assert.AreEqual(alert_win.Text, "Imate između 25 i 45 godina!");
            alert_win.Accept();
        }
        [TestMethod]
        [DynamicData("GodistaIznad1995")]
        public void Iznad1995(string Godiste)
        {
            input(Godiste);
            var alert_win = driver.SwitchTo().Alert();
            Assert.AreEqual(alert_win.Text, "Imate manje od 25 godina!");
            alert_win.Accept();
        }
    }
}
