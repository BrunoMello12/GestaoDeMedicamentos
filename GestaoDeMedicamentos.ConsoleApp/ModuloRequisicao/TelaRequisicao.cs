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

        public void InserirNovaRequisicao()
        {
            Requisicao novaRequisicao = ObterRequisicao();

            if (novaRequisicao == null)
                return;

            repositorioRequisicao.Cadastrar(novaRequisicao);

            ApresentarMensagem("Medicamento criado com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarRequisicao()
        {
            Console.Clear();
            Console.WriteLine("Histórico de requisições:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("|ID |Paciente         |Medicamento          |Funcionário   |Data      |Quantidade |");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.ResetColor();

            if (repositorioRequisicao.listaRegistro.Count == 0)
            {
                ApresentarMensagem("Nenhuma requisição registrada!", ConsoleColor.DarkRed);
                return;
            }

            foreach (Requisicao reposicao in repositorioRequisicao.listaRegistro)
            {
                Console.WriteLine("|{0,-3}|{1,-17}|{2,-21}|{3,-14}|{4,-10}|{5,-11}|", reposicao.id, reposicao.paciente.nome, reposicao.medicamento.nome, reposicao.funcionario.nome, reposicao.data, reposicao.qntdMedicamento);
            }

            Console.ReadKey();
        }

        public Requisicao ObterRequisicao()
        {
            Requisicao requisicao = new Requisicao();

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
            }
            

            return requisicao;
        }
    }
}
