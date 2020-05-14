using Microsoft.AspNetCore.Http;

namespace Models
{
    public class Attachments
    {
        public IFormFile IssueImage;
        public string AttachmentsLink { get; set; }
        public System.DateTime? AttachmentsDate { get; set; }
        public string AttachmentsUsername { get; set; }
        public Xamarin.Forms.Image AttachmentImage { get; private set; }
    }
}