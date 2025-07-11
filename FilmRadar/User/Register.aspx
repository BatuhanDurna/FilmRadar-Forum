<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FilmRadar.User.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Film-Radar Kayıt Ol</title>
    <link href="Assest/RegisterCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3>Kayıt Ol</h3>
            <div class="loginbox">
                <asp:Panel ID="pnl_verifyRegister" runat="server" Visible="false" CssClass="Verify">
                    Başarıyla Kayıt Oldunuz Lütfen Girişe Dön Butonuna Tıklayınız
                </asp:Panel>
                <asp:Panel ID="pnl_registerMessage" runat="server" Visible="false" CssClass="RegisterMessage">
                    <asp:Label ID="lbl_message" runat="server"></asp:Label>
                </asp:Panel>
                <div style="display: flex; justify-content: center;">
                    <asp:TextBox ID="tb_name" runat="server" placeholder="İsim" CssClass="textbox"></asp:TextBox>
                </div>
                <div style="display: flex; justify-content: center;">
                    <asp:TextBox ID="tb_surname" runat="server" placeholder="Soyisim" CssClass="textbox"></asp:TextBox>
                </div>
                <div style="display: flex; justify-content: center;">
                    <asp:TextBox ID="tb_Favoritefilm" runat="server" placeholder="Favori Film" CssClass="textbox"></asp:TextBox>
                </div>
                <div style="display: flex; justify-content: center;">
                    <asp:TextBox ID="tb_occupation" runat="server" placeholder="Meslek" CssClass="textbox"></asp:TextBox>
                </div>
                <div style="display: flex; justify-content: center;">
                    <asp:TextBox ID="tb_username" runat="server" placeholder="Kullanıcı Adı" CssClass="textbox"></asp:TextBox>
                </div>
                <div style="display: flex; justify-content: center;">
                    <asp:TextBox ID="tb_dateTime" runat="server" placeholder="Doğum Tarihi" TextMode="Date" CssClass="textbox"></asp:TextBox>
                </div>
                <div style="display: flex; justify-content: center;">
                    <asp:TextBox ID="tb_password" runat="server" placeholder="Şifre" TextMode="Password" CssClass="textbox"></asp:TextBox>
                </div>
                <div style="margin-top: 15px">
                    <asp:LinkButton ID="lbtn_register" runat="server" Text="Kayıt Ol" CssClass="LoginButton" OnClick="lbtn_register_Click"></asp:LinkButton>
                </div>
                <div style="margin-top: 15px">
                    <asp:LinkButton ID="lbtn_directLogin" runat="server" Text="Girişe Dön" CssClass="LoginButton" OnClick="lbtn_directLogin_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
