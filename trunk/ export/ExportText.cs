using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Export.Content;
using org.in2bits.MyOle2;
using System.IO;

namespace Export
{
    public class ExportText : IExport
    {
        private Encoding _Encoding;
        /// <summary>
        /// 编码方式
        /// </summary>
        Encoding Encoding
        {
            get
            {
                if (_Encoding == null)
                {
                    _Encoding = Encoding.GetEncoding("gb2312");
                }
                return _Encoding;
            }
        }

        #region IExport 成员
        /// <summary>
        /// 需要导出的文档
        /// 所调用方法都以该文档为导出内容
        /// </summary>
        public MyDocument MyDoc
        {
            get;
            set;
        }

        /// <summary>
        /// 主输出内容
        /// </summary>
        private IContent Content
        {
            get;
            set;
        }

        public ExportText(MyDocument doc)
            : this(doc, null)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ExportText(MyDocument doc, string[] columnsName)
        {
            MyDoc = doc;
            Content = ContentFactory.CreateInstance(doc.Content, columnsName);
        }

        /// <summary>
        /// 向Excel打印标题
        /// </summary>
        private void PrintHeader(System.IO.Stream stream)
        {
            if (string.IsNullOrEmpty(MyDoc.HeaderText)) return;
            byte[] buff = Encoding.GetBytes(MyDoc.HeaderText+"\r\n");
            stream.Write(buff, 0, buff.Length);
        }

        /// <summary>
        /// 向Excel打印主内容
        /// </summary>
        private void PrintContent(System.IO.Stream stream)
        {
            string s = string.Empty;
            for (int i = 0; i < Content.RowsCount; i++)
            {
                for (int j = 0; j < Content.ColumnsCount; j++)
                {
                    object val = Content.GetValue(i, j);
                    s += string.Format("{0}\t", val);
                }
                s += "\r\n";
            }
            byte[] buff = Encoding.GetBytes(s);
            stream.Write(buff, 0, buff.Length);
        }

        /// <summary>
        /// 打印结尾
        /// </summary>
        private void PrintFooter(System.IO.Stream stream)
        {
            if (string.IsNullOrEmpty(MyDoc.FooterText)) return;
            byte[] buff = Encoding.GetBytes(MyDoc.FooterText + "\r\n");
            stream.Write(buff, 0, buff.Length);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="path"></param>
        public void Export(string path)
        {
            using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
            {
                PrintHeader(stream);
                PrintContent(stream);
                PrintFooter(stream);
            }
        }

        #endregion
    }
}
