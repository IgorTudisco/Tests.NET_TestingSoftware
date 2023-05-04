using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    // The IDisposable helps us reuse code and clean your data after running the test methods.
    public class PatioTestes: IDisposable
    {
        private readonly Patio Estacionamento;
        private readonly Veiculo Veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            // Verify if all methods call the constructor
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Execução do construtor..\n");
            // Arrange 
            this.Veiculo = new Veiculo();
            this.Estacionamento = new Patio();
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            // Arrange
            Veiculo.Proprietario = "Igor";
            Veiculo.Tipo = TipoVeiculo.Automovel;
            Veiculo.Cor = "vermelho";
            Veiculo.Modelo = "Ferrari";
            Veiculo.Placa = "abc-1245";

            Estacionamento.RegistrarEntradaVeiculo(Veiculo);
            Estacionamento.RegistrarSaidaVeiculo(Veiculo.Placa);

            //Act
            double faturamento = Estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        // Theory is an annotation of the Test for many data tests
        [Theory(DisplayName = "Teste 2º")]
        [Trait("Funcinalidade", "Faturamento/Dados")]
        [InlineData("igor", "ASD-1625", "Preto", "Veyron", TipoVeiculo.Automovel)]
        [InlineData("Amanda", "ASG-1525", "Azul", "Civic", TipoVeiculo.Automovel)]
        [InlineData("Tainá", "DFD-1629", "Vermelho", "Corola", TipoVeiculo.Automovel)]
        [InlineData("Yuri", "ATR-8452", "Prata", "Ferrari", TipoVeiculo.Automovel)]
        [InlineData("Carol", "ATR-8992", "Prata", "S-10", TipoVeiculo.Automovel)]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string nome, string placa, string cor, string modelo, object tipo)
        {
            // Arrange
            Veiculo.Proprietario = nome;
            Veiculo.Tipo = (TipoVeiculo)tipo;
            Veiculo.Cor = cor;
            Veiculo.Modelo = modelo;
            Veiculo.Placa = placa;


            Estacionamento.RegistrarEntradaVeiculo(Veiculo);
            Estacionamento.RegistrarSaidaVeiculo(Veiculo.Placa);

            //Act
            double faturamento = Estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("igor", "ASD-1625", "Preto", "Veyron", TipoVeiculo.Automovel)]
        public void LocalizaVeiculoNoPatioComBaseNaPlaca(string nome, string placa, string cor, string modelo, object tipo)
        {
            // Arrange
            Veiculo.Proprietario = nome;
            Veiculo.Tipo = (TipoVeiculo)tipo;
            Veiculo.Cor = cor;
            Veiculo.Modelo = modelo;
            Veiculo.Placa = placa;
            Estacionamento.RegistrarEntradaVeiculo(Veiculo);

            //Act
            var consultado = Estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Theory]
        [InlineData("Amanda", "ASG-1525", "Azul", "Civic", TipoVeiculo.Automovel)]
        public void AlteraDadosDoProprioVeiculo(string nome, string placa, string cor, string modelo, object tipo)
        {
            // Arrange
            Veiculo.Proprietario = nome;
            Veiculo.Tipo = (TipoVeiculo)tipo;
            Veiculo.Cor = cor;
            Veiculo.Modelo = modelo;
            Veiculo.Placa = placa;
            Estacionamento.RegistrarEntradaVeiculo(Veiculo);

            var veiculoAlterado = new Veiculo
            {
                Proprietario = nome,
                Tipo = (TipoVeiculo)tipo,
                Cor = "Vermelho", // Changed data
                Modelo = modelo,
                Placa = placa
            };

            //Act
            var veiculoNovo = Estacionamento.AlterarVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(veiculoNovo.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.\n");
        }
    }
}
