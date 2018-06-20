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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonTrackView = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxForFullWayCombain = new System.Windows.Forms.TextBox();
            this.buttonOptymalTrack = new System.Windows.Forms.Button();
            this.buttonAddTrouble = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПолеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПолеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПрепяствияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыКомбайнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxCoordsTest = new System.Windows.Forms.TextBox();
            this.buttonOptPath = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxField)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxField
            // 
            this.pictureBoxField.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxField.Location = new System.Drawing.Point(9, 26);
            this.pictureBoxField.Name = "pictureBoxField";
            this.pictureBoxField.Size = new System.Drawing.Size(420, 367);
            this.pictureBoxField.TabIndex = 0;
            this.pictureBoxField.TabStop = false;
            // 
            // buttonViewField
            // 
            this.buttonViewField.Location = new System.Drawing.Point(473, 63);
            this.buttonViewField.Name = "buttonViewField";
            this.buttonViewField.Size = new System.Drawing.Size(151, 42);
            this.buttonViewField.TabIndex = 3;
            this.buttonViewField.Text = "Отрисовать поле";
            this.buttonViewField.UseVisualStyleBackColor = true;
            this.buttonViewField.Click += new System.EventHandler(this.buttonViewField_Click);
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
            // buttonAddTrouble
            // 
            this.buttonAddTrouble.Location = new System.Drawing.Point(630, 63);
            this.buttonAddTrouble.Name = "buttonAddTrouble";
            this.buttonAddTrouble.Size = new System.Drawing.Size(139, 42);
            this.buttonAddTrouble.TabIndex = 20;
            this.buttonAddTrouble.Text = "Отрисовать препятствия";
            this.buttonAddTrouble.UseVisualStyleBackColor = true;
            this.buttonAddTrouble.Click += new System.EventHandler(this.buttonAddTrouble_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.добавитьПолеToolStripMenuItem1,
            this.параметрыКомбайнаToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(794, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            // 
            // добавитьПолеToolStripMenuItem1
            // 
            this.добавитьПолеToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьПолеToolStripMenuItem,
            this.добавитьПрепяствияToolStripMenuItem});
            this.добавитьПолеToolStripMenuItem1.Name = "добавитьПолеToolStripMenuItem1";
            this.добавитьПолеToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.добавитьПолеToolStripMenuItem1.Text = "Поле...";
            // 
            // добавитьПолеToolStripMenuItem
            // 
            this.добавитьПолеToolStripMenuItem.Name = "добавитьПолеToolStripMenuItem";
            this.добавитьПолеToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.добавитьПолеToolStripMenuItem.Text = "Добавить поле";
            this.добавитьПолеToolStripMenuItem.Click += new System.EventHandler(this.добавитьПолеToolStripMenuItem_Click);
            // 
            // добавитьПрепяствияToolStripMenuItem
            // 
            this.добавитьПрепяствияToolStripMenuItem.Name = "добавитьПрепяствияToolStripMenuItem";
            this.добавитьПрепяствияToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.добавитьПрепяствияToolStripMenuItem.Text = "Добавить препяствия";
            this.добавитьПрепяствияToolStripMenuItem.Click += new System.EventHandler(this.добавитьПрепяствияToolStripMenuItem_Click);
            // 
            // параметрыКомбайнаToolStripMenuItem
            // 
            this.параметрыКомбайнаToolStripMenuItem.Name = "параметрыКомбайнаToolStripMenuItem";
            this.параметрыКомбайнаToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.параметрыКомбайнаToolStripMenuItem.Text = "Параметры комбайна";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // textBoxCoordsTest
            // 
            this.textBoxCoordsTest.Location = new System.Drawing.Point(9, 399);
            this.textBoxCoordsTest.Name = "textBoxCoordsTest";
            this.textBoxCoordsTest.ReadOnly = true;
            this.textBoxCoordsTest.Size = new System.Drawing.Size(420, 20);
            this.textBoxCoordsTest.TabIndex = 4;
            // 
            // buttonOptPath
            // 
            this.buttonOptPath.Location = new System.Drawing.Point(473, 227);
            this.buttonOptPath.Name = "buttonOptPath";
            this.buttonOptPath.Size = new System.Drawing.Size(296, 51);
            this.buttonOptPath.TabIndex = 22;
            this.buttonOptPath.Text = "Порядок обхода";
            this.buttonOptPath.UseVisualStyleBackColor = true;
            this.buttonOptPath.Click += new System.EventHandler(this.buttonOptPath_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(473, 284);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(296, 23);
            this.progressBar1.TabIndex = 23;
            this.progressBar1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 428);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonOptPath);
            this.Controls.Add(this.buttonAddTrouble);
            this.Controls.Add(this.buttonOptymalTrack);
            this.Controls.Add(this.textBoxForFullWayCombain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxField);
            this.Controls.Add(this.buttonTrackView);
            this.Controls.Add(this.textBoxCoordsTest);
            this.Controls.Add(this.buttonViewField);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Logistik";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxField)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxField;
        private System.Windows.Forms.Button buttonViewField;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonTrackView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxForFullWayCombain;
        private System.Windows.Forms.Button buttonOptymalTrack;
        private System.Windows.Forms.Button buttonAddTrouble;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПолеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПолеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПрепяствияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxCoordsTest;
        private System.Windows.Forms.ToolStripMenuItem параметрыКомбайнаToolStripMenuItem;
        private System.Windows.Forms.Button buttonOptPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

