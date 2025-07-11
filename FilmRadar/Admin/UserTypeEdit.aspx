<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserTypeEdit.aspx.cs" Inherits="FilmRadar.Admin.UserTypeEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="catAdd">
        <asp:Panel ID="pnl_successful" runat="server" CssClass="successful" Visible="false">
            Kullanıcı Tür Başarıyla Düzenlendi
        </asp:Panel>
        <asp:Panel ID="pnl_unsuccessful" runat="server" CssClass="unsuccessful" Visible="false">
            <asp:Label ID="lbl_message" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <label>Kullanıcı Tür Adı</label>
            <asp:TextBox ID="tb_name" runat="server" CssClass="inputBox"></asp:TextBox>
        </div>
        <div class="row">
            <label>Durum</label>
            <asp:CheckBox ID="cb_status" runat="server" Text="Aktif" />
        </div>
        <div class="row">
            <asp:LinkButton ID="lbtn_edit" runat="server" Text="Kullanıcı Tür Düzenle" CssClass="formButton" OnClick="lbtn_edit_Click"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
