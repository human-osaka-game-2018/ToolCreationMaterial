using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WinFormSample.Domain.DomainObjects.Entities;
using WinFormSample.Domain.Services;

namespace WinFormSample.Presentation {
	/// <summary>
	/// 敵画面クラス。
	/// </summary>
	public partial class FrmEnemy : Form {

		#region field members
		/// <summary>
		/// ビジネスロジッククラス。
		/// </summary>
		private EnemyService service = new EnemyService();

		/// <summary>
		/// 画面に表示する敵情報リスト。
		/// </summary>
		/// <remarks><see cref="IEnumerable{T}"/>を使用するパターン用</remarks>
		private BindingList<EnemyParameter> enemyParameters;

		/// <summary>
		/// 画面に表示する敵情報リスト。
		/// </summary>
		/// <remarks><see cref="DataTable"/>を使用するパターン用</remarks>
		private DataTable enemyDataTable;
		#endregion

		#region constructors
		/// <summary>
		/// コンストラクタ。
		/// </summary>
		public FrmEnemy() {
			InitializeComponent();
		}
		#endregion

		#region private methods
		/// <summary>
		/// 画面ロードイベント。
		/// </summary>
		/// <param name="sender">イベント発行元</param>
		/// <param name="e">イベントパラメータ</param>
		private void FrmEnemy_Load(object sender, EventArgs e) {
			try {
				// DBからデータを取得して表示
				this.enemyDataTable = this.service.Load();
				this.dgEnemies.DataSource = this.enemyDataTable;

				// DBにデータが存在しない場合のみサンプル表示ボタンを活性化
				this.btnDisplaySample.Enabled = (this.enemyDataTable.Rows.Count == 0);
			} catch(Exception) {
				this.btnDisplaySample.Enabled = true;
				this.btnSave.Enabled = false;
			}
		}

		/// <summary>
		/// サンプルデータ表示ボタンクリックイベント。
		/// </summary>
		/// <param name="sender">イベント発行元</param>
		/// <param name="e">イベントパラメータ</param>
		private void BtnDisplaySample_Click(object sender, EventArgs e) {
			// サンプルデータを生成して表示
			this.enemyParameters = new BindingList<EnemyParameter>(this.service.CreateSampleData());
			this.dgEnemies.DataSource = this.enemyParameters;
		}

		/// <summary>
		/// エクスポートボタンクリックイベント。
		/// </summary>
		/// <param name="sender">イベント発行元</param>
		/// <param name="e">イベントパラメータ</param>
		private void BtnExport_Click(object sender, EventArgs e) {
			var dialog = new SaveFileDialog();
			if (dialog.ShowDialog() == DialogResult.OK) {
				switch (this.dgEnemies.DataSource) {
					case IEnumerable<EnemyParameter> x:
						this.service.Export(x, dialog.FileName);
						break;
					case DataTable x:
						this.service.Export(x, dialog.FileName);
						break;
				}
			}
		}

		/// <summary>
		/// 保存ボタンクリックイベント。
		/// </summary>
		/// <param name="sender">イベント発行元</param>
		/// <param name="e">イベントパラメータ</param>
		private void BtnSave_Click(object sender, EventArgs e) {
			var isSuccess = false;
			switch (this.dgEnemies.DataSource) {
				case IEnumerable<EnemyParameter> x:
					isSuccess = this.service.Save(x);
					break;
				case DataTable x:
					isSuccess = this.service.Save(x);
					break;
			}

			if (isSuccess) {
				MessageBox.Show("更新完了しました。");
			} else {
				MessageBox.Show("更新失敗しました。");
			}
		}
		#endregion

	}
}
