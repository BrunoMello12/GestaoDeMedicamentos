using GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor;
using GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario;
using GestaoDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.Compartilhado
{
    public abstract class Tela
    {
        public string nome;
        public Repositorio repositorio;

        public Tela(Repositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public void ApresentarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        public abstract void VisualizarRegistros();

        public void Editar()
        {
            VisualizarRegistros();

            Console.WriteLine("Informe o id: ");
            int idSelecionado = int.Parse(Console.ReadLine());

            Entidade EntidadeAtualizada = (Entidade)ObterRegistro();

            repositorio.Editar(idSelecionado, EntidadeAtualizada);

            ApresentarMensagem("Registro editado com sucesso!", ConsoleColor.Green);
        }

        public void Excluir()
        {
            VisualizarRegistros();

            Console.WriteLine("Informe o id: ");
            int idSelecionado = int.Parse(Console.ReadLine());

            Entidade entidade = (Entidade)repositorio.PegarPorId(idSelecionado);

            repositorio.Excluir(entidade);

            ApresentarMensagem("Registro excluído com sucesso!", ConsoleColor.Green);
        }

        protected abstract Entidade ObterRegistro();

        public virtual void CadastrarRegistro()
        {
            Entidade registro = ObterRegistro();

            repositorio.Cadastrar(registro);

            ApresentarMensagem($"{nome} cadastrado com sucesso!", ConsoleColor.Green);
        }

    }
}
