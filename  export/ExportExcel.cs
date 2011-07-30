using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.in2bits.MyXls;
using System.Windows.Forms;

namespace Export
{
    public class ExportExcel : IExport
    {
        public static ExportExcel Current = new ExportExcel();

        #region IExport 成员

        public void FromDataGridView(System.Windows.Forms.DataGridView dgv, string path,Config config)
        {
            XlsDocument xls = new XlsDocument();
            Worksheet sheet = xls.Workbook.Worksheets.Add("sheet1");
            Cells cells = sheet.Cells;
            int cursor = 0;
            int rows = dgv.Rows.Count;
            int columns = dgv.Columns.Count;

            //打印Config.HeaderText
            if (config != null && !string.IsNullOrEmpty(config.HeaderText))
            {
                XF xfHeader = xls.NewXF();
                xfHeader.Font.Bold = true;
                xfHeader.Font.Height = (ushort)(20 * config.HeaderSize);
                xfHeader.HorizontalAlignment = HorizontalAlignments.Centered;
                Cell cell = cells.Add(cursor + 1, 1, config.HeaderText, xfHeader);
                sheet.AddMergeArea(new MergeArea(1, 1, 1, columns + 1));
                cursor++;
            }

            //列头
            XF xfColumnHead = xls.NewXF();
            xfColumnHead.Font.Bold = true;
            xfColumnHead.CellLocked = true;
            xfColumnHead.Font.Height = 20 * 12;
            for (int i = 0; i < dgv.Columns.Count;i++ )
            {
                Cell c = cells.Add(cursor + 1, i + 1, dgv.Columns[i].HeaderText, xfColumnHead);
            }
            cursor++;

            //数据
            XF xfCell = xls.NewXF();
            xfCell.Font.Height = 12 * 20;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    int row = cursor + 1;
                    int column = j + 1;
                    cells.Add(row, column, string.Format("{0}", dgv.Rows[i].Cells[j].Value), xfCell);
                }
                cursor++;
            }

            //打印结尾
            if (config != null && !string.IsNullOrEmpty(config.FooterText))
            {
                XF xfFooter = xls.NewXF();
                xfFooter.Font.Bold = true;
                xfFooter.Font.Height = (ushort)(20 * config.FooterSize);
                xfFooter.HorizontalAlignment = HorizontalAlignments.Centered;
                Cell cell = cells.Add(cursor + 1, 1, config.FooterText, xfFooter);
                sheet.AddMergeArea(new MergeArea(1, 1, 1, columns + 1));
                cursor++;
            }

            //设定列宽
            ColumnInfo colInfo = new ColumnInfo(xls, sheet);
            colInfo.ColumnIndexStart = 0;
            colInfo.ColumnIndexEnd = (ushort)dgv.Columns.Count;
            colInfo.Width = 256 * 15;
            sheet.AddColumnInfo(colInfo);
            xls.Save(path, true);
        }

        public void FromListView(System.Windows.Forms.ListView lv, string path)
        {
            XlsDocument xls = new XlsDocument();
            Worksheet sheet = xls.Workbook.Worksheets.Add("sheet1");
            Cells cells = sheet.Cells;
            //表头
            XF xfHead = xls.NewXF();
            xfHead.Font.Bold = true;
            xfHead.CellLocked = true;
            for (int i = 0; i < lv.Columns.Count; i++)
            {
                Cell c = cells.Add(1, i + 1, lv.Columns[i].Text, xfHead);
            }

            //数据
            XF xfCell = xls.NewXF();
            for (int i = 0; i < lv.Items.Count; i++)
            {
                for (int j = 0; j < lv.Columns.Count; j++)
                {
                    int row = i + 2;
                    int column = j + 1;
                    cells.Add(row, column, string.Format("{0}", lv.Items[i].SubItems[j].Text), xfCell);
                }
            }
            xls.Save(path, true);
        }

        public void FromDataTable(System.Data.DataTable dt, string path)
        {
            XlsDocument xls = new XlsDocument();
            Worksheet sheet = xls.Workbook.Worksheets.Add("sheet1");
            Cells cells = sheet.Cells;

            //数据
            XF xfCell = xls.NewXF();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    int row = i + 1;
                    int column = j + 1;
                    cells.Add(row, column, string.Format("{0}", dt.Rows[i][j]), xfCell);
                }
            }
            xls.Save(path, true);
        }

        #endregion
    }
}
