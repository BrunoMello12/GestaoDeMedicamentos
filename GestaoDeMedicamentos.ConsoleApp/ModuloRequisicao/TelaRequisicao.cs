using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor;
using GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario;
using GestaoDeMedicamentos.ConsoleApp.ModuloMedicamento;
using GestaoDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaRequisicao : Tela
    {
        public RepositorioFuncionario repositorioFuncionario;
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioRequisicao repositorioRequisicao;
        public RepositorioPaciente repositorioPaciente;
        private RepositorioFornecedor repositorioFornecedor;

        public TelaRequisicao(Repositorio repositorio, RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor, RepositorioPaciente repositorioPaciente) : base(repositorio)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioPaciente = repositorioPaciente;
        }

        public override void VisualizarRegistros()
        {
            Console.Clear();
            Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20}", "ID", "Paciente", "Medicamento", "Funcionário", "Data", "Quantidade de Medicamento");

            if (repositorioRequisicao.listaRegistro.Count == 0)
            {
                ApresentarMensagem("Nenhuma requisição registrada!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Requisicao requisicao in repositorioRequisicao.listaRegistro)
            {
                Console.WriteLine("{0,-3} | {1,-17} | {2,-21} | {3,-14} | {4,-10} | {5,-11}", requisicao.id, requisicao.paciente.nome, requisicao.medicamento.nome, requisicao.funcionario.nome, requisicao.data, requisicao.qntdMedicamento);
            }
        }

        protected override Entidade ObterRegistro()
        {
            Requisicao requisicao;


            if (repositorioPaciente.listaRegistro.Count == 0)
            {
                requisicao = null;
                ApresentarMensagem("Nenhum paciente registrado!", ConsoleColor.DarkYellow);
            }
            else if (repositorioMedicamento.listaRegistro.Count == 0)
            {
                requisicao = null;
                ApresentarMensagem("Nenhum medicamento registrado!", ConsoleColor.DarkYellow);
            }
            else if (repositorioFuncionario.listaRegistro.Count == 0)
            {
                requisicao = null;
                ApresentarMensagem("Nenhum funcionario registrado!", ConsoleColor.DarkYellow);
            }
            else
            {
                Console.Write("Informe o id do paciente: ");
                int idPaciente = int.Parse(Console.ReadLine());

                Console.Write("Informe o id do medicamento: ");
                int idMedicamento = int.Parse(Console.ReadLine());

                Console.Write("Informe o id do funcionário: ");
                int idFuncionario = int.Parse(Console.ReadLine());

                Console.Write("Informe a data da requisição: ");
                int dataRequisicao = int.Parse(Console.ReadLine());

                Console.Write("Informe a quantidade de medicamento: ");
                int qntdMedicamento = int.Parse(Console.ReadLine());

                Paciente paciente = (Paciente)repositorioPaciente.PegarPorId(idPaciente);
                Medicamento medicamento = (Medicamento)repositorioMedicamento.PegarPorId(idMedicamento);
                Funcionario funcionario = (Funcionario)repositorioFuncionario.PegarPorId(idFuncionario);

                medicamento.DiminuirQntd(qntdMedicamento);

                requisicao = new Requisicao(paciente, medicamento, funcionario, dataRequisicao, qntdMedicamento);
            }

            return requisicao;
        }
    }
}
