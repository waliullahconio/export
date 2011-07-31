using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using Export.Content;

namespace Export
{
    /// <summary>
    /// 导出Pdf类
    /// </summary>
    public class ExportPdf : IExport
    {
        /// <summary>
        /// 需要导出的文档
        /// </summary>
        public MyDocument MyDoc
        {
            get;
            set;
        }

        /// <summary>
        /// 记录导出数据时当前游标
        /// </summary>
        private int Cursor;

        /// <summary>
        /// 导出的Pdf文档
        /// 将MyDoc的内容转换为要导出的该对象,即生成的Pdf
        /// (可将该对象视为内存中的Pdf实现)
        /// </summary>
        private Document PdfDoc;

        private IContent _Content;
        /// <summary>
        /// 主输出内容
        /// </summary>
        private IContent Content
        {
            get
            {
                if (_Content == null)
                {
                    _Content = ContentFactory.CreateInstance(MyDoc.Content);
                }
                return _Content;
            }
        }

        #region IExport 成员

        public void Export(string path)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
