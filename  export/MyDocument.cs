using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Export
{
    /// <summary>
    /// 导出配置类
    /// </summary>
    public class MyDocument
    {
        /// <summary>
        /// 导出的文件名称
        /// </summary>
        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// 标题文字
        /// </summary>
        public string HeaderText
        {
            get;
            set;
        }

        private int _HeaderSize = 20;
        /// <summary>
        /// 标题大小
        /// </summary>
        public int HeaderSize
        {
            get { return _HeaderSize; }
            set { _HeaderSize = value; }
        }

        /// <summary>
        /// 结尾文字
        /// </summary>
        public string FooterText
        {
            get;
            set;
        }

        private int _FooterSize = 9;
        /// <summary>
        /// 结尾文字大小
        /// </summary>
        public int FooterSize
        {
            get { return _FooterSize; }
            set { _FooterSize = value; }
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

        /// <summary>
        /// 根据列数组导出
        /// </summary>
        /// <param name="path"></param>
        /// <param name="exportColumns"></param>
        public void Export(string path, string[] exportColumns)
        {
            if (string.IsNullOrEmpty(path))
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel文件|*.xls|Pdf文件|*.pdf|文本文件|*.txt";
                save.FileName = this.FileName;
                save.AddExtension = true;
                if (save.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                path = save.FileName;
            }
            IExport export = ExportFactory.CreateInstance(path, this, exportColumns);
            export.Export(path);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="type"></param>
        /// <param name="path"></param>
        public void Export(string path)
        {
            Export(path, null);
        }

        /// <summary>
        /// 导出
        /// </summary>
        public void Export()
        {
            Export(null, null);
        }
    }

    public enum ExportType
    { 
        Xls,
        Pdf,
        Txt,
    }
}
