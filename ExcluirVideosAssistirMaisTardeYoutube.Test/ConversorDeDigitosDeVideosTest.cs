using System;
using Xunit;
using ExcluirVideosAssistirMaisTardeYoutube;

namespace ExcluirVideosAssistirMaisTardeYoutube.Test
{
    public class ConversorDeDigitosDeVideosTest
    {
        [Theory]
        [InlineData("1,2,3,5,7,10", new [] { 1, 2, 3, 5, 7, 10 })]
        [InlineData("1-5", new [] { 1, 2, 3, 4, 5 })]
        [InlineData("1-5, 6, 8, 10-13", new [] { 1, 2, 3, 4, 5, 6, 8, 10, 11, 12, 13 })]
        [InlineData("1, 2, 4-6, 8", new [] { 1, 2, 4, 5, 6, 8 })]
        [InlineData("1,2,3,5,7,10, *5, *2", new[] { 1, 3, 7, 10 })]
        [InlineData("1-5, *3, *4", new[] { 1, 2, 5 })]
        [InlineData("1-5, *2, 6, 8, *8, 10-13, *10", new[] { 1, 3, 4, 5, 6, 11, 12, 13 })]
        [InlineData("1, 2, *1, 4-6, 8, *5", new[] { 2, 4, 6, 8 })]
        public void ObterDigitos_QuandoRecebeUmaStringCorreta_RetornaOsDigitosCorretamente(string textoEntrada, int[] retornoEsperado)
            => ObterDigitos_ValidaSeEntradaERetornoSaoIguais(textoEntrada, retornoEsperado);

        [Theory]
        [InlineData("", new int[0])]
        [InlineData("1, *1", new int[0])]
        [InlineData("*1", new int[0])]
        public void ObterDigitos_EntradasAtipicas_str(string textoEntrada, int[] retornoEsperado)
            => ObterDigitos_ValidaSeEntradaERetornoSaoIguais(textoEntrada, retornoEsperado);
        
        [Theory]
        [InlineData(new[] { " 1 " }, new[] { 1 })]
        public void ObterDigitos_EntradasAtipicas_array(string[] arrayEntrada, int[] retornoEsperado)
            => ObterDigitos_ValidaSeEntradaERetornoSaoIguais(arrayEntrada, retornoEsperado);

        private void ObterDigitos_ValidaSeEntradaERetornoSaoIguais(string textoEntrada, int[] retornoEsperado)
        {
            // Act
            var retornoObtido = ConversorDeDigitosDeVideos.ObterDigitos(textoEntrada);

            // Assert
            Assert.Equal(retornoEsperado, retornoObtido);
        }

        private void ObterDigitos_ValidaSeEntradaERetornoSaoIguais(string[] arrayEntrada, int[] retornoEsperado)
        {
            // Act
            var retornoObtido = ConversorDeDigitosDeVideos.ObterDigitos(arrayEntrada);

            // Assert
            Assert.Equal(retornoEsperado, retornoObtido);
        }
    }
}
