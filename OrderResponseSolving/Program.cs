using System.Reflection;
using System.Text;
using Business.Business;
using Business.Interfaces;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        IOrderManager orderManager = new OrderManager();
        string content = System.IO.File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"response.json"));
        Console.WriteLine(orderManager.SolvingOrderResponse(content));
        Console.ReadLine();
    }
}

