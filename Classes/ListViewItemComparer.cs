using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApplication.Classes
{
    // Implements the manual sorting of items by columns.
    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            int nr = 0;

            bool isNumber = int.TryParse(((ListViewItem)x).SubItems[col].Text, out nr);

            if (!isNumber)
                return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            else
            {
                int firstnumber = int.Parse(((ListViewItem)x).SubItems[col].Text);
                int secondNumber = int.Parse(((ListViewItem)y).SubItems[col].Text);

                return firstnumber.CompareTo(secondNumber);
            }
        }
    }
}
