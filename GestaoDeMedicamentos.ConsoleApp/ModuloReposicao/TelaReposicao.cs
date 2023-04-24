using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor;
using GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario;
using GestaoDeMedicamentos.ConsoleApp.ModuloMedicamento;
using GestaoDeMedicamentos.ConsoleApp.ModuloPaciente;
using GestaoDeMedicamentos.ConsoleApp.ModuloRequisicao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloReposicao
{
    public class TelaReposicao : Tela
    {
        public RepositorioReposicao repositorioReposicao;
        public RepositorioFuncionario repositorioFuncionario;
        public RepositorioFornecedor repositorioFornecedor;
        public RepositorioMedicamento repositorioMedicamento;

        public void InserirNovaReposicao()
        {
            Reposicao novaReposicao = ObterReposicao();

            if (novaReposicao == null)
                return;

            repositorioReposicao.Cadastrar(novaReposicao);

            ApresentarMensagem("Medicamento criado com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarReposicao()
        {
            Console.Clear();
            Console.WriteLine("Histórico de aquisições:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Fornecedor       |Medicamento          |Funcionário   |Data      |Quantidade |");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.ResetColor();

            if (repositorioReposicao.listaRegistro.Count == 0)
            {
                ApresentarMensagem("Nenhuma aquisição registrada!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Reposicao reposicao in repositorioReposicao.listaRegistro)
            {
                Console.WriteLine("|{0,-3}|{1,-17}|{2,-21}|{3,-14}|{4,-10}|{5,-11}|", reposicao.id, reposicao.fornecedor.nome, reposicao.medicamento.nome, reposicao.funcionario.nome, reposicao.data, reposicao.qntdMedicamento);
            }

            Console.ReadKey();
        }

        private Reposicao ObterReposicao()
        {
            Reposicao reposicao = new Reposicao();

            if (repositorioFornecedor.listaRegistro.Count == 0)
            {
                reposicao = null;
                ApresentarMensagem("Nenhum fornecedor registrado!", ConsoleColor.DarkYellow);
            }
            else if (repositorioMedicamento.listaRegistro.Count == 0)
            {
                reposicao = null;
                ApresentarMensagem("Nenhum medicamento registrado!", ConsoleColor.DarkYellow);
            }
            else if (repositorioFuncionario.listaRegistro.Count == 0)
            {
                reposicao = null;
                ApresentarMensagem("Nenhum funcionario registrado!", ConsoleColor.DarkYellow);
            }
            else
            {
                
                Console.Write("Informe o id do fornecedor: ");
                int idFornecedor = int.Parse(Console.ReadLine());

                Console.Write("Informe o id do medicamento: ");
                int idMedicamento = int.Parse(Console.ReadLine());

                Console.Write("Informe o id do funcionário: ");
                int idFuncionario = int.Parse(Console.ReadLine());

                Console.Write("Informe a data da aquisição: ");
                int dataAquisicao = int.Parse(Console.ReadLine());

                Console.Write("Informe a quantidade de medicamento: ");
                int qntdMedicamento = int.Parse(Console.ReadLine());

                Fornecedor fornecedor = (Fornecedor)repositorioFornecedor.PegarPorId(idFornecedor);
                Medicamento medicamento = (Medicamento)repositorioMedicamento.PegarPorId(idMedicamento);
                Funcionario funcionario = (Funcionario)repositorioFuncionario.PegarPorId(idFuncionario);

                medicamento.SomarQntd(qntdMedicamento);
                medicamento.ValidarQuantidade();
            }
            
            return reposicao;
        }
    }
}
