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
        Fornecedor fornecerdor;
        public RepositorioFornecedor repositorioFornecedor;

        public void CadastrarFornecedor()
        {
            Fornecedor fornecedor = ObterFornecedor();

            repositorioFornecedor.Cadastrar(fornecedor);

            ApresentarMensagem("Fornecedor cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarFornecedor()
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
                foreach(Fornecedor fornecedor in repositorioFornecedor.listaRegistro)
                {
                    Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20}", fornecedor.id, fornecedor.nome, fornecedor.telefone, fornecedor.cnpj);
                }
            }
        }

        public void EditarFuncionario()
        {
            VisualizarFornecedor();

            if (repositorioFornecedor.listaRegistro.Count == 0)
                return;

            Console.WriteLine("Informe o id do funcionario que deseja editar: ");
            int idSelecionado = int.Parse(Console.ReadLine());

            Fornecedor fornecedor = (Fornecedor)repositorioFornecedor.PegarPorId(idSelecionado);

            Fornecedor fornecedorAtualizado = ObterFornecedor();

            repositorioFornecedor.Editar(fornecedor, fornecedorAtualizado);

            ApresentarMensagem("Funcionario editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirFuncionario()
        {
            VisualizarFornecedor();

            if (repositorioFornecedor.listaRegistro.Count == 0)
                return;

            Console.WriteLine("Informe o id do funcionario que deseja excluir: ");
            int idSelecionado = int.Parse(Console.ReadLine());

            Funcionario funcionario = (Funcionario)repositorioFornecedor.PegarPorId(idSelecionado);

            repositorioFornecedor.Excluir(funcionario);

            ApresentarMensagem("Funcionario excluído com sucesso!", ConsoleColor.Green);
        }

        private Fornecedor ObterFornecedor()
        {
            Fornecedor fornecerdor = new Fornecedor();
            Console.Clear();
            Console.WriteLine("Informe o nome do Fornecedor: ");
            fornecerdor.nome = Console.ReadLine();
            Console.WriteLine("Informe o telefone do Fornecedor: ");
            fornecerdor.telefone = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o cnpj do Fornecedor: ");
            fornecerdor.cnpj = int.Parse(Console.ReadLine());

            return fornecerdor;
        }
    }
    
}
