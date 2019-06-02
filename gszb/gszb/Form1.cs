using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace gszb
{
    public partial class Form1 : Form
    {
        Class1.Ellipse _elsp = new Class1.Ellipse();
        Class1.Point pa = new Class1.Point();
        Class1 gszb = new Class1();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int i in this.listView1.SelectedIndices)
            {
                this.textBox8.Text = this.listView1.Items[i].SubItems[2].Text.ToString();
                this.textBox9.Text = this.listView1.Items[i].SubItems[3].Text.ToString();
            }
            foreach (int i in this.listView1.SelectedIndices)
            {
                this.textBox13.Text = this.listView1.Items[i].SubItems[2].Text.ToString();
                this.textBox17.Text = this.listView1.Items[i].SubItems[3].Text.ToString();
                this.textBox18.Text = this.listView1.Items[i].SubItems[4].Text.ToString();
             
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iPos = comboBox1.SelectedIndex;
            comboBox1.SelectedIndex = iPos;
             _elsp = gszb.SetEllipse(comboBox1.SelectedIndex);
            //获得当前椭球索引   
            textBox1.Text = _elsp.Name;
            textBox2.Text = _elsp._a.ToString("F4");
            textBox3.Text = _elsp._b.ToString("F6");
            textBox4.Text = _elsp._e2.ToString("F12");
            //计算扁率f             
            double _dzT = (_elsp._a - _elsp._b) / _elsp._a;
            textBox6.Text = _dzT.ToString("F9");
            _dzT = 1.0 / _dzT;
            string szf = "  ( 1/" + _dzT.ToString("F2") + " )";
            textBox6.Text += szf;
            //计算第一偏心率             
            _dzT = (Math.Pow(_elsp._a, 2) - Math.Pow(_elsp._b, 2)) / Math.Pow(_elsp._a, 2);
            textBox5.Text = _dzT.ToString("F12");
            //计算极曲率半径            
            _dzT = Math.Pow(_elsp._a, 2) / _elsp._b;
            textBox7.Text = _dzT.ToString("F4");
            richTextBox1.Text = Convert.ToString(_elsp._a) + '\n' + Convert.ToString(_elsp._b) + '\n' + Convert.ToString(_elsp._e1) + '\n' + Convert.ToString(_elsp._e2);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void button8_Click(object sender, EventArgs e)
        {

            OpenFileDialog oFD1 = new OpenFileDialog();
            oFD1.InitialDirectory = "c:\\";//显示的初始目录
            oFD1.Filter = "txt files(*.txt)|*.txt|All files(*.*)|*.*";//文件名筛选器字符串
            oFD1.FilterIndex = 2;
            oFD1.RestoreDirectory = true;
            if (oFD1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(oFD1.FileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] t1 = line.Split(',');
                        string _szStr = null;
                        ListViewItem lv = new ListViewItem(_szStr);  //新建一行表格 
                        lv.Text = (listView1.Items.Count + 1).ToString();   //修改首列显示字符串  

                        //Name
                        _szStr = t1[0].Trim();  //取得子字符串 
                        lv.SubItems.Add(_szStr);
                        //B
                        _szStr = t1[1].Trim();
                        lv.SubItems.Add(_szStr);
                        //L
                        _szStr = t1[2].Trim();
                        lv.SubItems.Add(_szStr);
                        //H
                        _szStr = t1[3].Trim();
                        lv.SubItems.Add(_szStr);

                        listView1.Items.Add(lv);  //将新建表格行添加到表格中  
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            _elsp = gszb.SetEllipse(comboBox1.SelectedIndex);
            double L0 = 117;
            double x = 0.0;
            double y = 0.0;
            double l = Convert.ToDouble(textBox8.Text);
            double b = Convert.ToDouble(textBox9.Text);
            Class1 l1 = new Class1();
            l1.zbzs(_elsp, l, b, L0, ref x, ref y);
            textBox11.Text = Convert.ToString(x);
            textBox12.Text = Convert.ToString(y);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            _elsp = gszb.SetEllipse(comboBox1.SelectedIndex);
            double L = 0.0;
            double B = 0.0;
            double x = Convert.ToDouble(textBox11.Text);
            double y = Convert.ToDouble(textBox12.Text);
            Class1 l2 = new Class1();
            l2.zbfs(_elsp, x, y, ref L, ref B);
            textBox8.Text = Convert.ToString(B);
            textBox9.Text = Convert.ToString(L);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(txt)|*.txt|所有文件(*.*)|*.*";
            string sepatator = ",";
            char[] cgap = sepatator.ToCharArray();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                StreamReader sr1 = new StreamReader(fs, Encoding.ASCII);
                string[][] s = new string[999][];
                for (int i = 0; i < 9999; i++)
                {
                    string str1 = sr1.ReadLine();
                    if (str1 == null)
                        break;
                    string[] str2 = str1.Split(cgap, StringSplitOptions.None);
                    ListViewItem b = new ListViewItem(new string[] { str2[0], str2[1], str2[2], str2[3], str2[4] });
                    listView1.Items.Add(b);
                    s[i] = str2;
                }
            }
        }
       
        //录入按钮
        //private void button1_Click_1(object sender, EventArgs e)
        //{

        //    ListViewItem lvi = addListView();
        //    this.listView1.Items.Add(lvi);
        //    this.listView1.Refresh();
        //}
        //private ListViewItem addListView()
        //{
        //    ListViewItem lvi = new ListViewItem((listView1.Items.Count + 1) + " ");
        //    //依次录入序号
        //    lvi.SubItems.Add(this.textBox14.Text);//录入点名
        //    lvi.SubItems.Add(this.textBox15.Text);//录入经度
        //    lvi.SubItems.Add(this.textBox16.Text);//录入纬度
        //    lvi.SubItems.Add(this.textBox10.Text);//录入高程
        //    lvi.EnsureVisible();//显示最新的录入内容
        //    return lvi;

        //}

        private void button2_Click(object sender, EventArgs e)
        {          
            pa.B = Convert.ToDouble(textBox13.Text);
            pa.L = Convert.ToDouble(textBox17.Text);
            pa.H = Convert.ToDouble(textBox18.Text);
            _elsp = gszb.SetEllipse(comboBox1.SelectedIndex);
            Class1 l3 = new Class1();
            l3.ddzkj(_elsp, pa);
            textBox19.Text = Convert.ToString(pa.x);
            textBox20.Text = Convert.ToString(pa.y);
            textBox21.Text = Convert.ToString(pa.z);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pa.x = Convert.ToDouble(textBox19.Text);
            pa.y = Convert.ToDouble(textBox20.Text);
            pa.z = Convert.ToDouble(textBox21.Text);
            _elsp = gszb.SetEllipse(comboBox1.SelectedIndex);
            Class1 l4 = new Class1();
            l4.kjzdd(_elsp, pa);
            textBox13.Text = Convert.ToString(pa.B);
            textBox17.Text = Convert.ToString(pa.L);
            textBox18.Text = Convert.ToString(pa.H);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        } 
    }
}