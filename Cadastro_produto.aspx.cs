using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P2_Programacao_Internet
{
    public partial class Cadastro_produto : System.Web.UI.Page
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
            txtDescricao.Text = string.Empty;
            dpTamanho.SelectedValue = "Selecionar...";
            dpGenero.SelectedValue = "Selecionar...";
            txtVlrUnit.Text = string.Empty;
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            double vlr_unit;

            /* Descrição */
            if (txtDescricao.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Descrição vazio!";
            }
            /* Tamanho */
            else if (dpTamanho.SelectedValue.ToString() == "Selecionar...")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Tamanho vazio!";
            }
            /* Gênero */
            else if (dpGenero.SelectedValue.ToString() == "Selecionar...")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Gênero vazio!";
            }
            /* Valor unitário */
            else if (txtVlrUnit.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Valor vazio!";
            }
            else if (!double.TryParse(txtVlrUnit.Text, out vlr_unit))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Valor inválido!";
            }
            else if (Convert.ToInt32(txtVlrUnit.Text) <= 0)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Valor inválido!";
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Produto cadastrado com sucesso!";

                using (LOJA_ROUPASEntities1 conexao = new LOJA_ROUPASEntities1())
                {
                    PRODUTOS cad_produtos = new PRODUTOS();

                    cad_produtos.DESCRICAO = txtDescricao.Text;
                    cad_produtos.TAMANHO = dpTamanho.SelectedValue.ToString();
                    cad_produtos.GENERO = dpGenero.SelectedValue.ToString();
                    cad_produtos.VALOR_UNITARIO = Convert.ToDouble(txtVlrUnit.Text);

                    conexao.PRODUTOS.Add(cad_produtos);
                    conexao.SaveChanges();
                    limpar_campos();

                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}