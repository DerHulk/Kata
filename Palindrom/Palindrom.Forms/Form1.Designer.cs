namespace Palindrom.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_calc = new System.Windows.Forms.Button();
            this.txt_Input = new System.Windows.Forms.TextBox();
            this.lbl_Result = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_ShowAll = new System.Windows.Forms.Button();
            this.lb_History = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(12, 39);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(120, 23);
            this.btn_calc.TabIndex = 0;
            this.btn_calc.Text = "Calc";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // txt_Input
            // 
            this.txt_Input.Location = new System.Drawing.Point(12, 13);
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.Size = new System.Drawing.Size(120, 20);
            this.txt_Input.TabIndex = 1;
            // 
            // lbl_Result
            // 
            this.lbl_Result.AutoSize = true;
            this.lbl_Result.Location = new System.Drawing.Point(138, 16);
            this.lbl_Result.Name = "lbl_Result";
            this.lbl_Result.Size = new System.Drawing.Size(37, 13);
            this.lbl_Result.TabIndex = 2;
            this.lbl_Result.Text = "Result";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(12, 68);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(120, 23);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_ShowAll
            // 
            this.btn_ShowAll.Location = new System.Drawing.Point(12, 114);
            this.btn_ShowAll.Name = "btn_ShowAll";
            this.btn_ShowAll.Size = new System.Drawing.Size(120, 23);
            this.btn_ShowAll.TabIndex = 4;
            this.btn_ShowAll.Text = "Show History";
            this.btn_ShowAll.UseVisualStyleBackColor = true;
            this.btn_ShowAll.Click += new System.EventHandler(this.btn_ShowAll_Click);
            // 
            // lb_History
            // 
            this.lb_History.FormattingEnabled = true;
            this.lb_History.Location = new System.Drawing.Point(12, 143);
            this.lb_History.Name = "lb_History";
            this.lb_History.Size = new System.Drawing.Size(120, 108);
            this.lb_History.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 304);
            this.Controls.Add(this.lb_History);
            this.Controls.Add(this.btn_ShowAll);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lbl_Result);
            this.Controls.Add(this.txt_Input);
            this.Controls.Add(this.btn_calc);
            this.Name = "Form1";
            this.Text = "Palindrom Kata";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.TextBox txt_Input;
        private System.Windows.Forms.Label lbl_Result;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_ShowAll;
        private System.Windows.Forms.ListBox lb_History;
    }
}

