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

        public TelaReposicao(RepositorioReposicao repositorioReposicao,Repositorio repositorio, RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor, RepositorioFuncionario repositorioFuncionario) : base(repositorio)
        {
            this.repositorioReposicao = repositorioReposicao;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioMedicamento = repositorioMedicamento;
        }

        public override void VisualizarRegistros()
        {
            Console.Clear();
            Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20}", "ID", "Fornecedor", "Medicamento", "Funcionário", "Data", "Quantidade de Medicamento");

            if (repositorioReposicao.listaRegistro.Count == 0)
            {
                ApresentarMensagem("Nenhuma aquisição registrada!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Reposicao reposicao in repositorioReposicao.listaRegistro)
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20}", reposicao.id, reposicao.fornecedor.nome, reposicao.medicamento.nome, reposicao.funcionario.nome, reposicao.data, reposicao.qntdMedicamento);
            }
        }

        protected override Entidade ObterRegistro()
        {
            Reposicao reposicao;

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

                reposicao = new Reposicao(fornecedor, medicamento, funcionario, dataAquisicao, qntdMedicamento);
            }

            return reposicao;
        }
    }
}
