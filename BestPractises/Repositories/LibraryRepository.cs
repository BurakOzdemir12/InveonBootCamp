using BestPractises.Interfaces;
using BestPractises.Models;

namespace BestPractises.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        public List<Book> GetBooks()
        {

            return new List<Book>()
            {

                new Book() {Id=1,Type="Kişisel Gelişim",Name="A Kitabı",stock=32,Author="aa aa"},
                new Book() {Id=2,Type="Dram",Name="B Kitabı",stock=21,Author="dd dd"},
                new Book() {Id=3, Type="Tarih",Name="C Kitabı",stock=3,Author="ss ss"},
                new Book() {Id=4, Type="a",Name="C Kitabı",stock=3,Author="ss ss"},
                new Book() {Id=5, Type="b",Name="b Kitabı",stock=3,Author="ss ss"},
                new Book() {Id=6, Type="c",Name="c Kitabı",stock=3,Author="ss ss"},
                new Book() {Id=7, Type="d",Name="d Kitabı",stock=3,Author="ss ss"},
                new Book() {Id=8, Type="g",Name="g Kitabı",stock=3,Author="ss ss"},
                new Book() {Id=9, Type="h",Name="h Kitabı",stock=3,Author="ss ss"},
                new Book() {Id=10, Type="j",Name="j Kitabı",stock=3,Author="ss ss"},
                new Book() {Id=11, Type="l",Name="l Kitabı",stock=3,Author="ss ss"},

            };
        }
        public List<Article> GetArticles()
        {
            return new List<Article>()
            { new Article() { Id = 1, Title = "Beslenme hakkında makale", Author = "X Yazarı" },
             new Article() { Id = 2, Title = "Spor hakkında makale", Author = "Y Yazarı" },
             new Article() { Id = 3, Title = "Yazılım hakkında makale", Author = "Z Yazarı" }

            };
        }
    }
}
