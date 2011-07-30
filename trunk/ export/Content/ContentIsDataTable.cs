using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Export.Content
{
    public class ContentIsDataTable : IContent
    {
        public DataTable Dt
        {
            get
            {
                return ContentObj as DataTable;
            }
        }

        public ContentIsDataTable(object dt)
        {
            ContentObj = dt;
        }

        #region IContent 成员

        public int ColumnsCount
        {
            get { return Dt.Columns.Count; }
        }

        public int RowsCount
        {
            get { return Dt.Rows.Count; }
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
                if (value is DataTable)
                {
                    _ContentObj = value;
                }
                else
                {
                    throw new ArgumentException("参数只能是DataTable");
                }
            }
        }

        public object GetValue(int rowIndex, int columnIndex)
        {
            if (rowIndex == 0)
            {
                return Dt.Columns[columnIndex].ColumnName;
            }
            return Dt.Rows[rowIndex - 1][columnIndex];
        }

        #endregion
    }
}
