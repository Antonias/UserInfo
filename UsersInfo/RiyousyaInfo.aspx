<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RiyousyaInfo.aspx.cs" Inherits="UsersInfo.RiyousyaInfo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>てすてぃんｇ</title>

<style>


#Title {
float:left;
background:#0000FF;
}
#userface {
float:left;
background:#FFFFFF;
}

#Header {
float:left;
background:#00FFFF;
}
#Main {
float:left;

}

#iroha {
float:left;

}



#ListBox1 {
float: right;
}

#footer {
float:left;
background:#0000FF;
}





#tbc_searchedname {
float:right;
}

#Title0 {
    float: left;
    background: #FFFFFF;
}







    #bt_ha0 {
float:left;
}







    </style>
</head>



<body style="height: 898px; width: 1200px;">
    <form id="form1" runat="server" class="auto-style1">
        <div>
            <asp:Panel ID="Title" runat="server" Height="75px" Width="200px">
                <asp:CheckBox ID="CB_UnlockBaseUseInfo" runat="server" AutoPostBack="True" Checked="True" Font-Size="Medium" ForeColor="White" OnCheckedChanged="CB_UnlockBaseUseInfo_CheckedChanged" Text="lock" />
                <asp:Button ID="bt_UpdateBaseUserInfo" runat="server" Enabled="False" OnClick="bt_UpdateBaseUserInfo_Click" Text="利用者情報更新" />
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="利用者情報" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="userface" runat="server" Height="70px" Width="90px" BorderStyle="Double">
                <asp:Image ID="img_userface" runat="server" Height="70px" Width="89px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </asp:Panel>
        </div>
        <asp:Panel ID="Header" runat="server" Height="78px" Width="900px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="la_userfurigana" runat="server" Text="ふりがな"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Font-Underline="True" Text="生年月日"></asp:Label>
            <asp:TextBox ID="TB_BirthDay" runat="server" Enabled="False" Height="16px" Width="80px"></asp:TextBox>
            　<asp:Label ID="Label2" runat="server" Font-Underline="True" Text="年齢"></asp:Label>
            <asp:TextBox ID="TB_Age" runat="server" Enabled="False" Height="16px" Width="35px"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label10" runat="server" Font-Underline="True" Text="部屋番号"></asp:Label>
            <asp:TextBox ID="TB_HeyaBan" runat="server" Enabled="False" Height="17px" Width="48px"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Font-Underline="True" Text="要介護度"></asp:Label>
            <asp:TextBox ID="TB_BirthDay0" runat="server" Enabled="False" Height="17px" Width="48px"></asp:TextBox>
            <br />
            <asp:Label ID="la_username" runat="server" Font-Size="XX-Large" Text="名前"></asp:Label>
            <br />
            　 
            </asp:Panel>
        <br />
        <asp:Panel ID="Main" runat="server" CssClass="auto-style1" Height="600px" Width="900px">
            <br />
            <ajaxToolkit:TabContainer ID="tbc_UserDetail" runat="server" ActiveTabIndex="2" CssClass="auto-style6" Height="600px" Width="900px" BackColor="Silver" BorderColor="Silver" Enabled="False"><ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1"><HeaderTemplate>水分摂取量</HeaderTemplate><ContentTemplate><br />&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 　　　　　　　　　　　　 1日合計<br /> <asp:Chart ID="Chart1" runat="server" Height="152px" Width="762px"><Series><asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series1"></asp:Series></Series><ChartAreas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></ChartAreas></asp:Chart><br />　　　　01:00～02:00&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:Chart ID="cht_wvdetail_1" runat="server" Height="75px" Width="760px">
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
                　　　　03:00～04:00<br /> <asp:Chart ID="cht_wvdetail_2" runat="server" Height="69px" Width="759px"><Series><asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series1"></asp:Series></Series><ChartAreas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></ChartAreas></asp:Chart>
                <br />
                　　　　05:00～06:00<br /> <asp:Chart ID="cht_wvdetail_3" runat="server" Height="76px" Width="761px"><Series><asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series1"></asp:Series></Series><ChartAreas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></ChartAreas></asp:Chart>
                <br />
                　　　　07:00～08:00<br /> <asp:Chart ID="cht_wvdetail_4" runat="server" Height="71px" Width="765px"><Series><asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series1"></asp:Series></Series><ChartAreas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></ChartAreas></asp:Chart><br /><br /></ContentTemplate></ajaxToolkit:TabPanel><ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2"><HeaderTemplate>利用設備<br /></HeaderTemplate><ContentTemplate>ベッド<br /> <asp:GridView ID="gv_userBedInfo" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Double" BorderWidth="3px" CellPadding="4" Height="16px" Width="666px"><FooterStyle BackColor="White" ForeColor="#333333" /><HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" /><RowStyle BackColor="White" ForeColor="#333333" /><SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" /><SortedAscendingCellStyle BackColor="#F7F7F7" /><SortedAscendingHeaderStyle BackColor="#487575" /><SortedDescendingCellStyle BackColor="#E5E5E5" /><SortedDescendingHeaderStyle BackColor="#275353" /></asp:GridView><br /></ContentTemplate></ajaxToolkit:TabPanel><ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3" ><HeaderTemplate>バーセルインデックス</HeaderTemplate><ContentTemplate><asp:Table ID="tbl_base_barthelinfo" runat="server"></asp:Table>
                <br />
                <asp:Label ID="Label4" runat="server" Text="前回のスコア"></asp:Label>
                <br />
                <asp:Label ID="La_BarthelScore" runat="server" Font-Bold="True" Font-Underline="True" Text="合計点"></asp:Label>
                <asp:TextBox ID="TB_BarthelScore" runat="server" Enabled="False" Font-Bold="True" Font-Size="Large" Width="165px" Height="16px"></asp:TextBox>
                <br />
                <br /><asp:GridView ID="gv_barthelindex" runat="server" CellPadding="4" ForeColor="#333333" ShowHeaderWhenEmpty="True" Width="900px"><AlternatingRowStyle BackColor="White" ForeColor="#284775" /><EditRowStyle BackColor="#999999" /><FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" /><HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" /><RowStyle BackColor="#F7F6F3" ForeColor="#333333" /><SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" /><SortedAscendingCellStyle BackColor="#E9E7E2" /><SortedAscendingHeaderStyle BackColor="#506C8C" /><SortedDescendingCellStyle BackColor="#FFFDF8" /><SortedDescendingHeaderStyle BackColor="#6F8DAE" /></asp:GridView>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="過去のスコア"></asp:Label>
                <br />
                <asp:GridView ID="gv_PastBarthelInfo" runat="server" CellPadding="4" ForeColor="#333333" ShowHeaderWhenEmpty="True" Width="900px">
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
                </ContentTemplate></ajaxToolkit:TabPanel></ajaxToolkit:TabContainer>
        </asp:Panel>
        <br />
        <br />
        <br />
        <ajaxToolkit:TabContainer ID="tbc_searchedname" runat="server" Height="600px" Width="281px" ActiveTabIndex="0">
            <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="tab_usesearch">
                <HeaderTemplate>
                    利用者一欄
                </HeaderTemplate>
                <ContentTemplate>
                <asp:Panel ID="Side" runat="server" CssClass="auto-style1" Height="444px" Width="268px">
                    <br />
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Underline="True" Text="あいうえお検索"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="bt_a" runat="server" OnClick="bt_a_Click" Text="あ" Width="20px" />
                    <asp:Button ID="bt_ka" runat="server" OnClick="bt_ka_Click" Text="か" Width="20px" />
                    <asp:Button ID="bt_sa" runat="server" OnClick="bt_sa_Click" Text="さ" Width="20px" />
                    <asp:Button ID="bt_ta" runat="server" OnClick="bt_ta_Click" Text="た" Width="20px" />
                    <asp:Button ID="bt_na" runat="server" OnClick="bt_na_Click" Text="な" Width="20px" />
                    <asp:Button ID="bt_ha" runat="server" OnClick="bt_ha_Click" Text="は" Width="20px" />
                    <asp:Button ID="bt_ma" runat="server" OnClick="bt_ha_Click" Text="ま" Width="20px" />
                    <asp:Button ID="bt_ya" runat="server" OnClick="bt_ya_Click" Text="や" Width="20px" />
                    <asp:Button ID="bt_ra" runat="server" OnClick="bt_ra_Click" Text="ら" Width="20px" />
                    <asp:Button ID="bt_wa" runat="server" OnClick="bt_wa_Click" Text="わ" Width="20px" />
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Underline="True" Text="バーセルインデックス合計点"></asp:Label>
                    <br />
                    <asp:TextBox ID="TxtBx_MinBarthelScore" runat="server" Height="16px" Width="46px"></asp:TextBox>
                    点 ～<asp:TextBox ID="TxtBx_MaxBarthelScore" runat="server" Height="16px" Width="46px"></asp:TextBox>
                    点<asp:Button ID="Btn_SerchNameFromBScore" runat="server" Height="26px" OnClick="Btn_SerchNameFromBScore_Click" Text="検索" Width="50px" />
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="La_SearchCondition" runat="server" Font-Size="Small" Text="検索結果"></asp:Label>
                    <br />
                    <asp:ListBox ID="lb_searchedname" runat="server" AutoPostBack="True" CssClass="auto-style1" Height="289px" OnSelectedIndexChanged="lb_searchedname_SelectedIndexChanged" Width="266px"></asp:ListBox>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </asp:Panel>
                <br />
                </ContentTemplate></ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="Expired" runat="server" HeaderText="期限切れ">
                <HeaderTemplate>
                    期限切れ
                </HeaderTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
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
        <asp:Panel ID="footer" runat="server" Height="90px" Width="1200px">
            <asp:Button ID="Btn_EditBarthelInfo" runat="server" Text="バーセル登録" Font-Bold="True" Font-Size="Large" Height="83px" OnClick="Btn_EditBarthelInfo_Click" Width="123px" />
            <asp:Button ID="Btn_EditFurnitureInfo" runat="server" Font-Bold="True" Font-Size="Large" Height="83px" OnClick="Btn_EditFurnitureInfo_Click" Text="利用設備" Width="123px" />
        </asp:Panel>
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <br />
        <br />
        <br />
        <p>
            &nbsp;</p>
    </form>
</body>
</html>

    
    