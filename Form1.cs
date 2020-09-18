using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Moya_Oborona
{
    public partial class MainFormMatrix : Form
    {
        int matrixSize, matrixNewRows, matrixNewColumns;                                            //Переменные, в которых хранятся значения размеров матриц
        int matrixARows, matrixAColumns, matrixBRows, matrixBColumns, matrixXRows, matrixXColumns;  //

        Bitmap bitmap1;                                                                             //Переменная-объект для работы с картинками

        public MainFormMatrix()
        {
            InitializeComponent();
        }

        void ReloadMatrix(int rows, int columns, DataGridView Matrix)                               //Перезагрузка таблицы
        {
                                                                                                    //При изменении размера какой-либо матрицы или расчета её новых значений соответствующая
                                                                                                    //таблица очищается и создается заново с помощью этого метода

            double[,] BackupMatrix = GetMatrixFromGrid(Matrix);                                     //Бэкап матрицы из таблицы. Нужен для того, чтобы матрица
                                                                                                    //не удалялась при изменении размеров таблицы

            Matrix.Columns.Clear();                                                                 //Очистка таблицы

            for (int j = 0; j < columns; j++)                                                       //Создание столбцов
            {
                StringBuilder columnText = new StringBuilder();
                columnText.AppendFormat("j{0}", j + 1);
                Matrix.Columns.Add(Matrix.Name + columnText.ToString(), columnText.ToString());
                Matrix.Columns[j].Width = 40;
                Matrix.Columns[j].SortMode = 0;
            }

            for (int i = 0; i < rows; i++)                                                          //Создание строк
            {
                StringBuilder rowText = new StringBuilder();
                rowText.AppendFormat("i{0}", i + 1);
                Matrix.Rows.Add();
                Matrix.Rows[i].HeaderCell.Value = rowText.ToString();
            }

            int rw, clmn;                                                                           //
            if (BackupMatrix.GetLength(0) < Matrix.RowCount)                                        //При изменении размера таблицы её размеры  
                rw = BackupMatrix.GetLength(0);                                                     //становятся отличны от размеров бэкап-матрицы. Необходимо
            else rw = Matrix.RowCount;                                                              //узнать, чей размер меньше, чтобы не возникало 
            if (BackupMatrix.GetLength(1) < Matrix.ColumnCount)                                     //ошибок переполнения таблицы
                clmn = BackupMatrix.GetLength(1);                                                   //
            else clmn = Matrix.ColumnCount;                                                         //

            for (int j = 0; j < clmn; j++)                                                          //Запись матрицы в таблицу
            {
                for (int i = 0; i < rw; i++)
                {
                    Matrix[j, i].Value = BackupMatrix[i, j];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)                                         //Загрузка формы. Вызывается при запуске программы
        {
            matrixSize = 3;                                                                     //
            matrixARows = 3;                                                                    //
            matrixAColumns = 3;                                                                 //
            matrixBRows = 3;                                                                    //Задаются размеры по умолчанию для всех матриц -- 3x3, 
            matrixBColumns = 3;                                                                 //в соответствие с данными размерами приводятся значения все меню выбора размеров
            cbMatrixSize.Text = "3x3";                                                          //
            cbMatrixARows.Text = "3";                                                           //
            cbMatrixAColumns.Text = "3";                                                        //
            cbMatrixBRows.Text = "3";                                                           //                                      
            cbMatrixBColumns.Text = "3";                                                        //

            ReloadMatrix(matrixSize, matrixSize, dgvMatrix);                                    //
            ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);                              //Размеры таблиц приводятся в соответствие с заданными размерами по умолчанию
            ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);                              //
        }

        private void cbMatrixSize_SelectedIndexChanged(object sender, EventArgs e)                  //Изменение порядка матрицы
        {
            matrixSize = Convert.ToInt32(cbMatrixSize.Text.Substring(0, 1));                        //Таблица создается заново с размерами,
            ReloadMatrix(matrixSize, matrixSize, dgvMatrix);                                        //выбранными в соответстветствующем меню
        }

        private void cbMatrixARows_SelectedIndexChanged(object sender, EventArgs e)                 //Изменение количества строк матрицы A
        {
            matrixARows = Convert.ToInt32(cbMatrixARows.Text.Substring(0, 1));                      //Таблица создается заново с размерами,
            ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);                                  //выбранными в соответстветствующем меню

            switch (cbTypeOfOperation.Text)                                                         //Данный оператор ставит размеры матриц в соответствие друг другу
            {                                                                                       //при их изменении. Например, складывать можно матрицы только
                case "сложение":                                                                    //одинаковых размеров, значит, если меняется, например, количество
                case "вычитание":                                                                   //строк первой матрицы-слагаемого, то и кол-во строк второй матрицы
                    if (matrixBRows != matrixARows)                                                 //нужно установить таким же.
                    {
                        matrixBRows = matrixARows;                                                  //Все остальные функции, меняющие размеры матриц, работают аналогично
                        cbMatrixBRows.Text = Convert.ToString(matrixBRows);
                        ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
                    }
                    break;
                case "уравнение A*X=B":
                    if (matrixAColumns != matrixARows)
                    {
                        matrixAColumns = matrixARows;
                        cbMatrixAColumns.Text = cbMatrixARows.Text;
                        ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
                    }
                    break;
                case "уравнение X*A=B":
                    if (matrixAColumns != matrixARows)
                    {
                        matrixAColumns = matrixARows;
                        cbMatrixAColumns.Text = cbMatrixARows.Text;
                        ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
                    }
                    if (matrixBColumns != matrixARows)
                    {
                        matrixBColumns = matrixARows;
                        cbMatrixBColumns.Text = cbMatrixARows.Text;
                        ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
                    }
                    break;
                default: break;
            }
        }

        private void cbMatrixAColumns_SelectedIndexChanged(object sender, EventArgs e)              //Изменение количества столбцов матрицы A
        {
            matrixAColumns = Convert.ToInt32(cbMatrixAColumns.Text.Substring(0, 1));
            ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
            switch (cbTypeOfOperation.Text)
            {
                case "умножение":
                    if (matrixBRows != matrixAColumns)
                    {
                        matrixBRows = matrixAColumns;
                        cbMatrixBRows.Text = cbMatrixAColumns.Text;
                        ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
                    }
                    break;
                case "сложение": 
                case "вычитание":
                    if (matrixBColumns != matrixAColumns)
                    {
                        matrixBColumns = matrixAColumns;                        
                        cbMatrixBColumns.Text = Convert.ToString(matrixBColumns);
                        ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
                    }
                    break;
                case "уравнение A*X=B":
                    if (matrixARows != matrixAColumns)
                    {
                        matrixARows = matrixAColumns;
                        cbMatrixARows.Text = cbMatrixAColumns.Text;
                        ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
                    }
                    if (matrixBRows != matrixAColumns)
                    {
                        matrixBRows = matrixAColumns;
                        cbMatrixBRows.Text = cbMatrixAColumns.Text;
                        ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
                    }
                    break;
                case "уравнение X*A=B":
                    if (matrixARows != matrixAColumns)
                    {
                        matrixARows = matrixAColumns;
                        cbMatrixARows.Text = cbMatrixAColumns.Text;
                        ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
                    }
                    break;
                default: break;
            }
        }

        private void cbMatrixBRows_SelectedIndexChanged(object sender, EventArgs e)                 //Изменение количества строк матрицы B
        {
            matrixBRows = Convert.ToInt32(cbMatrixBRows.Text.Substring(0, 1));
            ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
            switch (cbTypeOfOperation.Text)
            {
                case "умножение":
                    if (matrixAColumns != matrixBRows)
                    {
                        matrixAColumns = matrixBRows;
                        cbMatrixAColumns.Text = cbMatrixBRows.Text;
                        ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
                    }
                    break;
                case "сложение":
                case "вычитание":
                    if (matrixARows != matrixBRows)
                    {
                        matrixARows = matrixBRows;
                        cbMatrixARows.Text = Convert.ToString(matrixARows);
                        ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
                    }
                    break;
                case "уравнение A*X=B":
                    if (matrixAColumns != matrixBRows)
                    {
                        matrixAColumns = matrixBRows;
                        cbMatrixAColumns.Text = cbMatrixBRows.Text;
                        ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
                    }
                    break;
                default: break;
            }
        }

        private void cbMatrixBColumns_SelectedIndexChanged(object sender, EventArgs e)              //Изменение количества столбцов матрицы B
        {
            matrixBColumns = Convert.ToInt32(cbMatrixBColumns.Text.Substring(0, 1));
            ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
            switch (cbTypeOfOperation.Text)
            {
                case "сложение":
                case "вычитание":
                    if (matrixAColumns != matrixBColumns)
                    {
                        matrixAColumns = matrixBColumns;
                        cbMatrixAColumns.Text = Convert.ToString(matrixAColumns);
                        ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
                    }
                    break;
                case "уравнение X*A=B":
                    if (matrixARows != matrixBColumns)
                    {
                        matrixARows = matrixBColumns;
                        cbMatrixARows.Text = Convert.ToString(matrixBColumns);
                        ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
                    }
                    break;
                default: break;
            }
        }

        private void btnGetDeterminant_Click(object sender, EventArgs e)                            //Кнопка расчета определителя
        {
            double[,] matrixA = new double[matrixSize, matrixSize];
            matrixA = GetMatrixFromGrid(dgvMatrix);                                                 //Запись матрицы из таблицы в переменную
            tbDeterminant.Text = Convert.ToString(GetDeterminant(matrixA));                         //Расчет определителя и вывод его значения в текстовую ячейку
        }

        private void btnCalculate_Click(object sender, EventArgs e)                                 //Кнопка вычисления операции
        {
            switch (cbTypeOfOperation.Text)
            {
                case "умножение":           //X = A * B

                    matrixXRows = matrixARows;                                                      //Установка размеров итоговой матрицы
                    matrixXColumns = matrixBColumns;                                                //в соответствие с размерами матриц-множителей

                    ReloadMatrix(matrixXRows, matrixXColumns, dgvMatrixX);                          //Создание таблицы необходимого размера для матрицы-результата

                    for (int i = 0; i < matrixXRows; i++)                                           //Расчет значений каждого элемента итоговой матрицы и                
                    {                                                                               //его запись в соответствующую ячейку таблицы.
                        for (int j = 0; j < matrixXColumns; j++)
                        {
                            double matrixXValue = 0;
                            for (int k = 0; k < matrixAColumns; k++)
                            {
                                matrixXValue += Convert.ToDouble(dgvMatrixA[k, i].Value) * Convert.ToDouble(dgvMatrixB[j, k].Value);
                            }
                            dgvMatrixX[j, i].Value = matrixXValue;
                        }
                    }
                    break;

                case "сложение":            //X = A + B
                    matrixXRows = matrixARows;                                                      //Установка размеров итоговой матрицы
                    matrixXColumns = matrixAColumns;                                                //в соответствие с размерами матриц-слагаемых

                    ReloadMatrix(matrixXRows, matrixXColumns, dgvMatrixX);                          //Создание таблицы соответствующего размера

                    for (int i = 0; i < matrixXColumns; i++)                                        //Расчет значений каждого элемента итоговой матрицы и                      
                    {                                                                               //его запись в соответствующую ячейку таблицы.
                        for (int j = 0; j < matrixXRows; j++)
                        {
                            dgvMatrixX[i, j].Value = Convert.ToDouble(dgvMatrixA[i, j].Value) + Convert.ToDouble(dgvMatrixB[i, j].Value);
                        }
                    }
                    break;

                case "вычитание":           //X = A - B
                    matrixXRows = matrixARows;                                                      //Установка размеров итоговой матрицы
                    matrixXColumns = matrixAColumns;                                                //в соответствие с размерами вычитаемых матриц

                    ReloadMatrix(matrixXRows, matrixXColumns, dgvMatrixX);                          //Создание таблицы соответствующего размера 

                    for (int i = 0; i < matrixXColumns; i++)                                        //Расчет значений каждого элемента итоговой матрицы и   
                    {                                                                               //его запись в соответствующую ячейку таблицы.
                        for (int j = 0; j < matrixXRows; j++)
                        {
                            dgvMatrixX[i, j].Value = Convert.ToDouble(dgvMatrixA[i, j].Value) - Convert.ToDouble(dgvMatrixB[i, j].Value);
                        }
                    }
                    break;
                case "уравнение A*X=B":     //X = A^-1 * B
                    {
                        matrixXRows = matrixARows;                                                  //Установка размеров итоговой матрицы
                        matrixXColumns = matrixBColumns;                                            //в соответствие с размерами

                        ReloadMatrix(matrixXRows, matrixXColumns, dgvMatrixX);                      //Создание таблицы соответствующего размера 

                        double[,] matrixA = new double[matrixARows, matrixAColumns];                // 
                        double[,] matrixB = new double[matrixBRows, matrixBColumns];                //
                        double[,] invertibleMatrix = new double[matrixARows, matrixAColumns];       //
                        double[,] matrixX = new double[invertibleMatrix.GetLength(0), matrixB.GetLength(1)];//

                        matrixA = GetMatrixFromGrid(dgvMatrixA);                                    //Считывание A
                        matrixB = GetMatrixFromGrid(dgvMatrixB);                                    //Считывание B
                        invertibleMatrix = GetInvertedMatrix(matrixA);                              //Получение обратной матрицы от A
                        matrixX = GetMatrixMultiplication(invertibleMatrix, matrixB);               //Умножение матриц A^-1 и B и присваивание результата матрице X

                        for (int j = 0; j < matrixX.GetLength(1); j++)                              //Запись X
                        {
                            for (int i = 0; i < matrixX.GetLength(0); i++)
                            {
                                dgvMatrixX[j, i].Value = matrixX[i, j];
                            }
                        }
                        break;
                    }
                case "уравнение X*A=B":     //X = B * A^-1
                    {
                        matrixXRows = matrixBRows;                                                  //Установка размеров итоговой матрицы
                        matrixXColumns = matrixAColumns;                                            //в соответствие с размерами

                        ReloadMatrix(matrixXRows, matrixXColumns, dgvMatrixX);                      //Создание таблицы соответствующего размера 

                        double[,] matrixA = new double[matrixARows, matrixAColumns];
                        double[,] matrixB = new double[matrixBRows, matrixBColumns];
                        double[,] invertibleMatrix = new double[matrixARows, matrixAColumns];
                        double[,] matrixX = new double[invertibleMatrix.GetLength(0), matrixB.GetLength(1)];

                        matrixA = GetMatrixFromGrid(dgvMatrixA);    //Считывание A
                        matrixB = GetMatrixFromGrid(dgvMatrixB);    //Считывание B
                        invertibleMatrix = GetInvertedMatrix(matrixA);                              //Получение обратной матрицы от A
                        matrixX = GetMatrixMultiplication(matrixB, invertibleMatrix);               //Умножение матриц B и A^-1 и присваивание результата матрице X       

                        for (int j = 0; j < matrixX.GetLength(1); j++)                               //Запись X
                        {
                            for (int i = 0; i < matrixX.GetLength(0); i++)
                            {
                                dgvMatrixX[j, i].Value = matrixX[i, j];
                            }
                        }
                        break;
                    }
                default: break;
            }
        }

        private void cbTypeOfOperation_SelectedIndexChanged(object sender, EventArgs e)             //Выбор типа операции
        {
            switch (cbTypeOfOperation.Text)                                                         //Данный оператор ставит размеры матриц в соответствие друг другу
            {                                                                                       //при их изменении. Например, складывать можно матрицы только
                case "умножение":                                                                   //одинаковых размеров, значит, если меняется, например, количество
                    if (matrixBRows != matrixAColumns)                                              //строк первой матрицы-слагаемого, то и кол-во строк второй матрицы
                    {                                                                               //нужно установить таким же.
                        matrixBRows = matrixAColumns;
                        cbMatrixBRows.Text = cbMatrixAColumns.Text;
                        ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
                    }
                    break;
                case "сложение":
                    if (matrixBRows != matrixARows || matrixBColumns != matrixAColumns)
                    {
                        matrixBRows = matrixARows;
                        matrixBColumns = matrixAColumns;
                        cbMatrixBRows.Text = Convert.ToString(matrixBRows);
                        cbMatrixBColumns.Text = Convert.ToString(matrixBColumns);
                        ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
                    }
                    break;
                case "вычитание":
                    if (matrixBRows != matrixARows || matrixBColumns != matrixAColumns)
                    {
                        matrixBRows = matrixARows;
                        matrixBColumns = matrixAColumns;
                        cbMatrixBRows.Text = Convert.ToString(matrixBRows);
                        cbMatrixBColumns.Text = Convert.ToString(matrixBColumns);
                        ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
                    }
                    break;
                case "уравнение A*X=B":
                    if (matrixAColumns != matrixARows)
                    {
                        matrixAColumns = matrixARows;
                        cbMatrixAColumns.Text = cbMatrixARows.Text;
                        ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
                    }
                    if (matrixBRows != matrixAColumns)
                    {
                        matrixBRows = matrixAColumns;
                        cbMatrixBRows.Text = cbMatrixAColumns.Text;
                        ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
                    }                    
                    break;
                case "уравнение X*A=B":
                    if (matrixAColumns != matrixARows)
                    {
                        matrixAColumns = matrixARows;
                        cbMatrixAColumns.Text = cbMatrixARows.Text;
                        ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);
                    }
                    if (matrixBColumns != matrixARows)
                    {
                        matrixBColumns = matrixARows;
                        cbMatrixBColumns.Text = cbMatrixARows.Text;
                        ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB);
                    }                    
                    break;
                default: break;
            }         
        }

        private void btnTranspose_Click(object sender, EventArgs e)                                 //Кнопка получения транспонированной матрицы
        {
            matrixNewRows = matrixSize;                                                             //Приведение размеров таблицы транспонированной матрицы
            matrixNewColumns = matrixSize;                                                          //в соответствие с исходной

            ReloadMatrix(matrixNewRows, matrixNewColumns, dgvMatrixNew);                            //Создание таблицы для транспонированной матрицы

            double[,] transposeMatrix = GetTransposedMatrix(GetMatrixFromGrid(dgvMatrix));          //Считывание матрицы из таблицы, получение транспонированной матрицы
                                                                                                    //и присвоение переменной полученного значения

            for (int j = 0; j < transposeMatrix.GetLength(1); j++)                                  //и присвоение переменной полученного значения
            {
                for (int i = 0; i < transposeMatrix.GetLength(0); i++)
                {
                    dgvMatrixNew[j, i].Value = transposeMatrix[i, j];
                }
            }
        }                       

        private void btnInvert_Click(object sender, EventArgs e)                                    //Кнопка получения обратной матрицы
        {
            matrixNewRows = matrixSize;                                                             //Приведение размеров таблицы обратной матрицы
            matrixNewColumns = matrixSize;                                                          //в соответствие с исходной

            ReloadMatrix(matrixNewRows, matrixNewColumns, dgvMatrixNew);                            //Создание таблицы для обратной матрицы

            double[,] invertedMatrix = GetInvertedMatrix(GetMatrixFromGrid(dgvMatrix));             //Считывание матрицы из таблицы, получение обратной матрицы
                                                                                                    //и присвоение переменной полученного значения

            for (int j = 0; j < invertedMatrix.GetLength(1); j++)                                   //и присвоение переменной полученного значения
            {
                for (int i = 0; i < invertedMatrix.GetLength(0); i++)
                {
                    dgvMatrixNew[j, i].Value = invertedMatrix[i, j];
                }
            }
        }

        public double[,] GetMatrixFromGrid(DataGridView dgv)                                        //Считывание матрицы из таблицы
        {
            double[,] A = new double[dgv.RowCount, dgv.ColumnCount];
            for (int i = 0; i < A.GetLength(0); i++)                                                //С помощью двойного цикла происходит перебор
            {                                                                                       //всех ячеек таблицы, их значения записываются
                for (int j = 0; j < A.GetLength(1); j++)                                            //в массив размера, совпадающего с размерами таблицы
                {
                    A[i, j] = Convert.ToDouble(dgv[j, i].Value);
                }
            }
            return A;
        }

        public double GetDeterminant(double[,] A)                                                   //Получить определитель
        {
            if (A.GetLength(0) == 1) return A[0, 0];
            if (A.GetLength(0) == 2) return A[0, 0] * A[1, 1] - A[1, 0] * A[0, 1];
            else
            {
                double Determinant = 0;
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    Determinant += A[0, j] * Math.Pow(-1, (1 + j + 1)) * GetMinor(A, j);            //Матрица раскладывается по первой строке на миноры,
                }                                                                                   //для расчета значений которых используется отдельная функция
                return Determinant;
            }
            
        }

        public double GetMinor(double[,] A, int column)                                             //Получить минор матрицы по столбцу
        {
            double[,] MiniMatrix = new double[A.GetLength(0)-1, A.GetLength(0)-1];                  //
            for (int i = 0; i < MiniMatrix.GetLength(0); i++)                                       //
            {                                                                                       //
                for (int j = 0; j < column; j++)                                                    //
                {                                                                                   //
                    MiniMatrix[i, j] = A[i + 1, j];                                                 //"Отделение" минорной матрицы от основной путем
                }                                                                                   //удаления элементов первой строки и
                for (int j = column + 1; j < A.GetLength(0); j++)                                   //заданного столбца
                {                                                                                   //
                    MiniMatrix[i, j - 1] = A[i + 1, j];                                             //
                }                                                                                   //
            }                                                                                       //

            if (MiniMatrix.GetLength(0) == 2)                                                       //Если порядок минорной матрицы равен двум -- 
            {                                                                                       //происходит вычисление его значения
                return MiniMatrix[0, 0] * MiniMatrix[1, 1] - MiniMatrix[1, 0] * MiniMatrix[0, 1];
            }

            else                                                                                    //Если порядок больше -- с помощью рекурсии
            {                                                                                       //минорная матрица разбивается на матрицы 
                double InMinor = 0;                                                                 //меньших порядков до тех пор, пока они не станут
                for (int j = 0; j < MiniMatrix.GetLength(0); j++)                                   //равны двум, после чего происходит вычисление их
                {                                                                                   //определителей и суммирование с учетом знаков,
                    InMinor += MiniMatrix[0,j]*Math.Pow(-1, (1+j+1))* GetMinor(MiniMatrix, j);      //зависящих от номера столбца
                }
                return InMinor;
            } 
        }

        public double[,] GetMinorMatrix(double[,] A, int row, int column)                           //Получить минорную матрицу (индексация с нуля!)
        {
            double[,] B = new double[A.GetLength(0) - 1, A.GetLength(0) - 1];                       //"Отделение" минорной матрицы от основной путем
            for (int i = 0; i < row; i++)                                                           //удаления элементов заданных строки и стоблца
            {   
                for (int j = 0; j < column; j++)
                {
                    B[i, j] = A[i, j];
                }
                for (int j = column + 1; j < A.GetLength(1); j++)
                {
                    B[i, j - 1] = A[i, j];
                }
            }
            for (int i = row + 1; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < column; j++)
                {
                    B[i - 1, j] = A[i, j];
                }
                for (int j = column + 1; j < A.GetLength(1); j++)
                {
                    B[i - 1, j - 1] = A[i, j];
                }
            }
            return B;
        }

        public double[,] GetTransposedMatrix(double[,] A)                                           //Получение транспонированной матрицы
        {
            double[,] transposedMatrix = new double[A.GetLength(1), A.GetLength(0)];
            for (int i = 0; i < A.GetLength(0); i++)                                                //С помощью двойного цикла элементам транспонированной
            {                                                                                       //матрицы присваиваются те же значения, что и у исходной,
                for(int j = 0; j < A.GetLength(1); j++)                                             //но с заменой строк на столбцы и наоборот
                {
                    transposedMatrix[j, i] = A[i, j];
                }
            }
            return transposedMatrix;
        }

        public double[,] GetInvertedMatrix(double[,] A)                                             //Получение обратной матрицы
        {
            double[,] transposeMatrix = new double[A.GetLength(0), A.GetLength(0)];
            double[,] adjugateMatrix = new double[A.GetLength(0), A.GetLength(0)];
            double[,] invertedMatrix = new double[A.GetLength(0), A.GetLength(0)];

            transposeMatrix = GetTransposedMatrix(A);                                               //Получение транспонирование матрицы

            for (int i = 0; i < transposeMatrix.GetLength(0); i++)                                  //Получение союзной матрицы из транспонированной
            {
                for (int j = 0; j < transposeMatrix.GetLength(1); j++)
                {
                    adjugateMatrix[i, j] = Math.Pow(-1, i + 1 + j + 1) * GetDeterminant(GetMinorMatrix(transposeMatrix, i, j));
                }
            }
            for (int j = 0; j < adjugateMatrix.GetLength(1); j++)                                   //Получение обратной матрицы делением союзной матрицы
            {                                                                                       //на определитель исходной
                for (int i = 0; i < adjugateMatrix.GetLength(0); i++)
                {
                    invertedMatrix[i, j] = (adjugateMatrix[i, j] / GetDeterminant(A));
                }
            }
            return invertedMatrix;
        }

        public double[,] GetMatrixMultiplication(double[,] A, double[,] B)                          //Получение произведения матриц
        {
            double[,] matrixMultiplication = new double[A.GetLength(0), B.GetLength(1)];
            for (int i = 0; i < matrixMultiplication.GetLength(0); i++)
            {
                for (int j = 0; j < matrixMultiplication.GetLength(1); j++)
                {
                    matrixMultiplication[i, j] = 0;
                    for (int k = 0; k < matrixAColumns; k++)
                    {
                        matrixMultiplication[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return matrixMultiplication;
        }

        private void pbSun_Click(object sender, EventArgs e)                                        //Пасхалка
        {
            bitmap1 = (Bitmap)pbSun.Image;
            bitmap1.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbSun.Image = bitmap1;
        }

        private void llSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)             //Гиперссылка
        {
            System.Diagnostics.Process.Start("http://www.vk.com/souljrn");                          //Системный метод, предназначенный для запуска
        }                                                                                           //локального или удаленного процесса, в данном случае -- 
                                                                                                    //переход по гиперссылке
    }                                                                                               
}

