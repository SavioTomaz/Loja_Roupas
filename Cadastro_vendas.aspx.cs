using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P2_Programacao_Internet
{
    public partial class Cadastro_vendas : System.Web.UI.Page
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
                    carregarCliente(conexao);
                    carregarProduto(conexao);
                }
            }
        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }

        private void limpar_campos()
        {
            dpCliente.SelectedIndex = 0;
            dpProduto.SelectedIndex = 0;
            txtQuantidade.Text = string.Empty;
            lblValor.Text = string.Empty;
        }

        private void carregarCliente(LOJA_ROUPASEntities1 conexao)
        {
            List<CLIENTE> cliente = conexao.CLIENTE.OrderBy(linha => linha.NOME).ToList();
            dpCliente.DataSource = cliente;
            dpCliente.DataTextField = "NOME";
            dpCliente.DataValueField = "ID";
            dpCliente.DataBind();
            dpCliente.Items.Insert(0, "Selecionar...");
        }

        private void carregarProduto(LOJA_ROUPASEntities1 conexao)
        {
            List<PRODUTOS> produtos = conexao.PRODUTOS.OrderBy(linha => linha.DESCRICAO).ToList();
            dpProduto.DataSource = produtos;
            dpProduto.DataTextField = "DESCRICAO";
            dpProduto.DataValueField = "ID";
            dpProduto.DataBind();
            dpProduto.Items.Insert(0, "Selecionar...");
        }

        private void carregarGridProduto(LOJA_ROUPASEntities1 conexao)
        {
            List<REG_VENDAS> list_prod = conexao.REG_VENDAS.Where(linha => linha.ID_VENDAS.ToString().Equals(lblIDVen.Text)).ToList();
            gvProdutos.DataSource = list_prod;
            gvProdutos.DataBind();
        }

        protected void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            /* Cliente */
            if (dpCliente.SelectedValue.ToString() == "Selecionar...")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione o Cliente!";
            }
            else
            {
                using (LOJA_ROUPASEntities1 conexao = new LOJA_ROUPASEntities1())
                {
                    VENDAS cad_vendas = new VENDAS();
                    cad_vendas.ID_CLIENTE = Convert.ToInt32(dpCliente.SelectedValue.ToString());
                    cad_vendas.STATUS = Convert.ToString("Em andamento...");
                    DateTime dataatual = DateTime.Now;
                    cad_vendas.DATA = dataatual;

                    conexao.VENDAS.Add(cad_vendas);
                    conexao.SaveChanges();

                    lblIDVen.Text = cad_vendas.ID.ToString();
                }
                btnNovoRegistro.Enabled = false;
                dpCliente.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            /* Vendas */
            if (lblIDVen.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Registro de novo orçamento não realizado, aperte o botão 'Novo orçamento'";
            }
            /* Produto */
            else if (dpProduto.SelectedValue.ToString() == "Selecionar...")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um produto!";
            }
            /* Quantidade */
            else if (txtQuantidade.Text.ToString() == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Insira uma quantidade!";
            }
            else if (Convert.ToInt32(txtQuantidade.Text) <= 0)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Valor inválido!";
            }
            else
            {
                using (LOJA_ROUPASEntities1 conexao = new LOJA_ROUPASEntities1())
                {
                    int ID = Convert.ToInt32(dpProduto.SelectedValue.ToString());
                    {
                        PRODUTOS produtoselecionado = conexao.PRODUTOS.Where(linha1 => linha1.ID == ID).FirstOrDefault();

                        double quantidade, valor, subtotalpd;
                        quantidade = Convert.ToDouble(txtQuantidade.Text);
                        valor = Convert.ToDouble(produtoselecionado.VALOR_UNITARIO.ToString());
                        subtotalpd = (valor * quantidade);

                        if (produtoselecionado != null)
                        {
                            lblIDProduto.Text = produtoselecionado.ID.ToString();
                            lblQtdProduto.Text = txtQuantidade.Text.ToString();
                            lblValorProduto.Text = Convert.ToString(subtotalpd);
                        }

                        REG_VENDAS cad_vendas = new REG_VENDAS();
                        cad_vendas.ID_VENDAS = Convert.ToInt32(lblIDVen.Text);
                        cad_vendas.ID_PRODUTOS = Convert.ToInt32(lblIDProduto.Text);
                        cad_vendas.QUANTIDADE = Convert.ToInt32(lblQtdProduto.Text);
                        cad_vendas.VALOR_TOTAL = Convert.ToDouble(lblValorProduto.Text);

                        conexao.REG_VENDAS.Add(cad_vendas);
                        conexao.SaveChanges();

                        carregarGridProduto(conexao);

                        var items = conexao.REG_VENDAS.Where(linha => linha.ID_VENDAS.ToString().Equals(lblIDVen.Text)).ToList();
                        double totalpd = 0;
                        foreach (REG_VENDAS pd in items)
                        {
                            totalpd += pd.VALOR_TOTAL;
                        }

                        VENDAS ven = conexao.VENDAS.First(linha => linha.ID.ToString().Equals(lblIDVen.Text));
                        ven.VALOR_TOTAL = totalpd;
                        conexao.Entry(ven);
                        conexao.SaveChanges();
                        lblValor.Text = Convert.ToString(totalpd);
                        dpProduto.SelectedIndex = 0;
                        txtQuantidade.Text = string.Empty;
                    }
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (lblIDVen.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Registro de nova venda não realizada, aperte o botão 'Criar novo registro'";
            }
            else
            {
                lblError.Text = string.Empty;
                using (LOJA_ROUPASEntities1 conexao = new LOJA_ROUPASEntities1())
                {
                    VENDAS vendas = null;
                    if (lblError.Text.Equals(string.Empty))
                    {
                        int ID = Convert.ToInt32(lblIDVen.Text);
                        vendas = conexao.VENDAS.Where(linha => linha.ID.Equals(ID)).FirstOrDefault();
                    }

                    vendas.STATUS = Convert.ToString("Concluído");

                    if (lblError.Text.Equals(string.Empty))
                    {
                        conexao.Entry(vendas);
                    }

                    conexao.SaveChanges();
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Venda cadastrada com sucesso!";

                    /* Habilitar Botões */
                    btnNovoRegistro.Enabled = true;
                    dpCliente.Enabled = true;

                    /* Limpar campos */
                    limpar_campos();

                    /* Limpar grid's */
                    gvProdutos.DataSource = null;
                    gvProdutos.DataBind();
                }
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gvProdutos.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um produto!";
            }
            else if(gvProdutos.SelectedValue != null)
            {
                using (LOJA_ROUPASEntities1 conexao = new LOJA_ROUPASEntities1())
                {
                    string ID = gvProdutos.SelectedValue.ToString();
                    REG_VENDAS prod_ven = conexao.REG_VENDAS.Where(linha => linha.ID.ToString().Equals(ID)).FirstOrDefault();
                    conexao.REG_VENDAS.Remove(prod_ven);
                    conexao.SaveChanges();
                    carregarGridProduto(conexao);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Produto excluído com sucesso!";

                    var items = conexao.REG_VENDAS.Where(linha => linha.ID_VENDAS.ToString().Equals(lblIDVen.Text)).ToList();
                    double totalpd = 0;
                    foreach (REG_VENDAS pd in items)
                    {
                        totalpd += pd.VALOR_TOTAL;
                    }

                    lblValor.Text = Convert.ToString(totalpd);
                    gvProdutos.SelectedIndex = -1;

                    VENDAS ven = conexao.VENDAS.First(linha => linha.ID.ToString().Equals(lblIDVen.Text));
                    ven.VALOR_TOTAL = totalpd;
                    conexao.Entry(ven);
                    conexao.SaveChanges();
                }
            }
        }
    }
}