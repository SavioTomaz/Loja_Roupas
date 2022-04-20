<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro_produto.aspx.cs" Inherits="P2_Programacao_Internet.Cadastro_produto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro de produtos</title>
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
                <asp:Label ID="lblCadastro" runat="server" Text="Cadastro de produtos"></asp:Label>
            </div>
            <br/>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            <br/>
            <div class="form_cadastro">
                <div class="campos">
                    <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label>
                    <asp:TextBox ID="txtDescricao" runat="server" Width="500px"></asp:TextBox>
                </div>
                <br/>
                <div class="campos">
                    <asp:Label ID="lblTamanho" runat="server" Text="Tamanho:"></asp:Label>
                    <asp:DropDownList ID="dpTamanho" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="margin-bottom: 0px">
                        <asp:ListItem Selected="True">Selecionar...</asp:ListItem>
                        <asp:ListItem>P</asp:ListItem>
                        <asp:ListItem>M</asp:ListItem>
                        <asp:ListItem>G</asp:ListItem>
                        <asp:ListItem>GG</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br/>
                <div class="campos">
                    <asp:Label ID="lblGenero" runat="server" Text="Gênero:"></asp:Label>
                    <asp:DropDownList ID="dpGenero" runat="server">
                        <asp:ListItem Selected="True">Selecionar...</asp:ListItem>
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Feminino</asp:ListItem>
                        <asp:ListItem>Outros</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br/>
                <div class="campos">
                    <asp:Label ID="lblVlrUnit" runat="server" Text="Valor unitário:"></asp:Label>
                    <asp:TextBox ID="txtVlrUnit" runat="server" type="number" Width="250px"></asp:TextBox>
                </div>
                <br/>
                    <asp:Button ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click" Text="Cadastrar produto" class="botao"/>
            </div>
        </div>
    </form>
</body>
</html>
