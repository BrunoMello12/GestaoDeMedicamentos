using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloFuncionario;
using GestaoDeMedicamentos.ConsoleApp.ModuloMedicamento;
using GestaoDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao : Entidade 
    {
        public Paciente paciente;
        public Medicamento medicamento;
        public Funcionario funcionario;
        public int data;
        public int qntdMedicamento;
    }
}
