<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FilmRadar.User.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_Listfilm" runat="server">
        <ItemTemplate>
            <a href="FilmParse.aspx?fid=<%# Eval("ID") %>">
                <div class="film-parse">
                    <div class="film">
                        <img src="../Pictures/<%# Eval("Photo") %>" width="200" height="150"/>
                        <h3><%# Eval("FilmName") %></h3>
                    </div>
                </div>
            </a>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
