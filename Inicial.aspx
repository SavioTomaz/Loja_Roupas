<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicial.aspx.cs" Inherits="P2_Programacao_Internet.Inicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Tela Inicial</title>
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
    </form>
</body>
</html>
