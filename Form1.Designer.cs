namespace LogistikField
{
    partial class Form1
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
            this.pictureBoxField = new System.Windows.Forms.PictureBox();
            this.buttonViewField = new System.Windows.Forms.Button();
            this.textBoxCoordsTest = new System.Windows.Forms.TextBox();
            this.buttonView = new System.Windows.Forms.Button();
            this.labelFileWithField = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonTrackView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxForXPointCross = new System.Windows.Forms.ListBox();
            this.buttonChooseEnterPoint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxForFullWayCombain = new System.Windows.Forms.TextBox();
            this.buttonOptymalTrack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxField)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxField
            // 
            this.pictureBoxField.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxField.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxField.Name = "pictureBoxField";
            this.pictureBoxField.Size = new System.Drawing.Size(420, 367);
            this.pictureBoxField.TabIndex = 0;
            this.pictureBoxField.TabStop = false;
            // 
            // buttonViewField
            // 
            this.buttonViewField.Location = new System.Drawing.Point(473, 69);
            this.buttonViewField.Name = "buttonViewField";
            this.buttonViewField.Size = new System.Drawing.Size(114, 45);
            this.buttonViewField.TabIndex = 3;
            this.buttonViewField.Text = "Отрисовать поле";
            this.buttonViewField.UseVisualStyleBackColor = true;
            this.buttonViewField.Click += new System.EventHandler(this.buttonViewField_Click);
            // 
            // textBoxCoordsTest
            // 
            this.textBoxCoordsTest.Location = new System.Drawing.Point(473, 43);
            this.textBoxCoordsTest.Name = "textBoxCoordsTest";
            this.textBoxCoordsTest.ReadOnly = true;
            this.textBoxCoordsTest.Size = new System.Drawing.Size(42, 20);
            this.textBoxCoordsTest.TabIndex = 4;
            // 
            // buttonView
            // 
            this.buttonView.Location = new System.Drawing.Point(521, 43);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(66, 20);
            this.buttonView.TabIndex = 5;
            this.buttonView.Text = "Обзор";
            this.buttonView.UseVisualStyleBackColor = true;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // labelFileWithField
            // 
            this.labelFileWithField.AutoSize = true;
            this.labelFileWithField.Location = new System.Drawing.Point(470, 27);
            this.labelFileWithField.Name = "labelFileWithField";
            this.labelFileWithField.Size = new System.Drawing.Size(83, 13);
            this.labelFileWithField.TabIndex = 6;
            this.labelFileWithField.Text = "Файл с полем:";
            // 
            // buttonTrackView
            // 
            this.buttonTrackView.Location = new System.Drawing.Point(617, 72);
            this.buttonTrackView.Name = "buttonTrackView";
            this.buttonTrackView.Size = new System.Drawing.Size(114, 45);
            this.buttonTrackView.TabIndex = 12;
            this.buttonTrackView.Text = "Отрисовать разрез";
            this.buttonTrackView.UseVisualStyleBackColor = true;
            this.buttonTrackView.Click += new System.EventHandler(this.buttonTrackView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Задайте точку входа в поле:\r\n";
            // 
            // listBoxForXPointCross
            // 
            this.listBoxForXPointCross.FormattingEnabled = true;
            this.listBoxForXPointCross.Location = new System.Drawing.Point(473, 201);
            this.listBoxForXPointCross.Name = "listBoxForXPointCross";
            this.listBoxForXPointCross.Size = new System.Drawing.Size(114, 147);
            this.listBoxForXPointCross.TabIndex = 14;
            // 
            // buttonChooseEnterPoint
            // 
            this.buttonChooseEnterPoint.Location = new System.Drawing.Point(473, 356);
            this.buttonChooseEnterPoint.Name = "buttonChooseEnterPoint";
            this.buttonChooseEnterPoint.Size = new System.Drawing.Size(114, 23);
            this.buttonChooseEnterPoint.TabIndex = 15;
            this.buttonChooseEnterPoint.Text = "Выбрать";
            this.buttonChooseEnterPoint.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Введите полный ход комбайна:";
            // 
            // textBoxForFullWayCombain
            // 
            this.textBoxForFullWayCombain.Location = new System.Drawing.Point(597, 201);
            this.textBoxForFullWayCombain.Name = "textBoxForFullWayCombain";
            this.textBoxForFullWayCombain.Size = new System.Drawing.Size(163, 20);
            this.textBoxForFullWayCombain.TabIndex = 17;
            // 
            // buttonOptymalTrack
            // 
            this.buttonOptymalTrack.Location = new System.Drawing.Point(473, 120);
            this.buttonOptymalTrack.Name = "buttonOptymalTrack";
            this.buttonOptymalTrack.Size = new System.Drawing.Size(114, 51);
            this.buttonOptymalTrack.TabIndex = 19;
            this.buttonOptymalTrack.Text = "Оптимальный трек";
            this.buttonOptymalTrack.UseVisualStyleBackColor = true;
            this.buttonOptymalTrack.Click += new System.EventHandler(this.buttonOptymalTrack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 405);
            this.Controls.Add(this.buttonOptymalTrack);
            this.Controls.Add(this.textBoxForFullWayCombain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonChooseEnterPoint);
            this.Controls.Add(this.listBoxForXPointCross);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxField);
            this.Controls.Add(this.buttonTrackView);
            this.Controls.Add(this.labelFileWithField);
            this.Controls.Add(this.buttonView);
            this.Controls.Add(this.textBoxCoordsTest);
            this.Controls.Add(this.buttonViewField);
            this.Name = "Form1";
            this.Text = "Logistik";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxField;
        private System.Windows.Forms.Button buttonViewField;
        private System.Windows.Forms.TextBox textBoxCoordsTest;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.Label labelFileWithField;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonTrackView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxForXPointCross;
        private System.Windows.Forms.Button buttonChooseEnterPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxForFullWayCombain;
        private System.Windows.Forms.Button buttonOptymalTrack;
    }
}

