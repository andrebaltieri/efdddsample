using ConsoleApplication1.DataContext;
using ConsoleApplication1.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Objects
            var product01 = new Product("Mouse");
            var product02 = new Product("Teclado");
            var product03 = new Product("Monitor");
            var product04 = new Product("Cerveja");

            var category01 = new Category("Informática");
            var category02 = new Category("Bebidas");

            var book01 = new Book("Livro 01");
            var book02 = new Book("Livro 02");

            var author01 = new Author("Autor 01");
            var author02 = new Author("Autor 02");
            var author03 = new Author("Autor 03");
            var author04 = new Author("Autor 04");
            var author05 = new Author("Autor 05");
            #endregion

            #region Association
            category01.AddProduct(product01);
            category01.AddProduct(product02);
            category01.AddProduct(product03);
            category02.AddProduct(product04);

            book01.AddAuthor(author01);
            book01.AddAuthor(author02);
            book01.AddAuthor(author03);

            book02.AddAuthor(author04);
            book02.AddAuthor(author05);
            #endregion

            #region Insert
            using (AppDataContext _db = new AppDataContext())
            {
                _db.Categories.Add(category01);
                _db.Categories.Add(category02);

                _db.Books.Add(book01);
                _db.Books.Add(book02);

                _db.SaveChanges();
            }
            #endregion

            #region Atualiza Categoria / Produto
            using (AppDataContext _db = new AppDataContext())
            {
                var cat = _db.Categories.Where(x => x.Name == "Bebidas").FirstOrDefault();
                var prd = new Product("Milho");

                cat.ChangeName("Comidas e Bebidas");
                cat.AddProduct(prd);

                _db.Entry<Category>(cat).State = EntityState.Modified;
                _db.SaveChanges();
            }
            #endregion

            #region Atualiza Livro / Autor
            using (AppDataContext _db = new AppDataContext())
            {
                var book = _db.Books.Where(x => x.Name == "Livro 02").FirstOrDefault();
                var author = _db.Authors.Where(x => x.Name == "Autor 01").FirstOrDefault();
                var newAuthor = new Author("Andre");

                book.AddAuthor(author);
                book.AddAuthor(newAuthor);
                _db.Entry<Book>(book).State = EntityState.Modified;
                _db.SaveChanges();
            }
            #endregion

            #region Leitura
            using (AppDataContext _db = new AppDataContext())
            {
                Console.WriteLine("\nProducts");
                foreach (var item in _db.Products.ToList())
                    Console.WriteLine(item.Name);

                Console.WriteLine("\nCategories");
                foreach (var item in _db.Categories.ToList())
                    Console.WriteLine(item.Name);

                Console.WriteLine("\nBooks");
                foreach (var item in _db.Books.ToList())
                    Console.WriteLine(item.Name);

                Console.WriteLine("\nAuthors");
                foreach (var item in _db.Authors.ToList())
                    Console.WriteLine(item.Name);
            }
            #endregion

            #region Leitura com Include
            using (AppDataContext _db = new AppDataContext())
            {
                Console.WriteLine("");
                Console.WriteLine("Products");
                foreach (var item in _db.Categories.Include(x=>x.Products).ToList())
                {
                    Console.WriteLine("\t" + item.Name);
                    foreach (var subitem in item.Products)
                        Console.WriteLine("\t\t" + subitem.Name);
                }

                Console.WriteLine("");
                Console.WriteLine("Books");
                foreach (var item in _db.Books.Include(x => x.Authors).ToList())
                {
                    Console.WriteLine("\t" + item.Name);
                    foreach (var subitem in item.Authors)
                        Console.WriteLine("\t\t" + subitem.Name);
                }

            }
            #endregion

            Console.Read();
        }
    }
}
