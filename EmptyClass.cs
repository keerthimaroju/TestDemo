using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace TestOne
{ 
    public class EmptyClass
    {
       
            IWebDriver driver;

            [SetUp]
            public void startBrowser()
            {
             driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }

            [Test]
            public void Test1()
            {
            var expectedResult = "3 results have been found.";
            driver.Url = "http://automationpractice.com";
            driver.FindElement(By.Id("search_query_top")).SendKeys("&#39;Printed Summer Dress&#39;");
            driver.FindElement(By.Name("submit_search")).Click();
            var actualResult=driver.FindElement(By.ClassName("heading-counter")).Text;
            Assert.AreEqual(expectedResult, actualResult);
            Console.Write(actualResult);
            System.Threading.Thread.Sleep(5000);

            }
           [Test]
            public void Test2()
              {
            driver.Url = "http://automationpractice.com";
            driver.FindElement(By.Id("search_query_top")).SendKeys("&#39;Printed Summer Dress&#39;");
            driver.FindElement(By.Name("submit_search")).Click();
            //IList<IWebElement> selectElements = driver.FindElements(By.XPath("//a[@class='product-name' and contains(text(),'Printed Summer Dress')]"));
            IList<IWebElement> selectElements = driver.FindElements(By.XPath("//h5[@itemprop='name']"));
            foreach (IWebElement field in selectElements)
            {
                Assert.IsNotNull(field.Text);
            }
            IList<IWebElement> selectPrice = driver.FindElements(By.XPath("//span[@itemprop='price']"));
            foreach (IWebElement field in selectPrice)
            {
                Console.Write(field.Text);
                Assert.IsNotNull(field.Text);
            }
            IList<IWebElement> selectimage = driver.FindElements(By.XPath("//img[@itemprop='image']"));
            foreach (IWebElement field in selectimage)
            {
                Assert.True(field.Displayed);
            }

              }

        [Test]
        public void Test3(){
            driver.Url = "http://automationpractice.com";
            driver.FindElement(By.Id("search_query_top")).SendKeys("&#39;Printed Summer Dress&#39;");
            driver.FindElement(By.Name("submit_search")).Click();
            IList<IWebElement> selectimage = driver.FindElements(By.XPath("//img[@itemprop='image']"));
            selectimage[0].Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//h1[@itemprop='name' and contains(text(),'Printed Summer Dress')]")).Displayed);
            Assert.IsTrue(driver.FindElement(By.CssSelector("#product_condition label")).Displayed);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='rte']/p")).Displayed);
            Console.Write(driver.FindElement(By.XPath("//div[@class='rte']/p")).Text);
        }

        [Test]
         public void Test4()
        {
            driver.Url = "http://automationpractice.com";
            driver.FindElement(By.CssSelector("#contact-link a")).Click();
            SelectElement select = new SelectElement(driver.FindElement(By.Id("id_contact")));
            select.SelectByText("Customer service");
            driver.FindElement(By.Id("email")).SendKeys("kmaroju@gmail.com");
            driver.FindElement(By.Id("message")).SendKeys("hi");
            driver.FindElement(By.Id("submitMessage")).Click();
            String alertmsg = driver.FindElement(By.CssSelector("p.alert-success")).Text;
            Assert.AreEqual(alertmsg, "Your message has been successfully sent to our team.");
        }


            [TearDown]
            public void closeBrowser()
            {
                driver.Close();
            }
        }

       


}
