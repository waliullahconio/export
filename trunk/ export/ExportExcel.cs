using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.in2bits.MyXls;
using System.Windows.Forms;
using Export.Content;
using System.IO;

namespace Export
{
    public class ExportExcel : IExport
    {
        #region 属性或字段
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
        /// 记录导出数据时当前游标
        /// </summary>
        private int Cursor;

        /// <summary>
        /// 导出的Excel文档
        /// 将MyDoc的内容转换为要导出的该对象,即生成的Excel
        /// (可将该对象视为内存中的Excel实现)
        /// </summary>
        private XlsDocument XlsDoc;

        /// <summary>
        /// 当前导出的WorkSheet
        /// </summary>
        private Worksheet CurSheet;

        /// <summary>
        /// 当前WorkSheet所包含的Cells
        /// </summary>
        private Cells Cells
        {
            get
            {
                return CurSheet.Cells;
            }
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
        #endregion

        /// <summary>
        /// 构造函数
        /// 初始化_XlsDoc对象
        /// </summary>
        public ExportExcel(MyDocument doc)
        {
            MyDoc = doc;
            XlsDoc = new XlsDocument();
            string sheetName = string.Format("{0}", MyDoc.DocName);
            sheetName = string.IsNullOrEmpty(sheetName) ? "sheet1" : sheetName;
            CurSheet = XlsDoc.Workbook.Worksheets.Add(sheetName);
        }

        /// <summary>
        /// 向Excel打印标题
        /// </summary>
        private void PrintHeader()
        {
            if (string.IsNullOrEmpty(MyDoc.HeaderText)) return;
            XF xf = XlsDoc.NewXF();
            xf.Font.Bold = true;
            xf.Font.Height = (ushort)(20 * MyDoc.HeaderSize);//因为字体大小是以1/20point为单位，所以乘以20
            xf.HorizontalAlignment = HorizontalAlignments.Centered;
            Cells.Add(Cursor + 1, 1, MyDoc.HeaderText, xf);//Cursor所以起始为0，而Excel其实索引为1，故+1
            CurSheet.AddMergeArea(new MergeArea(Cursor + 1, Cursor + 1, 1, Content.ColumnsCount));//理由同上
            Cursor++;
        }

        /// <summary>
        /// 向Excel打印主内容
        /// </summary>
        private void PrintContent()
        {
            XF xf = XlsDoc.NewXF();
            xf.Font.Height = 12 * 20;
            for (int i = 0; i < Content.RowsCount; i++)
            {
                for (int j = 0; j < Content.ColumnsCount; j++)
                {
                    object val = Content.GetValue(i, j);
                    Cells.Add(Cursor + 1, j + 1, string.Format("{0}", val, xf));
                }
                Cursor++;
            }
        }

        /// <summary>
        /// 打印结尾
        /// </summary>
        private void PrintFooter()
        {
            if (string.IsNullOrEmpty(MyDoc.FooterText)) return;
            XF xf = XlsDoc.NewXF();
            xf.Font.Bold = true;
            xf.Font.Height = (ushort)(20 * MyDoc.FooterSize);
            xf.HorizontalAlignment = HorizontalAlignments.Centered;
            Cells.Add(Cursor + 1, 1, MyDoc.FooterText, xf);
            CurSheet.AddMergeArea(new MergeArea(Cursor + 1, Cursor + 1, 1, Content.ColumnsCount));
            Cursor++;
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="path"></param>
        public void Export(string path)
        {
            PrintHeader();
            PrintContent();
            PrintFooter();
            ColumnInfo colInfo = new ColumnInfo(XlsDoc, CurSheet);
            colInfo.ColumnIndexStart = 0;
            colInfo.ColumnIndexEnd = (ushort)(Content.ColumnsCount - 1);
            colInfo.Width = 256 * 15;
            CurSheet.AddColumnInfo(colInfo);
            XlsDoc.FileName = Path.GetFileName(path);
            XlsDoc.Save(Path.GetDirectoryName(path), true);
        }
    }
}
