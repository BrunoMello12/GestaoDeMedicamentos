using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : Tela
    {
        public RepositorioFornecedor repositorioFornecedor;

        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor) : base(repositorioFornecedor)
        {
            this.repositorioFornecedor = repositorioFornecedor;
        }

        public override void VisualizarRegistros()
        {
            if (repositorioFornecedor.listaRegistro.Count == 0)
            {
                ApresentarMensagem("Nenhum fornecedor cadastrado", ConsoleColor.DarkYellow);
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20}", "ID", "Nome", "telefone", "cpnj");
                foreach (Fornecedor fornecedor in repositorioFornecedor.listaRegistro)
                {
                    Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20}", fornecedor.id, fornecedor.nome, fornecedor.telefone, fornecedor.cnpj);
                }
            }
        }

        protected override Entidade ObterRegistro()
        {
            
            Console.Clear();
            Console.WriteLine("Informe o nome do Fornecedor: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o telefone do Fornecedor: ");
            int telefone = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o cnpj do Fornecedor: ");
            int cnpj = int.Parse(Console.ReadLine());

            Fornecedor fornecedor = new Fornecedor(nome,telefone,cnpj);
            return fornecedor;
        }
    }
    
}
