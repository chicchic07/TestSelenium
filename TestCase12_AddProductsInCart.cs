using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace AutomationExerciseTests
{
    [TestFixture]
    public class TestCase12_AddProductsInCart : BaseTest
    {
        [Test]
        public void AddProductsInCart()
        {
            // Verify that home page is visible successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
            
            // Click 'Products' button
            driver.FindElement(By.XPath("//a[contains(text(),' Products')]")).Click();
            
            // Hover over first product and click 'Add to cart'
            var firstProduct = driver.FindElements(By.XPath("//div[@class='product-image-wrapper']"))[0];
            actions.MoveToElement(firstProduct).Perform();
            driver.FindElements(By.XPath("//a[@class='btn btn-default add-to-cart']"))[0].Click();
            
            // Click 'Continue Shopping' button
            WaitForElementClickable(By.XPath("//button[contains(text(),'Continue Shopping')]"));
            driver.FindElement(By.XPath("//button[contains(text(),'Continue Shopping')]")).Click();
            
            // Hover over second product and click 'Add to cart'
            var secondProduct = driver.FindElements(By.XPath("//div[@class='product-image-wrapper']"))[1];
            actions.MoveToElement(secondProduct).Perform();
            driver.FindElements(By.XPath("//a[@class='btn btn-default add-to-cart']"))[1].Click();
            
            // Click 'View Cart' button
            WaitForElementClickable(By.XPath("//u[contains(text(),'View Cart')]"));
            driver.FindElement(By.XPath("//u[contains(text(),'View Cart')]")).Click();
            
            // Verify both products are added to Cart
            var cartProducts = driver.FindElements(By.XPath("//table[@id='cart_info_table']/tbody/tr"));
            Assert.AreEqual(2, cartProducts.Count, "Not all products were added to cart");
            
            // Verify their prices, quantity and total price
            for (int i = 0; i < cartProducts.Count; i++)
            {
                string price = cartProducts[i].FindElement(By.XPath("./td[@class='cart_price']/p")).Text;
                string quantity = cartProducts[i].FindElement(By.XPath("./td[@class='cart_quantity']/button")).Text;
                string total = cartProducts[i].FindElement(By.XPath("./td[@class='cart_total']/p")).Text;
                
                // Remove currency symbols for comparison
                decimal priceValue = decimal.Parse(price.Replace("Rs. ", ""));
                int quantityValue = int.Parse(quantity);
                decimal totalValue = decimal.Parse(total.Replace("Rs. ", ""));
                
                Assert.AreEqual(priceValue * quantityValue, totalValue, "Total price calculation is incorrect");
            }
        }
    }
}