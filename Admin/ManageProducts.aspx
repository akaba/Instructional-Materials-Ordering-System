<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="InstructionalMaterials.Admin.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div> 
      
      <div id="CategoryMenu" class="productslist">        
          <asp:DropDownList ID="CategoryDD" runat="server" DataTextField="CategoryName" DataValueField="CategoryID" 
              ItemType="InstructionalMaterials.Models.Category" SelectMethod="GetCategories" AutoPostBack="True" 
              OnDataBound="CategoryDD_DataBound" OnSelectedIndexChanged="CategoryDD_SelectedIndexChanged">
             </asp:DropDownList>  

           
           <asp:DropDownList ID="SubjectAreaDD" runat="server" ItemType="System.String"
              SelectMethod="GetSubjectArea" AutoPostBack="True" OnSelectedIndexChanged="SubjectAreaDD_SelectedIndexChanged"></asp:DropDownList>  
          <asp:Button ID="ButtonReset" runat="server" OnClick="ButtonReset_Click" Text="Reset Filters" />

     </div>
         
     <asp:ListView ItemType="InstructionalMaterials.Models.Product"  SelectMethod="GetProducts" 
        DataKeyNames="ProductID" UpdateMethod="UpdateProduct" DeleteMethod="DeleteProduct"
        InsertMethod="InsertProduct" GroupItemCount="3"  InsertItemPosition="LastItem" EnableViewState="False"
        runat="server" ID="ProductListView"  OnPagePropertiesChanging="ProductListView_PagePropertiesChanging" >
     <LayoutTemplate>
        <table>             
            <tr ID="groupPlaceholder" runat="server"></tr>
        </table> 
                   
   </LayoutTemplate>
   <GroupTemplate>
           <tr>               
              <td ID="itemPlaceholder" runat="server"></td>
           </tr>
   </GroupTemplate>       
        <ItemTemplate>
             <td><div style="float:left"> 
              
                 <b>Publisher:</b><%# Item.Publisher %><br/><b>Product Name:</b><%# Item.ProductName %><br/><b>ISBN/Product Number:</b><%# Item.ISBN %><br/><b>Language:</b><%# Item.Language %><br/><b>Subject Area:</b><%# Item.SubjectArea %><br/><b>Course Name:</b><%# Item.CourseName %><br/><b>Material Type:</b><%# Item.MaterialType %><br/><b>Grade:</b><%# Item.Grade %><br/><b>Grade Level:</b><%# Item.GradeLevel %><br/><b>Copyright Year:</b><%# Item.CopyrightYear %><br/><b>Media Format:</b><%# Item.MediaFormat %><br/><b>TEKS%:</b><%# Item.TEKS %><br/><b>Unit Price:</b><%#:String.Format("{0:c}", Item.UnitPrice)%><br/><b>Allotment Type:</b><%# Item.AllotmentType %><br/><b>Web Link:</b><%# Item.WebLink %><br/><b>MLC:</b><%# Item.MLC %><br/><b>Purchaser:</b><%# Item.Purchaser %><br/><b>Image1:</b><%# Item.ImagePath1 %><br/><b>image2:</b><%# Item.ImagePath2 %><br/><b>Category:</b><%# Item.CategoryID %><br/><asp:Button CommandName="Edit" Text="Edit" runat="server" />
                    <asp:Button CommandName="Delete" Text="Delete" runat="server" />

                 </div>
                </td>
            
        </ItemTemplate>      
        <EditItemTemplate>
               <td>
                   <b>Publisher:</b><input name="Publisher" value="<%# Item.Publisher %>" /><br />
                   <b>ProductName:</b><input name="ProductName" value="<%# Item.ProductName %>" /><br />
                   <b>ISBN:</b><input name="ISBN" value="<%# Item.ISBN %>" /><br />
                   <b>Language:</b><input name="Language" value="<%# Item.Language %>" /><br />
                   <b>SubjectArea:</b>
                    <asp:DropDownList ID="SubjectArea" runat="server" Text='<%# Bind("SubjectArea") %>'> 
                         <asp:ListItem Value="CAREER & TECHNICAL EDUCATION (CTE)">CAREER & TECHNICAL EDUCATION (CTE)</asp:ListItem>
                         <asp:ListItem Value="ENGLISH LANGUAGE ARTS AND READING, GRADES K-5">ENGLISH LANGUAGE ARTS AND READING, GRADES K-5</asp:ListItem>
                     </asp:DropDownList><br />
                   <b>CourseName:</b><input name="CourseName" value="<%# Item.CourseName %>" /><br />
                   <b>MaterialType:</b><input name="MaterialType" value="<%# Item.MaterialType %>" /><br />
                   <b>Grade:</b><input name="Grade" value="<%# Item.Grade %>" /><br />
                   <b>GradeLevel:</b><input name="GradeLevel" value="<%# Item.GradeLevel %>" /><br />
                   <b>CopyrightYear:</b><input name="CopyrightYear" value="<%# Item.CopyrightYear %>" /><br />
                   <b>Language:</b><input name="Language" value="<%# Item.Language %>" /><br />
                   <b>MediaFormat:</b><input name="MediaFormat" value="<%# Item.MediaFormat %>" /><br />
                   <b>TEKS:</b><input name="TEKS" value="<%# Item.TEKS %>" /><br />
                   <b>UnitPrice:</b><input name="UnitPrice" value="<%# Item.UnitPrice %>" /><br />
                   <b>WebLink:</b><input name="WebLink" value="<%# Item.WebLink %>" /><br />
                   <b>MLC:</b><input name="MLC" value="<%# Item.MLC %>" /><br />
                   <b>AllotmentType:</b><input name="AllotmentType" value="<%# Item.AllotmentType %>" /><br />
                   <b>Purchaser:</b><input name="Purchaser" value="<%# Item.Purchaser %>" /><br />
                   <b>ImagePath1:</b><input name="ImagePath1" value="<%# Item.ImagePath1 %>" /><br />
                   <b>ImagePath2:</b> <input name="ImagePath2" value="<%# Item.ImagePath2 %>" /><br />
                   <b>CategoryID:</b><input name="CategoryID" value="<%# Item.CategoryID %>" /><br />

                    <asp:Button CommandName="Update" Text="Update" runat="server"/>
                    <asp:Button CommandName="Cancel" Text="Cancel" runat="server"/>
                </td>
           
        </EditItemTemplate>
        <InsertItemTemplate>
           
        </InsertItemTemplate>
    </asp:ListView>

    <hr />

    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ProductListView" PageSize="2">
            <Fields>
                 <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                 <asp:NumericPagerField />
                 <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
            </Fields>
    </asp:DataPager>
  </div> 
</asp:Content>
