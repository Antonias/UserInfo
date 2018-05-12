<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersInfo.aspx.cs" Inherits="UsersInfo.UsersInfo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 523px;
        }
        .auto-style1 {
            width: 32px;
        }
        .auto-style2 {
            float: left;
            height: 589px;
            width: 1161px;
        }
        .auto-style3 {
            float: left;
            height: 528px;
        }
        .auto-style4 {
            height: 952px;
            width: 0.5px;
            margin-top: 0px;
        }
        .auto-style5 {
            height: 571px;
            width: 1390px;
        }
    </style>
</head>
<body style="height: 756px">
    <form id="form1" runat="server" class="auto-style5">
        <div id="bbb" class="auto-style3">
     <asp:Button ID="bt_na" runat="server" Text="な" Width="27px" OnClick="bt_na_Click" />
     <asp:Button ID="bt_ta" runat="server" Text="た" Width="27px" OnClick="bt_ta_Click" />
     <asp:Button ID="bt_sa" runat="server" Text="さ" Width="27px" OnClick="bt_sa_Click" />
     <asp:Button ID="bt_ka" runat="server" Text="か" Width="27px" OnClick="bt_ka_Click" />
     <asp:Button ID="bt_a" runat="server" Text="あ" Width="27px" OnClick="bt_a_Click" />
            <br />
            <br />
     
     <asp:Button ID="bt_wa" runat="server" Text="わ" Width="27px" OnClick="bt_wa_Click" />
     <asp:Button ID="bt_ra" runat="server" Text="ら" Width="27px" OnClick="bt_ra_Click" />
     <asp:Button ID="bt_ya" runat="server" Text="や" Width="27px" OnClick="bt_ya_Click" />
     <asp:Button ID="bt_ma" runat="server" Text="ま" Width="27px" OnClick="bt_ma_Click" />
     <asp:Button ID="bt_ha" runat="server" Text="は" Width="27px" OnClick="bt_ha_Click" />
            <br />
            <br />
            <br />
            ベッドメーカー<br />
            <asp:DropDownList ID="ddl_bedmaker" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            ＜検索結果＞<br />
            <asp:ListBox ID="lb_searchedname" runat="server" AutoPostBack="True" Height="123px" OnSelectedIndexChanged="lb_searchedname_SelectedIndexChanged" Width="134px"></asp:ListBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <asp:Table ID="tbl_seachedname" runat="server" BorderColor="Black" BorderStyle="Solid" GridLines="Both">
            </asp:Table>


        </div>

        <div id="ccc" style="float:left; height: 336px; width: 42px;">
            <table style="background-color: gray; border-collapse: collapse;" class="auto-style4">
        <tr>
        <td class="auto-style1">&nbsp; &nbsp;</td>
        </tr>
        </table>


        </div>
 
 <div id="aaa" class="auto-style2">
     <br />
     <asp:Table ID="tbl_userbaseinfo" runat="server" GridLines="Both">
     </asp:Table>
     <br />
     <ajaxToolkit:TabContainer ID="tbc_UserDetail" runat="server" ActiveTabIndex="2" Width="1500px" Height="865px" CssClass="auto-style6">
         <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
             <HeaderTemplate>
                 水分摂取量
             </HeaderTemplate>
             <ContentTemplate>
                 <br />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 　　　　　　　　　　　　 1日合計<br /> 
                 <asp:Chart ID="Chart1" runat="server" Height="152px" Width="762px">
                     <Series>
                         <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series1">
                         </asp:Series>
                     </Series>
                     <ChartAreas>
                         <asp:ChartArea Name="ChartArea1">
                         </asp:ChartArea>
                     </ChartAreas>
                 </asp:Chart>
                 <br />
                 &nbsp;　　　&nbsp;&nbsp;&nbsp;&nbsp; 01:00～02:00&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 03:00～04:00&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 05:00～06:00&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 07:00～08:00<br />
                 <asp:Chart ID="cht_wvdetail_1" runat="server" Height="134px" Width="196px">
                     <Series>
                         <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series1">
                         </asp:Series>
                     </Series>
                     <ChartAreas>
                         <asp:ChartArea Name="ChartArea1">
                         </asp:ChartArea>
                     </ChartAreas>
                 </asp:Chart>
                 <asp:Chart ID="cht_wvdetail_2" runat="server" Height="131px" Width="196px">
                     <Series>
                         <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series1">
                         </asp:Series>
                     </Series>
                     <ChartAreas>
                         <asp:ChartArea Name="ChartArea1">
                         </asp:ChartArea>
                     </ChartAreas>
                 </asp:Chart>
                 <asp:Chart ID="cht_wvdetail_3" runat="server" Height="128px" Width="196px">
                     <Series>
                         <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series1">
                         </asp:Series>
                     </Series>
                     <ChartAreas>
                         <asp:ChartArea Name="ChartArea1">
                         </asp:ChartArea>
                     </ChartAreas>
                 </asp:Chart>
                 <asp:Chart ID="cht_wvdetail_4" runat="server" Height="125px" Width="196px">
                     <Series>
                         <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series1">
                         </asp:Series>
                     </Series>
                     <ChartAreas>
                         <asp:ChartArea Name="ChartArea1">
                         </asp:ChartArea>
                     </ChartAreas>
                 </asp:Chart>
                 <br />
                 <br />
             </ContentTemplate>
         </ajaxToolkit:TabPanel>
         <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
             <HeaderTemplate>
                 利用設備<br />
             </HeaderTemplate>
             <ContentTemplate>
                 ベッド<br /> 
                 <asp:GridView ID="gv_userBedInfo" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="3px" CellPadding="4" Height="16px" Width="666px">
                     <FooterStyle BackColor="White" ForeColor="#333333" />
                     <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                     <RowStyle BackColor="White" ForeColor="#333333" />
                     <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F7F7F7" />
                     <SortedAscendingHeaderStyle BackColor="#487575" />
                     <SortedDescendingCellStyle BackColor="#E5E5E5" />
                     <SortedDescendingHeaderStyle BackColor="#275353" />
                 </asp:GridView>
                 <br />
             </ContentTemplate>
         </ajaxToolkit:TabPanel>
         <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
             <HeaderTemplate>
                        バーセルインデックス
                    </HeaderTemplate>
             <ContentTemplate>
                 <asp:Table ID="tbl_base_barthelinfo" runat="server">
                 </asp:Table>
                 <br />
                 <asp:GridView ID="gv_barthelindex" runat="server" CellPadding="4" ForeColor="#333333" ShowHeaderWhenEmpty="True" Width="862px">
                     <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
             </ContentTemplate>
         </ajaxToolkit:TabPanel>
     </ajaxToolkit:TabContainer>


        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
