using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using System.IO;
namespace report
{
    public partial class Form1 : Form
    {
        string From_date;
        string From_date2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           this.reportViewer1.RefreshReport();
        }

        private void search_Click(object sender, EventArgs e)
        {
            search_text();
        }

        private void search_text()
        {
                From_date = date1.Value.ToString("dd/MM/yyyy");
                From_date2 = date2.Value.ToString("dd/MM/yyyy");
                string value = "";
                this.report_hanheldTableAdapter.Fill(this.DataSet1.report_hanheld, in_part.Text, in_srct.Text, in_dock.Text, in_user.Text, value, From_date, From_date2);
                this.reportViewer1.RefreshReport();
                From_date = "0";

                if (rd_complete.Checked == true)
                {
                    From_date = date1.Value.ToString("dd/MM/yyyy");
                    From_date2 = date2.Value.ToString("dd/MM/yyyy");
                    string error = "complete";
                    this.report_hanheldTableAdapter.Fill(this.DataSet1.report_hanheld, in_part.Text, in_srct.Text, in_dock.Text, in_user.Text, error, From_date, From_date2);
                    this.reportViewer1.RefreshReport();
                    From_date = "0";
                    return;
                }
                else if (rd_error.Checked == true)
                {
                    From_date = date1.Value.ToString("dd/MM/yyyy");
                    From_date2 = date2.Value.ToString("dd/MM/yyyy");
                    string error = "error";
                    this.report_hanheldTableAdapter.Fill(this.DataSet1.report_hanheld, in_part.Text, in_srct.Text, in_dock.Text, in_user.Text, error, From_date, From_date2);
                    this.reportViewer1.RefreshReport();
                    From_date = "0";
                    return;
                   
                }
                else
                {
                    From_date = date1.Value.ToString("dd/MM/yyyy");
                    From_date2 = date2.Value.ToString("dd/MM/yyyy");
                    string error="" ;
                    this.report_hanheldTableAdapter.Fill(this.DataSet1.report_hanheld, in_part.Text, in_srct.Text, in_dock.Text, in_user.Text, error, From_date, From_date2);
                    this.reportViewer1.RefreshReport();
                    From_date = "0";
                    return;
                }
           
        }

        private void clear_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("คุณต้องการจะเคลียร์ข้อมูลหรือไม่ ", "Report Hanheld", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    reportViewer1.Clear();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            catch { }
            
          
        }
    }
}
