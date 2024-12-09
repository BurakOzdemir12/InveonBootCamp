// See https://aka.ms/new-console-template for more information
using System.Reflection.Emit;
using static AsyncProgramming.Async;

Console.WriteLine("Hello, World!");

    var async = new AsyncProgramming.Async();

    async.Plus(0,0);

    async.PlusAsync(0,0);

async.Discount("Hata");
Console.ReadLine();