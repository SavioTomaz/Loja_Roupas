<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta_vendas.aspx.cs" Inherits="P2_Programacao_Internet.Consulta_vendas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Consulta de vendas</title>
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
                <asp:Label ID="lblRegistro" runat="server" Text="Registro de vendas"></asp:Label>
            </div>
            <br/>
                <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblError" runat="server"></asp:Label>
                <asp:Label ID="Nome" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="Data" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="Valor" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="Valor2" runat="server" Visible="false"></asp:Label>
            <br/>
            <div class="form_cadastro">
                <div class="campos">
                    <asp:GridView ID="gvRegistro" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" GridLines="None" Width="621px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Venda"/>
                            <asp:BoundField DataField="CLIENTE.NOME" HeaderText="Nome do cliente"/>
                            <asp:BoundField DataField="DATA" HeaderText="Data"/>
                            <asp:BoundField DataField="VALOR_TOTAL" HeaderText="Valor Total"/>
                            <asp:CommandField ShowSelectButton="True"/>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
                <br/>
                <div class="campos_botao">
                    <asp:Button ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" Text="Excluir" class="botao" />
                    <asp:Button ID="btnExibir" runat="server" Text="Exibir informações" OnClick="btnExibir_Click" class="botao" />
                </div>
                <br/>
                <div class="registro">
                    <div class="campos_registro">
                        <asp:Label ID="Label1" runat="server" Text="Nome do cliente:"></asp:Label>
                        <asp:Label ID="lblNomeCliente" runat="server"></asp:Label>
                    </div>
                    <br/>
                    <div class="campos_registro">
                        <asp:Label ID="Label2" runat="server" Text="Produtos:"></asp:Label>
                        <asp:Label ID="lblProdutos" runat="server"></asp:Label>
                    </div>
                    <br/>
                    <div class="campos_registro">
                        <asp:Label ID="Label4" runat="server" Text="Valor:"></asp:Label>
                        <asp:Label ID="lblValor" runat="server"></asp:Label>
                    </div>
                    <br/>
                    <div class="campos_registro">
                        <asp:Label ID="Label3" runat="server" Text="Data:"></asp:Label>
                        <asp:Label ID="lblData" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
