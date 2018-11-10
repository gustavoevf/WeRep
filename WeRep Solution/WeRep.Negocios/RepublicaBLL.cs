using WeRep.Models;
//corrigir referencias 

namespace WeRep.Negocios
{
    public class RepublicaBLL
    {
        void CadastrarRepublica(int id_adm, string rua, string bairro, int numero, string complemento, int vagas, bool adm_mora)
        {
            var NovaRepublica = new RepublicaModel();
            NovaRepublica.id_adm = id_adm;
            NovaRepublica.rua = rua;
            NovaRepublica.bairro = bairro;
            NovaRepublica.numero = numero;
            NovaRepublica.complemento = complemento;
            NovaRepublica.vagas = vagas;

            // InserirRepublica(NovaRepublica);

            if (adm_mora)
            {
              //  var UsuarioAdmin = MostrarUsuario(id_adm, true); //Implementar função no acesso 

                var MoradorAdmin = new MoradorModel();
              //  MoradorAdmin.id_rep = MostrarIdDaRepublica();
              //  MoradorAdmin.id_user = UsuarioAdmin.id_user;

              //  InserirMoradores(MoradorAdmin);
            }
                
        }
    }
}