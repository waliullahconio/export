using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Export.Content
{
    public class ContentIsDataTable : IContent
    {
        /// <summary>
        /// 需要导出列的列名
        /// </summary>
        public string[] NeedColumnsName
        {
            get;
            set;
        }

        public DataTable Dt
        {
            get
            {
                return ContentObj as DataTable;
            }
        }

        public ContentIsDataTable(object dt)
            : this(dt, null)
        { 
            
        }

        public ContentIsDataTable(object dt,string[] columnsName)
        {
            ContentObj = dt;
            NeedColumnsName = columnsName;
        }

        #region IContent 成员

        public int ColumnsCount
        {
            get {
                if (NeedColumnsName != null && NeedColumnsName.Length != 0)
                    return NeedColumnsName.Length;
                return Dt.Columns.Count; 
            }
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
            if (NeedColumnsName != null && NeedColumnsName.Length != 0)
            {
                if (rowIndex == 0)
                {
                    return Dt.Columns[NeedColumnsName[columnIndex]].ColumnName;
                }
                return Dt.Rows[rowIndex - 1][NeedColumnsName[columnIndex]];
            }
            else
            {
                if (rowIndex == 0)
                {
                    return Dt.Columns[columnIndex].ColumnName;
                }
                return Dt.Rows[rowIndex - 1][columnIndex];
            }
        }

        #endregion
    }
}
