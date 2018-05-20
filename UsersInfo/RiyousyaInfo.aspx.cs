using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace UsersInfo
{
    public partial class RiyousyaInfo : System.Web.UI.Page
    {
        
        int def_water_calcount = 100;




        private void WriteUserName(string initial_code)
        {
            lb_searchedname.Items.Clear();

            string str_sql = "SELECT [riyousya_name], [riyousya_id] ";
            str_sql = str_sql + "FROM[kaigoryoku].[dbo].[TM_Riyousya] ";
            str_sql = str_sql + "WHERE left([furigana_ja],1) IN (" + initial_code + ") ";
            str_sql = str_sql + "order by furigana_ja";

            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            SqlDataReader reader = clsdb.GetReader(str_sql);

            while (reader.Read())
            {
                ListItem list = new ListItem(reader.GetValue(0).ToString(), reader.GetValue(1).ToString());
                lb_searchedname.Items.Add(list);

            }

            clsdb.closedb();
        }





        protected void bt_a_Click(object sender, EventArgs e)
        {
            WriteUserName("'あ','い','う','え','お'");
            this.La_SearchCondition.Text = "検索結果<あ行検索>";
        }


        protected void bt_ka_Click(object sender, EventArgs e)
        {
            WriteUserName("'か','き','く','け','こ'");
            this.La_SearchCondition.Text = "検索結果<か行検索>";
        }



        protected void bt_sa_Click(object sender, EventArgs e)
        {
            WriteUserName("'さ','し','す','せ','そ'");
            this.La_SearchCondition.Text = "検索結果<さ行検索>";
        }

        protected void bt_ta_Click(object sender, EventArgs e)
        {
            WriteUserName("'た','ち','つ','て','と'");
            this.La_SearchCondition.Text = "検索結果<た行検索>";
        }


        protected void bt_na_Click(object sender, EventArgs e)
        {
            WriteUserName("'な','に','ぬ','ね','の'");
            this.La_SearchCondition.Text = "検索結果<な行検索>";
        }


        protected void bt_ha_Click(object sender, EventArgs e)
        {
            WriteUserName("'は','ひ','ふ','へ','ほ'");
            this.La_SearchCondition.Text = "検索結果<は行検索>";
        }



        protected void bt_ma_Click(object sender, EventArgs e)
        {
            WriteUserName("'ま','み','む','め','も'");
            this.La_SearchCondition.Text = "検索結果<ま行検索>";
        }


        protected void bt_ya_Click(object sender, EventArgs e)
        {
            WriteUserName("'や','ゆ','よ'");
            this.La_SearchCondition.Text = "検索結果<や行検索>";
        }



        protected void bt_ra_Click(object sender, EventArgs e)
        {
            WriteUserName("'ら','り','る','れ','ろ'");
            this.La_SearchCondition.Text = "検索結果<ら行検索>";
        }


        protected void bt_wa_Click(object sender, EventArgs e)
        {
            WriteUserName("'わ'");
            this.La_SearchCondition.Text = "検索結果<わ行検索>";
        }



        

        protected void WriteBaseUseInfo(int id)
        {
            string str_sql = "SELECT [riyousya_name],[furigana_ja], [location_ja], [birth_dt] ";
            str_sql = str_sql + "FROM[kaigoryoku].[dbo].[TM_Riyousya] ";
            str_sql = str_sql + "WHERE riyousya_id = " + id;

            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            SqlDataReader reader = clsdb.GetReader(str_sql);

            reader.Read();

            DateTime birth_dt = (DateTime)reader.GetValue(reader.GetOrdinal("birth_dt"));
            int age = DateTime.Today.Year - birth_dt.Year;
            if (birth_dt > DateTime.Today.AddYears(-age)) age--;

            this.la_userfurigana.Text = reader.GetValue(reader.GetOrdinal("furigana_ja")).ToString();        
            this.la_username.Text = reader.GetValue(reader.GetOrdinal("riyousya_name")).ToString();
            this.TB_HeyaBan.Text = reader.GetValue(reader.GetOrdinal("location_ja")).ToString();
            this.TB_BirthDay.Text = birth_dt.ToString().Substring(0,10);
            this.TB_Age.Text = age.ToString();


            clsdb.closedb();
            
            img_userface.ImageUrl = "/image/" + id.ToString() + ".jpg";
            
        }

        private void WriteBarthelInfo(int id)
        {

            clsBarthelIndex clsbi = new clsBarthelIndex(id);
            var barthel_info = clsbi.GetLatestBarthelInfo();

            this.gv_barthelindex.DataSource = barthel_info.Item3;
            this.gv_barthelindex.DataBind();

            this.gv_PastBarthelInfo.DataSource = clsbi.GetPastBarthelDataTable(id);
            this.gv_PastBarthelInfo.DataBind();

            this.TB_BarthelScore.Text = barthel_info.Item2.ToString() + "/" + barthel_info.Item1.ToString();

            TableCell tc = new TableCell();
            TableRow tr = new TableRow();
            tbl_base_barthelinfo.Rows.Add(tr);

            
     
        }

        


        protected void AddBedInfo(int id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("メーカー");
            dt.Columns.Add("型番");
            dt.Columns.Add("購入日");


            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());

            string str_sql = "SELECT pm.maker_ja , f.lot_no , f.purchase_dt ";
            str_sql = str_sql + "FROM [kaigoryoku].[dbo].[T_Furnitures] f ";
            str_sql = str_sql + "inner join [kaigoryoku].[dbo].[TM_ProductName] pn on f.product_id = pn.product_id ";
            str_sql = str_sql + "inner join [kaigoryoku].[dbo].[TM_ProductMaker] pm on f.maker_id = pm.maker_id ";
            str_sql = str_sql + "where pn.product_ja  = 'ベッド' and f.riyousya_id = " + id;

            SqlDataReader reader = clsdb.GetReader(str_sql);
            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr["メーカー"] = main.TrimString(reader.GetValue(reader.GetOrdinal("maker_ja")));
                dr["型番"] = main.TrimString(reader.GetValue(reader.GetOrdinal("lot_no")));
                dr["購入日"] = main.TrimString(reader.GetValue(reader.GetOrdinal("purchase_dt")));


                dt.Rows.Add(dr);
            }

            gv_userBedInfo.DataSource = dt;
            gv_userBedInfo.DataBind();




            clsdb.closedb();
        }

        protected DataTable getBarthelInfoHeader()
        {
            DataTable dt = new DataTable();

            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            string str_sql = "SELECT [index_item] ";
            str_sql = str_sql + "FROM[kaigoryoku].[dbo].[TM_barthelIndexItem] ";
            str_sql = str_sql + "order by index_id ";

            SqlDataReader reader = clsdb.GetReader(str_sql);
            while (reader.Read())
            {
                int i = 0;
                dt.Columns.Add(reader.GetValue(i).ToString());
            }

            clsdb.closedb();
            return dt;
        }

        private void DrowWaterGraph(int calc_count, int user_id)
        {
            DateTime end_dt = DateTime.Today;
            DateTime start_dt = end_dt.AddDays(-1 * calc_count);
          

            string[] legends = new string[] { "g1", "g2", "g3" , "g4", "g5", "g6", "g7", "g8", "g9","g10", "g11", "g12"}; //凡例
            Chart1.Series.Clear();  //グラフ初期化

            foreach(var item in legends)
            {
                
                Chart1.Series.Add(item);
                Chart1.Series[item].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn;

                //Chart1.Series[item].Name = item;
                
            }


            while (start_dt != end_dt)
            {
                string str = string.Format("select intake_time_start , intake_time_end , intake_value from [kaigoryoku].[dbo].[T_WaterIntake] " +
                "where riyousya_id = {0} and intake_day = '{1}' order by intake_time_start", user_id, start_dt);
                clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
                SqlDataReader reader = clsdb.GetReader(str);
                int total_value = 0;
                int i = 1;

                System.Web.UI.DataVisualization.Charting.DataPoint dp = new System.Web.UI.DataVisualization.Charting.DataPoint();
                while (reader.Read())
                {
                    //凡例が無い場合ココで設定
                    if (string.IsNullOrEmpty(Chart1.Series["g" + i.ToString()].LegendText))
                    {
                        Chart1.Series["g" + i.ToString()].LegendText = reader.GetValue(0).ToString();
                    }

                    dp = new System.Web.UI.DataVisualization.Charting.DataPoint();
                    dp.SetValueXY(start_dt.ToString(), reader.GetValue(2));

                    
                    if (reader.GetValue(2).ToString() == "0")
                    {
                        dp.IsValueShownAsLabel = false;
                    }
                    else
                    {
                        dp.IsValueShownAsLabel = true;
                    }
                    
                    Chart1.Series["g" + i.ToString()].Points.Add(dp);
                    total_value = total_value + int.Parse(reader.GetValue(2).ToString());
                    i++;
                }

                

                clsdb.closedb();
                start_dt = start_dt.AddDays(1);
            }
            


            /*
            clsDataBase db = new clsDataBase(main.GetConnectionString());
            SqlDataReader reader = db.GetReader(str);
            while (reader.Read())
            {
                string tmp_dt = reader.GetValue(0).ToString();
                Chart1.Series["series1"].Points.AddXY(tmp_dt.Substring(1, 10), reader.GetValue(1));


            }

            db.closedb();
            */
        }

        private void DrowWaterGraph(int calc_count, int user_id, string start_time, System.Web.UI.DataVisualization.Charting.Chart cht)
        {
            DateTime end_dt = DateTime.Today;
            DateTime start_dt = end_dt.AddDays(-1 * calc_count);


            cht.Series.Add("series1");
            cht.Series["series1"].XValueType = System.Web.UI.DataVisualization.Charting.ChartValueType.Int32;
            //cht.Series["series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
            cht.ChartAreas[0].AxisX.LabelStyle.Enabled = false;




            string str = "select w.intake_day , sum(w.intake_value) from [kaigoryoku].[dbo].[T_WaterIntake] w ";
            str = str + "group by w.riyousya_id , w.intake_day, w.intake_time_start ";
            str = str + "having w.riyousya_id = " + user_id;
            str = str + " and w.intake_day between '" + start_dt + "' and '" + end_dt + "' ";
            str = str + " and w.intake_time_start = '" + start_time + "'";
            str = str + "order by w.intake_day ";


            clsDataBase db = new clsDataBase(main.GetConnectionString());
            SqlDataReader reader = db.GetReader(str);
            while (reader.Read())
            {
                string tmp_dt = reader.GetValue(0).ToString();
                cht.Series["series1"].Points.AddXY(tmp_dt.Substring(1, 10), reader.GetValue(1));


            }

            db.closedb();

        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            

            //DataTable dt_barthel = getBarthelInfoHeader();
            //gv_barthelindex.DataSource = dt_barthel;
            //gv_barthelindex.DataBind();


        }

        protected void AddBedMakerToList()
        {
            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());



            clsdb.closedb();
        }
        

        protected void lb_searchedname_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem list = (ListItem)lb_searchedname.SelectedItem;
            int id = int.Parse(list.Value.ToString());

            WriteBaseUseInfo(id);

            WriteBarthelInfo(id);

            AddBedInfo(id);

            DrowWaterGraph(def_water_calcount, id);

            /*
            DrowWaterGraph(def_water_calcount, id, "01:00:00", this.cht_wvdetail_1);
            DrowWaterGraph(def_water_calcount, id, "03:00:00", this.cht_wvdetail_2);
            DrowWaterGraph(def_water_calcount, id, "05:00:00", this.cht_wvdetail_3);
            DrowWaterGraph(def_water_calcount, id, "07:00:00", this.cht_wvdetail_4);
            */
        }

        protected void Btn_EditBarthelInfo_Click(object sender, EventArgs e)
        {
            ListItem list = (ListItem)lb_searchedname.SelectedItem;
            int id = int.Parse(list.Value.ToString());

            string url = string.Format("BarthelIndexQuestion.aspx?user_id={0:s}", id.ToString());
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenNewWindow", "window.open('" + url + "', null);", true);

        }

        protected void Btn_SerchNameFromBScore_Click(object sender, EventArgs e)
        {
            int min_score = int.Parse( TxtBx_MinBarthelScore.Text);
            int max_score = int.Parse(TxtBx_MaxBarthelScore.Text);

            lb_searchedname.Items.Clear();

            string str_sql = " select r.riyousya_name , base_data.riyousya_id, sum(ba.score) 得点 from ";
            str_sql = str_sql + "[kaigoryoku].[dbo].[T_BarthelIndexMeasurementScore] bs ";
            str_sql = str_sql + " inner join (select barthel_list_id, bl.riyousya_id from ";
            str_sql = str_sql + "[kaigoryoku].[dbo].[T_BarthelIndexMeasurementList] bl ";
            str_sql = str_sql + "inner join (select riyousya_id, max(measure_dt) measure_dt from ";
            str_sql = str_sql + "[kaigoryoku].[dbo].[T_BarthelIndexMeasurementList] ";
            str_sql = str_sql + "group by riyousya_id ) saisin on bl.riyousya_id = saisin.riyousya_id ";
            str_sql = str_sql + "and bl.measure_dt = saisin.measure_dt) base_data ";
            str_sql = str_sql + "on bs.barthel_list_id = base_data.barthel_list_id ";
            str_sql = str_sql + "inner join [kaigoryoku].[dbo].[TM_BarthelIndexAnser] ba ";
            str_sql = str_sql + "on bs.index_id = ba.index_id and bs.anser_id = ba.anser_id ";
            str_sql = str_sql + "inner join [kaigoryoku].[dbo].[TM_Riyousya] r on r.riyousya_id = base_data.riyousya_id ";
            str_sql = str_sql + "group by r.riyousya_name , base_data.riyousya_id";

                  
            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            SqlDataReader reader = clsdb.GetReader(str_sql);

            while (reader.Read())
            {
                int score = int.Parse( reader.GetValue(2).ToString());

                if (min_score <= score && score <= max_score)
                {
                    ListItem list = new ListItem(reader.GetValue(0).ToString(), reader.GetValue(1).ToString());
                    lb_searchedname.Items.Add(list);
                }
            }

            clsdb.closedb();

            this.La_SearchCondition.Text = "検索結果<バーサルインデクス:"+ min_score + "～" + max_score + ">";
        }

        protected void CB_UnlockBaseUseInfo_CheckedChanged(object sender, EventArgs e)
        {
            lockBaseUserInfo();
        }

        protected void bt_UpdateBaseUserInfo_Click(object sender, EventArgs e)
        {
            ListItem list = (ListItem)lb_searchedname.SelectedItem;
            int id = int.Parse(list.Value.ToString());

            DateTime birth_dt = DateTime.Parse(this.TB_BirthDay.Text.ToString());
            string location = this.TB_HeyaBan.Text.ToString();

            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            string sql = string.Format("update [kaigoryoku].[dbo].[TM_Riyousya] " +
                                        "set birth_dt = '{0}' , location_ja = '{1}'" +
                                        "where riyousya_id = {2}", birth_dt , location, id);

            clsdb.ExecuteSQL(sql);
            clsdb.closedb();

            WriteBaseUseInfo(id);
            this.CB_UnlockBaseUseInfo.Checked = true;
            lockBaseUserInfo();
        }

        private void lockBaseUserInfo()
        {
            if (CB_UnlockBaseUseInfo.Checked == true)
            {
                TB_BirthDay.Enabled = false;
                TB_HeyaBan.Enabled = false;
                bt_UpdateBaseUserInfo.Enabled = false;
            }
            else
            {
                TB_BirthDay.Enabled = true;
                TB_HeyaBan.Enabled = true;
                bt_UpdateBaseUserInfo.Enabled = true;
            }

        }

        protected void Btn_EditFurnitureInfo_Click(object sender, EventArgs e)
        {
            string url = "ViewFurnitures.aspx";
            Type cstype = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(cstype, "OpenNewWindow", "window.open('" + url + "', null);", true);
        }
    }
}
