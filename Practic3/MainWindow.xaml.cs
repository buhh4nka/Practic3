using System;
using System.Windows;
using LibMas;
using Lib_2;
using Microsoft.Win32;
using System.IO;

namespace Practic3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int[,] _matrix;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ИСП-31. Назаров Д. Вариант 2. \nДана целочисленная матрица размера M × N. Найти номер последнего из ее столбцов, содержащих равное количество положительных и отрицательных элементов(нулевые элементы матрицы не учитываются).\nЕсли таких столбцов нет,то вывести 0", "Данные о программе");
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void createArray_Click(object sender, RoutedEventArgs e)
        {
            bool isNotErrorInColumns = Int32.TryParse(numberOfColumns.Text, out int columns);
            bool isNotErrorInRows = Int32.TryParse(numberOfRows.Text, out int rows);
            if (isNotErrorInColumns &&  isNotErrorInRows)
            {
            _matrix = new int[columns, rows];

              dataGrid.ItemsSource = ArrayOperation.ToDataTable(_matrix).DefaultView;
            }
            else
            {
                MessageBox.Show("Число столбцов или строк введено неверно. \nВведите другое значение.", "Ошибка");
                numberOfColumns.Clear();
                numberOfRows.Clear();
            }
        }

        private void startProgramm_Click(object sender, RoutedEventArgs e)
        {
            if (_matrix != null)
            {

                _matrix.FillArray(-10, 10);
                dataGrid.ItemsSource = ArrayOperation.ToDataTable(_matrix).DefaultView;

                numberOfCorrectColumn.Text = Practice.LastEqualColumn(_matrix).ToString();

            }
            else
            {
                MessageBox.Show("Матрица не заполнена. Заполните матрицу.", "Ошибка");
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = null;
            _matrix.CleanArray();
        }

        private void saveArray_Click(object sender, RoutedEventArgs e)
        {
            if (_matrix == null)
            {
                MessageBox.Show("Таблица пуста", "Ошибка");
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                _matrix.SaveArray(save.FileName);
            }
        }

        private void openArray_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
                if (open.FileName != string.Empty)
                {
                    ArrayOperation.OpenArray(out _matrix, open.FileName);
                    dataGrid.ItemsSource = ArrayOperation.ToDataTable(_matrix).DefaultView;
                    numberOfCorrectColumn.Text = Practice.LastEqualColumn(_matrix).ToString();
                }
            }
        }

    }
}
