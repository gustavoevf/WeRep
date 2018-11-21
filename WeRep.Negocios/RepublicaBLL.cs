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
        public void CadastrarRepublica(RepublicaModel nova_rep)
        {
            if (nova_rep.complemento == null)
                nova_rep.complemento = "";
            nova_rep.moradores = new List<int>();
            try
            {
                new RepublicaDAL().CriarRepublica(nova_rep);
                new UsuarioBLL().AlterarTipo(nova_rep.id_adm, Recursos.tipoUsuario.Administrador.GetHashCode());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InserirMorador(string morador, int id_rep)
        {
            try
            {
                if (!(new UsuarioBLL().UsuarioExistente(morador)))
                    throw new Exception("O usuário " + morador + " não existe.");

                if (new RepublicaDAL().ProcurarMorador(new UsuarioBLL().ListarDadosPerfil(morador).id_user.Value, id_rep).Count > 0)
                    throw new Exception("O usuário " + morador + " já mora nessa república.");

                if (new UsuarioBLL().ListarDadosPerfil(morador).id_rep!=null)
                    throw new Exception("O usuário " + morador + " já mora em outra república.");

                new UsuarioBLL().AlterarTipo(
                    new UsuarioBLL().ListarDadosPerfil(morador).id_user.Value,
                    new UsuarioBLL().ListarDadosPerfil(morador).tipo == Recursos.tipoUsuario.Administrador.GetHashCode() ? Recursos.tipoUsuario.Administrador.GetHashCode() : Recursos.tipoUsuario.Morador.GetHashCode()
                    );

                new RepublicaDAL().InserirMorador(new UsuarioDAL().RetornarUsuario(morador).First().id_user.Value, id_rep);
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