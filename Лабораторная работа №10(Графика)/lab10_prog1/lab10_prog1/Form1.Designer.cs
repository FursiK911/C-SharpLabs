namespace lab10_prog1
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
            this.pb_source = new System.Windows.Forms.PictureBox();
            this.lb_p_q = new System.Windows.Forms.Label();
            this.lb_x_q = new System.Windows.Forms.Label();
            this.lb_y_q = new System.Windows.Forms.Label();
            this.tb_x_q = new System.Windows.Forms.TextBox();
            this.tb_y_q = new System.Windows.Forms.TextBox();
            this.tb_y_p = new System.Windows.Forms.TextBox();
            this.tb_x_p = new System.Windows.Forms.TextBox();
            this.lb_y_p = new System.Windows.Forms.Label();
            this.lb_x_p = new System.Windows.Forms.Label();
            this.lb_p_p = new System.Windows.Forms.Label();
            this.bt_draw = new System.Windows.Forms.Button();
            this.tb_xmax = new System.Windows.Forms.TextBox();
            this.tb_xmin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ymax = new System.Windows.Forms.TextBox();
            this.tb_ymin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_source)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_source
            // 
            this.pb_source.Location = new System.Drawing.Point(12, 12);
            this.pb_source.Name = "pb_source";
            this.pb_source.Size = new System.Drawing.Size(633, 362);
            this.pb_source.TabIndex = 0;
            this.pb_source.TabStop = false;
            // 
            // lb_p_q
            // 
            this.lb_p_q.AutoSize = true;
            this.lb_p_q.Location = new System.Drawing.Point(656, 22);
            this.lb_p_q.Name = "lb_p_q";
            this.lb_p_q.Size = new System.Drawing.Size(15, 13);
            this.lb_p_q.TabIndex = 1;
            this.lb_p_q.Text = "Q";
            // 
            // lb_x_q
            // 
            this.lb_x_q.AutoSize = true;
            this.lb_x_q.Location = new System.Drawing.Point(656, 41);
            this.lb_x_q.Name = "lb_x_q";
            this.lb_x_q.Size = new System.Drawing.Size(14, 13);
            this.lb_x_q.TabIndex = 2;
            this.lb_x_q.Text = "X";
            // 
            // lb_y_q
            // 
            this.lb_y_q.AutoSize = true;
            this.lb_y_q.Location = new System.Drawing.Point(718, 41);
            this.lb_y_q.Name = "lb_y_q";
            this.lb_y_q.Size = new System.Drawing.Size(14, 13);
            this.lb_y_q.TabIndex = 3;
            this.lb_y_q.Text = "Y";
            // 
            // tb_x_q
            // 
            this.tb_x_q.Location = new System.Drawing.Point(676, 38);
            this.tb_x_q.Name = "tb_x_q";
            this.tb_x_q.Size = new System.Drawing.Size(36, 20);
            this.tb_x_q.TabIndex = 4;
            this.tb_x_q.Text = "0,3";
            // 
            // tb_y_q
            // 
            this.tb_y_q.Location = new System.Drawing.Point(738, 38);
            this.tb_y_q.Name = "tb_y_q";
            this.tb_y_q.Size = new System.Drawing.Size(36, 20);
            this.tb_y_q.TabIndex = 5;
            this.tb_y_q.Text = "2";
            // 
            // tb_y_p
            // 
            this.tb_y_p.Location = new System.Drawing.Point(738, 88);
            this.tb_y_p.Name = "tb_y_p";
            this.tb_y_p.Size = new System.Drawing.Size(36, 20);
            this.tb_y_p.TabIndex = 10;
            this.tb_y_p.Text = "4";
            // 
            // tb_x_p
            // 
            this.tb_x_p.Location = new System.Drawing.Point(676, 88);
            this.tb_x_p.Name = "tb_x_p";
            this.tb_x_p.Size = new System.Drawing.Size(36, 20);
            this.tb_x_p.TabIndex = 9;
            this.tb_x_p.Text = "4,5";
            // 
            // lb_y_p
            // 
            this.lb_y_p.AutoSize = true;
            this.lb_y_p.Location = new System.Drawing.Point(718, 91);
            this.lb_y_p.Name = "lb_y_p";
            this.lb_y_p.Size = new System.Drawing.Size(14, 13);
            this.lb_y_p.TabIndex = 8;
            this.lb_y_p.Text = "Y";
            // 
            // lb_x_p
            // 
            this.lb_x_p.AutoSize = true;
            this.lb_x_p.Location = new System.Drawing.Point(656, 91);
            this.lb_x_p.Name = "lb_x_p";
            this.lb_x_p.Size = new System.Drawing.Size(14, 13);
            this.lb_x_p.TabIndex = 7;
            this.lb_x_p.Text = "X";
            // 
            // lb_p_p
            // 
            this.lb_p_p.AutoSize = true;
            this.lb_p_p.Location = new System.Drawing.Point(656, 72);
            this.lb_p_p.Name = "lb_p_p";
            this.lb_p_p.Size = new System.Drawing.Size(14, 13);
            this.lb_p_p.TabIndex = 6;
            this.lb_p_p.Text = "P";
            // 
            // bt_draw
            // 
            this.bt_draw.Location = new System.Drawing.Point(659, 347);
            this.bt_draw.Name = "bt_draw";
            this.bt_draw.Size = new System.Drawing.Size(192, 27);
            this.bt_draw.TabIndex = 11;
            this.bt_draw.Text = "Нарисовать";
            this.bt_draw.UseVisualStyleBackColor = true;
            this.bt_draw.Click += new System.EventHandler(this.bt_draw_Click);
            // 
            // tb_xmax
            // 
            this.tb_xmax.Location = new System.Drawing.Point(780, 204);
            this.tb_xmax.Name = "tb_xmax";
            this.tb_xmax.Size = new System.Drawing.Size(36, 20);
            this.tb_xmax.TabIndex = 16;
            this.tb_xmax.Text = "5,2";
            // 
            // tb_xmin
            // 
            this.tb_xmin.Location = new System.Drawing.Point(692, 204);
            this.tb_xmin.Name = "tb_xmin";
            this.tb_xmin.Size = new System.Drawing.Size(36, 20);
            this.tb_xmin.TabIndex = 15;
            this.tb_xmin.Text = "0,2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(741, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Xmax";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(656, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Xmin";
            // 
            // tb_ymax
            // 
            this.tb_ymax.Location = new System.Drawing.Point(780, 239);
            this.tb_ymax.Name = "tb_ymax";
            this.tb_ymax.Size = new System.Drawing.Size(36, 20);
            this.tb_ymax.TabIndex = 20;
            this.tb_ymax.Text = "6,5";
            // 
            // tb_ymin
            // 
            this.tb_ymin.Location = new System.Drawing.Point(692, 239);
            this.tb_ymin.Name = "tb_ymin";
            this.tb_ymin.Size = new System.Drawing.Size(36, 20);
            this.tb_ymin.TabIndex = 19;
            this.tb_ymin.Text = "0,5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(741, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ymax";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ymin";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 388);
            this.Controls.Add(this.tb_ymax);
            this.Controls.Add(this.tb_ymin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_xmax);
            this.Controls.Add(this.tb_xmin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_draw);
            this.Controls.Add(this.tb_y_p);
            this.Controls.Add(this.tb_x_p);
            this.Controls.Add(this.lb_y_p);
            this.Controls.Add(this.lb_x_p);
            this.Controls.Add(this.lb_p_p);
            this.Controls.Add(this.tb_y_q);
            this.Controls.Add(this.tb_x_q);
            this.Controls.Add(this.lb_y_q);
            this.Controls.Add(this.lb_x_q);
            this.Controls.Add(this.lb_p_q);
            this.Controls.Add(this.pb_source);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_source)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_source;
        private System.Windows.Forms.Label lb_p_q;
        private System.Windows.Forms.Label lb_x_q;
        private System.Windows.Forms.Label lb_y_q;
        private System.Windows.Forms.TextBox tb_x_q;
        private System.Windows.Forms.TextBox tb_y_q;
        private System.Windows.Forms.TextBox tb_y_p;
        private System.Windows.Forms.TextBox tb_x_p;
        private System.Windows.Forms.Label lb_y_p;
        private System.Windows.Forms.Label lb_x_p;
        private System.Windows.Forms.Label lb_p_p;
        private System.Windows.Forms.Button bt_draw;
        private System.Windows.Forms.TextBox tb_xmax;
        private System.Windows.Forms.TextBox tb_xmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ymax;
        private System.Windows.Forms.TextBox tb_ymin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

