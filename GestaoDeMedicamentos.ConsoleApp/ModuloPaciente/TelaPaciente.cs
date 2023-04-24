using GestaoDeMedicamentos.ConsoleApp.Compartilhado;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : Tela
    {
        Paciente paciente;
        public RepositorioPaciente repositorioPaciente;

        public void CadastrarPaciente()
        {
            Paciente paciente = obterPaciente();

            repositorioPaciente.Cadastrar(paciente);

            ApresentarMensagem("Paciente cadastrado com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarPacientes()
        {
            if(repositorioPaciente.listaRegistro.Count == 0)
            {
                ApresentarMensagem("Não tem pacientes cadastrados", ConsoleColor.DarkYellow);
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", "ID", "Nome", "CPF", "telefone", "endereço");

                foreach(Paciente paciente in repositorioPaciente.listaRegistro)
                {
                    Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", paciente.id, paciente.nome, paciente.cpf, paciente.telefone, paciente.endereco);
                }
                Console.WriteLine();
            }
        }

        public void EditarPaciente()
        {
            VisualizarPacientes();

            if (repositorioPaciente.listaRegistro.Count == 0)
                return;

            Console.WriteLine("Informe o id do paciente que deseja editar: ");
            int idSelecionado = int.Parse(Console.ReadLine());

            Paciente paciente = (Paciente)repositorioPaciente.PegarPorId(idSelecionado);

            Paciente pacienteAtualizado = obterPaciente();

            repositorioPaciente.Editar(paciente, pacienteAtualizado);

            ApresentarMensagem("Paciente editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirPaciente()
        {
            VisualizarPacientes();

            if (repositorioPaciente.listaRegistro.Count == 0)
                return;

            Console.WriteLine("Informe o id do paciente que deseja excluir: ");
            int idSelecionado = int.Parse(Console.ReadLine());

            Paciente paciente = (Paciente)repositorioPaciente.PegarPorId(idSelecionado);

            repositorioPaciente.Excluir(paciente);

            ApresentarMensagem("Paciente excluído com sucesso!", ConsoleColor.Green);
        }

        private Paciente obterPaciente()
        {
            Console.Clear();
            Paciente paciente = new Paciente();
            Console.WriteLine("Informe o nome do paciente: ");
            paciente.nome = Console.ReadLine();
            Console.WriteLine("Informe o cpf do paciente: ");
            paciente.cpf = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o telefone do paciente: ");
            paciente.telefone = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o endereco do paciente: ");
            paciente.endereco = Console.ReadLine();

            return paciente;
        }

    }
}
