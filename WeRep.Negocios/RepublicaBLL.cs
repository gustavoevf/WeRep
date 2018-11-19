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
        public void CadastrarRepublica(RepublicaModel nova_rep, bool admPresente)
        {
            try
            {
                new RepublicaDAL().CriarRepublica(nova_rep);
                if (admPresente)
                    new RepublicaDAL().InserirMorador(nova_rep.id_adm, new RepublicaDAL().RetornarRepublica(nova_rep.id_adm, nova_rep.nome).First().id_rep);
                if (admPresente) { new UsuarioBLL().AlterarTipo(nova_rep.id_adm, Recursos.tipoUsuario.AdministradorPresente.GetHashCode()); }
                else { new UsuarioBLL().AlterarTipo(nova_rep.id_adm, Recursos.tipoUsuario.Administrador.GetHashCode()); }
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

        public RepublicaModel RetornarRepublica(int id_rep)
        {
            return new RepublicaDAL().RetornarRepublica(id_rep).FirstOrDefault();
        }

        public List<RepublicaModel> GetRepublicasAdm(int id_adm)
        {
            return new RepublicaDAL().GetRepublicaAdm(id_adm);
        }
    }
}