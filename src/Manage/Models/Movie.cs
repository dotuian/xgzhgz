using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Manage.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }

    //public class User {
    //    public long ID { get; set; }
    //    public string Username { get; set; }
    //    public string Password { get; set; }
    //    public int status { get; set; }
    //    public long version { get; set; }
    //    public DateTime CreateTime { get; set; }
    //    public DateTime UpdateTime { get; set; }
    //    public long CreateUserId { get; set; }
    //    public long UpdateUserId { get; set; }
    //}

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
    }

}