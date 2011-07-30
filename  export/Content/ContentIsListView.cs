using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Export.Content
{
    class ContentIsListView : IContent
    {
        public ListView Lv
        {
            get
            {
                return ContentObj as ListView;
            }
        }

        public ContentIsListView(object lv)
        {
            ContentObj = lv;
        }

        #region IContent 成员

        public int ColumnsCount
        {
            get {
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
            if (rowIndex == 0)
            {
                return Lv.Columns[columnIndex].Text;
            }
            return Lv.Items[rowIndex - 1].SubItems[columnIndex].Text;
        }

        #endregion
    }
}
