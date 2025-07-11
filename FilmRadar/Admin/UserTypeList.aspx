<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UserTypeList.aspx.cs" Inherits="FilmRadar.Admin.UserTypeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Kullanıcı Tür Listele</h3>
    <div>
        <asp:ListView ID="lv_userType" runat="server" OnItemCommand="lv_userType_ItemCommand">
            <layouttemplate>
                <table class="table" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Kullanıcı Tür No</th>
                            <th>İsim</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </layouttemplate>
            <itemtemplate>
                <tr>
                    <td><%# Eval ("ID") %></td>
                    <td><%# Eval ("Name") %></td>
                    <td><%# Eval ("StatusStr") %></td>
                    <td>
                        <a href='UserTypeEdit.aspx?userTypeID=<%# Eval("ID") %>'>Düzenle</a>
                        <asp:LinkButton ID="lbtn_change" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="change">Durum Değiştir</asp:LinkButton>
                    </td>
                </tr>
            </itemtemplate>
        </asp:ListView>
    </div>
</asp:Content>
