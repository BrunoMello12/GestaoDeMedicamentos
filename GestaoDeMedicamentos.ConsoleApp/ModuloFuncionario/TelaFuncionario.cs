using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario : Tela
    {
        Funcionario funcionario;
        public RepositorioFuncionario repositorioFuncionario;

        public void CadastrarFuncionario()
        {
            Funcionario funcionario = obterFuncionario();

            repositorioFuncionario.Cadastrar(funcionario);

            ApresentarMensagem("Funcionario cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarFuncionarios()
        {
            if (repositorioFuncionario.listaRegistro.Count == 0)
            {
                ApresentarMensagem("Não tem funcionario cadastrados", ConsoleColor.DarkYellow);
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", "ID", "Nome", "CPF", "telefone", "endereço");

                foreach (Funcionario funcionario in repositorioFuncionario.listaRegistro)
                {
                    Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", funcionario.id, funcionario.nome, funcionario.cpf, funcionario.telefone, funcionario.endereco);
                }
                Console.WriteLine();
            }
        }

        public void EditarFuncionario()
        {
            VisualizarFuncionarios();

            if (repositorioFuncionario.listaRegistro.Count == 0)
                return;

            Console.WriteLine("Informe o id do funcionario que deseja editar: ");
            int idSelecionado = int.Parse(Console.ReadLine());

            Funcionario funcionario = (Funcionario)repositorioFuncionario.PegarPorId(idSelecionado);

            Funcionario funcionarioAtualizado = obterFuncionario();

            repositorioFuncionario.Editar(funcionario, funcionarioAtualizado);

            ApresentarMensagem("Funcionario editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirFuncionario()
        {
            VisualizarFuncionarios();

            if (repositorioFuncionario.listaRegistro.Count == 0)
                return;

            Console.WriteLine("Informe o id do funcionario que deseja excluir: ");
            int idSelecionado = int.Parse(Console.ReadLine());

            Funcionario funcionario = (Funcionario)repositorioFuncionario.PegarPorId(idSelecionado);

            repositorioFuncionario.Excluir(funcionario);

            ApresentarMensagem("Funcionario excluído com sucesso!", ConsoleColor.Green);
        }

        private Funcionario obterFuncionario()
        {
            Console.Clear();
            Funcionario funcionario = new Funcionario();
            Console.WriteLine("Informe o nome do funcionario: ");
            funcionario.nome = Console.ReadLine();
            Console.WriteLine("Informe o cpf do funcionario: ");
            funcionario.cpf = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o telefone do funcionario: ");
            funcionario.telefone = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o endereco do funcionario: ");
            funcionario.endereco = Console.ReadLine();

            return funcionario;
        }
    }
}
