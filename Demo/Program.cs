// See https://aka.ms/new-console-template for more information
using DataAccessLayer.ORM;
using Domain;

Console.WriteLine("Hello, World!");
var author = new Author("Пушкин", "Александр", "Сергеевич");
var book = new Book("Дубровский");
author.AddBook(book);
var shelf = new Shelf(1);
shelf.PutBook(book);
Console.WriteLine(shelf.ToString(), book);

var settings = new Settings();
settings.AddDabaseServer(@"4422WS19");
settings.AddDatabaseName("Library");

using var sessionFactory = Configurator.GetSessionFactory(settings, showSql: true);

using (var session = sessionFactory.OpenSession())
{
    session.Save(shelf);
    session.Save(book);
    session.Save(author);
    session.Flush();
};
