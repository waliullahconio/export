using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Export.Content
{
    class ContentIsListView : IContent
    {
        /// <summary>
        /// 需要导出列的列名
        /// </summary>
        public string[] NeedColumnsName
        {
            get;
            set;
        }

        public ListView Lv
        {
            get
            {
                return ContentObj as ListView;
            }
        }

        public ContentIsListView(object lv)
            : this(lv, null)
        {

        }

        public ContentIsListView(object lv,string[] columnsName)
        {
            ContentObj = lv;
            NeedColumnsName = columnsName;
        }

        #region IContent 成员

        public int ColumnsCount
        {
            get {
                if (NeedColumnsName != null && NeedColumnsName.Length != 0)
                    return NeedColumnsName.Length;
                return Lv.Columns.Count;
            }
        }

        public int RowsCount
        {
            get {
                return Lv.Items.Count + 1;
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
                    throw new ArgumentException("参数只能是ListView");
                }
            }
        }

        public object GetValue(int rowIndex, int columnIndex)
        {
            /* 由于行数包含了列头
             * 所以rowIndex为0时指向列头文本*/
            if (NeedColumnsName != null && NeedColumnsName.Length != 0)
            {
                if (rowIndex == 0)
                {
                    return Lv.Columns[NeedColumnsName[columnIndex]].Text;
                }
                return Lv.Items[rowIndex - 1].SubItems[NeedColumnsName[columnIndex]].Text;
            }
            else
            {
                if (rowIndex == 0)
                {
                    return Lv.Columns[columnIndex].Text;
                }
                return Lv.Items[rowIndex - 1].SubItems[columnIndex].Text;
            }
        }

        #endregion
    }
}
