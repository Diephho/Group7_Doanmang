namespace HTTPClient
{
    partial class Form1
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.postData = new System.Windows.Forms.TextBox();
            this.cookieBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusCode = new System.Windows.Forms.TextBox();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnViewSource = new System.Windows.Forms.Button();
            this.radioButtonHttp11 = new System.Windows.Forms.RadioButton();
            this.radioButtonHttp2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.Location = new System.Drawing.Point(216, 30);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(575, 30);
            this.txtUrl.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
            this.comboBox1.Location = new System.Drawing.Point(815, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(970, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // postData
            // 
            this.postData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postData.Location = new System.Drawing.Point(216, 82);
            this.postData.Name = "postData";
            this.postData.Size = new System.Drawing.Size(575, 30);
            this.postData.TabIndex = 4;
            // 
            // cookieBox
            // 
            this.cookieBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cookieBox.Location = new System.Drawing.Point(216, 135);
            this.cookieBox.Name = "cookieBox";
            this.cookieBox.Size = new System.Drawing.Size(575, 30);
            this.cookieBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "cookie:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // statusCode
            // 
            this.statusCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCode.Location = new System.Drawing.Point(982, 132);
            this.statusCode.Name = "statusCode";
            this.statusCode.Size = new System.Drawing.Size(215, 30);
            this.statusCode.TabIndex = 8;
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(25, 195);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(1666, 761);
            this.webView.TabIndex = 9;
            this.webView.ZoomFactor = 1D;
            // 
            // btnForward
            // 
            this.btnForward.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForward.Location = new System.Drawing.Point(68, 22);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(47, 42);
            this.btnForward.TabIndex = 12;
            this.btnForward.Text = ">";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(136, 20);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(52, 45);
            this.btnReload.TabIndex = 11;
            this.btnReload.Text = "⟳";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(15, 22);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(47, 42);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnViewSource
            // 
            this.btnViewSource.Location = new System.Drawing.Point(1486, 25);
            this.btnViewSource.Name = "btnViewSource";
            this.btnViewSource.Size = new System.Drawing.Size(122, 35);
            this.btnViewSource.TabIndex = 13;
            this.btnViewSource.Text = "Xem Source";
            this.btnViewSource.UseVisualStyleBackColor = true;
            this.btnViewSource.Click += new System.EventHandler(this.btnViewSource_Click);
            // 
            // radioButtonHttp11
            // 
            this.radioButtonHttp11.AutoSize = true;
            this.radioButtonHttp11.Location = new System.Drawing.Point(27, 11);
            this.radioButtonHttp11.Name = "radioButtonHttp11";
            this.radioButtonHttp11.Size = new System.Drawing.Size(100, 24);
            this.radioButtonHttp11.TabIndex = 14;
            this.radioButtonHttp11.TabStop = true;
            this.radioButtonHttp11.Text = "HTTP 1.1";
            this.radioButtonHttp11.UseVisualStyleBackColor = true;
            this.radioButtonHttp11.CheckedChanged += new System.EventHandler(this.radioButtonHttp11_CheckedChanged);
            // 
            // radioButtonHttp2
            // 
            this.radioButtonHttp2.AutoSize = true;
            this.radioButtonHttp2.Location = new System.Drawing.Point(28, 56);
            this.radioButtonHttp2.Name = "radioButtonHttp2";
            this.radioButtonHttp2.Size = new System.Drawing.Size(87, 24);
            this.radioButtonHttp2.TabIndex = 15;
            this.radioButtonHttp2.TabStop = true;
            this.radioButtonHttp2.Text = "HTTP 2";
            this.radioButtonHttp2.UseVisualStyleBackColor = true;
            this.radioButtonHttp2.CheckedChanged += new System.EventHandler(this.radioButtonHttp2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonHttp2);
            this.groupBox1.Controls.Add(this.radioButtonHttp11);
            this.groupBox1.Location = new System.Drawing.Point(1232, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 101);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1714, 979);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnViewSource);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.statusCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cookieBox);
            this.Controls.Add(this.postData);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox postData;
        private System.Windows.Forms.TextBox cookieBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox statusCode;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnViewSource;
        private System.Windows.Forms.RadioButton radioButtonHttp11;
        private System.Windows.Forms.RadioButton radioButtonHttp2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

