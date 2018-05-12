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
    public partial class BarthelIndexQuestion : System.Web.UI.Page
    {
        int user_id ;

       
        protected void Page_Load(object sender, EventArgs e)
        {
            user_id = int.Parse(Request.QueryString["user_id"]);    //クエリ文字列を参照 

            if (!IsPostBack)
            {
                
                InitQuestionList();
                InitUserTable();
                tb_measure_dt.Text = DateTime.Today.ToString().Substring(0, 10);
            }
        }

        private void InitQuestionList()
        {
            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            string sql = "select bi.index_id ,ba.anser_id ,bi.index_item, ba.index_question ";
            sql = sql + "from [kaigoryoku].[dbo].[TM_BarthelIndexAnser] ba ";
            sql = sql + "inner join [kaigoryoku].[dbo].[TM_BarthelIndexItem] bi ";
            sql = sql + "on ba.index_id = bi.index_id order by bi.index_id, ba.anser_id desc";

            SqlDataReader reader = clsdb.GetReader(sql);

            string question_ja = "";
            while (reader.Read())
            {                                
                int question_id = int.Parse( reader.GetValue(0).ToString());
                
                if (reader.GetValue(2).ToString() != question_ja)
                {
                    question_ja = reader.GetValue(2).ToString();
                    WriteQuestionLabel(question_id, question_ja);
                }

                AddAnserToListbox(int.Parse( reader.GetValue(0).ToString()), int.Parse(reader.GetValue(1).ToString()), reader.GetValue(3).ToString());

            }


            clsdb.closedb();

        }

        private void InitUserTable()
        {            
            
            clsDataBase clsdb = new clsDataBase(main.GetConnectionString());
            string sql = "select riyousya_name  from [kaigoryoku].[dbo].[TM_Riyousya] ";
                   sql = sql + "where riyousya_id =" + user_id;
            SqlDataReader reader = clsdb.GetReader(sql);

            reader.Read();

            la_username.Text = "名前:=" + reader.GetValue(0).ToString() + "測定日:=";



            clsdb.closedb();
        }
        

        private void WriteQuestionLabel(int i, string question)
        {
            if (i == 1)
            {
                this.La_question1.Text = question;
            }
            else if (i == 2)
            {
                this.La_question2.Text = question;
            }

            else if (i == 3)
            {
                this.La_question3.Text = question;
            }

            else if (i == 4)
            {
                this.La_question4.Text = question;
            }

            else if (i == 5)
            {
                this.La_question5.Text = question;
            }

            else if (i == 6)
            {
                this.La_question6.Text = question;
            }

            else if (i == 7)
            {
                this.La_question7.Text = question;
            }

            else if (i == 8)
            {
                this.La_question8.Text = question;
            }

            else if (i == 9)
            {
                this.La_question9.Text = question;
            }

            else if (i == 10)
            {
                this.La_question10.Text = question;
            }
        }

        private void AddAnserToListbox(int item_id, int ans_id, string ans_ja)
        {
            ListItem li = new ListItem(ans_ja, ans_id.ToString());

            if (item_id ==1)
            {
                this.lst_question1.Items.Add(li); 
            }
            else if (item_id == 2)
            {
                this.lst_question2.Items.Add(li);
            }

            else if (item_id == 3)
            {
                this.lst_question3.Items.Add(li);
            }
            else if (item_id == 4)
            {
                this.lst_question4.Items.Add(li);
            }
            else if (item_id == 5)
            {
                this.lst_question5.Items.Add(li);
            }
            else if (item_id == 6)
            {
                this.lst_question6.Items.Add(li);
            }
            else if (item_id == 7)
            {
                this.lst_question7.Items.Add(li);
            }
            else if (item_id == 8)
            {
                this.lst_question8.Items.Add(li);
            }
            else if (item_id == 9)
            {
                this.lst_question9.Items.Add(li);
            }
            else if (item_id == 10)
            {
                this.lst_question10.Items.Add(li);
            }
        }

        protected void cmb_InsertBarthelInfo_Click(object sender, EventArgs e)
        {
            string war_mess = string.Empty;

            if(IsCheckAllQuestion() == false)
            {
                la_insertState.Text = "答えていない質問が有ります";
                return;
            }

            DateTime measure_dt = DateTime.Parse( tb_measure_dt.Text.ToString());
            clsBarthelIndex clsbi = new clsBarthelIndex(user_id);

            
            int active_barthel_id = clsbi.InsertBarthelIndexList(measure_dt , user_id , ref war_mess);

            if (active_barthel_id == 0)
            {
                la_insertState.Text = war_mess;
            }
            else
            {
                ListItem li = (ListItem) lst_question1.SelectedItem;
                clsbi.InsertBarthelIndexScore(active_barthel_id, 1, int.Parse( li.Value.ToString()));

                li = (ListItem)lst_question2.SelectedItem;
                clsbi.InsertBarthelIndexScore(active_barthel_id, 2, int.Parse(li.Value.ToString()));

                li = (ListItem)lst_question3.SelectedItem;
                clsbi.InsertBarthelIndexScore(active_barthel_id, 3, int.Parse(li.Value.ToString()));

                li = (ListItem)lst_question4.SelectedItem;
                clsbi.InsertBarthelIndexScore(active_barthel_id, 4, int.Parse(li.Value.ToString()));

                li = (ListItem)lst_question5.SelectedItem;
                clsbi.InsertBarthelIndexScore(active_barthel_id, 5, int.Parse(li.Value.ToString()));

                li = (ListItem)lst_question6.SelectedItem;
                clsbi.InsertBarthelIndexScore(active_barthel_id, 6, int.Parse(li.Value.ToString()));

                li = (ListItem)lst_question7.SelectedItem;
                clsbi.InsertBarthelIndexScore(active_barthel_id, 7, int.Parse(li.Value.ToString()));

                li = (ListItem)lst_question8.SelectedItem;
                clsbi.InsertBarthelIndexScore(active_barthel_id, 8, int.Parse(li.Value.ToString()));

                li = (ListItem)lst_question9.SelectedItem;
                clsbi.InsertBarthelIndexScore(active_barthel_id, 9, int.Parse(li.Value.ToString()));

                li = (ListItem)lst_question10.SelectedItem;
                clsbi.InsertBarthelIndexScore(active_barthel_id, 10, int.Parse(li.Value.ToString()));
                
                la_insertState.Text = "登録が完了しました(3秒後にこのページを閉じます)";
                

                System.Text.StringBuilder script = new System.Text.StringBuilder();
                script.Append("<script language='javascript'>\n");
                script.Append("self.opener = self;\n");
                script.Append("self.close();\n");
                script.Append("</script>\n");
                // 
                // JavaScriptを登録する。 
                // 
                this.Page.RegisterClientScriptBlock("SetText", script.ToString());

                
            }

        }

        private bool IsCheckAllQuestion()
        {
            bool tmp_flg = true;

            if(lst_question1.SelectedItem == null)
            {
                tmp_flg = false;
            }
            if (lst_question2.SelectedItem == null)
            {
                tmp_flg = false;
            }
            if (lst_question3.SelectedItem == null)
            {
                tmp_flg = false;
            }
            if (lst_question4.SelectedItem == null)
            {
                tmp_flg = false;
            }
            if (lst_question5.SelectedItem == null)
            {
                tmp_flg = false;
            }
            if (lst_question6.SelectedItem == null)
            {
                tmp_flg = false;
            }
            if (lst_question7.SelectedItem == null)
            {
                tmp_flg = false;
            }
            if (lst_question8.SelectedItem == null)
            {
                tmp_flg = false;
            }
            if (lst_question9.SelectedItem == null)
            {
                tmp_flg = false;
            }
            if (lst_question10.SelectedItem == null)
            {
                tmp_flg = false;
            }

            return tmp_flg;
        }


    }
}

    

    
