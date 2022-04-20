using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace P2_Programacao_Internet
{
    public partial class Cadastro_cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String nomeuserlogado = (String)Session["usuariologado"];
            if (nomeuserlogado == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }

        private void limpar_campos()
        {
            txtNome.Text = string.Empty;
            txtRua.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtCPF.Text = string.Empty;
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (LOJA_ROUPASEntities1 conexao = new LOJA_ROUPASEntities1())
            {
                double tel, cpf;
                int number = 0;
                string tel_max = txtTelefone.Text;
                string cpf_max = txtCPF.Text;

                /* Nome */
                if (txtNome.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Nome vazio!";
                }
                else if (!Regex.IsMatch(txtNome.Text, @"[^0-9]+$"))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Nome inválido!";
                }
                /* Rua */
                else if (txtRua.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Rua vazio!";
                }
                /* Bairro */
                else if (txtBairro.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Bairro vazio!";
                }
                /* Número casa */
                else if (txtNumero.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Número vazio!";
                }
                else if (!int.TryParse(txtNumero.Text, out number))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Número inválido!";
                }
                /* Telefone */
                else if (txtTelefone.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Telefone vazio!";
                }
                else if (!double.TryParse(txtTelefone.Text, out tel))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Telefone inválido!";
                }
                else if (tel_max.Length > 11)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Telefone inválido!";
                }
                else if (tel_max.Length < 11)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Telefone inválido!";
                }
                /* CPF */
                else if (txtCPF.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo CPF vazio!";
                }
                else if (!double.TryParse(txtCPF.Text, out cpf))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo CPF inválido!";
                }
                else if (cpf_max.Length > 11)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo CPF inválido!";
                }
                else if (cpf_max.Length < 11)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo CPF inválido!";
                }
                else
                {
                    string cpf1 = txtCPF.Text;
                    string tel1 = txtTelefone.Text;

                    CLIENTE clientecpf = conexao.CLIENTE.Where(linha => linha.CPF.Equals(cpf1)).FirstOrDefault();
                    CLIENTE clientetel = conexao.CLIENTE.Where(linha => linha.TELEFONE.Equals(tel1)).FirstOrDefault();

                    if (clientecpf != null)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "CPF já cadastrado!";
                    }
                    else if (clientetel != null)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Telefone já cadastrado!";
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "Usuário cadastrado com sucesso!";

                        CLIENTE cad_cliente = new CLIENTE();

                        cad_cliente.NOME = txtNome.Text;
                        cad_cliente.RUA = txtRua.Text;
                        cad_cliente.BAIRRO = txtBairro.Text;
                        cad_cliente.NUMERO = Convert.ToInt32(txtNumero.Text);
                        cad_cliente.TELEFONE = txtTelefone.Text;
                        cad_cliente.CPF = txtCPF.Text;

                        conexao.CLIENTE.Add(cad_cliente);
                        conexao.SaveChanges();
                        limpar_campos();
                    }
                }
            }
        }
    }
}