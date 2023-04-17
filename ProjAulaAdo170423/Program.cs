using ProjAulaAdo170423.Controllers;
using ProjAulaAdo170423.Model;
using ProjAulaAdo170423.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Proj MVC - ADO.NET");
        Console.WriteLine("Teste de inclusao de dados");


        Airplane airplane = new()
        {
            Description = "Para testes",
            Id = 1,
            NumberofPassangers = 20,
            Name = "TOP TURBO",
            Engine = new Engine() { Description = "Motor legal"}
        };

        if (new AirplaneController().Insert(airplane))
            Console.WriteLine("Sucesso! registro inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");

        new AirplaneController().FindAll().ForEach(Console.WriteLine);
    }
}