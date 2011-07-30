using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Export.Content
{
    public class ContentFactory
    {
        public static IContent CreateInstance(object content)
        {
            switch (content.GetType().Name)
            {
                case "DataGridView":
                    return new ContentIsDataGridView(content);
                default:
                    throw new ArgumentException("暂不支持该内容输出");
            }
        }
    }
}
