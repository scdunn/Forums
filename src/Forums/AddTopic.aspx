<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddTopic.aspx.cs" Inherits="zobuno.forums.AddTopic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="mainContent" runat="server">

    <div class="add-topic">
    <h1>Start a new topic in <asp:PlaceHolder ID="forumTitle" runat="server" /></h1>
    <p>
    Enter a title for your topic providing a summary of what you will discuss.  Then enter
    a description of the issue or question providing as much detail as possible so that your
    topic can better be discussed. Keep the forums a clean place to learn and discuss by not using
    profanity or insulting comments.
    </p>
    
    <asp:Panel ID="topicMessage" runat="server" CssClass="errorMessage" Visible="false">
        Enter a topic title and detail before clicking submit.
    </asp:Panel>
    <p>
    <label>Topic Title</label><br />
    <asp:TextBox ID="topicTitle" runat="server" Rows="1" />
    </p>
    <p>
    <label>Topic Description and Details</label><br />
    <asp:TextBox ID="topicDescription" runat="server" TextMode=MultiLine Rows="10" />
    </p>

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

    <asp:Button ID="btnSubmit" CssClass="button icon icon-add" runat="server" Text="Submit" />
    </div>

</asp:Content>
