<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFurnitures.aspx.cs" Inherits="UsersInfo.ViewFurnitures" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 436px;
        }
        .auto-style2 {
            height: 426px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style1">
        <div class="auto-style2">
            <asp:Label ID="Label1" runat="server" Font-Size="Small" Font-Underline="True" Text="設備種類"></asp:Label>
            <asp:DropDownList ID="DDL_ProductSort" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_ProductSort_SelectedIndexChanged" Width="213px">
            </asp:DropDownList>
            <br />
            <br />
            検索結果<br />
            <asp:GridView ID="GV_FurnitureList" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnRowCommand="GV_FurnitureList_RowCommand" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                    <asp:BoundField DataField="ロット" HeaderText="ロット" SortExpression="ロット" />
                    <asp:BoundField DataField="メーカー" HeaderText="メーカー" SortExpression="メーカー" />
                    <asp:BoundField DataField="設置箇所" HeaderText="設置箇所" SortExpression="設置箇所" />
                    <asp:BoundField DataField="利用者名" HeaderText="利用者名" SortExpression="利用者名" />
                    <asp:BoundField DataField="購入日" HeaderText="購入日" SortExpression="購入日" />
                    <asp:ButtonField ButtonType="Button" Text="編集" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:kaigoryokuConnectionString %>" SelectCommand="select f.furniture_id as id ,  f.lot_no as ロット, m.maker_ja as メーカー, f.location_ja 設置箇所, r.riyousya_name 利用者名 ,f.purchase_dt as 購入日 from [kaigoryoku].[dbo].[T_Furnitures] f
left join [kaigoryoku].[dbo].[TM_Riyousya] r on f.riyousya_id = r.riyousya_id 
inner join [kaigoryoku].[dbo].[TM_ProductMaker] m on f.maker_id = m.maker_id
where f.product_id = @product_id
">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="product_id" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="設備データ変更"></asp:Label>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
