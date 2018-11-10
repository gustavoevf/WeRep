using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeRep.Models;
using System.Web.Script.Serialization;
using System.IO;

namespace Acesso.Banco
{
    public class Mock
    {
        List<USUARIOS> lista_usuarios;
        List<REPUBLICAS> lista_republicas;
        List<MORADORES> lista_moradores;
        List<KANBAN> lista_kanban;
        List<CONTAS> lista_contas;
        List<ADMINISTRADORES> lista_administradores;

        public void InserirRepublica(RepublicaModel republica_dados)
        {
            REPUBLICAS parametro = new REPUBLICAS();
            parametro.bairro = republica_dados.bairro;
            parametro.complemento = republica_dados.complemento;
            parametro.id_adm = republica_dados.id_adm;
            parametro.id_rep = republica_dados.id_rep;
            parametro.numero = republica_dados.numero;
            parametro.numero_moradores = republica_dados.numero_moradores;
            parametro.rua = republica_dados.rua;
            parametro.vagas = republica_dados.vagas;
            lista_republicas.Add(parametro);
            string lista_serial = new JavaScriptSerializer().Serialize(lista_republicas);
        }

        void InserirUsuario(UsuarioModel usuario_dados)
        {
            USUARIOS parametro = new USUARIOS();
            parametro.id_user = usuario_dados.id_user;
            parametro.nome = usuario_dados.nome;
            parametro.senha = usuario_dados.senha;
            parametro.id_rep = usuario_dados.id_rep;
            lista_usuarios.Add(parametro);
        }

        public UsuarioModel RetornarUsuario(int idt)
        {
            string readText = File.ReadAllText("usuarios.txt");
            return new UsuarioModel();
        } 

        void InserirMoradores(MoradorModel morador_dados)
        {
            MORADORES parametro = new MORADORES();
            parametro.id_rep = morador_dados.id_rep;
            parametro.id_user = morador_dados.id_user;
            lista_moradores.Add(parametro);
        }

        void InserirKanban(KanbanModel kanban_dados)
        {
            KANBAN parametro = new KANBAN();
            parametro.cor = kanban_dados.cor;
            parametro.id_nota = kanban_dados.id_nota;
            parametro.id_rep = kanban_dados.id_rep;
            parametro.mensagem = kanban_dados.mensagem;
            parametro.vencimento = kanban_dados.vencimento;
            lista_kanban.Add(parametro);
        }

        void InserirConta(ContaModel conta_dados)
        {
            CONTAS parametro = new CONTAS();
            parametro.expedicao = conta_dados.expedicao;
            parametro.id_conta = conta_dados.id_conta;
            parametro.id_rep = conta_dados.id_rep;
            parametro.nome = conta_dados.nome;
            parametro.valor = conta_dados.valor;
            parametro.vencimento = conta_dados.vencimento;
            lista_contas.Add(parametro);
        }

        void InserirAdministrador(AdministradorModel administrador_dados)
        {
            ADMINISTRADORES parametro = new ADMINISTRADORES();
            parametro.id = administrador_dados.id;
            parametro.tipo = administrador_dados.tipo;
            lista_administradores.Add(parametro);
        }
    }
}