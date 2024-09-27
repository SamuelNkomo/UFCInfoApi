﻿// Models/Article.cs
using System;

namespace UFCInfoApi.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
