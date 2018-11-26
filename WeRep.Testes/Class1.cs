using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using WeRep.Models;
using WeRep.Negocios;
using WeRep.Testes;


namespace WeRep.Testes
{
    [TestClass]
    class Testes
    {
        [TestInitialize]
        public void TestInitialize()
        {
            var rep_bll = new RepublicaBLL();
            var usr_bll = new UsuarioBLL();
            var kan_bll = new KanbanBLL();
        }

        [TestMethod]
        public void CriarUsuário()
        {
            var Usuario = new UsuarioModel();
            Usuario.id_user = 1000;
            Usuario.nome = "aaaaaa";
            Usuario.senha = "aaaaaa";

            Usuario.tipo = 1;
            
        }

        [TestMethod]
        public void CriarRepublica()
        {
            var Republica = new RepublicaModel();
            Republica.id_adm = 10000;
            Republica.id_rep = 10000;
            Republica.capacidade = 100;
        }
    }
}
