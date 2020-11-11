using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormMVC.View
{
    class CButton : System.Windows.Forms.Button
    {
        public CButton()
        {
            SetStyle(System.Windows.Forms.ControlStyles.Selectable, false);
        }
    }
}
