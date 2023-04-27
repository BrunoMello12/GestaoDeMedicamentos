using GestaoDeMedicamentos.ConsoleApp;
using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor;
using GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario;
using GestaoDeMedicamentos.ConsoleApp.ModuloMedicamento;
using GestaoDeMedicamentos.ConsoleApp.ModuloPaciente;
using GestaoDeMedicamentos.ConsoleApp.ModuloReposicao;
using GestaoDeMedicamentos.ConsoleApp.ModuloRequisicao;

internal class Program
{
    public static void Main(string[] args)
    {
        RepositorioPaciente repositorioPaciente = new RepositorioPaciente();
        RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario();
        RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento();
        RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor();
        RepositorioReposicao repositorioReposicao = new RepositorioReposicao();
        RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao();
        

        TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);
        telaPaciente.nome = "Paciente";
        TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
        telaFuncionario.nome = "Funcionario";
        TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioFornecedor);
        telaFornecedor.nome = "Fornecedor";
        TelaMedicamento telaMedicamento = new TelaMedicamento(repositorioMedicamento, repositorioFornecedor, telaFornecedor);
        telaMedicamento.nome = "Medicamento";
        TelaReposicao telaReposicao = new TelaReposicao(repositorioReposicao,repositorioReposicao, repositorioMedicamento, repositorioFornecedor, repositorioFuncionario);
        telaReposicao.nome = "Reposicao";
        TelaRequisicao telaRequisicao = new TelaRequisicao(repositorioRequisicao, repositorioMedicamento, repositorioFornecedor, repositorioPaciente);
        telaRequisicao.nome = "Requisicao";

        Menus menus = new Menus();
        menus.telaPaciente = telaPaciente;
        menus.telaFuncionario = telaFuncionario;
        menus.telaMedicamento = telaMedicamento;
        menus.telaFornecedor = telaFornecedor;
        menus.telaReposicao = telaReposicao;
        menus.telaRequisicao = telaRequisicao;
        

        menus.visualizarMenuPrincipal();
    }
}