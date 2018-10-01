using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
    class Game
    {
        private Random rnd = new Random();
        private int[,] _gameField = new int[4, 4];
        private int zeroX;
        private int zeroY;
        public bool IsWin()
        {
            Console.Clear();
            Print();
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (arr[i * 4 + j] != _gameField[j, i])
                        return false;
            Console.WriteLine("You win!");
            return true;
        }
        public void zeroUp()
        {
            if (zeroY == 3) return;
            _gameField[zeroX, zeroY] = _gameField[zeroX, zeroY + 1];
            ++zeroY;
            _gameField[zeroX, zeroY] = 0;

        }
        public void zeroDown()
        {
            if (zeroY == 0) return;

            _gameField[zeroX, zeroY] = _gameField[zeroX, zeroY - 1];
            --zeroY;
            _gameField[zeroX, zeroY] = 0;
        }
        public void zeroLeft()
        {
            if (zeroX == 3) return;
            _gameField[zeroX, zeroY] = _gameField[zeroX + 1, zeroY];
            ++zeroX;
            _gameField[zeroX, zeroY] = 0;
        }
        public void zeroRight()
        {
            if (zeroX == 0) return;
            _gameField[zeroX, zeroY] = _gameField[zeroX - 1, zeroY];
            --zeroX;
            _gameField[zeroX, zeroY] = 0;
        }
        public Game()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
            Shuffle(arr);
            check_it(arr);
            for (int n = 0, i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j, ++n)
                {
                    _gameField[j, i] = arr[n];
                    if (arr[n] == 0)
                    {
                        zeroX = j;
                        zeroY = i;
                    }
                }
            }
        }
        private void check_it(int[] arr)
        {
            int inv = inv_puzzle(arr);
            if (inv % 2 == 0)
            {
                return;
            }
            else
                Shuffle(arr);
        }
        private int inv_puzzle(int[] arr1)
        {
            int inv = 0;
            for (int i = 0; i < 16; ++i)
                if (arr1[i] != 0)
                    for (int j = 0; j < i; ++j)
                        if (arr1[j] > arr1[i])
                            ++inv;
            for (int i = 0; i < 16; ++i)
                if (arr1[i] == 0)
                    inv += 1 + i / 4;
            return inv;
        }
        private void Shuffle(int[] arr)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                int r = rnd.Next(arr.Length);
                int tmp = arr[i];
                arr[i] = arr[r];
                arr[r] = tmp;
            }
        }
        public void Print()
        {
            Console.CursorVisible = false;
            Console.WriteLine("=============================");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.WriteLine("|      |      |      |      |");
                if(i!=3)
                    Console.WriteLine("|------+------+------+------|");
            }
            Console.WriteLine("=============================");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.SetCursorPosition(j * 7 + 3, i * 4 + 2);
                    if (_gameField[j, i] != 0)
                        Console.Write("{0,2}", _gameField[j, i]);
                }
            }
            Console.SetCursorPosition(20, 20);
        }
    }
}
