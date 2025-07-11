<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="FilmParse.aspx.cs" Inherits="FilmRadar.User.FilmParse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="filmParse">
        <div class="filmPhoto">
            <asp:Image ID="img_picture" runat="server" />
        </div>
        <div class="title">
            <h2>
                <asp:Literal ID="ltrl_title" runat="server"></asp:Literal>
            </h2>
        </div>
        <div class="information">
            Kategori:
            <asp:Literal ID="ltrl_category" runat="server"></asp:Literal>
            | IMDB:
            <asp:Literal ID="ltrl_imdbrate" runat="server"></asp:Literal>
        </div>
        <div class="topic">
            <h2>Tür</h2>
            <asp:Literal ID="ltrl_topic" runat="server"></asp:Literal>
        </div>
        <div class="summary">
            <h2>Özet</h2>
            <asp:Literal ID="ltrl_summary" runat="server"></asp:Literal>
        </div>
        <div class="commentPanel">
            <div class="commentTitle">
                <h2>YORUMLAR</h2>
            </div>
            <asp:Panel ID="pnl_loginOK" runat="server" Visible="false">
                <div class="postComment">
                    <label>Yorum :</label>
                    <asp:TextBox ID="tb_writeComment" runat="server" placeholder="Yorum..." CssClass="inputBox"></asp:TextBox>
                    <div class="postComment_button">
                        <asp:LinkButton ID="lbtn_postComment_button" runat="server" Text="Yorum Yap" CssClass="comment-button" OnClick="lbtn_postComment_button_Click"></asp:LinkButton> 
                    </div>
                </div>                
            </asp:Panel>
            <asp:Panel ID="pnl_loginnotOK" runat="server" Visible="true">
                <label class="sign-in">Yorum Yapmak İçin <asp:LinkButton ID="lbtn_directLogin" runat="server" OnClick="lbtn_directLogin_Click">Giriş</asp:LinkButton> Yapınız.</label>
            </asp:Panel> 
            <div class="commentList">
                <asp:Repeater ID="rpt_commentList" runat="server">
                    <ItemTemplate>
                        <div class="com-list">
                            <label class="commentTopic"><%# Eval("Topic") %></label> <br />

                            <label class="username"> <%# Eval("UserStr") %> ||<%# Eval("CommentTime") %></label>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
