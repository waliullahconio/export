using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Export.Content
{
    /// <summary>
    /// DataGridView的主内容
    /// </summary>
    public class ContentIsDataGridView : IContent
    {
        /// <summary>
        /// 显示的列
        /// </summary>
        public Dictionary<int,int> VisibleColumnsMap
        {
            get;
            set;
        }

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
            VisibleColumnsMap = new Dictionary<int, int>();
            int f = 0;
            for (int i = 0; i < Dgv.Columns.Count; i++)
            {
                if (Dgv.Columns[i].Visible)
                {
                    VisibleColumnsMap.Add(f, i);
                    f++;
                }
            }
        }
        
        #region IContent 成员
        private int _ColumnsCount;
        /// <summary>
        /// 列数
        /// </summary>
        public int ColumnsCount
        {
            get
            {
                if (_ColumnsCount == 0)
                {
                    int count = 0;
                    for (int i = 0; i < Dgv.Columns.Count; i++)
                    {
                        if (Dgv.Columns[i].Visible == true)
                        {
                            count++;
                        }
                    }
                    _ColumnsCount = count;
                }
                return _ColumnsCount;
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
                return Dgv.Rows.Count;
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
                return Dgv.Columns[VisibleColumnsMap[columnIndex]].HeaderText;
            }
            return Dgv.Rows[rowIndex - 1].Cells[VisibleColumnsMap[columnIndex]].FormattedValue;
        }

        #endregion
    }
}
