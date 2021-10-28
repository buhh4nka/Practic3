using System;

namespace Lib_2
{
    /// <summary>
    /// ИСП-31. Назаров Д. Вариант 2
    /// Дана целочисленная матрица размера M × N. Найти номер последнего из ее столбцов, 
    /// содержащих равное количество положительных и отрицательных элементов(нулевые элементы матрицы не учитываются).Если таких столбцов нет,то вывести 0"
    /// </summary>
    public class Practice
    {
        public static int LastEqualColumn(int[,] matrix)
        {
            int positiveElement;
            int negativeElement;
            int equalColumn = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                positiveElement = 0;
                negativeElement = 0;
                for(int j = 0; j< matrix.GetLength(0); j++) //тут они 1 и 0 поменялись местами, так как в задании сказано проверить именно столбцы на положительные/отрицательные элементы
                {
                    if(matrix[j,i] > 0)
                    {
                        positiveElement++;
                    }
                    else if(matrix[j,i] < 0)
                    {
                        negativeElement++;
                    }
                }
                if (positiveElement == negativeElement)
                {
                    equalColumn = i+1;
                }
            }
            return equalColumn;
        }
    }
}
