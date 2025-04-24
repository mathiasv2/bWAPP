using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace bWAPP;

[Binding]
public class bWAPPSteps
{
    private IWebDriver _driver;
        
    [BeforeScenario]
    public void BeforeScenario()
    {
        _driver = new ChromeDriver();
    }
    
    [Given("Utilisateur login {string} et input password {string}")]
    public void GivenUtilisateurLoginEtInputPassword(string bee, string bug)
    {
        _driver.FindElement(By.Name("login")).SendKeys(bee);
        _driver.FindElement(By.Name("password")).SendKeys(bug);
    }
}