using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Export
{
    public class ExportPdf : IExport
    {

        #region IExport 成员
        public MyDocument MyDoc
        {
            get;
            set;
        }

        public void Export(string path)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
