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
    public partial class FrmprintLoaiSP : Form
    {
        public FrmprintLoaiSP()
        {
            InitializeComponent();
            DoAnTBao.print_LoaiSPDataTable b= new DoAnTBao.print_LoaiSPDataTable();
            DoAnTBaoTableAdapters.print_LoaiSPTableAdapter a = new DoAnTBaoTableAdapters.print_LoaiSPTableAdapter();
            b.Reset();
            a.Fill(b);
            Rpt_print_LoaiSP rp = new Rpt_print_LoaiSP();
            rp.SetDataSource((DataTable)b);
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.RefreshReport();
        }
      
      
    }
}
