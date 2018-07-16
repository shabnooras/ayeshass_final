using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace BASITraining
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // on clicking submit button following code runs
        protected void Button4_click(object sender, EventArgs e)
        {
            // try, catch - to catch an exception and handle it
            try
            {
                if (Page.IsValid)
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("YourGmailID@gmail.com");
                    mailMessage.To.Add("AdministratorID@YourCompany.com");
                    mailMessage.Subject = TextBox5.Text;

                    //all details are collected 
                    mailMessage.Body = "<b>Sender Name : </b>" + TextBox3.Text + "<br/>"
                        + "<b>Sender Email : </b>" + TextBox2.Text + "<br/>"
                        + "<b>Comments : </b>" + TextBox4.Text;
                    mailMessage.IsBodyHtml = true;

                    //define server and port number i.e., 587 of gmail used
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                    //enable SSL to encrypt the connection
                    smtpClient.EnableSsl = true;

                    //put the email and address(credentials) to where the message will be delivered
                    smtpClient.Credentials = new System.Net.NetworkCredential("YourGmailID@gmail.com", "YourGmailPassowrd");
                    smtpClient.Send(mailMessage);

                    Label1.ForeColor = System.Drawing.Color.Blue;
                    Label1.Text = "Thank you for contacting us";

                    //clear the texboxes once the message is sent
                    TextBox3.Text = " ";
                    TextBox2.Text = " ";
                    TextBox5.Text = " ";
                    TextBox4.Text = " ";
                }
            }
            catch (Exception ex)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                //if there is problem with connection or network adn message can't be sent, then this message is shown
                Label1.Text = "There is unknown problem. Pls try later again";
            }
        }
    }

}