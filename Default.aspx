<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="P2_Programacao_Internet.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="Styles/Folhaestilo.css"/>
</head>
<body>
    <form id="form_login" runat="server">
        <div class="login">
            <div class="campos_login">
                <div class="image">
                    <img src="Images/Logotipo.png" alt="logotipo-secundario"/>
                </div>
                <asp:Label ID="lblError" runat="server"></asp:Label>
                <br/>
                <asp:Label ID="lblUsuario" runat="server" Text="Usuário:"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                <br/>
                <br/>
                <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label>
                <asp:TextBox ID="txtSenha" runat="server" Type="password"></asp:TextBox>
                <br/>
                <br/>
                <br/>
                <asp:Button ID="btnEntrar" runat="server" OnClick="btnEntrar_Click" Text="Entrar" class="botao_login" />
            </div>
        </div>
    </form>
</body>
</html>
