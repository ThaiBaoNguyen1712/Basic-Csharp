using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_NguyenThaiBao_K17CNTT
{
    public partial class FrmPrint : Form
    {
        public FrmPrint()
        {
            InitializeComponent();
        }
        public FrmPrint(int MaHD)
        {
            InitializeComponent();
            DoAnTBao.print_HDDataTable b = new DoAnTBao.print_HDDataTable();
            DoAnTBaoTableAdapters.print_HDTableAdapter a = new DoAnTBaoTableAdapters.print_HDTableAdapter();
            b.Reset();
            a.Fill(b, MaHD);

            Print_HD rp = new  Print_HD();
            rp.SetDataSource((DataTable)b);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.RefreshReport();


        }
    }
}
