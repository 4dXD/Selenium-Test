using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace FinalSeleniumTest
{
    [TestFixture]
    public class SeleniumTest
    {

        IWebDriver driver;
        string baseURL;
        [SetUp]
        public void SetUpMethod()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "https://www.calculator.net/triangle-calculator.html";
            driver.Navigate().GoToUrl(baseURL);

        }

        [TearDown]
        public void TearDownMethod()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        /// <summary>
        /// Test for Error Message for values can not make a triangle: side values(2,2,4)
        /// </summary>
        [Test]
        public void EnterThreeSidesCanNotMakeTriangle_vx2vy2vz4_ErrorMessageIsCorrect()
        {
            driver.Navigate().GoToUrl(baseURL);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='content']/table[1]/tbody/tr/td/table/tbody/tr[5]/td/input")));
            System.Threading.Thread.Sleep(1500);

            IWebElement vx = driver.FindElement(By.Name("vx"));
            vx.Clear();
            vx.SendKeys("2");

            IWebElement vy = driver.FindElement(By.Name("vy"));
            vy.Clear();
            vy.SendKeys("2");

            IWebElement vz = driver.FindElement(By.Name("vz"));
            vz.Clear();
            vz.SendKeys("4");


            IWebElement va = driver.FindElement(By.Name("va"));
            va.Clear();
            IWebElement vb = driver.FindElement(By.Name("vb"));
            vb.Clear();
            IWebElement vc = driver.FindElement(By.Name("vc"));
            vc.Clear();

            IWebElement calculateButton = driver.FindElement(By.XPath("//*[@id='content']/table[1]/tbody/tr/td/table/tbody/tr[5]/td/input"));
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollTo(0, {calculateButton.Location.Y - 200 })");
            System.Threading.Thread.Sleep(1000);
            calculateButton.Click();

            System.Threading.Thread.Sleep(2000);
            IWebElement areaDiv = driver.FindElement(By.XPath("//*[@id='content']/p[2]/font"));
            string area = areaDiv.Text;

            Assert.AreEqual("The sum of two sides must be larger than the third.", area);
        }

        /// <summary>
        /// Test for Semiperimeter Value after calcultate with 2 sides(2, 2) and 1 angle(15) values
        /// </summary>
        [Test]
        public void DisplaySuccessResultAfterCalculateButtonClick_vx2vy2vc15_SemiperimeterValueIsCorrect()
        {
            driver.Navigate().GoToUrl(baseURL);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='content']/table[1]/tbody/tr/td/table/tbody/tr[5]/td/input")));
            System.Threading.Thread.Sleep(1500);

            IWebElement vx = driver.FindElement(By.Name("vx"));
            vx.Clear();
            vx.SendKeys("2");

            IWebElement vy = driver.FindElement(By.Name("vy"));
            vy.Clear();
            vy.SendKeys("2");

            IWebElement vz = driver.FindElement(By.Name("vz"));
            vz.Clear();


            IWebElement va = driver.FindElement(By.Name("va"));
            va.Clear();
            IWebElement vb = driver.FindElement(By.Name("vb"));
            vb.Clear();
            IWebElement vc = driver.FindElement(By.Name("vc"));
            vc.Clear();
            vc.SendKeys("15");


            IWebElement calculateButton = driver.FindElement(By.XPath("//*[@id='content']/table[1]/tbody/tr/td/table/tbody/tr[5]/td/input"));
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollTo(0, {calculateButton.Location.Y - 200 })");
            System.Threading.Thread.Sleep(1000);
            calculateButton.Click();

            System.Threading.Thread.Sleep(2000);
            IWebElement semiperimeter = driver.FindElement(By.XPath("//*[@id='content']/div[4]"));
            string semiperimeterTxt = semiperimeter.Text;

            Assert.AreEqual("Semiperimeter s = 2.26105", semiperimeterTxt);
        }

        /// <summary>
        /// Test for triangle Area with 3 sides(3,4,5)
        /// </summary>
        [Test]
        public void DisplaySuccessResultAfterCalculateButtonClick_vx3vy4vz5_AreaResultIsCorrect()
        {
            driver.Navigate().GoToUrl(baseURL);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='content']/table[1]/tbody/tr/td/table/tbody/tr[5]/td/input")));
            System.Threading.Thread.Sleep(1500);

            IWebElement vx = driver.FindElement(By.Name("vx"));
            vx.Clear();
            vx.SendKeys("3");

            IWebElement vy = driver.FindElement(By.Name("vy"));
            vy.Clear();
            vy.SendKeys("4");

            IWebElement vz = driver.FindElement(By.Name("vz"));
            vz.Clear();
            vz.SendKeys("5");


            IWebElement va = driver.FindElement(By.Name("va"));
            va.Clear();
            IWebElement vb = driver.FindElement(By.Name("vb"));
            vb.Clear();
            IWebElement vc = driver.FindElement(By.Name("vc"));
            vc.Clear();

            IWebElement calculateButton = driver.FindElement(By.XPath("//*[@id='content']/table[1]/tbody/tr/td/table/tbody/tr[5]/td/input"));
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollTo(0, {calculateButton.Location.Y - 200 })");
            System.Threading.Thread.Sleep(1000);
            calculateButton.Click();

            System.Threading.Thread.Sleep(2000);
            IWebElement areaDiv = driver.FindElement(By.XPath("//*[@id='content']/div[2]"));
            string area = areaDiv.Text;

            Assert.AreEqual("Area = 6", area);
        }

        /// <summary>
        /// Test for Error message with 4 input values
        /// </summary>
        [Test]
        public void DisplayErrorAfterCalculateButtonClick_vx10vy15vb60vc60_ErrorMessageIsCorrect()
        {

            driver.Navigate().GoToUrl(baseURL);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='content']/table[1]/tbody/tr/td/table/tbody/tr[5]/td/input")));
            System.Threading.Thread.Sleep(1500);

            IWebElement vx = driver.FindElement(By.Name("vx"));
            vx.Clear();
            vx.SendKeys("10");

            IWebElement vy = driver.FindElement(By.Name("vy"));
            vy.Clear();
            vy.SendKeys("15");


            IWebElement vz = driver.FindElement(By.Name("vz"));
            vz.Clear();


            IWebElement va = driver.FindElement(By.Name("va"));
            va.Clear();

            IWebElement vb = driver.FindElement(By.Name("vb"));
            vb.Clear();
            vb.SendKeys("60");

            IWebElement vc = driver.FindElement(By.Name("vc"));
            vc.Clear();
            vc.SendKeys("60");


            IWebElement calculateButton = driver.FindElement(By.XPath("//*[@id='content']/table[1]/tbody/tr/td/table/tbody/tr[5]/td/input"));
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollTo(0, {calculateButton.Location.Y - 200 })");
            System.Threading.Thread.Sleep(1000);
            calculateButton.Click();


            System.Threading.Thread.Sleep(2000);
            IWebElement erroeMsg = driver.FindElement(By.XPath("//*[@id='content']/p[2]/font"));
            string text = erroeMsg.Text;

            Assert.AreEqual("Please provide three positive values only. You have 4 now.", text);


        }

        /// <summary>
        /// Test one side and two angle for Equilateral Triangle
        /// </summary>
        [Test]
        public void DisplayResultAfterCalculateButtonClick_vx10vb60vc60_TriabgleTypeIsCorrect()
        {
            driver.Navigate().GoToUrl(baseURL);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='content']/table[1]/tbody/tr/td/table/tbody/tr[5]/td/input")));
            System.Threading.Thread.Sleep(1500);

            IWebElement vx = driver.FindElement(By.Name("vx"));
            vx.Clear();
            vx.SendKeys("10");

            IWebElement vy = driver.FindElement(By.Name("vy"));
            vy.Clear();
            IWebElement vz = driver.FindElement(By.Name("vz"));
            vz.Clear();


            IWebElement va = driver.FindElement(By.Name("va"));
            va.Clear();

            IWebElement vb = driver.FindElement(By.Name("vb"));
            vb.Clear();
            vb.SendKeys("60");

            IWebElement vc = driver.FindElement(By.Name("vc"));
            vc.Clear();
            vc.SendKeys("60");


            IWebElement calculateButton = driver.FindElement(By.XPath("//*[@id='content']/table[1]/tbody/tr/td/table/tbody/tr[5]/td/input"));
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollTo(0, {calculateButton.Location.Y - 200 })");
            System.Threading.Thread.Sleep(1000);
            calculateButton.Click();

            System.Threading.Thread.Sleep(2000);
            IWebElement triangleType = driver.FindElement(By.XPath("//*[@id='content']/table[1]/tbody/tr/td[1]/h3"));
            string text = triangleType.Text;

            Assert.AreEqual("Equilateral Triangle", text);
        }
    }
}
