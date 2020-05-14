using System;
using System.Collections.Generic;
using System.Text;


namespace Models
{
    public class Issues
    {
        public decimal IssueId { get; set; }
        public decimal IssuesCategoriesId { get; set; }
        public decimal IssuesStatusesId { get; set; }
        public decimal? IssuesSeverityId { get; set; }
        public decimal? IssuesPriorityId { get; set; }
        public string IssuesTitle { get; set; }
        public string IssuesDescription { get; set; }
        public string IssuesExpectedBehavior { get; set; }
        public decimal IssuesProjectsId { get; set; }
       
        public string IssueCategoriesTitle { get; set; }
        public string IssuesPriorityTitle { get; set; }
        public string IssuesProjectsTitle { get; set; }
        public bool? IssuesProjectsIsActive { get; set; }
        public string IssuesSeverityTitle { get; set; }
        public string IssuesStatusesTitle { get; set; }

        //==

        public string IssuesCreatedBy { get; set; }
        public DateTime IssuesCreatedDate { get; set; }
        public string IssuesLastModifiedBy { get; set; }
        public DateTime? IssuesLastModifiedDate { get; set; }
        //==
        public List<Attachments> AttachmentsView { get; set; }
        public List<Comments> Comments { get; set; }
    }
}
