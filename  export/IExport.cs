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
        /// 需要导出文档
        /// </summary>
        MyDocument MyDoc
        {
            get;
            set;
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="path"></param>
        void Export(string path);
    }
}
