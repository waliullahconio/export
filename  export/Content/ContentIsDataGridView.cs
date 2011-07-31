using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Export.Content
{
    /// <summary>
    /// DataGridView的主内容
    /// </summary>
    public class ContentIsDataGridView : IContent
    {
        /// <summary>
        /// DataGridView
        /// </summary>
        public DataGridView Dgv
        {
            get
            {
                return ContentObj as DataGridView;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dgv"></param>
        public ContentIsDataGridView(object dgv)
        {
            ContentObj = dgv;
        }
        

        #region IContent 成员
        /// <summary>
        /// 列数
        /// </summary>
        public int ColumnsCount
        {
            get
            {
                return Dgv.Columns.Count;
            }
        }

        /// <summary>
        /// 行数
        /// </summary>
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
        /// <summary>
        /// 主内容
        /// </summary>
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

        /// <summary>
        /// 通过索引获取主内容中的值
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
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
