using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Life
{
    public class MyCell
    {
        public bool Life { get; set; } = true;
        public List<int> Neighbors { get; set; }

        public MyCell(bool life)
        {
            Life = life;
            Neighbors = new List<int>();
        }
        public MyCell(MyCell myCell)
        {
            Life = myCell.Life;
            Neighbors = myCell.Neighbors;
        }
        public MyCell()
        {
            Neighbors = new List<int>();
        }
        
        public int CountLivingNeighbors(ObservableCollection<MyCell> myCells)
        {
            int count = 0;

            foreach (int index in Neighbors)
                count += myCells[index].Life ? 1 : 0;

            return count;
        }
    }
}
