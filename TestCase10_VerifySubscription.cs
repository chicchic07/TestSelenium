using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExerciseTests
{
    [TestFixture]
    public class TestCase10_VerifySubscription : BaseTest
    {
        [Test]
        public void VerifySubscriptionInHomePage()
        {
            // Verify that home page is visible successfully
            Assert.IsTrue(driver.FindElement(By.XPath("//a[contains(text(),'Home')]")).Displayed);
            
            // Scroll down to footer
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            
            // Verify text 'SUBSCRIPTION'
            Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(),'Subscription')]")).Displayed);
            
            // Enter email address in input and click arrow button
            driver.FindElement(By.Id("susbscribe_email")).SendKeys("test@example.com");
            driver.FindElement(By.Id("subscribe")).Click();
            
            // Verify success message 'You have been successfully subscribed!' is visible
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='alert-success']")).Displayed);
        }
    }
}