using System;
using System.Collections;
using System.Collections.Generic;

namespace Console_2048
{

    /// <summary>
    ///
    /// </summary>
    public class GameCore
    {
        //private static System.Random Random;
        private int[] colArray;
        private int[] removeZeroArray;
        private List<Location> locations;
        private int[,] ChangeArray { get; }
        public int[,] Map { get; }
        public GameCore()
        {
            Map = new int[4, 4];
            colArray = new int[Map.GetLength(0)];
            removeZeroArray = new int[4];
            random = new Random();
            locations = new List<Location>();
            ChangeArray = new int[4, 4];
        }
        public bool IsChangeMap { get; set; }

        /// <summary>
        /// 按方向移动
        /// </summary>
        /// <param name="direction"></param>
        public void Move(MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.Left: MoveLeft(); break;
                case MoveDirection.Right: MoveRight(); break;
                case MoveDirection.Up: MoveUp(); break;
                case MoveDirection.Down: MoveDown(); break;
            }
            ChangeMap();
        }
        /// <summary>
        /// 检测地图是否发上改变
        /// </summary>
        /// <returns></returns>
        private void ChangeMap()
        {
            for (int r = 0; r < Map.GetLength(0); r++)
            {
                for (int c = 0; c < Map.GetLength(1); c++)
                {
                    if (Map[r, c] != ChangeArray[r, c])
                    {
                        IsChangeMap = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 获取零元素
        /// </summary>
        private void GetZeroElementsByDoubleArray()
        {
            // 每次获取零元素 都必须先清空之前的元素 不然会一直叠加
            locations.Clear();
            for (int r = 0; r < Map.GetLength(0); r++)
            {
                for (int c = 0; c < Map.GetLength(1); c++)
                {
                    if (Map[r, c] == 0)
                        locations.Add(new Location(r, c));
                }
            }
        }

        private Random random;
        /// <summary>
        /// 生成新的随机数
        /// </summary>
        public void CreatNewRandomNumber(out Location? loc, out int? number)
        {
            GetZeroElementsByDoubleArray();
            if (locations.Count > 0)
            {
                //随机生成 list索引
                int listIndex = random.Next(0, locations.Count);
                // 将索引存的 数据拿出来
                loc = locations[listIndex];
                // 放入到对应的二维数组中
                number = Map[loc.Value.RowIndex, loc.Value.ColIndex] = random.Next(0, 10) == 1 ? 4 : 2;

                // 然后移除该元素
                locations.RemoveAt(listIndex);
            }
            else
            {
                loc = null;
                number = null;
            }
        }

        #region 方向控制
        private void MoveUp()
        {
            //int[] colArray = new int[doubleArray.GetLength(1)];
            for (int col = 0; col < Map.GetLength(1); col++)
            {
                for (int row = 0; row < Map.GetLength(0); row++)
                {
                    // 从当前二维数组 的 第一行第一列 开始获取 (上移 即 从上往下开始获取)
                    colArray[row] = Map[row, col];
                }
                // 去零后开始合并 
                Merge();
                // 合并后 还原每列
                for (int row = 0; row < Map.GetLength(0); row++)
                {
                    Map[row, col] = colArray[row];
                }
            }
        }
        private void MoveDown()
        {
            //int[] colArray = new int[doubleArray.GetLength(1)];
            for (int col = 0; col < Map.GetLength(1); col++)
            {
                for (int row = Map.GetLength(0) - 1; row >= 0; row--)
                {
                    // 从当前二维数组 的 第一行第一列 开始获取 (下移 即 从下往上开始获取)
                    colArray[3 - row] = Map[row, col];
                }

                Merge();        // 去零后开始合并 
                for (int row = Map.GetLength(0) - 1; row >= 0; row--)
                {
                    Map[row, col] = colArray[3 - row];
                }
            }
        }
        private void MoveLeft()
        {
            //int[] colArray = new int[doubleArray.GetLength(1)];
            for (int row = 0; row < Map.GetLength(0); row++)
            {
                for (int col = 0; col < Map.GetLength(1); col++)
                {
                    colArray[col] = Map[row, col];
                }
                Merge();
                for (int col = 0; col < Map.GetLength(1); col++)
                {
                    Map[row, col] = colArray[col];
                }
            }
        }
        private void MoveRight()
        {
            //int[] colArray = new int[doubleArray.GetLength(1)];
            for (int row = 0; row < Map.GetLength(0); row++)
            {
                for (int col = Map.GetLength(1) - 1; col >= 0; col--)
                {
                    colArray[3 - col] = Map[row, col];
                }
                Merge();
                for (int col = Map.GetLength(1) - 1; col >= 0; col--)
                {
                    Map[row, col] = colArray[3 - col];
                }
            }
        }
        #endregion

        public int scoreCount = 0;
        public int maxScore = 0;
        /// <summary>
        /// 合并元素
        /// </summary>
        /// 存的数组的引用 即内存地址 修改则是修改堆里面的数据
        private void Merge()
        {
            RemoveZero();   // 第一列获取完 开始去零
                            // 只需要获取前三个 元素即可
            for (int i = 0; i < colArray.Length - 1; i++)
            {
                // 如果 数组第一个元素 和第二个元素相同 就相加 随后吧第二个元素改为零
                if (colArray[i] != 0 && colArray[i] == colArray[i + 1])
                {
                    colArray[i] += colArray[i + 1];
                    colArray[i + 1] = 0;
                    // 积分
                    scoreCount += colArray[i];
                    maxScore = scoreCount;
                    // 记录合并位置（索引）r 和 c
                }
            }
            /*
             2  4   4
             2  0   4
             0  0   0
             4  4   0
             */
            // 合并完 在去一次零
            RemoveZero();
        }

        /// <summary>
        /// 移除零元素
        /// </summary>
        private void RemoveZero()
        {
            //removeZeroArray 将上次残留的数据清除  设置为零
            Array.Clear(removeZeroArray, 0, removeZeroArray.Length);
            //int[] removeZeroArray = new int[colArray.Length];
            int index = 0;
            for (int i = 0; i < colArray.Length; i++)
            {
                if (colArray[i] != 0)
                {
                    removeZeroArray[index++] = colArray[i];
                }
            }
            removeZeroArray.CopyTo(colArray, 0);
        }
    }
}