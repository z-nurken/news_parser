using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TokenEntity> Tokens { get; set; }
        public DbSet<NewsParserConfigEntity> NewsParserConfigs { get; set; }

        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SEED DATA

            modelBuilder.Entity<UserEntity>().HasData(
              new UserEntity
              {
                  Id = 1,
                  FirstName = "Test",
                  LastName = "Testov",
                  Login = "Test",
                  PasswordHash = "AQAAAAEAACcQAAAAEEquPo9ZbpqzCp+SFLr0l7WlBiox+n+5/mUyUWnEXbPSfQyten77cA1spUUl3c7C1Q==", /*jQ39VH*/
                  CreatedDate = DateTime.Now
              }
            );

            modelBuilder.Entity<NewsParserConfigEntity>().HasData(
                new NewsParserConfigEntity
                {
                    Id = 1,
                    SiteLink = "https://lenta.inform.kz/",
                    XPathNews = "//a[contains(@class, 'lenta_news_title')]",
                    XPathTitle = "//div[contains(@class, 'article_container')]//article//h1",
                    XPathBody = "//div[contains(@class, 'article_container')]//div//div[contains(@class, 'article_body')]",
                    XPathDateTime = "//div[contains(@class, 'article_container')]//div//div[contains(@class, 'block-date_social_icon')]//div[contains(@class, 'date_article')]",
                    CreatedDate = DateTime.Now,
                    DateTimeFormat = "dd MMM yyyy H:mm",
                    DateTimeCultureInfo = "ru-RU"
                },
                new NewsParserConfigEntity
                {
                  Id = 2,
                  SiteLink = "https://24.kz/ru/",
                  XPathNews = "//a[@class='nspImageWrapper tleft fnull']",
                  XPathTitle = "//article[@class='view-article itemView']//div[@class='itemheader']//header//h1",
                  XPathBody = "//div[@class='itemBody']",
                  XPathDateTime = "//ul//li[@class='itemDate']//time",
                  CreatedDate = DateTime.Now,
                  DateTimeFormat = "HH:mm, dd.MM.yyyy"
                }
          );

            #endregion
        }
    }
}
