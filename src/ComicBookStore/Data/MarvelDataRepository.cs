using Marvel.Api;
using Marvel.Api.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using ComicBookStore.Models;

namespace ComicBookStore.Data
{
    public class MarvelDataRepository 
    {

        private static MarvelDataRepository Instance;
        private readonly string publicKey = "<PRIVATE KEY>";
        private readonly string privateKey = "<PUBLIC KEY>";

        //Constructor
        private MarvelDataRepository()
        {
        }
        //Property
        public static MarvelDataRepository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new MarvelDataRepository();
            }
            return Instance;

        }

        public List<ComicBook> GetAllComics()
        {
            var client = new MarvelRestClient(publicKey, privateKey);
            var response = client.FindComics();
            List<ComicBook> comicList = new List<ComicBook>();
            if (response != null && response.Data != null)
            {
                foreach (var comic in response.Data.Results)
                {
                    var book = new ComicBook();
                    book.SeriesTitle = comic.Title;
                    book.Description = SetDescription(comic);
                    book.IssueNumber = comic.IssueNumber;
                    var thumbNail = new Thumbnail();
                    thumbNail.Path = comic.Thumbnail.Path;
                    thumbNail.Extension = comic.Thumbnail.Extension;
                    book.Thumbnail = thumbNail;
                    List<ComicImage> images = new List<ComicImage>();
                    for (int i = 0; i < comic.Images.Count; i++)
                    {
                        ComicImage image = new ComicImage();
                        image.Extension = comic.Images[i].Extension;
                        image.Path = comic.Images[i].Path;
                        images.Add(image);

                    }
                    comicList.Add(book);
                }
            }
            return comicList;
        }



        public List<ComicBook> GetFilteredComics(string filteredString)
        {
            var client = new MarvelRestClient(publicKey, privateKey);
            var filter = new ComicRequestFilter();
            filter.TitleStartsWith = filteredString;
            var response = client.FindComics(filter);
            List<ComicBook> comicList = new List<ComicBook>();
            if (response != null && response.Data != null)
            {
                foreach (var comic in response.Data.Results)
                {
                    var book = new ComicBook();
                    book.SeriesTitle = comic.Title;
                    book.Description = SetDescription(comic);//comic.Description;
                    book.IssueNumber = comic.IssueNumber;
                    var thumbNail = new Thumbnail();
                    thumbNail.Path = comic.Thumbnail.Path;
                    thumbNail.Extension = comic.Thumbnail.Extension;
                    book.Thumbnail = thumbNail;
                    List<ComicImage> images = new List<ComicImage>();
                    for (int i = 0; i < comic.Images.Count; i++)
                    {
                        ComicImage image = new ComicImage();
                        image.Extension = comic.Images[i].Extension;
                        image.Path = comic.Images[i].Path;
                        images.Add(image);

                    }
                    comicList.Add(book);
                }
            }
            return comicList;
        }

        private string SetDescription(Marvel.Api.Model.DomainObjects.Comic comic)
        {
            if (String.IsNullOrEmpty(comic.Description)) {
                return "No Description Available";
            }
            return comic.Description;
        }
    }
}
