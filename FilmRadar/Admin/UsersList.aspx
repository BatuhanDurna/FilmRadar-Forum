<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="FilmRadar.Admin.UsersList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h3>Kullanıcıları Listele</h3>
    <div>
        <asp:ListView ID="lv_users" runat="server" OnItemCommand="lv_users_ItemCommand">
            <LayoutTemplate>
                <table class="table" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Kullanıcı No</th>
                            <th>İsim</th>
                            <th>Soyisim</th>
                            <th>Favori Film</th>
                            <th>Meslek</th>
                            <th>Kullanıcı Türü</th>
                            <th>Kullanıcı Adı</th>
                            <th>Doğum Tarihi</th>
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
                    <td><%# Eval ("Surname") %></td>
                    <td><%# Eval ("FavoriteFilm") %></td>
                    <td><%# Eval ("Occupation") %></td>
                    <td><%# Eval ("UserTypeStr") %></td>
                    <td><%# Eval ("Username") %></td>
                    <td><%# Eval ("DateTime") %></td>
                    <td><%# Eval ("StatusStr") %></td>
                    <td>
                        <a href='UserEdit.aspx?userID=<%# Eval("ID") %>'>Düzenle</a>
                        <asp:LinkButton ID="lbtn_change" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="change">Durum Değiştir</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
