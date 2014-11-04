using EFDDDSample.Data.Repositories;
using EFDDDSample.DataContext;
using EFDDDSample.Domain;
using EFDDDSample.Domain.Repositories;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var container = new UnityContainer();
        container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
        container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
        container.RegisterType<ICategoryRepository, CategoryRepository>(new HierarchicalLifetimeManager());
        container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
        container.RegisterType<IAuthorRepository, AuthorRepository>(new HierarchicalLifetimeManager());

        var productRepository = container.Resolve<IProductRepository>();
        var categoryRepository = container.Resolve<ICategoryRepository>();
        var bookRepository = container.Resolve<IBookRepository>();
        var authorRepository = container.Resolve<IAuthorRepository>();

        var book = new Book("Livro 01");
        var author = new Author("Autor 01");
        var product = new Product("Produto 01");
        var category = new Category("Categoria 01");

        #region Adiciona Itens
        book.AddAuthor(author);
        category.AddProduct(product);

        bookRepository.SaveOrUpdate(book);
        categoryRepository.SaveOrUpdate(category);
        #endregion

        #region Mostra Itens
        Console.WriteLine("\nLivros");
        bookRepository.Get().ToList().ForEach(x => Console.WriteLine(x.Name));

        Console.WriteLine("\nAutores");
        authorRepository.Get().ToList().ForEach(x => Console.WriteLine(x.Name));

        Console.WriteLine("\nProdutos");
        productRepository.Get().ToList().ForEach(x => Console.WriteLine(x.Name));

        Console.WriteLine("\nCategorias");
        categoryRepository.Get().ToList().ForEach(x => Console.WriteLine(x.Name));
        #endregion

        Console.WriteLine("\n-----");
        Console.WriteLine("Objetos aninhados");
        Console.WriteLine("-----");

        #region Mostra Itens Aninhados
        Console.WriteLine("\nLivros");
        bookRepository.GetWithAuthors().ToList().ForEach(x =>
        {
            Console.WriteLine("\t" + x.Name);
            x.Authors.ToList().ForEach(y =>
            {
                Console.WriteLine("\t\t" + y.Name);
            });
        });

        Console.WriteLine("\nCategorias");
        categoryRepository.GetWithProducts().ToList().ForEach(x =>
        {
            Console.WriteLine("\t" + x.Name);
            x.Products.ToList().ForEach(y =>
            {
                Console.WriteLine("\t\t" + y.Name);
            });
        });
        #endregion

        #region Exclui os itens
        bookRepository.Delete(book.Id);
        authorRepository.Delete(author.Id);
        categoryRepository.Delete(category.Id); // Exclui os produtos também
        #endregion

        #region Mostra Itens
        Console.WriteLine("\nLivros");
        bookRepository.Get().ToList().ForEach(x => Console.WriteLine(x.Name));

        Console.WriteLine("\nAutores");
        authorRepository.Get().ToList().ForEach(x => Console.WriteLine(x.Name));

        Console.WriteLine("\nProdutos");
        productRepository.Get().ToList().ForEach(x => Console.WriteLine(x.Name));

        Console.WriteLine("\nCategorias");
        categoryRepository.Get().ToList().ForEach(x => Console.WriteLine(x.Name));
        #endregion

        Console.Read();
    }
}
