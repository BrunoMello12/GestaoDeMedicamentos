using GestaoDeMedicamentos.ConsoleApp;
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

        TelaPaciente telaPaciente = new TelaPaciente();
        TelaFuncionario telaFuncionario = new TelaFuncionario();
        TelaMedicamento telaMedicamento = new TelaMedicamento();
        TelaFornecedor telaFornecedor = new TelaFornecedor();
        TelaReposicao telaReposicao = new TelaReposicao();
        TelaRequisicao telaRequisicao = new TelaRequisicao();

        Menus menus = new Menus();
        menus.telaPaciente = telaPaciente;
        menus.telaFuncionario = telaFuncionario;
        menus.telaMedicamento = telaMedicamento;
        menus.telaFornecedor = telaFornecedor;
        menus.telaReposicao = telaReposicao;
        menus.telaRequisicao = telaRequisicao;


        telaPaciente.repositorioPaciente = repositorioPaciente;

        telaFuncionario.repositorioFuncionario = repositorioFuncionario;

        telaFornecedor.repositorioFornecedor = repositorioFornecedor;

        telaMedicamento.repositorioMedicamento = repositorioMedicamento;
        telaMedicamento.telaFornecedor = telaFornecedor;
        telaMedicamento.repositorioFornecedor = repositorioFornecedor;

        telaRequisicao.repositorioFuncionario = repositorioFuncionario;
        telaRequisicao.repositorioRequisicao = repositorioRequisicao;
        telaRequisicao.repositorioMedicamento = repositorioMedicamento;
        telaRequisicao.repositorioPaciente = repositorioPaciente;

        telaReposicao.repositorioFuncionario = repositorioFuncionario;
        telaReposicao.repositorioReposicao = repositorioReposicao;
        telaReposicao.repositorioMedicamento = repositorioMedicamento;
        telaReposicao.repositorioFornecedor = repositorioFornecedor;
        

        menus.visualizarMenuPrincipal();
    }
}