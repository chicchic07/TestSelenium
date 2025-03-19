using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExerciseTests
{
    [TestFixture]
    public class TestCase13_VerifyProductQuantityInCart : BaseTest
    {
        [Test]
        public void VerifyProductQuantityInCart()
        {
            // Verify that home page is visible successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
            
            // Click 'View Product' for any product on home page
            driver.FindElements(By.XPath("//a[contains(text(),'View Product')]"))[0].Click();
            
            // Verify product detail is opened
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='product-information']")).Displayed);
            
            // Increase quantity to 4
            var quantityInput = driver.FindElement(By.Id("quantity"));
            quantityInput.Clear();
            quantityInput.SendKeys("4");
            
            // Click 'Add to cart' button
            driver.FindElement(By.XPath("//button[@class='btn btn-default cart']")).Click();
            
            // Click 'View Cart' button
            WaitForElementClickable(By.XPath("//u[contains(text(),'View Cart')]"));
            driver.FindElement(By.XPath("//u[contains(text(),'View Cart')]")).Click();
            
            // Verify that product is displayed in cart page with exact quantity
            var quantity = driver.FindElement(By.XPath("//table[@id='cart_info_table']/tbody/tr/td[@class='cart_quantity']/button")).Text;
            Assert.AreEqual("4", quantity, "Product quantity in cart is incorrect");
        }
    }
}