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
            this.buttonViewField.Location = new System.Drawing.Point(655, 59);
            this.buttonViewField.Name = "buttonViewField";
            this.buttonViewField.Size = new System.Drawing.Size(114, 42);
            this.buttonViewField.TabIndex = 3;
            this.buttonViewField.Text = "Отрисовать поле";
            this.buttonViewField.UseVisualStyleBackColor = true;
            this.buttonViewField.Click += new System.EventHandler(this.buttonViewField_Click);
            // 
            // textBoxCoordsTest
            // 
            this.textBoxCoordsTest.Location = new System.Drawing.Point(473, 75);
            this.textBoxCoordsTest.Name = "textBoxCoordsTest";
            this.textBoxCoordsTest.ReadOnly = true;
            this.textBoxCoordsTest.Size = new System.Drawing.Size(42, 20);
            this.textBoxCoordsTest.TabIndex = 4;
            // 
            // buttonView
            // 
            this.buttonView.Location = new System.Drawing.Point(521, 75);
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
            this.labelFileWithField.Location = new System.Drawing.Point(470, 59);
            this.labelFileWithField.Name = "labelFileWithField";
            this.labelFileWithField.Size = new System.Drawing.Size(83, 13);
            this.labelFileWithField.TabIndex = 6;
            this.labelFileWithField.Text = "Файл с полем:";
            // 
            // buttonTrackView
            // 
            this.buttonTrackView.Location = new System.Drawing.Point(655, 184);
            this.buttonTrackView.Name = "buttonTrackView";
            this.buttonTrackView.Size = new System.Drawing.Size(114, 36);
            this.buttonTrackView.TabIndex = 12;
            this.buttonTrackView.Text = "Отрисовать разрез";
            this.buttonTrackView.UseVisualStyleBackColor = true;
            this.buttonTrackView.Click += new System.EventHandler(this.buttonTrackView_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Введите полный ход комбайна:";
            // 
            // textBoxForFullWayCombain
            // 
            this.textBoxForFullWayCombain.Location = new System.Drawing.Point(473, 200);
            this.textBoxForFullWayCombain.Name = "textBoxForFullWayCombain";
            this.textBoxForFullWayCombain.Size = new System.Drawing.Size(163, 20);
            this.textBoxForFullWayCombain.TabIndex = 17;
            // 
            // buttonOptymalTrack
            // 
            this.buttonOptymalTrack.Location = new System.Drawing.Point(473, 113);
            this.buttonOptymalTrack.Name = "buttonOptymalTrack";
            this.buttonOptymalTrack.Size = new System.Drawing.Size(296, 51);
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
            this.Controls.Add(this.pictureBoxField);
            this.Controls.Add(this.buttonTrackView);
            this.Controls.Add(this.labelFileWithField);
            this.Controls.Add(this.buttonView);
            this.Controls.Add(this.textBoxCoordsTest);
            this.Controls.Add(this.buttonViewField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxForFullWayCombain;
        private System.Windows.Forms.Button buttonOptymalTrack;
    }
}

