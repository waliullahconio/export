using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Export.Content
{
    public class ContentIsDataGridView : IContent
    {
        public DataGridView Dgv
        {
            get
            {
                return ContentObj as DataGridView;
            }
        }

        public ContentIsDataGridView(object dgv)
        {
            ContentObj = dgv;
        }
        

        #region IContent 成员

        public int ColumnsCount
        {
            get
            {
                return Dgv.Columns.Count;
            }
        }

        public int RowsCount
        {
            get
            {
                //由于DataGridView包含一行列头文本
                //所以在行数上+1
                return Dgv.Rows.Count + 1;
            }
        }

        private object _ContentObj;
        public object ContentObj
        {
            get
            {
                return _ContentObj;
            }
            set
            {
                if (value is DataGridView)
                {
                    _ContentObj = value;
                }
                else
                {
                    throw new ArgumentException("参数只能是DataGridView");
                }
            }
        }

        public object GetValue(int rowIndex, int columnIndex)
        {
            /* 由于行数包含了列头
             * 所以rowIndex为0时指向列头文本*/
            if (rowIndex == 0)
            {
                return Dgv.Columns[columnIndex].HeaderText;
            }
            return Dgv.Rows[rowIndex - 1].Cells[columnIndex].Value;
        }

        #endregion
    }
}
