using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
namespace Export
{
    public interface IExport
    {
        /// <summary>
        /// 将DataGridView里面的数据导出
        /// </summary>
        /// <param name="dgv"></param>
        void FromDataGridView(DataGridView dgv, string path, Config config);
        /// <summary>
        /// 将ListView里面的数据导出
        /// </summary>
        /// <param name="lv"></param>
        void FromListView(ListView lv, string path);
        /// <summary>
        /// 将DataTable里面的数据导出
        /// </summary>
        /// <param name="dt"></param>
        void FromDataTable(DataTable dt, string path);
    }
}
