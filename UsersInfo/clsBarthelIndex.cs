using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace UsersInfo
{
   

    public class clsBarthelIndex
    {
        int user_id;

        public clsBarthelIndex(int id )
        {
            user_id = id; 

        }

        public DataTable GetLatestAnserDataTableTotal()
        {
            DataTable dt = GetTableHedder();
            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            string sql = "select bi.index_item , ba.score, ";
            sql = sql + "case bs.anser_id when ba.anser_id then cast(ba.score as nvarchar(2)) else '' end as 回答, ba.index_question ";
            sql = sql + "from [kaigoryoku].[dbo].[T_BarthelIndexMeasurementScore] bs ";
            sql = sql + "inner join [kaigoryoku].[dbo].[T_BarthelIndexMeasurementList] bl ";
            sql = sql + "on bs.barthel_list_id = bl.barthel_list_id ";
            sql = sql + "inner join [kaigoryoku].[dbo].[TM_BarthelIndexAnser] ba ";
            sql = sql + "on bs.index_id = ba.index_id ";
            sql = sql + "inner join [kaigoryoku].[dbo].[TM_BarthelIndexItem] bi ";
            sql = sql + "on bs.index_id = bi.index_id ";
            sql = sql + "where bs.barthel_list_id = ";
            sql = sql + "(select top 1 barthel_list_id from [kaigoryoku].[dbo].[T_BarthelIndexMeasurementList] ";
            sql = sql + "where riyousya_id = " + user_id;
            sql = sql + " order by measure_dt desc)";


            try
            {
                SqlDataReader reader = clsdb.GetReader(sql);
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i <= reader.FieldCount - 1; i++)
                    {
                        dr[i] = reader.GetValue(i).ToString();


                    }

                    dt.Rows.Add(dr);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                clsdb.closedb();
            }


            return dt;
        }

        public Tuple<int, int, DataTable> GetLatestBarthelInfo()
        {
            DataTable dt = GetTableHedder();
            int max_score = 0;
            int act_score = 0;

            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            string sql = "select bi.index_item ,bi.max_score , ba.score , ba.index_question ";
            sql = sql + "from [kaigoryoku].[dbo].[T_BarthelIndexMeasurementScore] bs ";
            sql = sql + "inner join [kaigoryoku].[dbo].[T_BarthelIndexMeasurementList] bl ";
            sql = sql + "on bs.barthel_list_id = bl.barthel_list_id ";
            sql = sql + "inner join[kaigoryoku].[dbo].[TM_BarthelIndexAnser] ba ";
            sql = sql + "on bs.index_id = ba.index_id and bs.anser_id = ba.anser_id ";
            sql = sql + "inner join[kaigoryoku].[dbo].[TM_BarthelIndexItem] bi ";
            sql = sql + "on bs.index_id = bi.index_id ";
            sql = sql + "where bs.barthel_list_id = " ;
            sql = sql + "(select top 1 barthel_list_id from[kaigoryoku].[dbo].[T_BarthelIndexMeasurementList] ";
            sql = sql + "where riyousya_id = " +  user_id + " order by measure_dt desc)";


            try
            {
                SqlDataReader reader = clsdb.GetReader(sql);
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i <= reader.FieldCount - 1; i++)
                    {
                        dr[i] = reader.GetValue(i).ToString();
                    }

                    max_score = max_score + int.Parse(reader.GetValue(1).ToString());
                    act_score = act_score + int.Parse(reader.GetValue(2).ToString());

                    dt.Rows.Add(dr);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                clsdb.closedb();
            }

            var result = Tuple.Create(max_score, act_score, dt);
            return result;

        }

        public Tuple<string, int> GetMeasureInfo(int id)
        {
            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            string sql = "select top 1 measure_dt , count(*)  from [kaigoryoku].[dbo].[T_BarthelIndexMeasurementList] ";
            sql = sql + "where riyousya_id =" + id + " order by measure_dt desc";

            var result = Tuple.Create("", 0);
            SqlDataReader reader = clsdb.GetReader(sql);
            if (reader.Read())
            {
                result = Tuple.Create(reader.GetValue(0).ToString(), int.Parse(reader.GetValue(1).ToString()));
            }
            else
            {
                result = Tuple.Create("", 0);
            }

            clsdb.closedb();
            return result;
        }

        private DataTable GetTableHedder()

        {
            DataTable dt = new DataTable();
            dt.Columns.Add("設問");
            dt.Columns.Add("最大点数");
            dt.Columns.Add("点数");
            dt.Columns.Add("回答");

            return dt;
        }

        public DataTable GetPastBarthelDataTable(int id)
        {
            int times = 1;

            DataTable dt = new DataTable();
            dt.Columns.Add("回数");
            dt.Columns.Add("測定日");
            dt.Columns.Add("点数");

            string sql = "select  bl.measure_dt, sum(ba.score) as 点数 from [kaigoryoku].[dbo].[T_BarthelIndexMeasurementList] bl ";
            sql = sql + "inner join [kaigoryoku].[dbo].[T_BarthelIndexMeasurementScore] bs on bl.barthel_list_id = bs.barthel_list_id ";
            sql = sql + "inner join [kaigoryoku].[dbo].[TM_BarthelIndexAnser] ba on bs.index_id = ba.index_id and bs.anser_id = ba.anser_id ";
            sql = sql + "where bl.riyousya_id = " + id + " group by bl.measure_dt order by bl.measure_dt ";

            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            SqlDataReader reader = clsdb.GetReader(sql);

            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr[0] = times.ToString();
                dr[1] = reader.GetValue(0).ToString();
                dr[2] = reader.GetValue(1).ToString();

                dt.Rows.Add(dr);
                times++;
            }

            clsdb.closedb();
            return dt;
        }

        public int InsertBarthelIndexList(DateTime measure_dt, int user_id , ref string mes)
        {
            if (IsInsertBarthelIndexList(user_id, measure_dt) == false)
            {
                mes = "すでにデータが存在しています";
                return 0;
            }
            else
            {
                clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
                string sql = "insert into [kaigoryoku].[dbo].[T_BarthelIndexMeasurementList] ";
                sql = sql + "(measure_dt, barthel_list_id, riyousya_id) ";
                sql = sql + "values('" + measure_dt +"',(select case when max(barthel_list_id) is null then 1 else max(barthel_list_id) + 1 end ";
                sql = sql + "from [kaigoryoku].[dbo].[T_BarthelIndexMeasurementList]), " + user_id + ")";

                clsdb.ExecuteSQL(sql);


                SqlDataReader reader = clsdb.GetReader("select barthel_list_id from [kaigoryoku].[dbo].[T_BarthelIndexMeasurementList] " +
                                        "where riyousya_id =" + user_id + " and measure_dt = '" + measure_dt + "'");

                reader.Read();

                int tmp_id = int.Parse(reader.GetValue(0).ToString());
                clsdb.closedb();

                return tmp_id;
            }



        }

        public void InsertBarthelIndexScore(int barthel_id , int index_id , int anser_id)
        {
            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            string sql = "insert into [kaigoryoku].[dbo].[T_BarthelIndexMeasurementScore] ";
            sql = sql + "(barthel_list_id , index_id , anser_id) ";
            sql = sql + "values(" + barthel_id + "," + index_id + "," + anser_id +" )";

            clsdb.ExecuteSQL(sql);

            clsdb.closedb();
        }

        private bool IsInsertBarthelIndexList(int id , DateTime dt)
        {
            bool flg = false;
            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            SqlDataReader reader = clsdb.GetReader("select * from [kaigoryoku].[dbo].[T_BarthelIndexMeasurementList] " +
                                            "where riyousya_id = " + id + " and measure_dt = '" + dt + "'");

            if(reader.Read())
            {
                flg = false;
            }
            else
            {
                flg = true;
            }

            clsdb.closedb();

            return flg;
        }
    }
}