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
        public RepositorioFuncionario repositorioFuncionario;

        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario) : base(repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        protected override Entidade ObterRegistro()
        {
            Console.Clear();
            Console.WriteLine("Informe o nome do funcionario: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o cpf do funcionario: ");
            int cpf = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o telefone do funcionario: ");
            int telefone = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o endereco do funcionario: ");
            string endereco = Console.ReadLine();

            Funcionario funcionario = new Funcionario(nome,cpf,telefone,endereco);
            return funcionario;
        }

        public override void VisualizarRegistros()
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
    }
}
