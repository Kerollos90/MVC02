﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public static class EmailSettings
    {

        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com",587);

            client.EnableSsl = true;

            client.Credentials = new NetworkCredential("emadkero318@gmail.com", "jgmiojkgebjusoeo");

            client.Send("emadkero318@gmail.com",email.to,email.subject,email.body);
           
        
        
        
        }




    }
}