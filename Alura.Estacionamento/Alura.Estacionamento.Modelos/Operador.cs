using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Alura.Estacionamento.Modelos
{
    public class Operador
    {

        private string _matricula;
        private string _nome;

        public string Matricula { get => _matricula; set => _matricula = value; }
        public string Nome { get => _nome; set => _nome = value; }

        public Operador()
        {
            Matricula = new Guid().ToString()[..8];
        }

        public override string ToString()
        {
            return $"Operador: {this.Nome} \n" +
                    $"Matricula: {this.Matricula} ";
        }
    }
}
