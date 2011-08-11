using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Export.Content
{
    /// <summary>
    /// 导出主内容的工厂类
    /// </summary>
    public class ContentFactory
    {
        /// <summary>
        /// 构造主内容实例
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static IContent CreateInstance(object content)
        {
            switch (content.GetType().Name)
            {
                case "DoubleBufferDataGridView":
                case "DataGridView":
                    return new ContentIsDataGridView(content);
                case "ListView":
                    return new ContentIsListView(content);
                case "DataTable":
                    return new ContentIsDataTable(content);
                default:
                    throw new ArgumentException("暂不支持该内容输出");
            }
        }
    }
}
