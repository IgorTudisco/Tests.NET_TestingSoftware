using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        // Fact is an annotation of the Test
        [Fact (DisplayName = "Teste nº 1")]
        [Trait ("Funcionalidade", "Acelerar")]
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

        [Fact (DisplayName = "Teste nº 2")]
        [Trait ("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            // Arrange
            var veiculo = new Veiculo();
            // Act
            veiculo.Frear(10);
            // Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact (DisplayName = "Teste nº 3")]
        [Trait("Funcionalidade", "Tipo")]
        public void TestaVeiculoTipo()
        {
            var veiculo = new Veiculo
            {
                Tipo = TipoVeiculo.Automovel
            };
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact (DisplayName = "Teste nº 4")]
        [Trait("Funcionalidade", "Placa")]
        public void TestaVeiculoPlaca()
        {
            var veiculo = new Veiculo
            {
                Placa = "odb-1245"
            };
            Assert.Equal("odb-1245", veiculo.Placa);
        }

        [Fact (DisplayName = "Teste nº 5")]
        [Trait("Funcionalidade", "Placa")]
        public void TestaVeiculoPlacaTamanho()
        {
            var veiculo = new Veiculo
            {
                Placa = "abc-1245"
            };
            var tamanho = veiculo.Placa;
            bool testaTamanho = tamanho.Length != 8;
            Assert.False(testaTamanho);
        }

        [Fact (DisplayName = "Teste nº 6", Skip = "Teste ainda não implementado - Ignorar")]
        public void ValidaNomeProprietario()
        {

        }

        /*
         * Because of this Interface (IEnumerable<object[]>),
         * We can use the ClassData to test more objects without
         * polluting our test class
         */
        [Theory (DisplayName = "Teste nº 7")]
        [ClassData(typeof(Veiculo))]        
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

    }
}
