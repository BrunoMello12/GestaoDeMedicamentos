using GestaoDeMedicamentos.ConsoleApp.Compartilhado;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : Tela
    {
        public RepositorioPaciente repositorioPaciente;

        public TelaPaciente(RepositorioPaciente repositorioPaciente) : base(repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        protected override Entidade ObterRegistro()
        {
            Console.Clear();
            Console.WriteLine("Informe o nome do paciente: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o cpf do paciente: ");
            int cpf = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o telefone do paciente: ");
            int telefone = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o endereco do paciente: ");
            string endereco = Console.ReadLine();

            Paciente paciente = new Paciente(nome,cpf,telefone,endereco);
            return paciente;
        }

        public override void VisualizarRegistros()
        {
            if (repositorioPaciente.listaRegistro.Count == 0)
            {
                ApresentarMensagem("Não tem pacientes cadastrados", ConsoleColor.DarkYellow);
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", "ID", "Nome", "CPF", "telefone", "endereço");

                foreach (Paciente paciente in repositorioPaciente.listaRegistro)
                {
                    Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", paciente.id, paciente.nome, paciente.cpf, paciente.telefone, paciente.endereco);
                }
                Console.WriteLine();
            }
        }
    }
}
