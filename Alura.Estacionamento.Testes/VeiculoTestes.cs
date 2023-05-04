using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        private readonly Veiculo Veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            // Verify if all methods call the constructor
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Execução do construtor..\n");
            // Arrange 
            this.Veiculo = new Veiculo();
        }

        // Fact is an annotation of the Test
        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            // pattern of Triple A or AAA

            // Arrange - Sceneries preparation of tests (constructor)

            // Act - The method that I want to test
            Veiculo.Acelerar(10);
            // Assert - Results of my tests
            Assert.Equal(100, Veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {                       
            // Act
            Veiculo.Frear(10);
            // Assert
            Assert.Equal(-150, Veiculo.VelocidadeAtual);
        }

        [Fact (DisplayName = "Testa o tipo do veículo")]
        [Trait("Funcionalidade", "Atributo tipo")]
        public void TestaOTipoDoVeiculo()
        {
            var veiculo = new Veiculo
            {
                Tipo = TipoVeiculo.Automovel
            };
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact (DisplayName = "Testa a placa do Veículo")]
        [Trait("Funcionalidade", "Atributo placa")]
        public void TestaAPlacaDoVeiculo()
        {
            var veiculo = new Veiculo
            {
                Placa = "odb-1245"
            };
            Assert.Equal("odb-1245", veiculo.Placa);
        }

        [Fact (DisplayName = "Testa o tamanho da placa do veiculo")]
        [Trait("Método", "Verifica o tamanho da placa")]
        public void TestaOTamanhoDaPlacaDoVeiculo()
        {
            var veiculo = new Veiculo
            {
                Placa = "abc-1245"
            };
            var tamanho = veiculo.Placa;
            bool testaTamanho = tamanho.Length != 8;
            Assert.False(testaTamanho);
        }

        [Fact (Skip = "Teste ainda não implementado - Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        /*
         * Because of this Interface (IEnumerable<object[]>),
         * We can use the ClassData to test more objects without
         * polluting our test class
         */
        [Theory (DisplayName = "Testa os dados direto da classe ")]
        [Trait("ClassData", "Dados direto dá classe")]
        [ClassData(typeof(Veiculo))]        
        public void TestaODadoDoVeiculoPassandoElesDiretoDaClasse(Veiculo modelo)
        {
            // Act
            Veiculo.Acelerar(10);
            modelo.Acelerar(10);

            // Assert
            Assert.Equal(modelo.VelocidadeAtual, Veiculo.VelocidadeAtual);
        }

        [Theory]
        [InlineData("Amanda", "ASG-1525", "Azul", "Civic", TipoVeiculo.Automovel)]
        public void FichaDeInformacaoDoVeiculo(string nome, string placa, string cor, string modelo, object tipo)
        {

            // Arrange
            var veiculo = new Veiculo
            {
                Proprietario = nome,
                Tipo = (TipoVeiculo)tipo,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            // Act
            string dados = veiculo.ToString();

            // Assert
            Assert.Contains("Ficha do veículo:", dados);

        }

    }
}
