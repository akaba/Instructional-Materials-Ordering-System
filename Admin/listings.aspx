<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="listings.aspx.cs" Inherits="InstructionalMaterials.Admin.listings" %>
<%@ Import Namespace="System.Web.Routing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div id="content">
        <asp:Repeater ID="Repeater1" ItemType="InstructionalMaterials.Models.Product" 
                SelectMethod="GetProducts" runat="server">
            <ItemTemplate>
                <div class="item">
                    <h3><%# Item.ProductName %></h3>
                    <%# Item.SubjectArea %>
                    <h4><%#:String.Format("{0:c}", Item.UnitPrice)%></h4>
                    <button name="add" type="submit" 
                        value="<%# Item.ProductID %>">Add to Cart</button>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="pager">
        <% for (int i = 1; i <= MaxPage; i++) {
            string path = RouteTable.Routes.GetVirtualPath(null, null,
                new RouteValueDictionary() {{ "page", i }}).VirtualPath;
            Response.Write(
                string.Format("<a href='{0}' {1}>{2}</a>",
                path, i == CurrentPage ? "class='selected'" : "", i));
           }%>
    </div>
</asp:Content>
