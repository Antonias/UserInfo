using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace UsersInfo
{
    public partial class UsersInfo : System.Web.UI.Page
    {
        int def_water_calcount = 100;

        


        private void WriteUserName(string initial_code)
        {                 
            lb_searchedname.Items.Clear();

            string str_sql = "SELECT [riyousya_name], [riyousya_id] ";
            str_sql = str_sql + "FROM[kaigoryoku].[dbo].[TM_Riyousya] ";
            str_sql = str_sql + "WHERE left([furigana_ja],1) IN (" + initial_code + ")";

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
        }
        

        protected void bt_ka_Click(object sender, EventArgs e)
        {
            WriteUserName("'か','き','く','け','こ'");
        }

        
        
        protected void bt_sa_Click(object sender, EventArgs e)
        {
            WriteUserName("'さ','し','す','せ','そ'");
        }
        
        protected void bt_ta_Click(object sender, EventArgs e)
        {
            WriteUserName("'た','ち','つ','て','と'");
        }
        

        protected void bt_na_Click(object sender, EventArgs e)
        {
            WriteUserName("'な','に','ぬ','ね','の'");
        }
        

        protected void bt_ha_Click(object sender, EventArgs e)
        {
            WriteUserName("'は','ひ','ふ','へ','ほ'");
        }
        
        

        protected void bt_ma_Click(object sender, EventArgs e)
        {
            WriteUserName("'ま','み','む','め','も'");
        }
        

        protected void bt_ya_Click(object sender, EventArgs e)
        {
            WriteUserName("'や','ゆ','よ'");
        }
        
        

        protected void bt_ra_Click(object sender, EventArgs e)
        {
            WriteUserName("'ら','り','る','れ','ろ'");
        }
        

        protected void bt_wa_Click(object sender, EventArgs e)
        {
            WriteUserName("'わ'");
        }
        
        

        

        protected void lb_searchedname_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem list = (ListItem)lb_searchedname.SelectedItem;
            int id = int.Parse( list.Value.ToString());

            WriteBaseUseInfo(id);

            WriteBarthelInfo(id);

            AddBedInfo(id);
           
            DrowWaterGraph(def_water_calcount, id);

            DrowWaterGraph(def_water_calcount, id, "01:00:00", this.cht_wvdetail_1);
            DrowWaterGraph(def_water_calcount, id, "03:00:00", this.cht_wvdetail_2);
            DrowWaterGraph(def_water_calcount, id, "05:00:00", this.cht_wvdetail_3);
            DrowWaterGraph(def_water_calcount, id, "07:00:00", this.cht_wvdetail_4);

        }

        protected void WriteBaseUseInfo(int id)
        {
            string str_sql = "SELECT [riyousya_name],[location_ja], [birth_dt] ";
            str_sql = str_sql + "FROM[kaigoryoku].[dbo].[TM_Riyousya] ";
            str_sql = str_sql + "WHERE riyousya_id = " + id;

            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            SqlDataReader reader = clsdb.GetReader(str_sql);

            TableRow tr = new TableRow();
            TableCell tc;
            tbl_userbaseinfo.Rows.Add(tr);

            while (reader.Read())
            {
                tc = new TableCell();
                tc.Text =  reader.GetValue(0).ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.Text = reader.GetValue(1).ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.Text = reader.GetValue(2).ToString();
                tr.Cells.Add(tc);

            }

            clsdb.closedb();

            tc = new TableCell();
            Image im = new Image();
            im.ImageUrl = "/image/" + id.ToString() + ".jpg";
            tc.Controls.Add(im);
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Wrap = false;
            HyperLink hl_ev = new HyperLink();
            hl_ev.Text = "編集";
            hl_ev.Target = "_blank";
            hl_ev.NavigateUrl = "~/UpdateUserInfo.aspx?id=" + id;
            tc.Controls.Add(hl_ev);
            tr.Cells.Add(tc);


        }

        private void WriteBarthelInfo(int id)
        {
            clsBarthelIndex clsbi = new clsBarthelIndex(id);
            //this.gv_barthelindex.DataSource = clsbi.GetLatestAnserDataTable();
            this.gv_barthelindex.DataBind();

            TableCell tc = new TableCell();
            TableRow tr = new TableRow();
            tbl_base_barthelinfo.Rows.Add(tr);

            if (clsbi.GetMeasureInfo(id).Item2 != 0)
            {
                tc.Text = "実行回数:=" + clsbi.GetMeasureInfo(id).Item2;
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.Text = "最終登録日:=" + clsbi.GetMeasureInfo(id).Item1.Substring(0, 10);
                tr.Cells.Add(tc);
            }

            tc = new TableCell();
            HyperLink hl_ev = new HyperLink();
            hl_ev.Text = "編集";
            hl_ev.Target = "_blank";
            hl_ev.NavigateUrl = "~/BarthelIndexQuestion.aspx?user_id=" + id;
            tc.Controls.Add(hl_ev);
            tr.Cells.Add(tc);

            //gv_barthelindex.Rows[0].Cells[0].RowSpan = 2;


        }

        protected void WriteBaseUserInfoFlame()
        {
            TableRow tr = new TableRow();
            tbl_userbaseinfo.Rows.Add(tr);
            TableCell tc = new TableCell();
            tc.Text = "名前";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "部屋番号";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "誕生日";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "画像";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "   ";
            tr.Cells.Add(tc);

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

        private void DrowWaterGraph(int calc_count , int user_id)
        {
            DateTime end_dt = DateTime.Today;
            DateTime start_dt = end_dt.AddDays(-1 * calc_count);


            this.Chart1.Series.Add("series1");
            Chart1.Series["series1"].XValueType = System.Web.UI.DataVisualization.Charting.ChartValueType.Int32;
            Chart1.Series["series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

            string str = "select w.intake_day , sum(w.intake_value) from [kaigoryoku].[dbo].[T_WaterIntake] w ";
            str = str + "group by w.riyousya_id , w.intake_day ";
            str = str + "having w.riyousya_id = " + user_id;
            str = str + " and w.intake_day between '" + start_dt + "' and '" + end_dt + "' ";
            str = str + "order by w.intake_day ";


            clsDataBase db = new clsDataBase(main.GetConnectionString());
            SqlDataReader reader = db.GetReader(str);
            while (reader.Read())
            {
                string tmp_dt =  reader.GetValue(0).ToString();
                Chart1.Series["series1"].Points.AddXY(tmp_dt.Substring(1,10), reader.GetValue(1));


            }

            db.closedb();

        }

        private void DrowWaterGraph(int calc_count, int user_id, string start_time, System.Web.UI.DataVisualization.Charting.Chart cht)
        {
            DateTime end_dt = DateTime.Today;
            DateTime start_dt = end_dt.AddDays(-1 * calc_count);


            cht.Series.Add("series1");
            cht.Series["series1"].XValueType = System.Web.UI.DataVisualization.Charting.ChartValueType.Int32;
            cht.Series["series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;

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
            
            WriteBaseUserInfoFlame();

            //DataTable dt_barthel = getBarthelInfoHeader();
            //gv_barthelindex.DataSource = dt_barthel;
            //gv_barthelindex.DataBind();


        }

        protected void AddBedMakerToList()
        {
            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());

            

            clsdb.closedb();
        }
        
    }
}