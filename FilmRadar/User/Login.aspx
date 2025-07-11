<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FilmRadar.User.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Assest/LoginCss.css" rel="stylesheet" />
    <title>Film-Radar Giriş Yap</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3>Giriş Yap</h3>
            <div class="loginbox">
                <asp:Panel ID="pnl_loginMessage" runat="server" Visible="false" CssClass="LoginPanel">
                    <asp:Label ID="lbl_message" runat="server"></asp:Label>
                </asp:Panel>
                <div style="display: flex; justify-content: center;">
                    <asp:TextBox ID="tb_username" runat="server" placeholder="Kullanıcı Adı" CssClass="textbox"></asp:TextBox>
                </div>
                <div style="display: flex; justify-content: center;">
                    <asp:TextBox ID="tb_password" runat="server" placeholder="Şifre" TextMode="Password" CssClass="textbox"></asp:TextBox>
                </div>
                <div style="margin-top: 15px">
                    <asp:LinkButton ID="lbtn_login" runat="server" Text="Giriş Yap" CssClass="LoginButton" OnClick="lbtn_login_Click"></asp:LinkButton>
                </div>
                <div style="margin-top: 15px">
                    <asp:LinkButton ID="lbtn_signup" runat="server" Text="Kayıt Ol" CssClass="LoginButton" OnClick="lbtn_signup_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
