using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eml
{
    /// <summary>Holds data for one email of the format EML
    /// <para></para>
    /// <para></para>
    /// </summary>
    public class JazzEml
    {
        /// <summary>Full name for the eml file</summary>
        private string m_path_file_name_local = @"";
        /// <summary>Get and set full name for the eml file</summary>
        public string EmlFileNameLocal { get { return m_path_file_name_local; } set { m_path_file_name_local = value; } }

        /// <summary>Server path for the eml file</summary>
        private string m_path_server = @"";
        /// <summary>Get and set server path for the eml file</summary>
        public string EmlPathServer { get { return m_path_server; } set { m_path_server = value; } }

        /// <summary>Server name for the eml file</summary>
        private string m_file_server = @"";
        /// <summary>Get and set server name for the eml file</summary>
        public string EmlFileServer { get { return m_file_server; } set { m_file_server = value; } }

        /// <summary>Send year</summary>
        private int m_send_year = -12345;
        /// <summary>Get and set send year</summary>
        public int SendYear { get { return m_send_year; } set { m_send_year = value; } }

        /// <summary>Send month</summary>
        private int m_send_month = -12345;
        /// <summary>Get and set send month</summary>
        public int SendMonth { get { return m_send_month; } set { m_send_month = value; } }

        /// <summary>Send day</summary>
        private int m_send_day = -12345;
        /// <summary>Get and set send day</summary>
        public int SendDay { get { return m_send_day; } set { m_send_day = value; } }

        /// <summary>Email subject</summary>
        private string m_subject = @"";
        /// <summary>Get and set email subject</summary>
        public string Subject { get { return m_subject; } set { m_subject = value; } }

        /// <summary>Email from</summary>
        private string m_from = @"";
        /// <summary>Get and set email from</summary>
        public string From { get { return m_from; } set { m_from = value; } }

        /// <summary>Email to</summary>
        private string m_to = @"";
        /// <summary>Get and set email to</summary>
        public string To { get { return m_to; } set { m_to = value; } }

        /// <summary>Message text</summary>
        private string m_message_text = @"";
        /// <summary>Get and set message text</summary>
        public string MsgText { get { return m_message_text; } set { m_message_text = value; } }

        /// <summary>Message HTML</summary>
        private string m_message_html = @"";
        /// <summary>Get and set message HTML</summary>
        public string MsgHtml { get { return m_message_html; } set { m_message_html = value; } }

        /// <summary>Local attachment image name</summary>
        private string m_attachment_image_name_local = @"";
        /// <summary>Get and set the local attachment image name</summary>
        public string AttachmentImageLocal { get { return m_attachment_image_name_local; } set { m_attachment_image_name_local = value; } }

        /// <summary>Server attachments path</summary>
        private string m_attachment_image_path_server = @"";
        /// <summary>Get and set the server attachments path</summary>
        public string AttachmentImagePathServer { get { return m_attachment_image_path_server; } set { m_attachment_image_path_server = value; } }

        /// <summary>Server attachment image file name</summary>
        private string m_attachment_image_server = @"";
        /// <summary>Get and set the server attachment image file name</summary>
        public string AttachmentImageServer { get { return m_attachment_image_server; } set { m_attachment_image_server = value; } }

        /// <summary>Embedded poster flag</summary>
        private bool m_b_embedded_poster = false;
        /// <summary>Get and set embedded poster flag</summary>
        public bool EmbeddedPosterFlag { get { return m_b_embedded_poster; } set { m_b_embedded_poster = value; } }

        /// <summary>Local attachment file name</summary>
        private string m_attachment_file_name_local = @"";
        /// <summary>Get and set the local attachment file name</summary>
        public string AttachmentFileLocal { get { return m_attachment_file_name_local; } set { m_attachment_file_name_local = value; } }

        /// <summary>Server attachments path</summary>
        private string m_attachment_path_server = @"";
        /// <summary>Get and set the server attachments path</summary>
        public string AttachmentPathServer { get { return m_attachment_path_server; } set { m_attachment_path_server = value; } }

        /// <summary>Server attachment file name</summary>
        private string m_attachment_file_server = @"";
        /// <summary>Get and set the server attachment file name</summary>
        public string AttachmentFileServer { get { return m_attachment_file_server; } set { m_attachment_file_server = value; } }

        /// <summary>Returns the img html element string for the embedded poster of the newsletter</summary>
        public string GetImgHtmlString()
        {
            string ret_img_html = @"";

            if (m_attachment_image_server.Length < 4)
            {
                // Image server file name is not set.
                return ret_img_html;
            }

            if (m_attachment_image_path_server.Length == 0)
            {
                // Image server path is not set.
                return ret_img_html;
            }

            ret_img_html = @"<img src= '" + m_attachment_image_path_server + m_attachment_image_server + 
                           @"' width= '259' 'alt= 'Plakat' class= 'cl_newsletter_embedded_img'>";

            return ret_img_html;

        } // GetImgHtmlString


    } // JazzEml

} // namespace
