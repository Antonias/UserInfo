<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFurnitureDetail.aspx.cs" Inherits="UsersInfo.EditFurnitureDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 334px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:DetailsView ID="DV_FurnitureDetail" runat="server" AutoGenerateRows="False" DataKeyNames="furniture_id" DataSourceID="SqlDataSource1" Height="241px" Width="419px" OnItemUpdated="DV_FurnitureDetail_ItemUpdated" OnModeChanged="DV_FurnitureDetail_ModeChanged">
                <Fields>
                    <asp:BoundField DataField="furniture_id" HeaderText="furniture_id" ReadOnly="True" SortExpression="furniture_id" />
                    <asp:BoundField DataField="lot_no" HeaderText="lot_no" SortExpression="lot_no" />
                    <asp:BoundField DataField="maker_ja" HeaderText="maker_ja" SortExpression="maker_ja" />
                    <asp:BoundField DataField="location_ja" HeaderText="location_ja" SortExpression="location_ja" />
                    <asp:BoundField DataField="riyousya_name" HeaderText="riyousya_name" SortExpression="riyousya_name" />
                    <asp:BoundField DataField="purchase_dt" HeaderText="purchase_dt" SortExpression="purchase_dt" />
                    <asp:CommandField ShowEditButton="True" />
                </Fields>
            </asp:DetailsView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:kaigoryokuConnectionString %>" SelectCommand="select f.furniture_id,  f.lot_no , m.maker_ja , f.location_ja, r.riyousya_name, f.purchase_dt  from [kaigoryoku].[dbo].[T_Furnitures] f
left join [kaigoryoku].[dbo].[TM_Riyousya] r on f.riyousya_id = r.riyousya_id 
inner join [kaigoryoku].[dbo].[TM_ProductMaker] m on f.maker_id = m.maker_id
where f.furniture_id = @id" UpdateCommand="update [kaigoryoku].[dbo].[T_Furnitures] 
set purchase_dt  = @dt
where furniture_id = @id">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="id" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="dt" Type="Datetime"/>
                    <asp:Parameter Name="id" Type="Int32"/>
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
