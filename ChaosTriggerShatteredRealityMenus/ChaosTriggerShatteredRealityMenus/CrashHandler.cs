using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net.Mail;

namespace ChaosTriggerShatteredRealityMenus
{
    public partial class CrashHandler : Form
    {
        public CrashHandler(string errorMessage, string stackTrace)
        {
            InitializeComponent();
            errorLabel.Text = errorMessage + "\n" + stackTrace; //Sets the label in the form equal to the type of exception that caused the crash
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage("brenthesda@gmail.com", "brenthesda@gmail.com"); //Sets the email to send from and receive to (emailing to the same email address)
            SmtpClient Client = new SmtpClient("smtp.gmail.com", 587);

            Client.DeliveryMethod = SmtpDeliveryMethod.Network; //Delivery goes through Smtp newtork to deliver message
            Client.EnableSsl = true;
            Client.UseDefaultCredentials = false;
            Client.Credentials = new System.Net.NetworkCredential("brenthesda@gmail.com", "Gh0stC0mm4nd04"); //email and password

            message.Subject = ("Crash Report");
            message.Body = errorLabel.Text; //Sets the body of the message equal to the error in the textbox of the crashhandler form
            message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            Client.Send(message);
        }
    }
}
