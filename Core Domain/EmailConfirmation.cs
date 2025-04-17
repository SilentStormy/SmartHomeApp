using Core_Domain;
using Core_Domain.Entities;
using Core_Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EmailConfirmation : IRegistrationConfirmation
    {
        
        public AuthResult Send(User user)
        {
            try
            {
                var mail = "smarthome_appp@outlook.com";
                var pass = "Smart0102";
                var smartuser = new SmtpClient("smtp-mail.outlook.com", 587)
                {
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(mail, pass)
                };
                smartuser.Send(
                    new MailMessage(from: mail,
                    to: user.Email,
                    subject: "Welkom bij de smarthomeapp!",
                    body: $"Dag {user.Firstname}, je registratie is gelukt."
                    ));

                return AuthResult.SuccessResult(true, "Jouw Registratie is gelukt!");
            }
            catch (Exception ex) 
            {
                return AuthResult.FailedResult(false,ex.Message);
            }
          

        }
    }
}
