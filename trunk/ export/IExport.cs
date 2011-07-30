using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
namespace Export
{
    public interface IExport
    {
        MyDocument MyDoc
        {
            get;
            set;
        }
        void Export(string path);
    }
}
