using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutomationExerciseTests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected Actions actions;
        
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            actions = new Actions(driver);
            driver.Navigate().GoToUrl("https://www.automationexercise.com/");
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver?.Quit();
        }
        
        protected bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        protected void WaitForElementVisible(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }
        
        protected void WaitForElementClickable(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
        
        protected void DismissAdsIfPresent()
        {
            try
            {
                if (IsElementPresent(By.Id("dismiss-button")))
                {
                    driver.FindElement(By.Id("dismiss-button")).Click();
                }
                // Xử lý các loại quảng cáo khác nếu cần
            }
            catch (Exception) { /* Bỏ qua lỗi xử lý quảng cáo */ }
        }
    }
}