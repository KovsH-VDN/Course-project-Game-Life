using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public class Setting
    {
        public int FieldRow { get; set; } = 15;
        public int FieldColumn { get; set; } = 15;
        public int MinAlive { get; set; } = 2;
        public int MaxAlive { get; set; } = 3;
        public int MinBorn { get; set; } = 3;
        public int MaxBorn { get; set; } = 3;
        public bool Eight { get; set; } = true;
        public bool Four { get; set; } = false;




        public Setting() { }
        public Setting(Setting setting)
        {
            FieldRow = setting.FieldRow;
            FieldColumn = setting.FieldColumn;
            MinAlive = setting.MinAlive;
            MaxAlive = setting.MaxAlive;
            MinBorn = setting.MinBorn;
            MaxBorn = setting.MaxBorn;
            Eight = setting.Eight;
            Four = setting.Four;
        }
        public Setting (int row, int col)
        {
            FieldRow = row;
            FieldColumn = col;
        }
    }
}
