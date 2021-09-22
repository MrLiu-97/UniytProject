using System.Collections;
using System.Collections.Generic;

namespace Console_2048
{
    /// <summary>
    /// 位置索引
    /// </summary>
    public struct Location
    {
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }

        public Location(int row, int col) : this()
        {
            RowIndex = row;
            ColIndex = col;
        }

    }
}