<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FilmEdit.aspx.cs" Inherits="FilmRadar.Admin.FilmEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="userAdd">
    <asp:Panel ID="pnl_successful" runat="server" CssClass="successful" Visible="false">
        Film Başarıyla Düzenlendi
    </asp:Panel>
    <asp:Panel ID="pnl_unsuccessful" runat="server" CssClass="unsuccessful" Visible="false">
        <asp:Label ID="lbl_message" runat="server"></asp:Label>
    </asp:Panel>
    <div class="row">
        <label>İsim</label>
        <asp:TextBox ID="tb_filmName" runat="server" CssClass="inputBox"></asp:TextBox>
    </div>
    <div class="row">
        <label>IMDB</label>
        <asp:TextBox ID="tb_imdbRating" runat="server" CssClass="inputBox" placeholder="(Örnek:7.2)"></asp:TextBox>
    </div>
    <div class="row">
        <label>Kategori</label>
        <asp:DropDownList ID="ddl_cat" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="row">
        <label>Resim</label>
        <asp:FileUpload ID="fu_pictures" runat="server" />
    </div>
        <asp:Image ID="img_pictures" runat="server" Width="300" CssClass="picture" />
    <div class="multi">
        <div class="row">
            <label>Özet</label>
            <asp:TextBox ID="tb_summary" TextMode="MultiLine" Style="min-height: 50px" runat="server" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <label>İçerik</label>
            <asp:TextBox ID="tb_topic" TextMode="MultiLine" Style="min-height: 100px" runat="server" CssClass="inputBox"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <label>Durum</label>
        <asp:CheckBox ID="cb_status" runat="server" Text="Aktif" />
    </div>
    <div class="row">
        <asp:LinkButton ID="lbtn_add" runat="server" Text="Film Düzenle" CssClass="formButton" OnClick="lbtn_add_Click"></asp:LinkButton>
    </div>
</div>
</asp:Content>
