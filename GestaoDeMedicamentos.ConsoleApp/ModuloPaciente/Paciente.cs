using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : Entidade
    {
        public string nome;
        public int cpf;
        public int telefone;
        public string endereco;
    }
}
