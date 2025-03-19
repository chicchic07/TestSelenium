using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExerciseTests
{
    [TestFixture]
    public class TestCase8_VerifyProductsAndDetailPage : BaseTest
    {
        [Test]
        public void VerifyProductsAndDetailPage()
        {
            // Verify that home page is visible successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
            
            // Click on 'Products' button
            driver.FindElement(By.XPath("//a[contains(text(),' Products')]")).Click();
            
            // Verify user is navigated to ALL PRODUCTS page successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'All Products')]")).Displayed);
            
            // The products list is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='features_items']")).Displayed);
            
            // Click on 'View Product' of first product
            driver.FindElements(By.XPath("//a[contains(text(),'View Product')]"))[0].Click();
            
            // User is landed to product detail page
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='product-information']")).Displayed);
            
            // Verify that detail is visible: product name, category, price, availability, condition, brand
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='product-information']/h2")).Displayed); // Name
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='product-information']/p[1]")).Displayed); // Category
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='product-information']/span/span")).Displayed); // Price
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='product-information']/p[2]")).Displayed); // Availability
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='product-information']/p[3]")).Displayed); // Condition
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='product-information']/p[4]")).Displayed); // Brand
        }
    }
}