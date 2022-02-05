using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using console_exemplo_itau.Models;
using Newtonsoft.Json;
using Nito.AsyncEx;

namespace console_exemplo_itau
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => validador());
        }

        static async void validador()
        {
            using (var client = new HttpClient())
            {
                var objLicenca = new Licenca { Chave = "4323ssddss232dssddssd" };
                var json = JsonConvert.SerializeObject(objLicenca);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = client.PostAsync("https://validacao-desktop.azurewebsites.net/validar", content).Result;
                string resultContent = await result.Content.ReadAsStringAsync();
                var respostaAPI = JsonConvert.DeserializeObject<RespostaAPI>(resultContent);

                if(respostaAPI.sucesso)
                {
                    carregarPrograma();
                }
                else
                {
                    Console.WriteLine("Sua licença expirou, contate o administrador do sistema");
                }                
            } 
        }

        static void carregarPrograma(){
            List<Cliente> clientes = new List<Cliente>();

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Digite uma das opções abaixo:");
                Console.WriteLine("1 - Cadastrar clientes");
                Console.WriteLine("2 - Listar clientes");
                Console.WriteLine("3 - Sair");

                var opcao = Convert.ToInt32(Console.ReadLine());
                if(opcao == 3)
                {
                    Console.Clear();
                    break;
                }
                else if (opcao == 1)
                    ServicoCliente.Cadastrar(clientes);
                else if (opcao == 2)
                    ServicoCliente.Listar(clientes);
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }
    }
}
