using GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.Compartilhado
{
    public abstract class Entidade
    {
        public int id = 1;
        public ArrayList listaRegistros = new ArrayList();

        public abstract void AtualizarInformacoes(Entidade RegistroAtualizado);

    }
}
