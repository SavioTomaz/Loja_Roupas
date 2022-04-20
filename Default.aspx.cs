using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P2_Programacao_Internet
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void limpar_campos()
        {
            txtUsuario.Text = string.Empty;
            txtSenha.Text = string.Empty;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            using (LOJA_ROUPASEntities1 conexao = new LOJA_ROUPASEntities1())
            {
                if (txtUsuario.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.White;
                    lblError.Text = "Usuário não informado!";
                }
                else if (txtSenha.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.White;
                    lblError.Text = "Senha não informada!";
                }
                else
                {
                    string usuario = txtUsuario.Text;
                    string senha = txtSenha.Text;

                    LOGIN usuarioconect = conexao.LOGIN.Where(linha => linha.USUARIO.Equals(usuario) && linha.SENHA.Equals(senha)).FirstOrDefault();

                    if (usuarioconect != null)
                    {
                        //Usuário encontrado no banco de dados
                        Session["usuariologado"] = usuarioconect.USUARIO;
                        Response.Redirect("Inicial.aspx");
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.White;
                        lblError.Text = "Usuário ou senha inválidos!";
                        limpar_campos();
                    }
                }
            }
        }
    }
}