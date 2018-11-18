using WeRep.Models;
using WeRep.Models.Models;
using Acesso;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WeRep.Negocios
{
    public class RepublicaBLL
    {
        public void CadastrarRepublica(string nome, int id_adm, string rua, string bairro, int numero, string complemento, int capacidade, bool admPresente)
        {
            try
            {
                new RepublicaDAL().CriarRepublica(nome, id_adm, rua, bairro, numero, complemento, capacidade);
                if (admPresente)
                    new RepublicaDAL().InserirMorador(id_adm, new RepublicaDAL().RetornarRepublica(id_adm, nome).First().id_rep);
                if (admPresente) { new UsuarioBLL().AlterarTipo(id_adm, 4); }
                else { new UsuarioBLL().AlterarTipo(id_adm, 3); }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InserirMorador(List<string> moradores, int id_rep)
        {
            try
            {
                foreach (string morador in moradores)
                {
                    if(new RepublicaDAL().ProcurarMorador(new UsuarioBLL().ListarDadosPerfil(morador).id_user.Value, id_rep).Count<=0)
                        throw new Exception("O usuário " + morador + " já mora nessa república.");
                }

                foreach (string morador in moradores)
                {
                    if (!(new UsuarioBLL().UsuarioExistente(morador)))
                        throw new Exception("O usuário " + morador + " não existe.");
                }

                foreach (string morador in moradores)
                {
                    new UsuarioBLL().AlterarTipo(new UsuarioBLL().ListarDadosPerfil(morador).id_user.Value, 2);
                    new RepublicaDAL().InserirMorador(new UsuarioDAL().RetornarUsuario(morador).First().id_user.Value, id_rep);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}