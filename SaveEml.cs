using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.IO;
using System.Reflection;
using System.Net.Mime;

namespace Eml
{
    /// <summary>Save of an email in the EML format
    /// <para></para>
    /// <para></para>
    /// </summary>
    public static class SaveEml
    {
        #region Internet links to EML information

        // https://www.codeguru.com/csharp/csharp/cs_internet/mail/saving-an-e-mail-as-an-.eml-file-in-c.html

        #endregion // Internet links to EML information

        #region Main execution function

        /// <summary>Save of an email in the EML format
        /// <para></para>
        /// <para></para>
        /// </summary>
        /// <param name="ref_eml">JazzEml object with all data for the email</param>
        /// <param name="o_error">Error message</param>
        public static bool Execute(ref JazzEml ref_eml, out string o_error)
        {
            o_error = @"";

            string to_str = ref_eml.To;

            string from_str = ref_eml.From;

            string subject_str = ref_eml.Subject;

            string body_str = @"<body>" + ref_eml.MsgHtml + @"</body>";

            string email_dir_str = Path.GetDirectoryName(ref_eml.EmlFileNameLocal);

            string msg_name_str = Path.GetFileName(ref_eml.EmlFileNameLocal);

            using (var smtp_client = new SmtpClient())
            {
                MailMessage mail_msg = new MailMessage(from_str, to_str, subject_str, body_str);

                AlternateView html_view = AlternateView.CreateAlternateViewFromString(body_str, null, "text/html");

                mail_msg.AlternateViews.Add(html_view);

                AddAttachmentToMail(ref_eml.AttachmentImageLocal, ref mail_msg);

                AddAttachmentToMail(ref_eml.AttachmentFileLocal, ref mail_msg);

                smtp_client.UseDefaultCredentials = true;

                smtp_client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;

                smtp_client.PickupDirectoryLocation = email_dir_str;

                try
                {
                    smtp_client.Send(mail_msg);
                }
                catch (Exception ex)
                {
                    o_error = @"SaveEml.Execute SmtpClient.Send failed " + ex.ToString();

                    return false;
                }

            } // using SmtpClient

            var default_msg_path = new DirectoryInfo(email_dir_str).GetFiles().OrderByDescending(f => f.LastWriteTime).First();

            string warning_msg = @"";

            var real_msg_path = Path.Combine(email_dir_str, msg_name_str);
            try
            {
                File.Move(default_msg_path.FullName, real_msg_path);
               
            }
            catch (System.IO.IOException e)
            {
                warning_msg = e.ToString();

                File.Delete(real_msg_path);

                File.Move(default_msg_path.FullName, real_msg_path);
            }

            return true;

        } // Execute

        #endregion // Main execution function

        /// <summary>Add attachement</summary>
        private static void AddAttachmentToMail(string i_attachment_file_name, ref MailMessage o_mail_poster)
        {
            if (i_attachment_file_name == "")
            {
                return;
            }

            if (!File.Exists(i_attachment_file_name))
            {
                return;
            }

            Attachment data = new Attachment(i_attachment_file_name, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(i_attachment_file_name);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(i_attachment_file_name);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(i_attachment_file_name);
            // Add the file attachment to this e-mail message.
            o_mail_poster.Attachments.Add(data);

        } // AddAttachmentToMail

    } // SaveEml

} // namespace
