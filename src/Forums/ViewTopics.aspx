<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="ViewTopics.aspx.cs" Inherits="zobuno.forums.ViewTopics" %>

<%@ import namespace="zobuno.forums" %>

<asp:Content ID="Content1" ContentPlaceHolderID=mainContent runat="server">
    <h2><%# Forum.Title %></h2>
    <a href="default.aspx" class="button">Back to Forums</a>
    <asp:HyperLink ID="btnAddTopic" Visible=false  runat="server" CssClass="button icon icon-add" Text="Add new topic" />
    <br /><br />
    
    <div class="topic-list">
    <asp:Repeater ID="topicList" runat="server" >
    <ItemTemplate>
    <div class="topic-item <%# Container.ItemType != ListItemType.AlternatingItem ? "alt" : "" %>">
        <div class="description">
        <strong><a href="/<%# Eval("Forum.Url") %>/<%# DataBinder.Eval(Container.DataItem,"id") %>-<%# DataBinder.Eval(Container.DataItem,"title").ToString().Replace(" ","-") %>"><%# DataBinder.Eval(Container.DataItem,"title") %></a></strong>
        <br />Started by:&nbsp;<%#Eval("User.Nickname")%>&nbsp;-&nbsp;
        <%# DataBinder.Eval(Container.DataItem, "datecreated", "{0:MMM-d-yy h:mm tt}")%>
         <asp:Button ID="delete" Text="Delete" CommandName="delete" CommandArgument='<%# Eval("ID").ToString() %>'  Visible=<%#  helper.CurrentUser.EmailAddress=="cdunn@cidean.com" ? true: false %> runat="server"/>
       
        </div>
    
        <div class="post-count"><%#Eval("ForumPosts.Count")%>&nbsp; replies
        </div>
        <div class="post-last">
            by&nbsp;            <%# Eval("LastPost.User.Nickname") %><br /><%# this.DateToText(Eval("DateCreated").ToString())%>
        </div>
    </div>
    </ItemTemplate>
    </asp:Repeater>
    </div>
    <asp:Panel ID="paging" runat="server">
    
    </asp:Panel>
</asp:Content>