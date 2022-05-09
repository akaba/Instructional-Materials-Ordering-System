<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="InstructionalMaterials.Admin.ManageOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div id="Orders" class="OrderContainer"> 
       <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" SelectMethod="GetOrders" OnRowCommand="GridView1_RowCommand" ItemType="InstructionalMaterials.Models.Order"  AutoGenerateColumns="False"  CellPadding="4" ForeColor="#333333" GridLines="None" BorderWidth="1px" DataKeyNames="OrderID" AllowPaging="True" Width="1000px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
    					 <asp:TemplateField>
                 <itemtemplate>					
					<asp:linkbutton id="btnEdit" runat="server" commandname="Edit" text="Edit" />					
				</itemtemplate>
				<edititemtemplate>
					<asp:linkbutton id="btnUpdate" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  commandname="UpdateStatus" text="Update" />
					<asp:linkbutton id="btnCancel" runat="server" commandname="Cancel" text="Cancel" />
				</edititemtemplate>
       </asp:TemplateField>
       <asp:HyperLinkField DataNavigateUrlFields="OrderID" DataNavigateUrlFormatString="~/Admin/IMRequestForm.aspx?orderid={0}" 
                             DataTextFormatString="{0}" SortExpression="OrderID" HeaderText="OrderID" ItemStyle-HorizontalAlign="Center" DataTextField="OrderID" />
            <asp:BoundField HeaderText="Order Date" DataField="OrderDate" SortExpression="OrderDate"  ReadOnly="true" HeaderStyle-Width="90" />
            <asp:TemplateField>
            <ItemTemplate>
              <asp:Label ID="LabelOrderID" runat="server" Visible="false" Text='<%# Bind("OrderID") %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField>
            <asp:BoundField DataField="Username" Visible="false" />

              <asp:TemplateField HeaderText="Order Status" SortExpression="Status">
                <EditItemTemplate>
                     <asp:DropDownList ID="statusDD" runat="server" Text='<%# Bind("Status") %>'>                                    
                           <asp:ListItem Value="0">Submitted-Under Review</asp:ListItem>
                           <asp:ListItem Value="1">Incomplete-Please Resubmit</asp:ListItem>
                           <asp:ListItem Value="2">Submitted to EMAT</asp:ListItem>
                           <asp:ListItem Value="3">Received</asp:ListItem>
                     </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                     <asp:Label ID="LabelStatus" runat="server" Text='<%# GetStatus(Convert.ToInt32(Eval("Status"))) %>'></asp:Label>
                </ItemTemplate>
           </asp:TemplateField> 
            <asp:TemplateField HeaderText="Campus">
               <ItemTemplate>
                 <asp:Label ID="LabelCampus" runat="server" Text='<%# GetCampusName(Convert.ToInt32(Eval("CampusID"))) %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="IM Coordinator">
            <ItemTemplate>
                    <asp:Label ID="LabelIM" runat="server" Text='<%#Eval("FirstName")+ " " + Eval("LastName")%>' Width="150"></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Contact">
            <ItemTemplate>
                    <asp:Label ID="LabelContact" runat="server" Text='<%#Eval("Email")+ "<br>" + Eval("Phone")%>' Width="150"></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Shipping Address">
            <ItemTemplate>
                    <asp:Label ID="LabelShipping" runat="server" Text='<%#Eval("Address")+ " " + Eval("City")+ " " + Eval("State")+ " " + Eval("ZipCode")%>' Width="150"></asp:Label>
            </ItemTemplate>
            </asp:TemplateField> 
           <asp:TemplateField HeaderText="Total">
            <ItemTemplate>
                 <asp:Label ID="LabelTotal" runat="server" Text='<%# "$" + Eval("Total") %>'></asp:Label>
            </ItemTemplate>
          </asp:TemplateField> 
         </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>   
   </div>  
</asp:Content>

