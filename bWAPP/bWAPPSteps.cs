using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

    }
    
    [AfterScenario]
    public void AfterScenario()
    {
        _driver.Quit();
    }
    

    [Given("L'utilisateur est sur la page de login")]
    public void GivenLutilisateurEstSurLaPageDeLogin()
    {
        _driver.Navigate().GoToUrl("http://localhost/login.php"); // adapte l'URL si besoin
    }


    [When("Il saisit {string} dans le champ username")]
    public void WhenIlSaisitDansLeChampUsername(string bee)
    {
        _driver.FindElement(By.Name("login")).SendKeys(bee);
    }

    [When("Il saisit {string} dans le champ password")]
    public void WhenIlSaisitDansLeChampPassword(string bug)
    {
        _driver.FindElement(By.Name("password")).SendKeys(bug);
    }

    [When("Il clique sur le bouton de connexion")]
    public void WhenIlCliqueSurLeBoutonDeConnexion()
    {
        _driver.FindElement(By.XPath("/html/body/div[2]/form/button")).Click();
    }

    [Then("Il est redirigé vers la page d'accueil sécurisée")]
    public void ThenIlEstRedirigeVersLaPageDaccueilSecurisee()
    {
        Assert.IsTrue(_driver.Url.EndsWith("portal.php"));
    }

    [Then("Un message d'erreur est affiché")]
    public void ThenUnMessageDerreurEstAffiche()
    {
        var body = _driver.FindElement(By.TagName("body")).Text;
        Assert.IsTrue(body.ToLower().Contains("Invalid credentials or user not activated!"));

    }
    

    [Then("L'utilisateur est sur la page de login")]
    public void ThenLutilisateurEstSurLaPageDeLogin()
    {
        Assert.IsTrue(_driver.Url.EndsWith("login.php"));
    }

    [When("Il clique sur le lien de déconnexion")]
    public void WhenIlCliqueSurLeLienDeDeconnexion()
    {
        var test = _driver.FindElement(By.CssSelector("#menu > table > tbody > tr > td:nth-child(8) > a"));
        test.Click();

    }

    [When("Il confirme la déconnexion dans la popup")]
    public void WhenIlConfirmeLaDeconnexionDansLaPopup()
    {
        IAlert alert = _driver.SwitchTo().Alert();
        alert.Accept();    
    }

    [When("Il navigue vers la page de changement de mot de passe")]
    public void WhenIlNavigueVersLaPageDeChangementDeMotDePasse()
    {
        _driver.FindElement(By.CssSelector("#menu > table > tbody > tr > td:nth-child(2) > a")).Click();
    }

    [When("Il entre {string} comme ancien mot de passe")]
    public void WhenIlEntreCommeAncienMotDePasse(string bug)
    {
        _driver.FindElement(By.Id("password_curr")).SendKeys(bug);
    }

    [When("Il entre {string} comme nouveau mot de passe")]
    public void WhenIlEntreCommeNouveauMotDePasse(string newbug)
    {
        _driver.FindElement(By.Id("password_new")).SendKeys(newbug);
    }

    [When("Il confirme avec {string}")]
    public void WhenIlConfirmeAvec(string newbug)
    {
        _driver.FindElement(By.Id("password_conf")).SendKeys(newbug);
    }
    

    [Then("Un message confirmant le changement de mot de passe est affiché")]
    public void ThenUnMessageConfirmantLeChangementDeMotDePasseEstAffiche()
    {
        string message = _driver.FindElement(By.CssSelector("#main > font")).Text.ToLower();
        Assert.AreEqual("the password has been changed!", message);;
    }

    [When("Il clique sur le bouton de changement de mot de passe")]
    public void WhenIlCliqueSurLeBoutonDeChangementDeMotDePasse()
    {
        _driver.FindElement(By.CssSelector("#menu > table > tbody > tr > td:nth-child(2) > a")).Click();
    }

    [When("Il clique sur Change password")]
    public void WhenIlCliqueSurChangePassword()
    {
        _driver.FindElement(By.CssSelector("#main > form > button")).Click();
    }

    [When("Il navigue vers la page de configuration de sécurité")]
    public void WhenIlNavigueVersLaPageDeConfigurationDeSecurite()
    {
        _driver.FindElement(By.CssSelector("#menu > table > tbody > tr > td:nth-child(4) > a")).Click();
    }


    [When("Il clique sur le bouton de Set")]
    public void WhenIlCliqueSurLeBoutonDeSet()
    {
        _driver.FindElement(By.CssSelector("#main > form > p > button")).Click();
    }

    [Then("Le niveau de sécurité affiché est {string}")]
    public void ThenLeNiveauDeSecuriteAfficheEst(string high)
    {
        string text = _driver.FindElement(By.CssSelector("#security_level > form > font > b")).Text;
        Console.WriteLine(text);
        Assert.AreEqual(high.ToLower(), text.ToLower());
    }

    [When("Il sélectionne le niveau high")]
    public void WhenIlSelectionneLeNiveauHigh()
    {
        var dropdown = _driver.FindElement(By.Name("security_level"));
        var select = new SelectElement(dropdown);
        select.SelectByValue("2");
    }
}