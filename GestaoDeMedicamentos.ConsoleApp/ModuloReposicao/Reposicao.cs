using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor;
using GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario;
using GestaoDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloReposicao
{
    public class Reposicao : Entidade
    {
        public Fornecedor fornecedor;
        public Medicamento medicamento;
        public Funcionario funcionario;
        public int data;
        public int qntdMedicamento;

        public Reposicao(Fornecedor fornecedor, Medicamento medicamento, Funcionario funcionario, int data, int qntdMedicamento)
        {
            this.fornecedor = fornecedor;
            this.medicamento = medicamento;
            this.funcionario = funcionario;
            this.data = data;
            this.qntdMedicamento = qntdMedicamento;
        }

        public override void AtualizarInformacoes(Entidade RegistroAtualizado)
        {
            throw new NotImplementedException();
        }
    }
}
