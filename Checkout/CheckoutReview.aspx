<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutReview.aspx.cs" Inherits="InstructionalMaterials.Checkout.CheckoutReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Order Review</h1></div>
    <p></p>
    <h3 style="padding-left: 33px">Products:</h3>
    <asp:GridView ID="OrderItemList" runat="server" AutoGenerateColumns="False" GridLines="Both" CellPadding="10" Width="500" BorderColor="#efeeef" BorderWidth="33">              
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText=" Product ID" />        
            <asp:BoundField DataField="Product.ProductName" HeaderText=" Product Name" />        
            <asp:BoundField DataField="Product.UnitPrice" HeaderText="Price (each)" DataFormatString="{0:c}"/>     
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />        
        </Columns>    
    </asp:GridView>
    <asp:DetailsView ID="ShipInfo" runat="server" AutoGenerateRows="false" GridLines="None" CellPadding="10" BorderStyle="None" CommandRowStyle-BorderStyle="None">
        <Fields>
        <asp:TemplateField>
            <ItemTemplate>
                <h3>Personal Details:</h3>                
                <br />
                <asp:Label ID="Label7" runat="server" Text="First Name:" Font-Bold="True"></asp:Label>
                <asp:Label ID="FirstName" runat="server" Text='<%#: Eval("FirstName") %>'></asp:Label>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Last Name:" Font-Bold="True"></asp:Label>
                <asp:Label ID="LastName" runat="server" Text='<%#: Eval("LastName") %>'></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Email:" Font-Bold="True"></asp:Label>
                <asp:Label ID="Email" runat="server" Text='<%#: Eval("Email") %>'></asp:Label> 
                <br />
                <asp:Label ID="Label5" runat="server" Text="Phone:" Font-Bold="True"></asp:Label>
                <asp:Label ID="Phone" runat="server" Text='<%#: Eval("Phone") %>'></asp:Label> 
                <br /><br />
                <asp:Label ID="Label1" runat="server" Text="Campus:" Font-Bold="True"></asp:Label>
                <asp:Label ID="Campusname" runat="server" Text='<%#: Session["campusname"] %>'></asp:Label>  
                <h3>Shipping Address:</h3>
                <br />
                <asp:Label ID="Label3" runat="server" Text='<%#: Eval("FirstName") %>'></asp:Label>  
                <asp:Label ID="Label4" runat="server" Text='<%#: Eval("LastName") %>'></asp:Label>                
                <br />
                <asp:Label ID="Address" runat="server" Text='<%#: Eval("Address") %>'></asp:Label>
                <br />
                <asp:Label ID="City" runat="server" Text='<%#: Eval("City") %>'></asp:Label>
                <asp:Label ID="State" runat="server" Text='<%#: Eval("State") %>'></asp:Label>
                <asp:Label ID="ZipCode" runat="server" Text='<%#: Eval("ZipCode") %>'></asp:Label>
                <p></p>
                <h3>Order Total:</h3>
                <br />
                <asp:Label ID="Total" runat="server" Text='<%#: Eval("Total", "{0:C}") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
          </Fields>
    </asp:DetailsView>
    <p></p>
    <hr />
    
    <asp:Button ID="BackButton" runat="server" Text="Go Back" OnClientClick="JavaScript: window.history.back(1); return false;"  />  
     &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="CheckoutConfirm" runat="server" Text="Confirm Checkout" OnClick="CheckoutConfirm_Click" />
    <asp:Label ID="LabelMsg" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
