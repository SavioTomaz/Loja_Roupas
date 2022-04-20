<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro_vendas.aspx.cs" Inherits="P2_Programacao_Internet.Cadastro_vendas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro de vendas</title>
    <link rel="stylesheet" type="text/css" href="Styles/Folhaestilo.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="secondary-container">
		    <div class="logo2">
			    <img src="Images/Logotipo.png" alt="logotipo-secundario"/>
		    </div>
	    </div>
        <div class="tertiary-container">
		    <nav>
			    <ul class="menu">
			    	<li><a href="Inicial.aspx">Início</a></li>
			    	<li><a href="Cadastro_cliente.aspx">Cadastro de clientes</a></li>
			    	<li><a href="Cadastro_produto.aspx">Cadastro de produtos</a></li>
				    <li><a href="Cadastro_vendas.aspx">Cadastro de vendas</a></li>
				    <li><a href="Consulta_vendas.aspx">Consulta de vendas</a></li>
				    <li id="logout"><asp:LinkButton ID="lb_sair" runat="server" OnClick="lb_sair_Click">Sair</asp:LinkButton></li>
			    </ul>
		    </nav>
	    </div>
        <div class="cadastro">
            <div class="title">
                <asp:Label ID="lblCadastro" runat="server" Text="Cadastro de vendas"></asp:Label>
            </div>
            <br/>
                <asp:Label ID="lblError" runat="server"></asp:Label>
                <asp:Label ID="lblIDVen" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblIDProduto" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblQtdProduto" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblValorProduto" runat="server" Visible="false"></asp:Label>
            <br/>
            <div class="form_cadastro">
                <div class="campos">
                    <asp:Label ID="lblTituloCliente" runat="server" Text="Selecione um cliente:"></asp:Label>
                    <asp:DropDownList ID="dpCliente" runat="server"></asp:DropDownList>
                    <asp:Button ID="btnNovoRegistro" runat="server" Text="Criar novo registro" OnClick="btnNovoRegistro_Click" class="botao" />
                </div>
                <br/>
                <div class="campos">
                    <asp:Label ID="lblTituloProduto" runat="server" Text="Selecione um produto:"></asp:Label>
                    <asp:DropDownList ID="dpProduto" runat="server"></asp:DropDownList>
                    <asp:Label ID="lblTituloQuantidade" runat="server" Text="Quantidade:"></asp:Label>
                    <asp:TextBox ID="txtQuantidade" runat="server" Type="number" Width="60px"></asp:TextBox>
                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar produto" OnClick="Button1_Click" class="botao" />
                </div>
                <br/>
                <div class="campos">
                    <asp:GridView ID="gvProdutos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="ID_PRODUTOS" HeaderText="Item"/>
                            <asp:BoundField DataField="PRODUTOS.DESCRICAO" HeaderText="Descrição"/>
                            <asp:BoundField DataField="PRODUTOS.GENERO" HeaderText="Gênero"/>
                            <asp:BoundField DataField="PRODUTOS.TAMANHO" HeaderText="Tamanho" />
                            <asp:BoundField DataField="PRODUTOS.VALOR_UNITARIO" HeaderText="Valor unitário"/>
                            <asp:BoundField DataField="QUANTIDADE" HeaderText="Quantidade"/>
                            <asp:BoundField DataField="VALOR_TOTAL" HeaderText="Subtotal"/>
                            <asp:CommandField ShowSelectButton="True"/>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
                <br/>
                <asp:Button ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" Text="Excluir" class="botao" />
                <br/>
                <div class="campos">
                    <asp:Label ID="lblValorTotal" runat="server" Text="Valor total:"></asp:Label>
                    <asp:Label ID="lblValor" runat="server"></asp:Label>
                </div>
                <br/>
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar venda" OnClick="btnRegistrar_Click" class="botao" />
            </div>
        </div>
    </form>
</body>
</html>