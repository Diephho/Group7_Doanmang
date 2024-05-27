namespace HTTPClient
{
    partial class SourceForm
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
            this.txtSource = new System.Windows.Forms.RichTextBox();
            this.dvRequest = new System.Windows.Forms.DataGridView();
            this.dvResponse = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestHeaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responseheaderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvResponse)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(12, 91);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(621, 870);
            this.txtSource.TabIndex = 0;
            this.txtSource.Text = "";
            // 
            // dvRequest
            // 
            this.dvRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvRequest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.requestHeaderName,
            this.Value});
            this.dvRequest.Location = new System.Drawing.Point(652, 91);
            this.dvRequest.Name = "dvRequest";
            this.dvRequest.RowHeadersWidth = 62;
            this.dvRequest.RowTemplate.Height = 28;
            this.dvRequest.Size = new System.Drawing.Size(558, 870);
            this.dvRequest.TabIndex = 1;
            // 
            // dvResponse
            // 
            this.dvResponse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvResponse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT2,
            this.responseheaderName,
            this.Value2});
            this.dvResponse.Location = new System.Drawing.Point(1232, 91);
            this.dvResponse.Name = "dvResponse";
            this.dvResponse.RowHeadersWidth = 62;
            this.dvResponse.RowTemplate.Height = 28;
            this.dvResponse.Size = new System.Drawing.Size(558, 870);
            this.dvResponse.TabIndex = 2;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 8;
            this.STT.Name = "STT";
            this.STT.Width = 150;
            // 
            // requestHeaderName
            // 
            this.requestHeaderName.HeaderText = "Name";
            this.requestHeaderName.MinimumWidth = 8;
            this.requestHeaderName.Name = "requestHeaderName";
            this.requestHeaderName.Width = 150;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 8;
            this.Value.Name = "Value";
            this.Value.Width = 150;
            // 
            // STT2
            // 
            this.STT2.HeaderText = "STT";
            this.STT2.MinimumWidth = 8;
            this.STT2.Name = "STT2";
            this.STT2.Width = 150;
            // 
            // responseheaderName
            // 
            this.responseheaderName.HeaderText = "Name";
            this.responseheaderName.MinimumWidth = 8;
            this.responseheaderName.Name = "responseheaderName";
            this.responseheaderName.Width = 150;
            // 
            // Value2
            // 
            this.Value2.HeaderText = "Value";
            this.Value2.MinimumWidth = 8;
            this.Value2.Name = "Value2";
            this.Value2.Width = 150;
            // 
            // SourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1817, 1019);
            this.Controls.Add(this.dvResponse);
            this.Controls.Add(this.dvRequest);
            this.Controls.Add(this.txtSource);
            this.Name = "SourceForm";
            this.Text = "SourceForm";
            ((System.ComponentModel.ISupportInitialize)(this.dvRequest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvResponse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtSource;
        private System.Windows.Forms.DataGridView dvRequest;
        private System.Windows.Forms.DataGridView dvResponse;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestHeaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn responseheaderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value2;
    }
}