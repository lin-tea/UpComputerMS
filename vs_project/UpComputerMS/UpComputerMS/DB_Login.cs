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
    public partial class DB_Login : UserControl
    {
        public static int id = 0;
        public string strDataBaseName = "";
        public string strDataTableName = "";
        private string account = "";
        public string password = "";
        public string account_Re = "";
        public string password_Re = "";
        public string password_Co = "";
        public string current_user = "";

        public DB_Login()
        {
            InitializeComponent();
        }

        private void Button_Login_Click(object sender, EventArgs e)
        {
            account = this.Account.Text.Trim();
            password = this.Password.Text.Trim();
            if (account.Equals("") || password.Equals(""))//用户名或密码为空
            {
                MessageBox.Show("用户名或密码不能为空");
            }
            else
            {
                String connetStr = "server=127.0.0.1;port=3306;user=root;password=123456; database=teammates;";
            //创建数据库连接
            MySqlConnection con = new MySqlConnection(connetStr);
            //打开连接
            con.Open();
   
            String sql = string.Format("select id from information where account='{0}' and passcode='{1}';", account, password);
            // 创建MySqlCommand对象
            MySqlCommand mySqlCommand = new MySqlCommand(sql, con);
            // 执行查询操作，获取查询结果
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            // 遍历查询结果
            while (mySqlDataReader.Read())
            {
                id = mySqlDataReader.GetInt32("id");
                Console.WriteLine("{0}", id);
            }
                
                //关闭数据读取器
                con.Close();
                

                //con.Open();
                //string now = System.DateTime.Now.ToString();
                //String insert = string.Format("insert into using_inf values ({0},'{1}');", id, now);
                //MySqlCommand mycmd1 = new MySqlCommand(insert, con);
                //mycmd1.ExecuteNonQuery();



                if (id!=0)
                {
                    
                    MessageBox.Show("成功登录");
                    if(MainForm.frm2!=null) MainForm.frm2.cur_user.Text = account.ToString();
                    
                }
                else
                {
                    MessageBox.Show("账号或密码错误");
                }
            }


        }

        private void Register_Click(object sender, EventArgs e)
        {
            string Text_account = "";
            string Text_password = "";
            string Text_password_com = "";
            Text_account = this.text_account.Text.Trim();
            Text_password = this.text_psaaword.Text.Trim();
            Text_password_com = this.text_password_com.Text.Trim();
            int a = Text_account.Length;
            int b = Text_password.Length;
            if (a >= 15)
            {
                MessageBox.Show("账号长度必须小于15");
            }
            else if (b >= 15)
            {
                MessageBox.Show("密码长度必须小于15");
            }
            else if (Text_password != Text_password_com)
            {
                MessageBox.Show("前后密码不相同");
            }
            else
            {
                String connetStr = "server=127.0.0.1;port=3306;user=root;password=123456; database=teammates;";
                try
                {

                    MySqlConnection re_con = new MySqlConnection(connetStr);

                    re_con.Open();
                    String re_insert = string.Format("insert into information(account,passcode) values ('{0}','{1}');", Text_account, Text_password);
                    MySqlCommand re_mycmd1 = new MySqlCommand(re_insert, re_con);
                    if (re_mycmd1.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("注册成功");
                        
                    }

                }

                catch
                //关闭数据读取器
                {
                    MessageBox.Show("该账号已注册");

                    
                }
            }
        }
    }
}
