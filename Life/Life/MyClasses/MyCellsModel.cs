using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public class MyCellsModel
    {
        public ObservableCollection<MyCell> MyCells { get; set; }
        public Setting Setting { get; set; }


        public MyCellsModel()
        {
            Setting = new Setting();
            MyCells = new ObservableCollection<MyCell>();
        }

        public void ClearCells()
        {
            MyCell cell = MyCells[MyCells.Count - 1];
            cell.Life = false;

            foreach (MyCell myCell in MyCells)
                myCell.Life = false;

            MyCells[MyCells.Count - 1] = cell;
            RefreshCells();
        }
        public void RefreshCells()
        {
            List<MyCell> cells = new List<MyCell>();

            foreach (MyCell myCell in MyCells)
                cells.Add(new MyCell(myCell));

            for (int i = 0; i < MyCells.Count; ++i)
            {
                int countLife = cells[i].CountLivingNeighbors(MyCells);

                if (!cells[i].Life && (countLife >= Setting.MinBorn && countLife <= Setting.MaxBorn))
                        cells[i].Life = true;
                else if (cells[i].Life)
                    if (countLife < Setting.MinAlive || countLife > Setting.MaxAlive)
                        cells[i].Life = false;
            }


            MyCells.Clear();

            foreach (MyCell myCell in cells)
                MyCells.Add(myCell);
        }
        public void RandFilling()
        {
            MyCells.Clear();
            Random random = new Random();
            for (int i = 0; i < Setting.FieldRow; ++i)
                for (int j = 0; j < Setting.FieldColumn; ++j)
                    MyCells.Add(new MyCell((random.Next(-80, 19) < 0 ? false : true)));

            RegistrationOfNeighbors();
        }

        private void RegistrationOfNeighbors()
        {
            if (Setting.Eight)
                EightNeighbors();
            else if (Setting.Four)
                FourNeighbors();
        }


        private void EightNeighbors()
        {
            for (int i = 0; i < MyCells.Count; ++i)
            {
                if (i < Setting.FieldColumn)
                {
                    if (i == 0)
                    {
                        MyCells[i].Neighbors.Add(i + 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn + 1);
                    }
                    else if (0 < i && i < Setting.FieldColumn - 1)
                    {
                        MyCells[i].Neighbors.Add(i - 1);
                        MyCells[i].Neighbors.Add(i + 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn - 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn + 1);
                    }
                    else if (i == Setting.FieldColumn - 1)
                    {
                        MyCells[i].Neighbors.Add(i - 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn - 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                    }
                }
                else if (i % Setting.FieldColumn == 0)
                {
                    if (i == 0)
                    {
                        MyCells[i].Neighbors.Add(i + 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn + 1);
                    }
                    else if (0 < i && i < Setting.FieldColumn * Setting.FieldRow - Setting.FieldColumn)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn + 1);
                        MyCells[i].Neighbors.Add(i + 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn + 1);
                    }
                    else if (i == Setting.FieldColumn * Setting.FieldRow - Setting.FieldColumn)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn + 1);
                        MyCells[i].Neighbors.Add(i + 1);
                    }
                }
                else if (i % Setting.FieldColumn == Setting.FieldColumn - 1)
                {
                    if (i == Setting.FieldColumn - 1)
                    {
                        MyCells[i].Neighbors.Add(i - 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn - 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                    }
                    else if (Setting.FieldColumn - 1 < i && i < Setting.FieldColumn * Setting.FieldRow - 1)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn - 1);
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i - 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn - 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                    }
                    else if (i == Setting.FieldColumn * Setting.FieldRow - 1)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn - 1);
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i - 1);
                    }
                }
                else if (Setting.FieldColumn * Setting.FieldRow - Setting.FieldColumn - 1 < i && i < Setting.FieldColumn * Setting.FieldRow)
                {
                    if (i == Setting.FieldColumn * Setting.FieldRow - Setting.FieldColumn)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn + 1);
                        MyCells[i].Neighbors.Add(i + 1);
                    }
                    else if (Setting.FieldColumn * Setting.FieldRow - Setting.FieldColumn < i && i < Setting.FieldColumn * Setting.FieldRow - 1)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn - 1);
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn + 1);
                        MyCells[i].Neighbors.Add(i - 1);
                        MyCells[i].Neighbors.Add(i + 1);
                    }
                    else if (i == Setting.FieldColumn * Setting.FieldRow - 1)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn - 1);
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i - 1);
                    }
                }
                else
                {
                    MyCells[i].Neighbors.Add(i - Setting.FieldColumn - 1);
                    MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                    MyCells[i].Neighbors.Add(i - Setting.FieldColumn + 1);
                    MyCells[i].Neighbors.Add(i - 1);
                    MyCells[i].Neighbors.Add(i + 1);
                    MyCells[i].Neighbors.Add(i + Setting.FieldColumn - 1);
                    MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                    MyCells[i].Neighbors.Add(i + Setting.FieldColumn + 1);
                }
            }
        }
        private void FourNeighbors()
        {
            for (int i = 0; i < MyCells.Count; ++i)
            {
                if (i < Setting.FieldColumn)
                {
                    if (i == 0)
                    {
                        MyCells[i].Neighbors.Add(i + 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                    }
                    else if (0 < i && i < Setting.FieldColumn - 1)
                    {
                        MyCells[i].Neighbors.Add(i - 1);
                        MyCells[i].Neighbors.Add(i + 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                    }
                    else if (i == Setting.FieldColumn - 1)
                    {
                        MyCells[i].Neighbors.Add(i - 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                    }
                }
                else if (i % Setting.FieldColumn == 0)
                {
                    if (i == 0)
                    {
                        MyCells[i].Neighbors.Add(i + 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                    }
                    else if (0 < i && i < Setting.FieldColumn * Setting.FieldRow - Setting.FieldColumn)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i + 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                    }
                    else if (i == Setting.FieldColumn * Setting.FieldRow - Setting.FieldColumn)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i + 1);
                    }
                }
                else if (i % Setting.FieldColumn == Setting.FieldColumn - 1)
                {
                    if (i == Setting.FieldColumn - 1)
                    {
                        MyCells[i].Neighbors.Add(i - 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                    }
                    else if (Setting.FieldColumn - 1 < i && i < Setting.FieldColumn * Setting.FieldRow - 1)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i - 1);
                        MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                    }
                    else if (i == Setting.FieldColumn * Setting.FieldRow - 1)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i - 1);
                    }
                }
                else if (Setting.FieldColumn * Setting.FieldRow - Setting.FieldColumn - 1 < i && i < Setting.FieldColumn * Setting.FieldRow)
                {
                    if (i == Setting.FieldColumn * Setting.FieldRow - Setting.FieldColumn)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i + 1);
                    }
                    else if (Setting.FieldColumn * Setting.FieldRow - Setting.FieldColumn < i && i < Setting.FieldColumn * Setting.FieldRow - 1)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i - 1);
                        MyCells[i].Neighbors.Add(i + 1);
                    }
                    else if (i == Setting.FieldColumn * Setting.FieldRow - 1)
                    {
                        MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                        MyCells[i].Neighbors.Add(i - 1);
                    }
                }
                else
                {
                    MyCells[i].Neighbors.Add(i - Setting.FieldColumn);
                    MyCells[i].Neighbors.Add(i - 1);
                    MyCells[i].Neighbors.Add(i + 1);
                    MyCells[i].Neighbors.Add(i + Setting.FieldColumn);
                }
            }
        }
    }
}
