<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ViewPosts.aspx.cs" Inherits="zobuno.forums.ViewPosts" %>

<%@ import namespace="zobuno.forums" %>

<asp:Content ContentPlaceHolderID=mainContent runat="server">


    <asp:HyperLink ID="returnTopics" runat="server" Text="" CssClass="button" /><br />
    <div class="post-item">

         <div class="user rounded">
    <b><%# ForumTopic.User.Nickname%></b>
        <div class="date"><%# this.DateToText(ForumTopic.DateCreated.ToString())%> </div>
        <div>Posts:<%#  ForumTopic.User.PostCount %></div>
                 
    </div>
    <div class="description">     
    <h3><%# ForumTopic.Title %></h3>
    <%# HttpUtility.HtmlDecode(ForumTopic.Description) %>
    </div>
    </div>
    <asp:DataList ID="postList" runat="server" class="post-list">
    <ItemTemplate>
    <div class="post-item ">
    <div class="user rounded">
    <b><%#Eval("User.Nickname")%></b>
        <div class="date"><%# this.DateToText(Eval("DateCreated").ToString())%></div>
        <div>Posts:<%# Eval("User.PostCount") %></div>
        <asp:Button ID="delete" Text="Delete" CommandName="delete" CommandArgument='<%# Eval("ID").ToString() %>'  Visible=<%#  (helper.CurrentUser.ID.ToString() == Eval("UserID").ToString()) || helper.CurrentUser.EmailAddress=="cdunn@cidean.com" ? true: false %> runat="server"/>
       
    </div>
    <div class="description">

    <%# HttpUtility.HtmlDecode(DataBinder.Eval(Container.DataItem,"description").ToString()) %>
    <br />

    </div>
    </div>
    </ItemTemplate>
    </asp:DataList>
    
   
    <div class="post-reply" id="postReply" runat="server" visible=false>
    <strong>Post a reply:</strong><br />
    <asp:Panel ID="postReplyMessage" runat="server" CssClass="errorMessage" Visible="false">
        Enter a reply before clicking submit.
    </asp:Panel>
    <asp:TextBox ID="postDescription" runat="server" TextMode=MultiLine Rows="10" />
    <asp:Panel ID="adminPost" runat="server" Visible=false>
    <p>
    <label>Post Date</label>
    <asp:TextBox ID="postDate" runat="server" />
    </p>
    <p>
    <label>Post User</label>
    <asp:DropDownList ID="postUser" runat="server" DataTextField="Nickname" DataValueField="ID" />
    </p>
    </asp:Panel>
    <asp:Button ID="btnSubmit" CssClass="button" runat="server" Text="Submit" />
    </div>
     <a name="post-reply">&nbsp;</a>
</asp:Content>