<%@ Page Title="Topics and Discussions" Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Forums._Default" MasterPageFile="~/Master.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID=mainContent runat="server">
    <asp:DataList ID="forumList" runat="server" CssClass="forum-list">
<ItemTemplate>
<div class="forum-item">
<div class="description">
<strong><a href="<%# DataBinder.Eval(Container.DataItem,"url") %>"><%# DataBinder.Eval(Container.DataItem,"title") %></a></strong>
<br />
<%# DataBinder.Eval(Container.DataItem,"description") %>
</div>
  <div class="post-count"><%#Eval("TopicCount")%>&nbsp; topics
        </div>
        <div class="post-count"><%#Eval("PostCount")%>&nbsp; replies
        </div>
              
        <div class="post-last">
            by&nbsp;            <%# Eval("LastPostUser.Nickname")%><br /><%# this.DateToText(Eval("LastPostDate").ToString())%>
        </div>

</div>

</ItemTemplate>
</asp:DataList>

</asp:Content>