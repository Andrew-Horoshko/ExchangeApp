<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Kantor.aspx.cs" Inherits="Exchange.Kantor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="CustomStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="error" runat="server" Width="200px" CssClass="Error"   Text=""></asp:Label>
        </p>
        <asp:Panel ID="Panel1" runat="server" Height="312px" style="margin-left: 0px" Width="1205px">
            <asp:TextBox ID="amountFrom" CssClass="moneyField" style="margin-left: 250px;"  runat="server"></asp:TextBox>
            
            <asp:DropDownList ID="curFrom" runat="server">
                <asp:ListItem>USD</asp:ListItem>
                <asp:ListItem>EUR</asp:ListItem>
                <asp:ListItem>GBP</asp:ListItem>
                <asp:ListItem>CHF</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="amountTo" runat="server" CssClass="moneyField"  ReadOnly ="true" style="margin-left:200px;" ></asp:TextBox>
            <asp:DropDownList ID="curTo" runat="server" >
                <asp:ListItem>USD</asp:ListItem>
                <asp:ListItem>EUR</asp:ListItem>
                <asp:ListItem>GBP</asp:ListItem>
                <asp:ListItem>CHF</asp:ListItem>
            </asp:DropDownList>
            
           
            <asp:Button ID="Button5" style="  margin-left:500px;"     width ="90px" runat="server" CssClass="button"  OnClick ="Switch"  Text =" SWITCH"/>
            <asp:Button ID="Button1" CssClass="button" runat="server"  OnClick="Exchange" style="margin-top:50px;
margin-left:80px;" Text="Exchange" Width="120px" />
            
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Height="260px">
            <asp:Table ID="ExchangeHistory" runat="server" Height="37px" Width="1066px"  CellPadding="10" 
        GridLines="Both"
        HorizontalAlign="Center" style="margin-top: 3px">
            </asp:Table>
            <asp:Panel ID="Panel3" runat="server" Height="113px">
                <asp:DropDownList ID="field" runat="server" style="position:absolute; top:250px; right:790px;"   Height="27px" >
                    <asp:ListItem>Id</asp:ListItem>
                    <asp:ListItem>FromCurrency</asp:ListItem>
                    <asp:ListItem>FromAmount</asp:ListItem>
                    <asp:ListItem>ToCurrency</asp:ListItem>
                    <asp:ListItem>ToAmount</asp:ListItem>
                    <asp:ListItem>Date</asp:ListItem>
                </asp:DropDownList>
                        <asp:CheckBoxList ID="Order"   style="position:absolute; top:250px; right:650px;"  runat="server" Height="31px">
                    <asp:ListItem>Descending</asp:ListItem>
                </asp:CheckBoxList>
                <asp:Button ID="Button2" CssClass="button" runat="server" style="position:absolute; top:250px; right:480px;" OnClick="Sort" Text="Sort" Width="91px" />
        
                <asp:Button ID="Button3"  CssClass="button" style="position:absolute; top:320px; right:640px;" runat="server"  OnClick="Filter" Text="Filter" Width="81px" />
                <asp:TextBox ID="search" CssClass="moneyField" runat="server" style="position:absolute; top:320px; right:790px;"></asp:TextBox>
                <asp:Button ID="Button4" CssClass="button" runat="server" OnClick="All" style="position:absolute; top:320px; right:500px;" Text="All" Width="82px" />
            </asp:Panel>
        </asp:Panel>
    </form>
</body>
</html>
