using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor;
using GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : Tela
    {
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioFornecedor repositorioFornecedor;
        public TelaFornecedor telaFornecedor;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor, TelaFornecedor telaFornecedor) : base(repositorioMedicamento)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
            this.telaFornecedor = telaFornecedor;
        }

        public void VisualizarRelatorioMedicamento()
        {
            Console.Clear();
            Console.WriteLine("Relatório de medicamentos:");
            Console.WriteLine();

            if (repositorioMedicamento.listaRegistro.Count == 0)
            {
                ApresentarMensagem("Nenhum medicamento registrado!", ConsoleColor.DarkRed);
                return;
            }
            Console.WriteLine("Medicamentos em falta: \n");
            foreach (Medicamento medicamento in repositorioMedicamento.listaRegistro)
            {
                if (medicamento.qntdDisponivel < 10)
                {
                    Console.WriteLine(medicamento.nome);
                }
            }
            Console.ReadKey();
        }

        protected override Entidade ObterRegistro()
        {
            Medicamento medicamento;

            Console.Clear();
            telaFornecedor.VisualizarRegistros();

            if (repositorioFornecedor.listaRegistro.Count == 0)
                medicamento = null;
            else
            {
                Console.WriteLine("Informe o nome do Medicamento: ");
                string nome = Console.ReadLine();
                Console.WriteLine("Informe a descrição: ");
                string descricao = Console.ReadLine();
                Console.WriteLine("Informe a quantidade Disponível: ");
                int quantidade = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe a quantidade limite: ");
                int qntdLimite = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe o id do fornecedor do medicamento: ");
                int idFornecedor = int.Parse(Console.ReadLine());

                Fornecedor fornecedorSelecionado = (Fornecedor)repositorioFornecedor.PegarPorId(idFornecedor);

                if (fornecedorSelecionado == null)
                {
                    medicamento = null;
                    ApresentarMensagem("Id inválido, tente novamente!", ConsoleColor.Red);
                }

                medicamento = new Medicamento(nome, descricao, quantidade, qntdLimite, fornecedorSelecionado);
            }

            
            return medicamento;

        }

        public override void VisualizarRegistros()
        {
            if (repositorioMedicamento.listaRegistro.Count == 0)
            {
                ApresentarMensagem("Não tem medicamentos cadastrados", ConsoleColor.DarkYellow);
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", "ID", "Nome", "Descrição", "Quantidade diponível", "Fornecedor");

                foreach (Medicamento medicamento in repositorioMedicamento.listaRegistro)
                {
                    Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", medicamento.id, medicamento.nome, medicamento.descricao, medicamento.qntdDisponivel, medicamento.fornecedor.nome);
                }
                Console.WriteLine();
            }
        }
    }
}
