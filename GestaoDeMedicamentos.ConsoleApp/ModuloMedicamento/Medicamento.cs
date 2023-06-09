﻿using GestaoDeMedicamentos.ConsoleApp.Compartilhado;
using GestaoDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : Entidade
    {
        public string nome;
        public string descricao;
        public int qntdDisponivel;
        public int qntdLimite;
        public Fornecedor fornecedor;

        public Medicamento(string nome, string descricao, int qntdDisponivel, int qntdLimite, Fornecedor fornecedor)
        {
            this.nome = nome;
            this.descricao = descricao;
            this.qntdDisponivel = qntdDisponivel;
            this.qntdLimite = qntdLimite;
            this.fornecedor = fornecedor;
        }

        public void ValidarQuantidade()
        {
            if (qntdDisponivel > qntdLimite)
            {
                qntdDisponivel = qntdLimite;
                Console.WriteLine("Essa quantidade excederá o limite de medicamentos. \n");
                Console.ReadLine();
            }
        }

        public void DiminuirQntd(int qntdMedicamento)
        {
            qntdDisponivel = qntdDisponivel - qntdMedicamento;
        }

        public void SomarQntd(int qntdMedicamento)
        {
            qntdDisponivel = qntdDisponivel + qntdMedicamento;
        }

        public override void AtualizarInformacoes(Entidade RegistroAtualizado)
        {
            throw new NotImplementedException();
        }
    }
}
