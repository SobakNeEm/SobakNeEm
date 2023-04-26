using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagmentSudentsOIk
{
    internal class Bloked
    {
        public async void BlokedGrid(UIElement element, int second)
        {
            second = second * 1000;
            await Task.Delay(second);
        }
    }
}
