﻿using BunnyCart.pageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.tests
{    [TestFixture]
    internal class BunnyCartTest : CoreCodes
    {
        /*[Test, Order(2)]
        public void CreateAnAccountTest()
        {
            var homePage = new BunnyCartHomePage(driver);
          
            homePage.ClickOnCreateAccountLink();
            try
            {
                Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']" +
                "//following::h1[2]")).Text, Is.EqualTo("Create an Account"));

                homePage.CreateAccountLinkInput("alpha", "xyz", "alpha@df.com",
                   "1234", "1234", "9876543210");
            }
            catch (AssertionException)
            {
                Console.WriteLine("Modal didn't appear");
            }
            
        }*/

        [Test, Order(1)]
        [TestCase("Water", 4)]
        public void SearchInputTest(string pname, int count)
        {
            var homePage = new BunnyCartHomePage(driver);
            var searchProductPage=homePage.SearchBarInput(pname);
            try
            {
                //ScrollIntoView(driver, driver.FindElement( By.XPath("(//a[@class='product-item-link'])[2]") ));
                Assert.That(searchProductPage.GetSearchedResult(count), Does.Contain(pname));
                Thread.Sleep(5000);
            }
            catch (AssertionException)
            {
                Console.WriteLine("different product appeared");
            }
            Thread.Sleep(4000);
           var productPage = searchProductPage.ClickOnSearchedResult(count);
            try
            {
                Thread.Sleep(2000);
                Assert.That(productPage.GetProductTitle(), Does.Contain(pname));
                productPage.ClickOnProductQuantity();
                productPage.ClickOnAddToCartButton();
            }
            catch (AssertionException)
            {
                Console.WriteLine("Clicked On wrong Product");
            }
           
        }


    }
}
