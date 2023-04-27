using GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor;
using GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario;
using GestaoDeMedicamentos.ConsoleApp.ModuloMedicamento;
using GestaoDeMedicamentos.ConsoleApp.ModuloPaciente;
using GestaoDeMedicamentos.ConsoleApp.ModuloReposicao;
using GestaoDeMedicamentos.ConsoleApp.ModuloRequisicao;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp
{
    public class Menus
    {
        public TelaPaciente telaPaciente;
        public TelaFuncionario telaFuncionario;
        public TelaMedicamento telaMedicamento;
        public TelaFornecedor telaFornecedor;
        public TelaReposicao telaReposicao;
        public TelaRequisicao telaRequisicao;

        public void visualizarMenuPrincipal()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("**************************************************");
                Console.WriteLine("*************CONTROLE DE MEDICAMENTOS*************");
                Console.WriteLine("**************************************************");
                Console.WriteLine();
                Console.WriteLine("Digite 1 para gerenciar Pacientes");
                Console.WriteLine("Digite 2 para gerenciar Funcionarios");
                Console.WriteLine("Digite 3 para gerenciar Medicamentos");
                Console.WriteLine("Digite 4 para gerenciar Fornecedores");
                Console.WriteLine("Digite 5 para gerenciar Reposições");
                Console.WriteLine("Digite 6 para gerenciar Requisições");
                Console.WriteLine();
                Console.WriteLine("Digite S para sair");

                string opcaoMenuPrincipal = Console.ReadLine();

                if (opcaoMenuPrincipal.ToUpper() == "S")
                {
                    Console.WriteLine("Saindo...");
                    break;
                }

                switch (opcaoMenuPrincipal)
                {
                    case "1": visualizarMenuPaciente(); break;
                    case "2": visualizarMenuFuncionario(); break;
                    case "3": visualizarMenuMedicamentos(); break;
                    case "4": visualizarMenuFornecedores(); break;
                    case "5": visualizarMenuReposicao(); break;
                    case "6": visualizarMenuRequisicao(); break;
                }
            }
        }

        public void visualizarMenuPaciente()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para cadastrar Paciente");
            Console.WriteLine("Digite 2 para visualizar Pacientes");
            Console.WriteLine("Digite 3 para editar Paciente");
            Console.WriteLine("Digite 4 para excluir Paciente");
            Console.WriteLine();
            Console.WriteLine("Digite V para voltar");

            string opcaoMenuPaciente = Console.ReadLine();

            switch (opcaoMenuPaciente)
            {
                case "1": telaPaciente.CadastrarRegistro(); break;
                case "2": telaPaciente.VisualizarRegistros(); Console.ReadLine(); break;
                case "3": telaPaciente.Editar(); break;
                case "4": telaPaciente.Excluir(); break;
            }
        }

        public void visualizarMenuFuncionario()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para cadastrar Funcionario");
            Console.WriteLine("Digite 2 para visualizar Funcionarios");
            Console.WriteLine("Digite 3 para editar Funcionario");
            Console.WriteLine("Digite 4 para excluir Funcionario");
            Console.WriteLine();
            Console.WriteLine("Digite V para voltar");

            string opcaoMenuFuncionario = Console.ReadLine();

            switch (opcaoMenuFuncionario)
            {
                case "1": telaFuncionario.CadastrarRegistro(); break;
                case "2": telaFuncionario.VisualizarRegistros(); Console.ReadLine(); break;
                case "3": telaFuncionario.Editar(); break;
                case "4": telaFuncionario.Excluir(); break;
            }
        }

        public void visualizarMenuMedicamentos()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para Adicionar medicamento");
            Console.WriteLine("Digite 2 para Visualizar medicamentos");
            Console.WriteLine("Digite 3 para Visualizar relatorio de medicamentos");
            Console.WriteLine();
            Console.WriteLine("Digite V para voltar");

            string opcaoMenuMedicamentos = Console.ReadLine();

            switch (opcaoMenuMedicamentos)
            {
                case "1": telaMedicamento.CadastrarRegistro(); break;
                case "2": telaMedicamento.VisualizarRegistros(); Console.ReadLine(); break;
                case "3": telaMedicamento.VisualizarRelatorioMedicamento(); Console.ReadLine(); break;
            }
        }

        public void visualizarMenuFornecedores()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para cadastrar Fornecedor");
            Console.WriteLine("Digite 2 para visualizar Fornecedor");
            Console.WriteLine("Digite 3 para editar Fornecedor");
            Console.WriteLine("Digite 4 para excluir Fornecedor");
            Console.WriteLine();
            Console.WriteLine("Digite V para voltar");

            string opcaoMenuFornecedores = Console.ReadLine();

            switch (opcaoMenuFornecedores)
            {
                case "1": telaFornecedor.CadastrarRegistro(); break;
                case "2": telaFornecedor.VisualizarRegistros(); Console.ReadLine(); break;
                case "3": telaFornecedor.Editar(); break;
                case "4": telaFornecedor.Excluir(); break;
            }
        }

        public void visualizarMenuReposicao()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para fazer Reposição de medicamentos");
            Console.WriteLine("Digite 2 para visualizar Reposições feitas");
            Console.WriteLine();
            Console.WriteLine("Digite V para voltar");

            string opcaoMenuReposicao = Console.ReadLine();

            switch (opcaoMenuReposicao)
            {
                case "1": telaReposicao.CadastrarRegistro(); break;
                case "2": telaReposicao.VisualizarRegistros(); break;
            }
        }

        public void visualizarMenuRequisicao()
        {
            Console.Clear();
            Console.WriteLine("Digite 1 para fazer Requisição");
            Console.WriteLine("Digite 2 para visualizar Requisições");
            Console.WriteLine();
            Console.WriteLine("Digite V para voltar");

            string opcaoMenuRequisicao = Console.ReadLine();

            switch (opcaoMenuRequisicao)
            {
                case "1": telaRequisicao.CadastrarRegistro(); break;
                case "2": telaRequisicao.VisualizarRegistros(); break;
            }
        }
    }
}
