using ExcluirVideosAssistirMaisTardeYoutube.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcluirVideosAssistirMaisTardeYoutube
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite seu usuário: ");
            var usuário = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            var senha = ReadPassword();

            Console.WriteLine("Digite qual a conta que você deseja modificar: ");
            var conta = Console.ReadLine();

            Console.WriteLine("Digite os números das linhas que você deseja excluir:");
            Console.WriteLine("(Separe por vírgula e crie intervalos com hífen, ex: 1,2-5,6)");
            var digitos = ObterDigitos(Console.ReadLine().Replace(" ", string.Empty));
            
            var driverConfig = new WebDriverConfig();

            try
            {
                var loginPO = new LoginPO(driverConfig.Driver);
                loginPO.Acessar();
                loginPO.Logar(usuário, senha);

                new ContaPO(driverConfig.Driver).SelecionarConta(conta);

                var assistirMaisTardePO = new AssistirMaisTardePO(driverConfig.Driver);
                assistirMaisTardePO.Acessar();

                assistirMaisTardePO.CarregarTudo();
                assistirMaisTardePO.ExcluirVídeos(digitos);


                Console.WriteLine("Excluídos com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Um ou mais vídeos não puderam ser excluídos!");
                Console.WriteLine(ex);
            }
            finally
            {
                driverConfig.Dispose();
            }
            Console.ReadKey();
        }

        static int[] ObterDigitos(string textoInserido)
        {
            var itensPorVirgula = textoInserido.Split(',');

            var itensEmIntervalo = new List<int>();
            for (var i = 0; i < itensPorVirgula.Length; i++)
            {
                var range = itensPorVirgula[i]
                    .Split('-')
                    .Select(p => int.Parse(p))
                    .ToArray();

                if (range.Length == 1)
                    continue;

                for (var j = range[0]; j <= range[1]; j++)
                    itensEmIntervalo.Add(j);
            }

            return itensPorVirgula
                .Where(p => !p.Contains('-'))
                .Select(p => int.Parse(p))
                .Union(itensEmIntervalo)
                .OrderBy(p => p)
                .ToArray();
        }

        static string ReadPassword()
        {
            string pass = "";
            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    pass += key.KeyChar;
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                        pass = pass.Substring(0, (pass.Length - 1));
                    else if (key.Key == ConsoleKey.Enter)
                        return pass;
                }
            }
        }
    }
}
