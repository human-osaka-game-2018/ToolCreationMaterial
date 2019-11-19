namespace WinFormSample.Presentation {
	partial class FrmEnemy {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.dgEnemies = new System.Windows.Forms.DataGridView();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDisplaySample = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgEnemies)).BeginInit();
			this.SuspendLayout();
			// 
			// dgEnemies
			// 
			this.dgEnemies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgEnemies.Location = new System.Drawing.Point(80, 70);
			this.dgEnemies.Name = "dgEnemies";
			this.dgEnemies.RowTemplate.Height = 21;
			this.dgEnemies.Size = new System.Drawing.Size(643, 268);
			this.dgEnemies.TabIndex = 0;
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(323, 374);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(155, 42);
			this.btnExport.TabIndex = 1;
			this.btnExport.Text = "エクスポート";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(554, 374);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(155, 42);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "保存";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// btnDisplaySample
			// 
			this.btnDisplaySample.Location = new System.Drawing.Point(92, 374);
			this.btnDisplaySample.Name = "btnDisplaySample";
			this.btnDisplaySample.Size = new System.Drawing.Size(155, 42);
			this.btnDisplaySample.TabIndex = 3;
			this.btnDisplaySample.Text = "サンプルデータ表示";
			this.btnDisplaySample.UseVisualStyleBackColor = true;
			this.btnDisplaySample.Click += new System.EventHandler(this.BtnDisplaySample_Click);
			// 
			// FrmEnemy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnDisplaySample);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.dgEnemies);
			this.Name = "FrmEnemy";
			this.Text = "FrmEnemy";
			this.Load += new System.EventHandler(this.FrmEnemy_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgEnemies)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgEnemies;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDisplaySample;
	}
}