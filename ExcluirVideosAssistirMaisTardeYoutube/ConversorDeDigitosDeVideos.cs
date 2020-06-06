using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcluirVideosAssistirMaisTardeYoutube
{
    public static class ConversorDeDigitosDeVideos
    {
        public static int[] ObterDigitos(string textoInserido)
            => !string.IsNullOrWhiteSpace(textoInserido) ? 
                ObterDigitos(textoInserido.Replace(" ", string.Empty).Split(',')) : 
                new int[0];
        
        public static int[] ObterDigitos(string[] itensPorVirgula)
        {
            if (itensPorVirgula.Length == 0)
                return new int[0];

            var itensPorVirgulaAfirmacao = itensPorVirgula.Where(i => !i.StartsWith('*')).Select(p => p.Trim()).ToArray();
            var itensPorVirgulaNegacao = itensPorVirgula.Where(i => i.StartsWith('*')).Select(i => i.Remove(0, 1).Trim()).ToArray();

            var itensUnitarios = new List<int>();
            var itensEmIntervalo = new List<int>();

            for (var i = 0; i < itensPorVirgulaAfirmacao.Length; i++)
            {
                var range = itensPorVirgulaAfirmacao[i]
                    .Split('-')
                    .Select(p => int.Parse(p))
                    .ToArray();

                if (range.Length == 1)
                    itensUnitarios.Add(range.First());
                else
                    for (var j = range[0]; j <= range[1]; j++)
                        itensEmIntervalo.Add(j);
            }

            var itensNegacaoTodos = ObterDigitos(itensPorVirgulaNegacao);

            return itensUnitarios
                .Union(itensEmIntervalo)
                .Where(p => !itensNegacaoTodos.Contains(p))
                .OrderBy(p => p)
                .ToArray();
        }

    }
}
