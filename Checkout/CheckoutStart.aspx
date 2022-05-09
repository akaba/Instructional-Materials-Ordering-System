<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutStart.aspx.cs" Inherits="InstructionalMaterials.Checkout.CheckoutStart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Checkout</h1></div>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="InstructionalMaterials.Models.CartItem" SelectMethod="GetShoppingCartItems" 
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />        
        <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />        
        <asp:BoundField DataField="Product.UnitPrice" HeaderText="Price (each)" DataFormatString="{0:c}"/>          
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />    
        <asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.Product.UnitPrice)))%>
                </ItemTemplate>        
        </asp:TemplateField>     
        </Columns>    
    </asp:GridView>
        <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 

    </div>

    <h1>Order Details</h1>
    <hr />
    <h3>IM Coordinator:</h3>
    <table>
      
        <tr><td><asp:Label ID="Label1" runat="server">First Name:</asp:Label></td>
            <td><asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName" ErrorMessage="*First Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server">Last Name:</asp:Label></td>
            <td><asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LastName" ErrorMessage="*Last Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>      
        <tr>
            <td><asp:Label ID="Label3" runat="server">Email:</asp:Label></td>
            <td><asp:TextBox ID="Email" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email" ErrorMessage="*Email is not valid" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Email" ErrorMessage="*Email is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server">Phone:</asp:Label></td>
            <td><asp:TextBox ID="Phone" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Phone" ErrorMessage="*Use this format: 888-333-4444" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" ForeColor="Red"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Phone is required" ForeColor="Red" ControlToValidate="Phone"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td><br><asp:Label ID="LabelCampus" runat="server">Campus:</asp:Label></td>
            <td><br>
                <asp:DropDownList ID="Campus" runat="server" 
                    ItemType="InstructionalMaterials.Models.Campus" 
                    SelectMethod="GetCampuses" DataTextField="CampusName" 
                    DataValueField="CampusID" AppendDataBoundItems="True" >
                <asp:ListItem Selected="True">Please Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="Please Select" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Select Campus" ForeColor="Red" ControlToValidate="Campus"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2"><h3>Shipping Address</h3></td>

        </tr>
         <tr>
             
             <td><asp:Label ID="Label5" runat="server">Address:</asp:Label></td>
            <td><asp:TextBox ID="Address" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Street is required" ForeColor="Red" ControlToValidate="Address"></asp:RequiredFieldValidator>
             </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label6" runat="server">City:</asp:Label></td>
            <td><asp:TextBox ID="City" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*City is required" ForeColor="Red" ControlToValidate="City"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label7" runat="server">State:</asp:Label></td>
            <td><asp:TextBox ID="State" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*State is required" ForeColor="Red" ControlToValidate="State"></asp:RequiredFieldValidator>
            </td>
        </tr>
          <tr>
             <td style="height: 22px"><asp:Label ID="Label8" runat="server">Zip Code:</asp:Label></td>
            <td style="height: 22px"><asp:TextBox ID="Zip" runat="server"></asp:TextBox>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Zip" ErrorMessage="*Zip is not valid" ForeColor="Red" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*Zip Code is required" ForeColor="Red" ControlToValidate="Zip"></asp:RequiredFieldValidator>
                
              </td>
        </tr>
           <tr>
            <td> 
                <br /> 
                <asp:Button ID="BackButton" runat="server" Text="Go Back" OnClientClick="JavaScript: window.history.back(1); return false;"  />              
             </td>
            <td>
                <br />
                &nbsp;<asp:Button ID="SubmitChekout" runat="server" Text="Submit Order" OnClick="SubmitOrder_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
