
namespace GetAPI
{
    partial class fLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.btndangnhap = new System.Windows.Forms.Button();
            this.btndangky = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(180, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(346, 196);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(237, 20);
            this.txtusername.TabIndex = 2;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(346, 299);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(237, 20);
            this.txtpassword.TabIndex = 3;
            // 
            // btndangnhap
            // 
            this.btndangnhap.Location = new System.Drawing.Point(211, 408);
            this.btndangnhap.Name = "btndangnhap";
            this.btndangnhap.Size = new System.Drawing.Size(102, 62);
            this.btndangnhap.TabIndex = 4;
            this.btndangnhap.Text = "Đăng nhập";
            this.btndangnhap.UseVisualStyleBackColor = true;
            // 
            // btndangky
            // 
            this.btndangky.Location = new System.Drawing.Point(346, 408);
            this.btndangky.Name = "btndangky";
            this.btndangky.Size = new System.Drawing.Size(102, 62);
            this.btndangky.TabIndex = 5;
            this.btndangky.Text = "Đăng ký";
            this.btndangky.UseVisualStyleBackColor = true;
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 575);
            this.Controls.Add(this.btndangky);
            this.Controls.Add(this.btndangnhap);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fLogin";
            this.Text = "fLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Button btndangnhap;
        private System.Windows.Forms.Button btndangky;
    }
}