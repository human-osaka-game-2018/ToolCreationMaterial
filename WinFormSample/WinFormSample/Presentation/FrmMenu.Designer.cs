namespace WinFormSample.Presentation {
	partial class FrmMenu {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.btnPlyayer = new System.Windows.Forms.Button();
			this.btnEnemy = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnPlyayer
			// 
			this.btnPlyayer.Location = new System.Drawing.Point(171, 100);
			this.btnPlyayer.Name = "btnPlyayer";
			this.btnPlyayer.Size = new System.Drawing.Size(123, 47);
			this.btnPlyayer.TabIndex = 0;
			this.btnPlyayer.Text = "プレイヤー";
			this.btnPlyayer.UseVisualStyleBackColor = true;
			this.btnPlyayer.Click += new System.EventHandler(this.BtnPlyayer_Click);
			// 
			// btnEnemy
			// 
			this.btnEnemy.Location = new System.Drawing.Point(375, 100);
			this.btnEnemy.Name = "btnEnemy";
			this.btnEnemy.Size = new System.Drawing.Size(128, 47);
			this.btnEnemy.TabIndex = 1;
			this.btnEnemy.Text = "敵";
			this.btnEnemy.UseVisualStyleBackColor = true;
			this.btnEnemy.Click += new System.EventHandler(this.BtnEnemy_Click);
			// 
			// Menu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnEnemy);
			this.Controls.Add(this.btnPlyayer);
			this.Name = "Menu";
			this.Text = "Menu";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnPlyayer;
		private System.Windows.Forms.Button btnEnemy;
	}
}

