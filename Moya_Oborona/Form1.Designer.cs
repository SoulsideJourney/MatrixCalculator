namespace Moya_Oborona
{
    partial class MainFormMatrix
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormMatrix));
            this.tcLayout = new System.Windows.Forms.TabControl();
            this.tcOperations = new System.Windows.Forms.TabPage();
            this.lbMatrixAX = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lbMatrixX = new System.Windows.Forms.Label();
            this.dgvMatrixX = new System.Windows.Forms.DataGridView();
            this.cbMatrixBColumns = new System.Windows.Forms.ComboBox();
            this.cbMatrixAColumns = new System.Windows.Forms.ComboBox();
            this.lbMatrixBX = new System.Windows.Forms.Label();
            this.cbMatrixBRows = new System.Windows.Forms.ComboBox();
            this.cbMatrixARows = new System.Windows.Forms.ComboBox();
            this.lbMatrixBDimensions = new System.Windows.Forms.Label();
            this.lbMatrixADimensions = new System.Windows.Forms.Label();
            this.lbMatrixB = new System.Windows.Forms.Label();
            this.lbMatrixA = new System.Windows.Forms.Label();
            this.cbTypeOfOperation = new System.Windows.Forms.ComboBox();
            this.lbTypeOfOperation = new System.Windows.Forms.Label();
            this.dgvMatrixB = new System.Windows.Forms.DataGridView();
            this.Bj1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMatrixA = new System.Windows.Forms.DataGridView();
            this.Aj1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcDeterminant = new System.Windows.Forms.TabPage();
            this.btnTranspose = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.dgvMatrixNew = new System.Windows.Forms.DataGridView();
            this.dgvMatrix = new System.Windows.Forms.DataGridView();
            this.j1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.j2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.j3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGetDeterminant = new System.Windows.Forms.Button();
            this.tbDeterminant = new System.Windows.Forms.TextBox();
            this.cbMatrixSize = new System.Windows.Forms.ComboBox();
            this.lbMatrixSize = new System.Windows.Forms.Label();
            this.tbAboutProgram = new System.Windows.Forms.TabPage();
            this.pbSun = new System.Windows.Forms.PictureBox();
            this.lbAboutProgram = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.llSite = new System.Windows.Forms.LinkLabel();
            this.tcLayout.SuspendLayout();
            this.tcOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrixX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrixB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrixA)).BeginInit();
            this.tcDeterminant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrixNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).BeginInit();
            this.tbAboutProgram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSun)).BeginInit();
            this.SuspendLayout();
            // 
            // tcLayout
            // 
            this.tcLayout.Controls.Add(this.tcOperations);
            this.tcLayout.Controls.Add(this.tcDeterminant);
            this.tcLayout.Controls.Add(this.tbAboutProgram);
            this.tcLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcLayout.Location = new System.Drawing.Point(0, 0);
            this.tcLayout.Name = "tcLayout";
            this.tcLayout.SelectedIndex = 0;
            this.tcLayout.Size = new System.Drawing.Size(1175, 290);
            this.tcLayout.TabIndex = 0;
            // 
            // tcOperations
            // 
            this.tcOperations.Controls.Add(this.lbMatrixAX);
            this.tcOperations.Controls.Add(this.btnCalculate);
            this.tcOperations.Controls.Add(this.lbMatrixX);
            this.tcOperations.Controls.Add(this.dgvMatrixX);
            this.tcOperations.Controls.Add(this.cbMatrixBColumns);
            this.tcOperations.Controls.Add(this.cbMatrixAColumns);
            this.tcOperations.Controls.Add(this.lbMatrixBX);
            this.tcOperations.Controls.Add(this.cbMatrixBRows);
            this.tcOperations.Controls.Add(this.cbMatrixARows);
            this.tcOperations.Controls.Add(this.lbMatrixBDimensions);
            this.tcOperations.Controls.Add(this.lbMatrixADimensions);
            this.tcOperations.Controls.Add(this.lbMatrixB);
            this.tcOperations.Controls.Add(this.lbMatrixA);
            this.tcOperations.Controls.Add(this.cbTypeOfOperation);
            this.tcOperations.Controls.Add(this.lbTypeOfOperation);
            this.tcOperations.Controls.Add(this.dgvMatrixB);
            this.tcOperations.Controls.Add(this.dgvMatrixA);
            this.tcOperations.Location = new System.Drawing.Point(4, 22);
            this.tcOperations.Name = "tcOperations";
            this.tcOperations.Padding = new System.Windows.Forms.Padding(3);
            this.tcOperations.Size = new System.Drawing.Size(1167, 264);
            this.tcOperations.TabIndex = 1;
            this.tcOperations.Text = "Операции c с двумя матрицами";
            this.tcOperations.UseVisualStyleBackColor = true;
            // 
            // lbMatrixAX
            // 
            this.lbMatrixAX.AutoSize = true;
            this.lbMatrixAX.Location = new System.Drawing.Point(135, 43);
            this.lbMatrixAX.Name = "lbMatrixAX";
            this.lbMatrixAX.Size = new System.Drawing.Size(14, 13);
            this.lbMatrixAX.TabIndex = 17;
            this.lbMatrixAX.Text = "X";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(730, 118);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 16;
            this.btnCalculate.Text = "Вычислить";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lbMatrixX
            // 
            this.lbMatrixX.AutoSize = true;
            this.lbMatrixX.Location = new System.Drawing.Point(916, 14);
            this.lbMatrixX.Name = "lbMatrixX";
            this.lbMatrixX.Size = new System.Drawing.Size(61, 13);
            this.lbMatrixX.TabIndex = 15;
            this.lbMatrixX.Text = "Матрица X";
            // 
            // dgvMatrixX
            // 
            this.dgvMatrixX.AllowUserToAddRows = false;
            this.dgvMatrixX.AllowUserToDeleteRows = false;
            this.dgvMatrixX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrixX.Location = new System.Drawing.Point(811, 69);
            this.dgvMatrixX.Name = "dgvMatrixX";
            this.dgvMatrixX.ReadOnly = true;
            this.dgvMatrixX.RowHeadersWidth = 50;
            this.dgvMatrixX.Size = new System.Drawing.Size(292, 155);
            this.dgvMatrixX.TabIndex = 14;
            // 
            // cbMatrixBColumns
            // 
            this.cbMatrixBColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatrixBColumns.FormattingEnabled = true;
            this.cbMatrixBColumns.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbMatrixBColumns.Location = new System.Drawing.Point(576, 40);
            this.cbMatrixBColumns.Name = "cbMatrixBColumns";
            this.cbMatrixBColumns.Size = new System.Drawing.Size(39, 21);
            this.cbMatrixBColumns.TabIndex = 13;
            this.cbMatrixBColumns.SelectedIndexChanged += new System.EventHandler(this.cbMatrixBColumns_SelectedIndexChanged);
            // 
            // cbMatrixAColumns
            // 
            this.cbMatrixAColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatrixAColumns.FormattingEnabled = true;
            this.cbMatrixAColumns.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbMatrixAColumns.Location = new System.Drawing.Point(155, 40);
            this.cbMatrixAColumns.Name = "cbMatrixAColumns";
            this.cbMatrixAColumns.Size = new System.Drawing.Size(36, 21);
            this.cbMatrixAColumns.TabIndex = 12;
            this.cbMatrixAColumns.SelectedIndexChanged += new System.EventHandler(this.cbMatrixAColumns_SelectedIndexChanged);
            // 
            // lbMatrixBX
            // 
            this.lbMatrixBX.AutoSize = true;
            this.lbMatrixBX.Location = new System.Drawing.Point(556, 43);
            this.lbMatrixBX.Name = "lbMatrixBX";
            this.lbMatrixBX.Size = new System.Drawing.Size(14, 13);
            this.lbMatrixBX.TabIndex = 11;
            this.lbMatrixBX.Text = "X";
            // 
            // cbMatrixBRows
            // 
            this.cbMatrixBRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatrixBRows.FormattingEnabled = true;
            this.cbMatrixBRows.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbMatrixBRows.Location = new System.Drawing.Point(513, 40);
            this.cbMatrixBRows.Name = "cbMatrixBRows";
            this.cbMatrixBRows.Size = new System.Drawing.Size(37, 21);
            this.cbMatrixBRows.TabIndex = 9;
            this.cbMatrixBRows.SelectedIndexChanged += new System.EventHandler(this.cbMatrixBRows_SelectedIndexChanged);
            this.cbMatrixBRows.TextUpdate += new System.EventHandler(this.cbMatrixBRows_SelectedIndexChanged);
            // 
            // cbMatrixARows
            // 
            this.cbMatrixARows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatrixARows.FormattingEnabled = true;
            this.cbMatrixARows.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbMatrixARows.Location = new System.Drawing.Point(92, 40);
            this.cbMatrixARows.Name = "cbMatrixARows";
            this.cbMatrixARows.Size = new System.Drawing.Size(37, 21);
            this.cbMatrixARows.TabIndex = 8;
            this.cbMatrixARows.SelectedIndexChanged += new System.EventHandler(this.cbMatrixARows_SelectedIndexChanged);
            // 
            // lbMatrixBDimensions
            // 
            this.lbMatrixBDimensions.AutoSize = true;
            this.lbMatrixBDimensions.Location = new System.Drawing.Point(429, 43);
            this.lbMatrixBDimensions.Name = "lbMatrixBDimensions";
            this.lbMatrixBDimensions.Size = new System.Drawing.Size(78, 13);
            this.lbMatrixBDimensions.TabIndex = 7;
            this.lbMatrixBDimensions.Text = "Размерность:";
            // 
            // lbMatrixADimensions
            // 
            this.lbMatrixADimensions.AutoSize = true;
            this.lbMatrixADimensions.Location = new System.Drawing.Point(8, 43);
            this.lbMatrixADimensions.Name = "lbMatrixADimensions";
            this.lbMatrixADimensions.Size = new System.Drawing.Size(78, 13);
            this.lbMatrixADimensions.TabIndex = 6;
            this.lbMatrixADimensions.Text = "Размерность:";
            // 
            // lbMatrixB
            // 
            this.lbMatrixB.AutoSize = true;
            this.lbMatrixB.Location = new System.Drawing.Point(554, 14);
            this.lbMatrixB.Name = "lbMatrixB";
            this.lbMatrixB.Size = new System.Drawing.Size(61, 13);
            this.lbMatrixB.TabIndex = 5;
            this.lbMatrixB.Text = "Матрица B";
            // 
            // lbMatrixA
            // 
            this.lbMatrixA.AutoSize = true;
            this.lbMatrixA.Location = new System.Drawing.Point(130, 14);
            this.lbMatrixA.Name = "lbMatrixA";
            this.lbMatrixA.Size = new System.Drawing.Size(61, 13);
            this.lbMatrixA.TabIndex = 4;
            this.lbMatrixA.Text = "Матрица A";
            // 
            // cbTypeOfOperation
            // 
            this.cbTypeOfOperation.FormattingEnabled = true;
            this.cbTypeOfOperation.Items.AddRange(new object[] {
            "умножение",
            "сложение",
            "вычитание",
            "уравнение A*X=B",
            "уравнение X*A=B"});
            this.cbTypeOfOperation.Location = new System.Drawing.Point(305, 67);
            this.cbTypeOfOperation.Name = "cbTypeOfOperation";
            this.cbTypeOfOperation.Size = new System.Drawing.Size(121, 21);
            this.cbTypeOfOperation.TabIndex = 3;
            this.cbTypeOfOperation.Text = "умножение";
            this.cbTypeOfOperation.SelectedIndexChanged += new System.EventHandler(this.cbTypeOfOperation_SelectedIndexChanged);
            // 
            // lbTypeOfOperation
            // 
            this.lbTypeOfOperation.AutoSize = true;
            this.lbTypeOfOperation.Location = new System.Drawing.Point(324, 51);
            this.lbTypeOfOperation.Name = "lbTypeOfOperation";
            this.lbTypeOfOperation.Size = new System.Drawing.Size(80, 13);
            this.lbTypeOfOperation.TabIndex = 2;
            this.lbTypeOfOperation.Text = "Тип операции:";
            // 
            // dgvMatrixB
            // 
            this.dgvMatrixB.AllowUserToAddRows = false;
            this.dgvMatrixB.AllowUserToDeleteRows = false;
            this.dgvMatrixB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrixB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bj1});
            this.dgvMatrixB.Location = new System.Drawing.Point(432, 67);
            this.dgvMatrixB.Name = "dgvMatrixB";
            this.dgvMatrixB.RowHeadersWidth = 50;
            this.dgvMatrixB.Size = new System.Drawing.Size(292, 155);
            this.dgvMatrixB.TabIndex = 1;
            // 
            // Bj1
            // 
            this.Bj1.HeaderText = "j1";
            this.Bj1.Name = "Bj1";
            this.Bj1.ReadOnly = true;
            this.Bj1.Width = 40;
            // 
            // dgvMatrixA
            // 
            this.dgvMatrixA.AllowUserToAddRows = false;
            this.dgvMatrixA.AllowUserToDeleteRows = false;
            this.dgvMatrixA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrixA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Aj1});
            this.dgvMatrixA.Location = new System.Drawing.Point(8, 67);
            this.dgvMatrixA.Name = "dgvMatrixA";
            this.dgvMatrixA.RowHeadersWidth = 50;
            this.dgvMatrixA.Size = new System.Drawing.Size(292, 155);
            this.dgvMatrixA.TabIndex = 0;
            // 
            // Aj1
            // 
            this.Aj1.HeaderText = "j1";
            this.Aj1.Name = "Aj1";
            this.Aj1.ReadOnly = true;
            this.Aj1.Width = 40;
            // 
            // tcDeterminant
            // 
            this.tcDeterminant.Controls.Add(this.btnTranspose);
            this.tcDeterminant.Controls.Add(this.btnInvert);
            this.tcDeterminant.Controls.Add(this.dgvMatrixNew);
            this.tcDeterminant.Controls.Add(this.dgvMatrix);
            this.tcDeterminant.Controls.Add(this.btnGetDeterminant);
            this.tcDeterminant.Controls.Add(this.tbDeterminant);
            this.tcDeterminant.Controls.Add(this.cbMatrixSize);
            this.tcDeterminant.Controls.Add(this.lbMatrixSize);
            this.tcDeterminant.Location = new System.Drawing.Point(4, 22);
            this.tcDeterminant.Name = "tcDeterminant";
            this.tcDeterminant.Padding = new System.Windows.Forms.Padding(3);
            this.tcDeterminant.Size = new System.Drawing.Size(1167, 264);
            this.tcDeterminant.TabIndex = 0;
            this.tcDeterminant.Text = "Операции с одной матрицей";
            this.tcDeterminant.UseVisualStyleBackColor = true;
            // 
            // btnTranspose
            // 
            this.btnTranspose.Location = new System.Drawing.Point(383, 63);
            this.btnTranspose.Name = "btnTranspose";
            this.btnTranspose.Size = new System.Drawing.Size(117, 23);
            this.btnTranspose.TabIndex = 44;
            this.btnTranspose.Text = "Транспонировать";
            this.btnTranspose.UseVisualStyleBackColor = true;
            this.btnTranspose.Click += new System.EventHandler(this.btnTranspose_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(383, 92);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(117, 23);
            this.btnInvert.TabIndex = 43;
            this.btnInvert.Text = "Обратить";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // dgvMatrixNew
            // 
            this.dgvMatrixNew.AllowUserToAddRows = false;
            this.dgvMatrixNew.AllowUserToDeleteRows = false;
            this.dgvMatrixNew.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMatrixNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrixNew.Location = new System.Drawing.Point(506, 63);
            this.dgvMatrixNew.Name = "dgvMatrixNew";
            this.dgvMatrixNew.RowHeadersWidth = 50;
            this.dgvMatrixNew.Size = new System.Drawing.Size(290, 154);
            this.dgvMatrixNew.TabIndex = 42;
            // 
            // dgvMatrix
            // 
            this.dgvMatrix.AllowUserToAddRows = false;
            this.dgvMatrix.AllowUserToDeleteRows = false;
            this.dgvMatrix.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvMatrix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.j1,
            this.j2,
            this.j3});
            this.dgvMatrix.Location = new System.Drawing.Point(87, 63);
            this.dgvMatrix.Name = "dgvMatrix";
            this.dgvMatrix.RowHeadersWidth = 50;
            this.dgvMatrix.Size = new System.Drawing.Size(290, 154);
            this.dgvMatrix.TabIndex = 41;
            // 
            // j1
            // 
            this.j1.HeaderText = "j1";
            this.j1.Name = "j1";
            this.j1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.j1.Width = 40;
            // 
            // j2
            // 
            this.j2.HeaderText = "j2";
            this.j2.Name = "j2";
            this.j2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.j2.Width = 40;
            // 
            // j3
            // 
            this.j3.HeaderText = "j3";
            this.j3.Name = "j3";
            this.j3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.j3.Width = 40;
            // 
            // btnGetDeterminant
            // 
            this.btnGetDeterminant.Location = new System.Drawing.Point(87, 223);
            this.btnGetDeterminant.Name = "btnGetDeterminant";
            this.btnGetDeterminant.Size = new System.Drawing.Size(92, 23);
            this.btnGetDeterminant.TabIndex = 40;
            this.btnGetDeterminant.Text = "Определитель";
            this.btnGetDeterminant.UseVisualStyleBackColor = true;
            this.btnGetDeterminant.Click += new System.EventHandler(this.btnGetDeterminant_Click);
            // 
            // tbDeterminant
            // 
            this.tbDeterminant.Location = new System.Drawing.Point(185, 225);
            this.tbDeterminant.Name = "tbDeterminant";
            this.tbDeterminant.Size = new System.Drawing.Size(100, 20);
            this.tbDeterminant.TabIndex = 39;
            // 
            // cbMatrixSize
            // 
            this.cbMatrixSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMatrixSize.FormattingEnabled = true;
            this.cbMatrixSize.Items.AddRange(new object[] {
            "2x2",
            "3x3",
            "4x4",
            "5x5",
            "6x6"});
            this.cbMatrixSize.Location = new System.Drawing.Point(6, 79);
            this.cbMatrixSize.Name = "cbMatrixSize";
            this.cbMatrixSize.Size = new System.Drawing.Size(41, 21);
            this.cbMatrixSize.TabIndex = 11;
            this.cbMatrixSize.SelectedIndexChanged += new System.EventHandler(this.cbMatrixSize_SelectedIndexChanged);
            // 
            // lbMatrixSize
            // 
            this.lbMatrixSize.AutoSize = true;
            this.lbMatrixSize.Location = new System.Drawing.Point(3, 63);
            this.lbMatrixSize.Name = "lbMatrixSize";
            this.lbMatrixSize.Size = new System.Drawing.Size(78, 13);
            this.lbMatrixSize.TabIndex = 10;
            this.lbMatrixSize.Text = "Размерность:";
            // 
            // tbAboutProgram
            // 
            this.tbAboutProgram.Controls.Add(this.llSite);
            this.tbAboutProgram.Controls.Add(this.pbSun);
            this.tbAboutProgram.Controls.Add(this.lbAboutProgram);
            this.tbAboutProgram.Location = new System.Drawing.Point(4, 22);
            this.tbAboutProgram.Name = "tbAboutProgram";
            this.tbAboutProgram.Padding = new System.Windows.Forms.Padding(3);
            this.tbAboutProgram.Size = new System.Drawing.Size(1167, 264);
            this.tbAboutProgram.TabIndex = 2;
            this.tbAboutProgram.Text = "О программе";
            this.tbAboutProgram.UseVisualStyleBackColor = true;
            // 
            // pbSun
            // 
            this.pbSun.Image = ((System.Drawing.Image)(resources.GetObject("pbSun.Image")));
            this.pbSun.Location = new System.Drawing.Point(485, 6);
            this.pbSun.Name = "pbSun";
            this.pbSun.Size = new System.Drawing.Size(160, 160);
            this.pbSun.TabIndex = 1;
            this.pbSun.TabStop = false;
            this.pbSun.Click += new System.EventHandler(this.pbSun_Click);
            this.pbSun.DoubleClick += new System.EventHandler(this.pbSun_Click);
            // 
            // lbAboutProgram
            // 
            this.lbAboutProgram.AutoSize = true;
            this.lbAboutProgram.Location = new System.Drawing.Point(482, 168);
            this.lbAboutProgram.Name = "lbAboutProgram";
            this.lbAboutProgram.Size = new System.Drawing.Size(138, 65);
            this.lbAboutProgram.TabIndex = 0;
            this.lbAboutProgram.Text = "          Автор программы:\r\n              студент ЮУрГУ\r\n          Александр Соко" +
    "лов\r\n                         aka\r\n              Soulside Journey";
            // 
            // llSite
            // 
            this.llSite.AutoSize = true;
            this.llSite.Location = new System.Drawing.Point(528, 233);
            this.llSite.Name = "llSite";
            this.llSite.Size = new System.Drawing.Size(77, 13);
            this.llSite.TabIndex = 2;
            this.llSite.TabStop = true;
            this.llSite.Text = "vk.com/souljrn";
            this.llSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSite_LinkClicked);
            // 
            // MainFormMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 290);
            this.Controls.Add(this.tcLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1191, 329);
            this.MinimumSize = new System.Drawing.Size(1191, 329);
            this.Name = "MainFormMatrix";
            this.Text = "Матрицы";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcLayout.ResumeLayout(false);
            this.tcOperations.ResumeLayout(false);
            this.tcOperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrixX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrixB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrixA)).EndInit();
            this.tcDeterminant.ResumeLayout(false);
            this.tcDeterminant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrixNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).EndInit();
            this.tbAboutProgram.ResumeLayout(false);
            this.tbAboutProgram.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSun)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcLayout;
        private System.Windows.Forms.TabPage tcDeterminant;
        private System.Windows.Forms.TabPage tcOperations;
        private System.Windows.Forms.ComboBox cbMatrixSize;
        private System.Windows.Forms.Label lbMatrixSize;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnGetDeterminant;
        private System.Windows.Forms.TextBox tbDeterminant;
        private System.Windows.Forms.DataGridView dgvMatrix;
        private System.Windows.Forms.DataGridViewTextBoxColumn j1;
        private System.Windows.Forms.DataGridViewTextBoxColumn j2;
        private System.Windows.Forms.DataGridViewTextBoxColumn j3;
        private System.Windows.Forms.Label lbTypeOfOperation;
        private System.Windows.Forms.DataGridView dgvMatrixB;
        private System.Windows.Forms.DataGridView dgvMatrixA;
        private System.Windows.Forms.Label lbMatrixB;
        private System.Windows.Forms.Label lbMatrixA;
        private System.Windows.Forms.ComboBox cbTypeOfOperation;
        private System.Windows.Forms.Label lbMatrixADimensions;
        private System.Windows.Forms.ComboBox cbMatrixBRows;
        private System.Windows.Forms.ComboBox cbMatrixARows;
        private System.Windows.Forms.Label lbMatrixBDimensions;
        private System.Windows.Forms.ComboBox cbMatrixBColumns;
        private System.Windows.Forms.ComboBox cbMatrixAColumns;
        private System.Windows.Forms.Label lbMatrixBX;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bj1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aj1;
        private System.Windows.Forms.Label lbMatrixX;
        private System.Windows.Forms.DataGridView dgvMatrixX;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lbMatrixAX;
        private System.Windows.Forms.Button btnTranspose;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.DataGridView dgvMatrixNew;
        private System.Windows.Forms.TabPage tbAboutProgram;
        private System.Windows.Forms.Label lbAboutProgram;
        private System.Windows.Forms.PictureBox pbSun;
        private System.Windows.Forms.LinkLabel llSite;
    }
}

