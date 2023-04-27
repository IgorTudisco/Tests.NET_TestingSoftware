using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        // Fact is an annotation of the Test
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            // pattern of Triple A or AAA

            // Arrange - Sceneries preparation of tests
            var veiculo = new Veiculo();
            //Act - The method that I want to test
            veiculo.Acelerar(10);
            // Assert - Results of my tests
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            // Arrange
            var veiculo = new Veiculo();
            // Act
            veiculo.Frear(10);
            // Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoTipo()
        {
            var veiculo = new Veiculo();
            veiculo.Tipo = TipoVeiculo.Automovel;
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact]
        public void TestaVeiculoPlaca()
        {
            var veiculo = new Veiculo();
            veiculo.Placa = "odb-1245";
            Assert.Equal("odb-1245", veiculo.Placa);
        }

        [Fact]
        public void TestaVeiculoPlacaTamanho()
        {
            var veiculo = new Veiculo();
            veiculo.Placa = "abc-1245";
            var tamanho = veiculo.Placa;
            bool testaTamanho = tamanho.Length != 8;
            Assert.False(testaTamanho);
        }

    }
}
