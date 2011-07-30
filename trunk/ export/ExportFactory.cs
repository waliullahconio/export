using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Export
{
    public class ExportFactory
    {
        public static IExport CreateInstance(ExportType type,MyDocument doc)
        {
            switch (type)
            { 
                case ExportType.Xls:
                    return new ExportExcel(doc);
                case ExportType.Pdf:
                    return new ExportPdf();
                default:
                    throw new ArgumentException("该类型方法未实现");
            }
        }
    }
}
