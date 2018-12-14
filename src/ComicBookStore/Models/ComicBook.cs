using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicBookStore.Models
{
    public class ComicBook
    {
        public int Id { get; set; }
        public string SeriesTitle { get; set; }
        public string IssueNumber { get; set; }
        public string Description { get; set; }
        public string[] Artists { get; set; }
        public List<ComicImage> ComicImages { get; set; }
        public Thumbnail Thumbnail { get; set; }

        public string DisplayText
        {
            get
            {
                return SeriesTitle + " # " + IssueNumber;
            }
        }

    }
}