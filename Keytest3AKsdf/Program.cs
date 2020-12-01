using System;

using System.Collections.Generic;
using System.Windows.Forms;

using Microsoft.WindowsCE.Forms;
using OpenNETCF.Windows.Forms;

namespace Keytest3AKsdf
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            //if i use AddMessageFilter only in the forms code, I was unable to any msg
            //using Application.Run()
            //MUST use Application2.Run()
            //###########################
            //FilterMsg filterCloseMsg = new FilterMsg();
            //Application2.AddMessageFilter(FilterMsg); 
            //Application2.Run(new Form1());
            Application2.Run(new Keytest3AKsdfForm());

        }

        public class FilterMsg : IMessageFilter
        {
            private const int WM_CLOSE = 0x0010;

            public bool PreFilterMessage(ref Message m)
            {
                //System.Diagnostics.Debug.WriteLine("msghandler1: " + m.HWnd.ToInt32().ToString("X8") +
                //    ", " + m.Msg.ToString("X8") + 
                //    ", " + m.WParam.ToInt32().ToString("X8") + 
                //    ", " + m.LParam.ToInt32().ToString("X8"));
                return false;
            }
        }
    }
}