﻿using Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Email()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(SendMailDto sendMailDto)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                MailMessage mail = new MailMessage();
                // you need to enter your mail address
                mail.From = new MailAddress("saroj2shresthaa@hotmail.com");

                // To Email Address - you need to enter your to email address
                mail.To.Add("shresthasaroj855@outlook.com");

                mail.Subject = sendMailDto.Subject;

                // you can specify also CC and BCC - I will skip this
                // mail.CC.Add("");
                // mail.Bcc.Add("");

                mail.IsBodyHtml = true;

                string content = "Name: " + sendMailDto.Name;
                content += "<br/> Message: " + sendMailDto.Message;

                mail.Body = content;

                // create SMTP instance

                // you need to pass mail server address and you can also specify the port number if you required
                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");

                // Create network credential and you need to give from email address and password
                NetworkCredential networkCredential = new NetworkCredential("saroj2shresthaa@hotmail.com", "9860474988@");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587; // Outlook uses port 587 for TLS
                smtpClient.EnableSsl = true; // Outlook requires SSL to be enabled

                smtpClient.Send(mail);

                ViewBag.Message = "Mail Send";

                // now I need to create the form 
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                // If any error occurred it will show
                ViewBag.Message = ex.Message.ToString();
            }
            return View();
        }
    }
}

