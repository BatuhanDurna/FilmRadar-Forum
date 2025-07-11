<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CommentList.aspx.cs" Inherits="FilmRadar.Admin.CommentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="comment">
        <asp:LinkButton ID="lbtn_allcommentList" runat="server" Text="Tümünü Listele" OnClick="lbtn_allcommentList_Click"></asp:LinkButton>
        <asp:LinkButton ID="lbtn_activecommentList" runat="server" Text="Aktif Yorum Listele" OnClick="lbtn_activecommentList_Click"></asp:LinkButton>
        <asp:LinkButton ID="lbtn_passivecommentList" runat="server" Text="Pasif Yorum Listele" OnClick="lbtn_passivecommentList_Click"></asp:LinkButton>
    </div>
    <div>
        <asp:ListView ID="lv_allComment" runat="server" Visible="true" OnItemCommand="lv_allComment_ItemCommand">
            <LayoutTemplate>
                <table class="table" cellpaddin="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Yorum No</th>
                            <th>İsim</th>
                            <th>Konu</th>
                            <th>Kullanıcı Adı</th>
                            <th>Film Adı</th>
                            <th>Yorum Saati</th>
                            <th>Görüntülenme</th>
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
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Topic") %></td>
                    <td><%# Eval("UserStr") %></td>
                    <td><%# Eval("FilmsStr") %></td>
                    <td><%# Eval("CommentTime") %></td>
                    <td><%# Eval("Viewcomment") %></td>
                    <td><%# Eval("StatusStr") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_change" runat="server" CommandName="change" CommandArgument='<%# Eval("ID") %>'>Durum Değiştir</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div>
        <asp:ListView ID="lv_activeComment" runat="server" Visible="false" OnItemCommand="lv_allComment_ItemCommand">
            <LayoutTemplate>
                <table class="table" cellpaddin="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Yorum No</th>
                            <th>İsim</th>
                            <th>Konu</th>
                            <th>Kullanıcı Adı</th>
                            <th>Film Adı</th>
                            <th>Yorum Saati</th>
                            <th>Görüntülenme</th>
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
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Topic") %></td>
                    <td><%# Eval("UserStr") %></td>
                    <td><%# Eval("FilmsStr") %></td>
                    <td><%# Eval("CommentTime") %></td>
                    <td><%# Eval("Viewcomment") %></td>
                    <td><%# Eval("StatusStr") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_change" runat="server" CommandName="change" CommandArgument='<%# Eval("ID") %>'>Durum Değiştir</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <div>
        <asp:ListView ID="lv_passiveComment" runat="server" Visible="false" OnItemCommand="lv_allComment_ItemCommand">
            <LayoutTemplate>
                <table class="table" cellpaddin="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Yorum No</th>
                            <th>İsim</th>
                            <th>Konu</th>
                            <th>Kullanıcı Adı</th>
                            <th>Film Adı</th>
                            <th>Yorum Saati</th>
                            <th>Görüntülenme</th>
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
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("Topic") %></td>
                    <td><%# Eval("UserStr") %></td>
                    <td><%# Eval("FilmsStr") %></td>
                    <td><%# Eval("CommentTime") %></td>
                    <td><%# Eval("Viewcomment") %></td>
                    <td><%# Eval("StatusStr") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_change" runat="server" CommandName="change" CommandArgument='<%# Eval("ID") %>'>Durum Değiştir</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
