using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSEFOS.Paths
{
    internal static class Login
    {
        //Fields
        public static By EmailFieldID { get; } = By.Id("login_email");
        public static By ErrorMessageXPath { get; } = By.XPath("//*[@id=\"noty_layout__bottomCenter\"]");

        //Buttons
        public static By LoginButtonXPath { get; } = By.XPath("//*[@id=\"main-content\"]/div/div[2]/section/div/button");
    }
}
