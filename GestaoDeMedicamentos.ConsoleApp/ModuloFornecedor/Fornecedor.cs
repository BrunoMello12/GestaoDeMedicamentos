using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class Fornecedor : Entidade
    {
        public string nome;
        public int telefone;
        public int cnpj;

        public Fornecedor(string nome, int telefone, int cnpj)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.cnpj = cnpj;
        }

        public override void AtualizarInformacoes(Entidade RegistroAtualizado)
        {
            Fornecedor fornecedorAtualizado = (Fornecedor)RegistroAtualizado;

            nome = fornecedorAtualizado.nome;
            telefone = fornecedorAtualizado.telefone;
            cnpj = fornecedorAtualizado.telefone;
        }
    }
}
