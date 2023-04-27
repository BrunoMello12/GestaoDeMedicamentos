using GestaoDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.Compartilhado
{
    public class Repositorio
    {
        public int ContadorId = 1;
        public ArrayList listaRegistro = new ArrayList();

        public void Cadastrar(Entidade entidade)
        {
            listaRegistro.Add(entidade);
            entidade.id = ContadorId;
            ContarId();
        }

        public virtual void Editar(int idSelecionado, Entidade RegistroAtualizado)
        {
            Entidade entidade = PegarPorId(idSelecionado);

            entidade.AtualizarInformacoes(RegistroAtualizado);
        }

        public void ContarId()
        {
            ContadorId++;
        }

        public Entidade PegarPorId(int id)
        {
            Entidade entidade = null;

            foreach(Entidade e in listaRegistro)
            {
                if(e.id == id)
                {
                    entidade = e;
                    break;
                }
            }
            return entidade;
        }

        public void Excluir(Entidade entidade)
        {
            listaRegistro.Remove(entidade);
        }

        
    }
}
