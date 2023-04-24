using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class RepositorioPaciente : Repositorio
    {
        public void Editar(Paciente paciente, Paciente pacienteAtualizado)
        {
            paciente.nome = pacienteAtualizado.nome;
            paciente.cpf = pacienteAtualizado.cpf;
            paciente.telefone = pacienteAtualizado.telefone;
            paciente.endereco = pacienteAtualizado.endereco;
        }
    }
}
