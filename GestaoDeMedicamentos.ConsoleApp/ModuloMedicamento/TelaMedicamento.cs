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
        Medicamento medicamento;
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioFornecedor repositorioFornecedor;
        public TelaFornecedor telaFornecedor;

        public void CadastrarMedicamento()
        {
            Medicamento medicamento = ObterMedicamento();

            if (medicamento == null)
                return;

            repositorioMedicamento.Cadastrar(medicamento);

            ApresentarMensagem("Medicamento cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarMedicamentos()
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

        private Medicamento ObterMedicamento()
        {
            Medicamento medicamento = new Medicamento();
            Console.Clear();
            telaFornecedor.VisualizarFornecedor();

            if (repositorioFornecedor.listaRegistro.Count == 0)
                 medicamento = null;
            else
            {
                Console.WriteLine("Informe o nome do Medicamento: ");
                medicamento.nome = Console.ReadLine();
                Console.WriteLine("Informe a descrição: ");
                medicamento.descricao = Console.ReadLine();
                Console.WriteLine("Informe a quantidade: ");
                medicamento.qntdDisponivel = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe a quantidade limite: ");
                medicamento.qntdLimite = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe o id do fornecedor do medicamento: ");
                int idFornecedor = int.Parse(Console.ReadLine());

                medicamento.fornecedor = (Fornecedor)repositorioFornecedor.PegarPorId(idFornecedor);

                if (medicamento.fornecedor == null)
                {
                    medicamento = null;
                    ApresentarMensagem("Id inválido, tente novamente!", ConsoleColor.Red);
                }
                    
            }
            
            return medicamento;
        }
    }
}
