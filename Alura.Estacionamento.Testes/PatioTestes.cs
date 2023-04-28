using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
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
        [Theory]
        [InlineData ("igor", "ASD-1625", "Preto", "Veyron", TipoVeiculo.Automovel)]
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
    }
}
