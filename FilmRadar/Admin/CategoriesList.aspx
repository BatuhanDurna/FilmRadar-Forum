<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CategoriesList.aspx.cs" Inherits="FilmRadar.Admin.CategoriesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Kategorileri Listele</h3>
    <div>
        <asp:ListView ID="lv_categories" runat="server" OnItemCommand="lv_categories_ItemCommand">
            <LayoutTemplate>
                <table class="table" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Kategori No</th>
                            <th>İsim</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval ("ID") %></td>
                    <td><%# Eval ("Name") %></td>
                    <td><%# Eval ("StatusStr") %></td>
                    <td>
                        <a href='CategoriesEdit.aspx?catID=<%# Eval("ID") %>'>Düzenle</a>
                        <asp:LinkButton ID="lbtn_change" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="change">Durum Değiştir</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
