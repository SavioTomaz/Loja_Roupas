using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P2_Programacao_Internet
{
    public partial class Consulta_vendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String nomeuserlogado = (String)Session["usuariologado"];
            if (nomeuserlogado == null)
            {
                Response.Redirect("Default.aspx");
            }
            else if (!IsPostBack)
            {
                using (LOJA_ROUPASEntities1 conexao = new LOJA_ROUPASEntities1())
                {
                    carregarGrid(conexao);
                }
            }
        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }

        private void carregarGrid(LOJA_ROUPASEntities1 conexao)
        {
            List<VENDAS> vendas = conexao.VENDAS.Where(linha => linha.STATUS.Equals("Em andamento...") || linha.STATUS.Equals("Concluído")).ToList();
            gvRegistro.DataSource = vendas;
            gvRegistro.DataBind();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gvRegistro.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvRegistro.SelectedValue != null)
            {
                lblError.Text = string.Empty;
                int IDGV = Convert.ToInt32(gvRegistro.SelectedValue.ToString());
                using (LOJA_ROUPASEntities1 conexao = new LOJA_ROUPASEntities1())
                {
                    VENDAS gven = conexao.VENDAS.Where(linha => linha.ID == IDGV).FirstOrDefault();

                    if (gven != null)
                    {
                        lblID.Text = gven.ID.ToString();
                    }

                    VENDAS vendas = null;
                    if (lblError.Text.Equals(string.Empty))
                    {
                        int ID = Convert.ToInt32(lblID.Text);
                        vendas = conexao.VENDAS.Where(linha => linha.ID.Equals(ID)).FirstOrDefault();
                    }

                    vendas.STATUS = Convert.ToString("Excluído");

                    if (lblError.Text.Equals(string.Empty))
                    {
                        conexao.Entry(vendas);
                    }

                    conexao.SaveChanges();
                    carregarGrid(conexao);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Orçamento excluído com sucesso!";
                    gvRegistro.SelectedIndex = -1;
                }
            }
        }

        protected void btnExibir_Click(object sender, EventArgs e)
        {
            if (gvRegistro.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione uma venda!";
            }
            else if (gvRegistro.SelectedValue != null)
            {
                using (LOJA_ROUPASEntities1 conexao = new LOJA_ROUPASEntities1())
                {
                    int ID = Convert.ToInt32(gvRegistro.SelectedValue.ToString());
                    VENDAS ven = conexao.VENDAS.Where(linha => linha.ID == ID).FirstOrDefault();

                    Nome.Text = ven.CLIENTE.NOME.ToString();
                    Data.Text = ven.DATA.ToString();
                    Valor.Text = ven.VALOR_TOTAL.ToString();
                    lblID.Text = gvRegistro.SelectedValue.ToString();

                    int IDP = Convert.ToInt32(lblID.Text);
                    var prod = conexao.REG_VENDAS.Where(linha => linha.ID_VENDAS.Equals(IDP)).ToList();
                    string items_string = string.Empty;
                    string sub_pd = string.Empty;

                    foreach (REG_VENDAS po in prod)
                    {
                        items_string += po.PRODUTOS.DESCRICAO + "(Quantidade: " + po.QUANTIDADE + ")" + "\n";
                    }

                    REG_VENDAS reg_ven_null = null;
                    int IDPSUB = Convert.ToInt32(lblID.Text);
                    reg_ven_null = conexao.REG_VENDAS.Where(linha => linha.ID_VENDAS.Equals(IDP)).FirstOrDefault();
                    Valor2.Text = reg_ven_null.VALOR_TOTAL.ToString();

                    lblNomeCliente.Text = Nome.Text;
                    lblProdutos.Text = items_string + "\n";
                    lblValor.Text = Valor.Text;
                    lblData.Text = Data.Text;
                }
            }
        }
    }
}