using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using Export.Content;
using iTextSharp.text.pdf;
using System.IO;

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

        /// <summary>
        /// 基字体
        /// </summary>
        private BaseFont BaseFont
        {
            get;
            set;
        }

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

        public ExportPdf(MyDocument doc)
        {
            MyDoc = doc;
        }

        private void Init(string path)
        {
            PdfDoc = new Document();
            PdfWriter.getInstance(PdfDoc, new FileStream(path, FileMode.Create));
            PdfDoc.Open();
            string fontPath = System.IO.Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.System)).FullName + "\\fonts\\simhei.ttf";
            BaseFont = BaseFont.createFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        }

        private void Exit()
        {
            if (!PdfDoc.isOpen())
            {
                return;
            }
            PdfDoc.Close();
            PdfDoc = null;
        }

        /// <summary>
        /// 打印头信息
        /// </summary>
        private void PrintHeader(string path)
        {
            if (string.IsNullOrEmpty(MyDoc.HeaderText)) return;
            Font font = new Font(BaseFont, MyDoc.HeaderSize);
            Paragraph p = new Paragraph(MyDoc.HeaderText, font);
            p.Alignment = Element.ALIGN_CENTER;
            PdfDoc.Add(p);
        }

        /// <summary>
        /// 打印主内容
        /// </summary>
        private void PrintContent()
        {
            PdfPTable pdfTable = new PdfPTable(Content.ColumnsCount);
            pdfTable.WidthPercentage = 110;
            Font font = new Font(BaseFont, 9);
            for (int i = 0; i < Content.RowsCount; i++)
            {
                for (int j = 0; j < Content.ColumnsCount; j++)
                {
                    Paragraph par = new Paragraph(string.Format("{0}", Content.GetValue(i, j)), font);
                    pdfTable.addCell(par);
                }
            }
            PdfDoc.Add(pdfTable);
        }

        /// <summary>
        /// 打印结尾
        /// </summary>
        private void PrintFooter()
        {
            if (string.IsNullOrEmpty(MyDoc.FooterText)) return;
            Font font = new Font(BaseFont, MyDoc.FooterSize);
            Paragraph p = new Paragraph(MyDoc.FooterText, font);
            p.Alignment = Element.ALIGN_CENTER;
            PdfDoc.Add(p);
        }

        #region IExport 成员
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="path"></param>
        public void Export(string path)
        {
            Init(path);
            PrintHeader(path);
            PrintContent();
            PrintFooter();
            Exit();
        }

        #endregion
    }
}
