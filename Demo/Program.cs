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
settings.AddDabaseServer(@"Имя подключения в SSMS");
settings.AddDatabaseName("Library");
