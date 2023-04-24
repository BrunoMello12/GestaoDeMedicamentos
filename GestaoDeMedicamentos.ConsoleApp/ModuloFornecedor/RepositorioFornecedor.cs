using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class RepositorioFornecedor : Repositorio
    {
        public void Editar(Fornecedor fornecedor, Fornecedor fornecedorAtualizado)
        {
            fornecedor.nome = fornecedorAtualizado.nome;
            fornecedor.telefone = fornecedorAtualizado.telefone;
            fornecedor.cnpj = fornecedorAtualizado.telefone;
        }
    }
}
