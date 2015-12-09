<%@ Page Language="C#" AutoEventWireup="true" CodeFile="basket.aspx.cs" Inherits="public_basket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="id" DataSourceID="SqlDataSource2" 
            EmptyDataText="There are no data records to display." AllowPaging="True" 
            PageSize="4">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                    SortExpression="id" />
                <asp:TemplateField HeaderText="pic">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("pic") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="62px" 
                            ImageUrl='<%# Eval("pic") %>' Width="80px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="?ID={0}" HeaderText="buy" Text="buy" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            DeleteCommand="DELETE FROM [Items] WHERE [id] = @id" 
            InsertCommand="INSERT INTO [Items] ([id], [name], [pic], [price]) VALUES (@id, @name, @pic, @price)" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT [id], [name], [pic], [price] FROM [Items]" 
            UpdateCommand="UPDATE [Items] SET [name] = @name, [pic] = @pic, [price] = @price WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="pic" Type="String" />
                <asp:Parameter Name="price" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="pic" Type="String" />
                <asp:Parameter Name="price" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" EmptyDataText="There are no data records to display.">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" 
                SortExpression="id" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:TemplateField HeaderText="pic">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("pic") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="63px" 
                        ImageUrl='<%# Eval("pic") %>' Width="75px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            
            <asp:TemplateField HeaderText="count">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="TextBoxCount" runat="server" Height="19px" 
                        Text='<%# Bind("count") %>' Width="35px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="total" HeaderText="totalprice" />
            <asp:HyperLinkField DataNavigateUrlFields="id" 
                DataNavigateUrlFormatString="?DelID={0}" HeaderText="delete" 
                Text="delete" />
            
        </Columns>
    </asp:GridView>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="change" />
    <asp:Button ID="save" runat="server" Text="Save To DataBase" 
        onclick="save_Click" />
    </form>
</body>
</html>
