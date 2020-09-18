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
        //Переменные, в которых хранятся значения размеров матриц
        int matrixSize, matrixNewRows, matrixNewColumns;                                            
        int matrixARows, matrixAColumns, matrixBRows, matrixBColumns, matrixXRows, matrixXColumns;

        //Переменная-объект для работы с картинками
        Bitmap bitmap1;

        public MainFormMatrix()
        {
            InitializeComponent();
        }

        //Перезагрузка таблицы
        void ReloadMatrix(int rows, int columns, DataGridView Matrix)
        {
            //При изменении размера какой-либо матрицы или расчета её новых значений соответствующая
            //таблица очищается и создается заново с помощью этого метода

            //Бэкап матрицы из таблицы. Нужен для того, чтобы матрица
            //не удалялась при изменении размеров таблицы
            double[,] BackupMatrix = GetMatrixFromGrid(Matrix);

            //Очистка таблицы                                         
            Matrix.Columns.Clear();

            //Создание столбцов
            for (int j = 0; j < columns; j++)                                                       
            {
                StringBuilder columnText = new StringBuilder();
                columnText.AppendFormat("j{0}", j + 1);
                Matrix.Columns.Add(Matrix.Name + columnText.ToString(), columnText.ToString());
                Matrix.Columns[j].Width = 40;
                Matrix.Columns[j].SortMode = 0;
            }
            //Создание строк
            for (int i = 0; i < rows; i++)                                                          
            {
                StringBuilder rowText = new StringBuilder();
                rowText.AppendFormat("i{0}", i + 1);
                Matrix.Rows.Add();
                Matrix.Rows[i].HeaderCell.Value = rowText.ToString();
            }

            //При изменении размера таблицы её размеры становятся отличны от размеров бэкап-матрицы.
            //Необходимо узнать, чей размер меньше, чтобы не возникало ошибок переполнения таблицы
            int rw, clmn;
            if (BackupMatrix.GetLength(0) < Matrix.RowCount)                                          
                rw = BackupMatrix.GetLength(0); 
            else rw = Matrix.RowCount;    
            if (BackupMatrix.GetLength(1) < Matrix.ColumnCount)    
                clmn = BackupMatrix.GetLength(1);                        
            else clmn = Matrix.ColumnCount;

            //Запись матрицы в таблицу
            for (int j = 0; j < clmn; j++)                                                          
            {
                for (int i = 0; i < rw; i++)
                {
                    Matrix[j, i].Value = BackupMatrix[i, j];
                }
            }
        }

        //Загрузка формы. Вызывается при запуске программы
        private void Form1_Load(object sender, EventArgs e) 
        {
            //Задаются размеры по умолчанию для всех матриц -- 3x3,
            //в соответствие с данными размерами приводятся значения все меню выбора размеров
            matrixSize = 3;                               
            matrixARows = 3;                                                     
            matrixAColumns = 3;                                      
            matrixBRows = 3;                                                                     
            matrixBColumns = 3;                                                                 
            cbMatrixSize.Text = "3x3";                       
            cbMatrixARows.Text = "3";                          
            cbMatrixAColumns.Text = "3";                           
            cbMatrixBRows.Text = "3";                                                                         
            cbMatrixBColumns.Text = "3";

            //Размеры таблиц приводятся в соответствие с заданными размерами по умолчанию
            ReloadMatrix(matrixSize, matrixSize, dgvMatrix);                           
            ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);                              
            ReloadMatrix(matrixBRows, matrixBColumns, dgvMatrixB); 
        }

        //Изменение порядка матрицы
        private void cbMatrixSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Таблица создается заново с размерами, выбранными в соответстветствующем меню
            matrixSize = Convert.ToInt32(cbMatrixSize.Text.Substring(0, 1));                        
            ReloadMatrix(matrixSize, matrixSize, dgvMatrix);
        }

        //Изменение количества строк матрицы A
        private void cbMatrixARows_SelectedIndexChanged(object sender, EventArgs e)                 
        {
            //Таблица создается заново с размерами, выбранными в соответстветствующем меню
            matrixARows = Convert.ToInt32(cbMatrixARows.Text.Substring(0, 1));                      
            ReloadMatrix(matrixARows, matrixAColumns, dgvMatrixA);

            //Данный оператор ставит размеры матриц в соответствие друг другу
            //при их изменении. Например, складывать можно матрицы только
            //одинаковых размеров, значит, если меняется, например, количество
            //строк первой матрицы-слагаемого, то и кол-во строк второй матрицы
            //нужно установить таким же. Все остальные функции, меняющие размеры матриц,
            //работают аналогично
            switch (cbTypeOfOperation.Text)                                                         
            {                                                                                       
                case "сложение":                                                       
                case "вычитание":           
                    if (matrixBRows != matrixARows)                 
                    {
                        matrixBRows = matrixARows;                                                  
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

        //Изменение количества столбцов матрицы A
        private void cbMatrixAColumns_SelectedIndexChanged(object sender, EventArgs e)              
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

        //Изменение количества строк матрицы B
        private void cbMatrixBRows_SelectedIndexChanged(object sender, EventArgs e)
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

        //Изменение количества столбцов матрицы B
        private void cbMatrixBColumns_SelectedIndexChanged(object sender, EventArgs e) 
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

        //Кнопка расчета определителя
        private void btnGetDeterminant_Click(object sender, EventArgs e) 
        {
            double[,] matrixA = new double[matrixSize, matrixSize];
            //Запись матрицы из таблицы в переменную
            matrixA = GetMatrixFromGrid(dgvMatrix);                         
            //Расчет определителя и вывод его значения в текстовую ячейку
            tbDeterminant.Text = Convert.ToString(GetDeterminant(matrixA)); 
        }

        //Кнопка вычисления операции
        private void btnCalculate_Click(object sender, EventArgs e)  
        {
            switch (cbTypeOfOperation.Text)
            {
                case "умножение":           //X = A * B

                    
                    matrixXRows = matrixARows;                                                      
                    matrixXColumns = matrixBColumns;

                    //Создание таблицы необходимого размера для матрицы-результата
                    ReloadMatrix(matrixXRows, matrixXColumns, dgvMatrixX);

                    //Расчет значений каждого элемента итоговой матрицы и его запись в соответствующую ячейку таблицы.
                    for (int i = 0; i < matrixXRows; i++)                                                        
                    {                                        
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

                    //Установка размеров итоговой матрицы в соответствие с размерами матриц-слагаемых
                    matrixXRows = matrixARows;                                   
                    matrixXColumns = matrixAColumns;

                    //Создание таблицы соответствующего размера
                    ReloadMatrix(matrixXRows, matrixXColumns, dgvMatrixX);

                    //Расчет значений каждого элемента итоговой матрицы и его запись в соответствующую ячейку таблицы.
                    for (int i = 0; i < matrixXColumns; i++)                                                            
                    {                                                                            
                        for (int j = 0; j < matrixXRows; j++)
                        {
                            dgvMatrixX[i, j].Value = Convert.ToDouble(dgvMatrixA[i, j].Value) + Convert.ToDouble(dgvMatrixB[i, j].Value);
                        }
                    }
                    break;

                case "вычитание":           //X = A - B

                    //Установка размеров итоговой матрицы в соответствие с размерами вычитаемых матриц
                    matrixXRows = matrixARows;                                                      
                    matrixXColumns = matrixAColumns;

                    //Создание таблицы соответствующего размера 
                    ReloadMatrix(matrixXRows, matrixXColumns, dgvMatrixX);

                    //Расчет значений каждого элемента итоговой матрицы и его запись в соответствующую ячейку таблицы.
                    for (int i = 0; i < matrixXColumns; i++)                                        
                    {                                                  
                        for (int j = 0; j < matrixXRows; j++)
                        {
                            dgvMatrixX[i, j].Value = Convert.ToDouble(dgvMatrixA[i, j].Value) - Convert.ToDouble(dgvMatrixB[i, j].Value);
                        }
                    }
                    break;
                case "уравнение A*X=B":     //X = A^-1 * B
                    {
                        //Установка размеров итоговой матрицы
                        matrixXRows = matrixARows;                                                  
                        matrixXColumns = matrixBColumns;

                        //Создание таблицы соответствующего размера
                        ReloadMatrix(matrixXRows, matrixXColumns, dgvMatrixX);                       

                        double[,] matrixA = new double[matrixARows, matrixAColumns];          
                        double[,] matrixB = new double[matrixBRows, matrixBColumns];
                        double[,] invertibleMatrix = new double[matrixARows, matrixAColumns];  
                        double[,] matrixX = new double[invertibleMatrix.GetLength(0), matrixB.GetLength(1)];

                        matrixA = GetMatrixFromGrid(dgvMatrixA); //Считывание A
                        matrixB = GetMatrixFromGrid(dgvMatrixB); //Считывание B
                        invertibleMatrix = GetInvertedMatrix(matrixA); //Получение обратной матрицы от A

                        //Умножение матриц A^-1 и B и присваивание результата матрице X
                        matrixX = GetMatrixMultiplication(invertibleMatrix, matrixB); 

                        for (int j = 0; j < matrixX.GetLength(1); j++) //Запись X
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
                        //Установка размеров итоговой матрицы
                        matrixXRows = matrixBRows;                                                  
                        matrixXColumns = matrixAColumns;

                        //Создание таблицы соответствующего размера 
                        ReloadMatrix(matrixXRows, matrixXColumns, dgvMatrixX);                      

                        double[,] matrixA = new double[matrixARows, matrixAColumns];
                        double[,] matrixB = new double[matrixBRows, matrixBColumns];
                        double[,] invertibleMatrix = new double[matrixARows, matrixAColumns];
                        double[,] matrixX = new double[invertibleMatrix.GetLength(0), matrixB.GetLength(1)];

                        matrixA = GetMatrixFromGrid(dgvMatrixA);    //Считывание A
                        matrixB = GetMatrixFromGrid(dgvMatrixB);    //Считывание B
                        invertibleMatrix = GetInvertedMatrix(matrixA);//Получение обратной матрицы от A

                        //Умножение матриц B и A^-1 и присваивание результата матрице X   
                        matrixX = GetMatrixMultiplication(matrixB, invertibleMatrix);    

                        for (int j = 0; j < matrixX.GetLength(1); j++)//Запись X
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

        //Выбор типа операции
        private void cbTypeOfOperation_SelectedIndexChanged(object sender, EventArgs e)           
        {
            switch (cbTypeOfOperation.Text)
            //Данный оператор ставит размеры матриц в соответствие друг другу
            //при их изменении. Например, складывать можно матрицы только
            //одинаковых размеров, значит, если меняется, например, количество
            //строк первой матрицы-слагаемого, то и кол-во строк второй матрицы
            //нужно установить таким же.
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

        //Кнопка получения транспонированной матрицы
        private void btnTranspose_Click(object sender, EventArgs e)  
        {
            //Приведение размеров таблицы транспонированной матрицы в соответствие с исходной
            matrixNewRows = matrixSize;                                                             
            matrixNewColumns = matrixSize;

            //Создание таблицы для транспонированной матрицы
            ReloadMatrix(matrixNewRows, matrixNewColumns, dgvMatrixNew);

            //Считывание матрицы из таблицы, получение транспонированной матрицы
            //и присвоение переменной полученного значения
            double[,] transposeMatrix = GetTransposedMatrix(GetMatrixFromGrid(dgvMatrix));

            //Запись матрицы в таблицу
            for (int j = 0; j < transposeMatrix.GetLength(1); j++)                                  
            {
                for (int i = 0; i < transposeMatrix.GetLength(0); i++)
                {
                    dgvMatrixNew[j, i].Value = transposeMatrix[i, j];
                }
            }
        }

        //Кнопка получения обратной матрицы
        private void btnInvert_Click(object sender, EventArgs e)                                    
        {
            //Приведение размеров таблицы обратной матрицы в соответствие с исходной
            matrixNewRows = matrixSize;                                                             
            matrixNewColumns = matrixSize;

            //Создание таблицы для обратной матрицы
            ReloadMatrix(matrixNewRows, matrixNewColumns, dgvMatrixNew);

            //Считывание матрицы из таблицы, получение обратной матрицы и присвоение переменной полученного значения
            double[,] invertedMatrix = GetInvertedMatrix(GetMatrixFromGrid(dgvMatrix));

            //Запись матрицы в таблицу
            for (int j = 0; j < invertedMatrix.GetLength(1); j++)                      
            {
                for (int i = 0; i < invertedMatrix.GetLength(0); i++)
                {
                    dgvMatrixNew[j, i].Value = invertedMatrix[i, j];
                }
            }
        }

        //Считывание матрицы из таблицы
        public double[,] GetMatrixFromGrid(DataGridView dgv)                                       
        {
            //С помощью двойного цикла происходит перебор
            //всех ячеек таблицы, их значения записываются
            //в массив размера, совпадающего с размерами таблицы
            double[,] A = new double[dgv.RowCount, dgv.ColumnCount];
            for (int i = 0; i < A.GetLength(0); i++)                                               
            {                                                                                       
                for (int j = 0; j < A.GetLength(1); j++)                                           
                {
                    A[i, j] = Convert.ToDouble(dgv[j, i].Value);
                }
            }
            return A;
        }

        //Получить определитель
        public double GetDeterminant(double[,] A)                                                  
        {
            if (A.GetLength(0) == 1) return A[0, 0];
            if (A.GetLength(0) == 2) return A[0, 0] * A[1, 1] - A[1, 0] * A[0, 1];
            else
            {
                double Determinant = 0;
                //Матрица раскладывается по первой строке на миноры,
                //для расчета значений которых используется отдельная функция
                for (int j = 0; j < A.GetLength(0); j++)
                {
                    Determinant += A[0, j] * Math.Pow(-1, (1 + j + 1)) * GetMinor(A, j);            
                }                                                                                   
                return Determinant;
            }
            
        }

        //Получить минор матрицы по столбцу
        public double GetMinor(double[,] A, int column)                                            
        {
            double[,] MiniMatrix = new double[A.GetLength(0)-1, A.GetLength(0)-1];
            //"Отделение" минорной матрицы от основной путем
            //удаления элементов первой строки и
            //заданного столбца
            for (int i = 0; i < MiniMatrix.GetLength(0); i++)               
            {                                                                    
                for (int j = 0; j < column; j++)                         
                {                                                    
                    MiniMatrix[i, j] = A[i + 1, j];         
                }                                                                                   
                for (int j = column + 1; j < A.GetLength(0); j++)                                  
                {                                                           
                    MiniMatrix[i, j - 1] = A[i + 1, j];                   
                }                                                         
            }

            //Если порядок минорной матрицы равен двум -- происходит вычисление его значения
            if (MiniMatrix.GetLength(0) == 2)                                                       
            {                                                                
                return MiniMatrix[0, 0] * MiniMatrix[1, 1] - MiniMatrix[1, 0] * MiniMatrix[0, 1];
            }

            //Если порядок больше -- с помощью рекурсии минорная матрица разбивается на матрицы 
            //меньших порядков до тех пор, пока они не станут равны двум, после чего происходит вычисление их
            //определителей и суммирование с учетом знаков, зависящих от номера столбца
            else
            {                                                                  
                double InMinor = 0;                                                                 
                for (int j = 0; j < MiniMatrix.GetLength(0); j++)                                  
                {                                                                                   
                    InMinor += MiniMatrix[0,j]*Math.Pow(-1, (1+j+1))* GetMinor(MiniMatrix, j);     
                }
                return InMinor;
            } 
        }

        //Получить минорную матрицу (индексация с нуля!)
        public double[,] GetMinorMatrix(double[,] A, int row, int column)                           
        {
            //"Отделение" минорной матрицы от основной путем
            //удаления элементов заданных строки и стоблца
            double[,] B = new double[A.GetLength(0) - 1, A.GetLength(0) - 1];                       
            for (int i = 0; i < row; i++)                                                        
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

        //Получение транспонированной матрицы
        public double[,] GetTransposedMatrix(double[,] A)   
        {
            //С помощью двойного цикла элементам транспонированной
            //матрицы присваиваются те же значения, что и у исходной,
            //но с заменой строк на столбцы и наоборот
            double[,] transposedMatrix = new double[A.GetLength(1), A.GetLength(0)];
            for (int i = 0; i < A.GetLength(0); i++)                                               
            {                                            
                for(int j = 0; j < A.GetLength(1); j++)   
                {
                    transposedMatrix[j, i] = A[i, j];
                }
            }
            return transposedMatrix;
        }

        //Получение обратной матрицы
        public double[,] GetInvertedMatrix(double[,] A)
        {
            double[,] transposeMatrix = new double[A.GetLength(0), A.GetLength(0)];
            double[,] adjugateMatrix = new double[A.GetLength(0), A.GetLength(0)];
            double[,] invertedMatrix = new double[A.GetLength(0), A.GetLength(0)];

            //Получение транспонирование матрицы
            transposeMatrix = GetTransposedMatrix(A);

            //Получение союзной матрицы из транспонированной
            for (int i = 0; i < transposeMatrix.GetLength(0); i++)                       
            {
                for (int j = 0; j < transposeMatrix.GetLength(1); j++)
                {
                    adjugateMatrix[i, j] = Math.Pow(-1, i + 1 + j + 1) * GetDeterminant(GetMinorMatrix(transposeMatrix, i, j));
                }
            }

            //Получение обратной матрицы делением союзной матрицы на определитель исходной
            for (int j = 0; j < adjugateMatrix.GetLength(1); j++)                                   
            {                                                                                   
                for (int i = 0; i < adjugateMatrix.GetLength(0); i++)
                {
                    invertedMatrix[i, j] = (adjugateMatrix[i, j] / GetDeterminant(A));
                }
            }
            return invertedMatrix;
        }

        //Получение произведения матриц
        public double[,] GetMatrixMultiplication(double[,] A, double[,] B)  
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

        //Пасхалка
        private void pbSun_Click(object sender, EventArgs e)  
        {
            bitmap1 = (Bitmap)pbSun.Image;
            bitmap1.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbSun.Image = bitmap1;
        }

        //Гиперссылка
        private void llSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)            
        {
            //Системный метод, предназначенный для запуска локального 
            //или удаленного процесса, в данном случае -- переход по гиперссылке
            System.Diagnostics.Process.Start("http://www.vk.com/souljrn");                          
        }                                                                                           
                                                                                        
    }                                                                                               
}

