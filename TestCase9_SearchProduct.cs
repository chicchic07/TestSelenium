using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExerciseTests
{
    [TestFixture]
    public class TestCase9_SearchProduct : BaseTest
    {
        [Test]
        public void SearchProduct()
        {
            // Verify that home page is visible successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
            
            // Click on 'Products' button
            driver.FindElement(By.XPath("//a[contains(text(),' Products')]")).Click();
            
            // Verify user is navigated to ALL PRODUCTS page successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'All Products')]")).Displayed);
            
            // Enter product name in search input and click search button
            driver.FindElement(By.Id("search_product")).SendKeys("tshirt");
            driver.FindElement(By.Id("submit_search")).Click();
            
            // Verify 'SEARCHED PRODUCTS' is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Searched Products')]")).Displayed);
            
            // Verify all the products related to search are visible
            var searchResults = driver.FindElements(By.XPath("//div[@class='features_items']/div[@class='col-sm-4']"));
            Assert.Greater(searchResults.Count, 0, "No search results found");
            
            // Verify that search results contain the search term (case insensitive)
            bool allProductsMatchSearch = true;
            foreach (var product in searchResults)
            {
                string productName = product.FindElement(By.XPath(".//div[@class='productinfo text-center']/p")).Text.ToLower();
                if (!productName.Contains("tshirt") && !productName.Contains("t-shirt"))
                {
                    allProductsMatchSearch = false;
                    break;
                }
            }
            Assert.IsTrue(allProductsMatchSearch, "Not all products match the search term");
        }
    }
}