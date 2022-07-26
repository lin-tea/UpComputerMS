using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace UpComputerMS
{
    public partial class DBLogForm : Form
    {
        public DBLogForm()
        {
            InitializeComponent();
        }

        private void DBLogForm_Load(object sender, EventArgs e)
        {
            int ac_id = DB_Login.id;
            String enter = "server=127.0.0.1;port=3306;user=root;password=123456; database=teammates;";
            MySqlConnection con = new MySqlConnection(enter);
            //打开连接
            con.Open();
            String check_max = string.Format("select count(*) from using_inf group by id having id='{0}';", ac_id);
            MySqlCommand check = new MySqlCommand(check_max, con);
            int c = Convert.ToInt32(check.ExecuteScalar());


            // 创建MySqlCommand对象

            // 执行查询操作，获取查询结果


            // 遍历查询结果
            int d = 0;
            con.Close();
            con.Open();
            String sql = string.Format("select id,using_time from using_inf where id ='{0}' order by using_time;", ac_id);
            MySqlCommand mySqlCommand = new MySqlCommand(sql, con);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();


            int[] num1 = new int[c];
            string[] num2 = new string[c];
            while (mySqlDataReader.Read())
            {
                num1[d] = mySqlDataReader.GetInt32("id");
                num2[d] = mySqlDataReader.GetString("using_time");
                Console.WriteLine("{0}", num1[d]);
                Console.WriteLine("{0}", num2[d]);
                d++;
            }
            con.Close();

            int l;
            int j = 1;
            listBox1.Items.Insert(0, "共" + c + "条使用记录");
            for (l = 0; l < c; l++)
            {
                listBox1.Items.Insert(0, "第" + j + "条使用记录" + "使用时间为" + num2[l]);
                j++;
            }
        }


        private void button_date_delete_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            int ac_id = DB_Login.id;
            string date = this.date.Text;

            String enter = "server=127.0.0.1;port=3306;user=root;password=123456; database=teammates;";
            MySqlConnection con = new MySqlConnection(enter);
            //打开连接
            con.Open();
            String sql1 = string.Format("select using_id from using_inf where id='{0}' and using_time='{1}';", ac_id, date);
            // 创建MySqlCommand对象
            MySqlCommand mySqlCommand1 = new MySqlCommand(sql1, con);
            // 执行查询操作，获取查询结果
            MySqlDataReader mySqlDataReader1 = mySqlCommand1.ExecuteReader();
            // 遍历查询结果
            int using_id = 0;
            while (mySqlDataReader1.Read())
            {
                using_id = mySqlDataReader1.GetInt32("using_id");
                Console.WriteLine("{0}", using_id);
            }
            con.Close();
            try
            {
                con.Open();
                String delete_data = string.Format("delete from chips where using_id='{0}';", using_id);
                MySqlCommand re_mycmd2 = new MySqlCommand(delete_data, con);

                if (re_mycmd2.ExecuteNonQuery() != 0)
                {
                    con.Close();
                    con.Open();
                    String delete_date = string.Format("delete from using_inf where using_id='{0}';", using_id);
                    MySqlCommand re_mycmd1 = new MySqlCommand(delete_date, con);
                    if (re_mycmd1.ExecuteNonQuery() == 1)
                    {
                        con.Close();
                        MessageBox.Show("删除成功");

                    }
                    else
                    {
                        MessageBox.Show("该日期无用户数据");
                    }
                }
                else
                {
                    MessageBox.Show("该日期无用户数据");
                }
            }
            catch
            {
                MessageBox.Show("删除失败");

            }
            con.Close();
            con.Open();
            String check_max = string.Format("select count(*) from using_inf group by id having id='{0}';", ac_id);
            MySqlCommand check = new MySqlCommand(check_max, con);
            int c = Convert.ToInt32(check.ExecuteScalar());


            // 创建MySqlCommand对象

            // 执行查询操作，获取查询结果


            // 遍历查询结果
            int d = 0;
            con.Close();
            con.Open();
            String sql = string.Format("select id,using_time from using_inf where id ='{0}' order by using_time;", ac_id);
            MySqlCommand mySqlCommand = new MySqlCommand(sql, con);
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();


            int[] num1 = new int[c];
            string[] num2 = new string[c];
            while (mySqlDataReader.Read())
            {
                num1[d] = mySqlDataReader.GetInt32("id");
                num2[d] = mySqlDataReader.GetString("using_time");
                Console.WriteLine("{0}", num1[d]);
                Console.WriteLine("{0}", num2[d]);
                d++;
            }
            con.Close();

            int l;
            int j = 1;
            listBox1.Items.Insert(0, "共" + c + "条使用记录");
            for (l = 0; l < c; l++)
            {
                listBox1.Items.Insert(0, "第" + j + "条使用记录" + "使用时间为" + num2[l]);
                j++;
            }
        }
    }
}
