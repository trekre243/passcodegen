using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace PasscodeGenerator.Controllers
{
    public class PassGenController : Controller
    {
        [HttpGet("")]
        public ViewResult Passcode()
        {
            int? passwordCount = HttpContext.Session.GetInt32("PassCount");
            if(passwordCount == null)
            {
                passwordCount = 1;
            }
            else
            {
                passwordCount++;
            }
            HttpContext.Session.SetInt32("PassCount", (int)passwordCount);

            Random rand = new Random();
            string randPassword;
            randPassword = "";
            for(int i = 0; i < 14; i++)
            {
                int newChar;
                int numOrLetter = rand.Next(2);
                if(numOrLetter == 0)
                {
                    newChar = rand.Next(10);
                    randPassword += newChar.ToString();
                }
                else
                {
                    newChar = 65 + rand.Next(26);
                    randPassword += (char)newChar;
                }
            }
            ViewBag.password = randPassword;
            ViewBag.passCount = passwordCount;
            return View("Index");
        }
    }
}