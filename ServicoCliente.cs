using System;
using System.Collections.Generic;
using System.Threading;

namespace console_exemplo_itau
{
  internal class ServicoCliente
  {
    internal static void Cadastrar(List<Cliente> clientes)
    {
      Console.WriteLine("Digite o nome");
      var cliente = new Cliente();
      cliente.Nome = Console.ReadLine();
      
      Console.WriteLine("Digite o telefone");
      cliente.Telefone = Console.ReadLine();
      
      Console.WriteLine("Digite o email");
      cliente.Email = Console.ReadLine();

      clientes.Add(cliente);
    }

    internal static void Listar(List<Cliente> clientes)
    {
      if(clientes.Count == 0)
      {
        Console.Clear();
        Console.WriteLine("Não existe nenhum cliente na lista");
        Thread.Sleep(2000);
        Console.Clear();
        return;
      }

      foreach(var cliente in clientes)
      {
        Console.WriteLine("------------------------");
        Console.WriteLine("Nome: " + cliente.Nome);
        Console.WriteLine("Telefone: " + cliente.Telefone);
        Console.WriteLine("Email: " + cliente.Email);
        Console.WriteLine("------------------------");
      }
    }
  }
}