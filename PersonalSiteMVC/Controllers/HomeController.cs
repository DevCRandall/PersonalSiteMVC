﻿using Microsoft.AspNetCore.Mvc;
using PersonalSiteMVC.Models;
using System.Diagnostics;
using MimeKit;// Added for access to MimeMessage class
using MailKit.Net.Smtp;// Added for access to SmtpClient class

namespace PersonalSiteMVC.Controllers
{
    public class HomeController : Controller
    {
        //Fields
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration _config;

        // Properties
        // No properties

        // Constructor
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        // Methods
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        public IActionResult Testimonials()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            var mm = new MimeMessage();

            string message = $"You have received a new email from your site's contact form!<br/>" +
                $"Sender: {cvm.Name}<br/>Email: {cvm.Email}<br/>Subject: {cvm.Subject}<br/>" +
                $"Message: {cvm.Message}";

            mm.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:User")));
            mm.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));

            mm.Subject = cvm.Subject;
            mm.Body = new TextPart("HTML") { Text = message };
            mm.Priority = MessagePriority.Urgent;
            mm.ReplyTo.Add(new MailboxAddress("User", cvm.Email));

            using (var client = new SmtpClient())
            {
                client.Connect(_config.GetValue<string>("Credentials:Email:Client"));

                client.Authenticate(
                    _config.GetValue<string>("Credentials:Email:User"),
                    _config.GetValue<string>("Credentials:Email:Password")
                    );

                try
                {
                    client.Send(mm);
                }
                catch (Exception ex)
                {

                    ViewBag.ErrorMessage = $"There was an error processing your request." +
                        $"Please try again later.<br/>" +
                        $"Error Message: {ex.StackTrace}";

                    return View(cvm);  
                }
            }

            return View("EmailConfirmation", cvm);

        }
    }
}