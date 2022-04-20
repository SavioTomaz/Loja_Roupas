<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro_cliente.aspx.cs" Inherits="P2_Programacao_Internet.Cadastro_cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cadastro de clientes</title>
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
                <asp:Label ID="lblCadastro" runat="server" Text="Cadastro de clientes"></asp:Label>
            </div>
            <br/>
            <asp:Label ID="lblError" runat="server"></asp:Label>
            <br/>
            <div class="form_cadastro">
                <div class="campos">
                    <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
                    <asp:TextBox ID="txtNome" runat="server" Width="500px"></asp:TextBox>
                </div>
                <br/>
                <div class="campos">
                    <asp:Label ID="lblRua" runat="server" Text="Rua:"></asp:Label>
                    <asp:TextBox ID="txtRua" runat="server" Width="300px"></asp:TextBox>
                </div>
                <br/>
                <div class="campos">
                    <asp:Label ID="lblBairro" runat="server" Text="Bairro:"></asp:Label>
                    <asp:TextBox ID="txtBairro" runat="server" Width="200px"></asp:TextBox>
                    <asp:Label ID="lblNumero" runat="server" Text="Número:"></asp:Label>
                    <asp:TextBox ID="txtNumero" runat="server" Width="100px"></asp:TextBox>
                </div>
                <br/>
                <div class="campos">
                    <asp:Label ID="lblTelefone" runat="server" Text="Telefone:"></asp:Label>
                    <asp:TextBox ID="txtTelefone" runat="server" Width="200px"></asp:TextBox>
                </div>
                <br/>
                <div class="campos">
                    <asp:Label ID="lblCPF" runat="server" Text="CPF:"></asp:Label>
                    <asp:TextBox ID="txtCPF" runat="server" Width="200px"></asp:TextBox>
                </div>
                <br/>
                <asp:Button ID="btnCadastrar" runat="server" OnClick="btnCadastrar_Click" Text="Cadastrar" class="botao" />
            </div>
        </div>
    </form>
</body>
</html>
