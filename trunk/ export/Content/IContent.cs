using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Export.Content
{
    /// <summary>
    /// 文档所要导出的主内容
    /// 内容为表格形式
    /// </summary>
    public interface IContent
    {
        /// <summary>
        /// 需要导出列的列名
        /// </summary>
        string[] NeedColumnsName
        {
            get;
            set;
        }

        /// <summary>
        /// 内容所包含的列数
        /// </summary>
        int ColumnsCount
        {
            get;
        }

        /// <summary>
        /// 内容所包含的行数
        /// </summary>
        int RowsCount
        {
            get;
        }

        /// <summary>
        /// 内容对象
        /// </summary>
        object ContentObj
        {
            get;
            set;
        }

        /// <summary>
        /// 根据行索引和列索引获取到对应的值
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="columnIndex">列索引</param>
        /// <returns></returns>
        object GetValue(int rowIndex, int columnIndex);
    }
}
