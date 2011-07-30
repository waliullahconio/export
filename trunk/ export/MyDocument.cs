using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Export
{
    /// <summary>
    /// 导出配置类
    /// </summary>
    public class MyDocument
    {
        /// <summary>
        /// 标题文字
        /// </summary>
        public string HeaderText
        {
            get;
            set;
        }

        /// <summary>
        /// 标题大小
        /// </summary>
        public int HeaderSize
        {
            get;
            set;
        }

        /// <summary>
        /// 结尾文字
        /// </summary>
        public string FooterText
        {
            get;
            set;
        }

        /// <summary>
        /// 结尾文字大小
        /// </summary>
        public int FooterSize
        {
            get;
            set;
        }

        /// <summary>
        /// 是否导出时间
        /// </summary>
        public bool IsPrintTime
        {
            get;
            set;
        }

        /// <summary>
        /// 文档名称
        /// </summary>
        public string DocName
        {
            get;
            set;
        }

        /// <summary>
        /// 要导出的内容
        /// </summary>
        public object Content
        {
            get;
            set;
        }

        public void Export(ExportType type, string path)
        {
            IExport export = ExportFactory.CreateInstance(type, this);
            export.Export(path);
        }
    }

    public enum ExportType
    { 
        Xls,
        Pdf,
    }
}
