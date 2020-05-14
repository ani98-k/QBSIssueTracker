using System;

namespace Models
{
    public class Comments
    {
        public string CommentsComment { get; set; }
        public Guid? CommenterUserId { get; set; }
        public string CommenterUserName { get; set; }
        public DateTime? CommentedDate { get; set; }
    }
}