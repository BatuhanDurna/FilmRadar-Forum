<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="FilmList.aspx.cs" Inherits="FilmRadar.Admin.FilmList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Filmleri Listele</h3>
    <div>
        <asp:ListView ID="lv_films" runat="server" OnItemCommand="lv_films_ItemCommand">
            <LayoutTemplate>
                <table class="table" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Resim</th>
                            <th>Film No</th>
                            <th>Film İsim</th>
                            <th>IMDB</th>
                            <th>Kategori</th>
                            <th>Özet</th>
                            <th>Konu</th>
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
                    <td>
                        <img src="../Pictures/<%# Eval ("Photo") %>" width="50" /></td>
                    <td><%# Eval ("ID") %></td>
                    <td><%# Eval ("FilmName") %></td>
                    <td><%# Eval ("IMDB") %></td>
                    <td><%# Eval ("CategoryStr") %></td>
                    <td><%# Eval ("Summary") %></td>
                    <td><%# Eval ("Topic") %></td>
                    <td><%# Eval ("StatusStr") %></td>
                    <td>
                        <div class="filmOptionsCss">
                            <a href='FilmEdit.aspx?fID=<%# Eval("ID") %>'>Düzenle</a>
                            <asp:LinkButton ID="lbtn_change" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="change">Durum Değiştir</asp:LinkButton>
                        </div>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
