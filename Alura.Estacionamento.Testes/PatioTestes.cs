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

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact(DisplayName = "Teste 1º")]
        [Trait("Funcinalidade", "Faturamento")]
        public void ValidaFaturamento()
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = "Igor",
                Tipo = TipoVeiculo.Automovel,
                Cor = "vermelho",
                Modelo = "Ferrari",
                Placa = "abc-1245"
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

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
        public void ValidaFaturamentoComVariosVeiculos(string nome, string placa, string cor, string modelo, object tipo)
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = nome,
                Tipo = (TipoVeiculo)tipo,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory (DisplayName = "Teste 3º")]
        [Trait("Funcinalidade", "Pátio")]
        [InlineData("igor", "ASD-1625", "Preto", "Veyron", TipoVeiculo.Automovel)]
        public void LocalizaVeiculoPatio(string nome, string placa, string cor, string modelo, object tipo)
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = nome,
                Tipo = (TipoVeiculo)tipo,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Theory (DisplayName = "Teste 4º")]
        [Trait ("Funcionalidade", "Alteração")]
        [InlineData("Amanda", "ASG-1525", "Azul", "Civic", TipoVeiculo.Automovel)]
        public void AlteraDadosVeiculo(string nome, string placa, string cor, string modelo, object tipo)
        {
            // Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            {
                Proprietario = nome,
                Tipo = (TipoVeiculo)tipo,
                Cor = cor,
                Modelo = modelo,
                Placa = placa
            };
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo
            {
                Proprietario = nome,
                Tipo = (TipoVeiculo)tipo,
                Cor = "Vermelho", // Changed data
                Modelo = modelo,
                Placa = placa
            };

            //Act
            var veiculoNovo = estacionamento.AlterarVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(veiculoNovo.Cor, veiculoAlterado.Cor);
        }
    }
}
