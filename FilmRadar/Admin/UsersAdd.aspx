<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UsersAdd.aspx.cs" Inherits="FilmRadar.Admin.UsersAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="userAdd">
        <asp:Panel ID="pnl_successful" runat="server" CssClass="successful" Visible="false">
            Kullanıcı Başarıyla Eklendi
        </asp:Panel>
        <asp:Panel ID="pnl_unsuccessful" runat="server" CssClass="unsuccessful" Visible="false">
            <asp:Label ID="lbl_message" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <label>İsim</label>
            <asp:TextBox ID="tb_name" runat="server" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <label>Soyisim</label>
            <asp:TextBox ID="tb_surname" runat="server" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <label>Favori Film</label>
            <asp:TextBox ID="tb_favoriteFilm" runat="server" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <label>Meslek</label>
            <asp:TextBox ID="tb_occupation" runat="server" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <label>Kullanıcı Tür</label>
            <asp:DropDownList ID="ddl_userType" runat="server" AppendDataBoundItems="true">
                <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="row">
            <label>Kullanıcı Adı</label>
            <asp:TextBox ID="tb_username" runat="server" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <label>Doğum Tarihi</label>
            <asp:TextBox ID="tb_dateTime" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div class="row">
            <label>Şifre</label>
            <asp:TextBox ID="tb_password" runat="server" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <label>Durum</label>
            <asp:CheckBox ID="cb_status" runat="server" Text="Aktif" />
        </div>
        <div class="row">
            <asp:LinkButton ID="lbtn_add" runat="server" Text="Kullanıcı Ekle" CssClass="formButton" OnClick="lbtn_add_Click">
            </asp:LinkButton>
        </div>
    </div>
</asp:Content>
