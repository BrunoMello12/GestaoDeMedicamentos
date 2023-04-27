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

        public Paciente(string nome, int cpf, int telefone, string endereco)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        public override void AtualizarInformacoes(Entidade RegistroAtualizado)
        {
            Paciente pacienteAtualizado = (Paciente)RegistroAtualizado;

            nome = pacienteAtualizado.nome;
            cpf = pacienteAtualizado.cpf;
            telefone = pacienteAtualizado.telefone;
            endereco = pacienteAtualizado.endereco;
        }
    }
}
