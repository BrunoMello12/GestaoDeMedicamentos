using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class RepositorioFuncionario : Repositorio
    {
        public void Editar(Funcionario funcionario, Funcionario funcionarioAtualizado)
        {
            funcionario.nome = funcionarioAtualizado.nome;
            funcionario.cpf = funcionarioAtualizado.cpf;
            funcionario.telefone = funcionarioAtualizado.telefone;
            funcionario.endereco = funcionarioAtualizado.endereco;
        }
    }
}
