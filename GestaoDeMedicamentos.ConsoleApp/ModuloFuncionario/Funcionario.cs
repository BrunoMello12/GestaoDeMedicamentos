using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class Funcionario : Entidade
    {
        public string nome;
        public int telefone;
        public int cpf;
        public string endereco;

        public Funcionario(string nome, int telefone, int cpf, string endereco)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.cpf = cpf;
            this.endereco = endereco;
        }

        public override void AtualizarInformacoes(Entidade RegistroAtualizado)
        {
            Funcionario funcionarioAtualizado = (Funcionario) RegistroAtualizado;

            nome = funcionarioAtualizado.nome;
            cpf = funcionarioAtualizado.cpf;
            telefone = funcionarioAtualizado.telefone;
            endereco = funcionarioAtualizado.endereco;
        }
    }
}
