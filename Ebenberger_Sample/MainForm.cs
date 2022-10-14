using Ebenberger_Sample.Classes;
using Ebenberger_Sample.Forms;
using Ebenberger_Sample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ebenberger_Sample
{
    public partial class MainForm : Form
    {
        #region Properties

        #region MainWorker
        public MainWorker MainWorker
        {
            get
            {
                if (_mainworker == null) _mainworker = new MainWorker();
                return _mainworker;
            }
            set { _mainworker = value; }
        }
        private MainWorker _mainworker;
        #endregion
        #region BackgroundWorker
        private BackgroundWorker BgWorker
        {
            get
            {
                if (_bgworker == null) _bgworker = new BackgroundWorker();
                return _bgworker;
            }
            set { _bgworker = value; }
        }
        private BackgroundWorker _bgworker;
        #endregion
        #region Loadbrowser
        private Loadbrowser Loadbrowser { get; set; }
        #endregion
        #region FileName
        private string FileName
        {
            get { return _filename; }
            set
            {
                if (_filename != value)
                {
                    _filename = value;
                    OnFileNameChanged();
                }
            }
        }
        private string _filename;
        protected virtual void OnFileNameChanged()
        {
            pshStart.Enabled = !string.IsNullOrEmpty(FileName);
            txtPath.Text = FileName;
        }
        #endregion

        #endregion

        #region Konstruktor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region OnEvents

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitializeControls();
            RegisterEvents();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.CenterToScreen();
        }

        #endregion

        #region Methoden

        private void InitializeControls()
        {
            this.Icon = Properties.Resources.StartIcon;
            Text = "Textparser (Jürgen Ebenberger)";

            BgWorker.WorkerSupportsCancellation = true;
            BgWorker.WorkerReportsProgress = true;

            pshStart.Enabled = false;

            listView.Columns.Add("Wort");
            listView.Columns.Add("Anzahl");

            DetectColumnWidth();
        }

        private void RegisterEvents()
        {
            BgWorker.DoWork += BgWorker_DoWork;
            BgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;

            MainWorker.WorkerChangedProgress += MainWorker_WorkerChangedProgress;

            pshSearchFile.Click += PshSearchFile_Click;

            pshStart.Click += PshStart_Click;
            pshClose.Click += PshClose_Click;

            this.SizeChanged += MainForm_SizeChanged;
        }

        private void Showloadbrowser()
        {
            Closeloadbrowser();

            Loadbrowser = new Loadbrowser();

            Loadbrowser.KillProcessEvent += Loadbrowser_KillProcessEvent;

            Loadbrowser.Show(this);
        }

        private void Closeloadbrowser()
        {
            if (Loadbrowser != null)
            {
                Loadbrowser.Close();
                Loadbrowser.Dispose();
            }
        }

        private void DetectColumnWidth()
        {
            int width = (listView.Width / listView.Columns.Count) - 10;

            foreach (ColumnHeader header in listView.Columns)
            {
                header.Width = width;
            }
        }

        private void ReportProgress(ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
            {
                Loadbrowser.TopText = $"{e.UserState}";
            }
            else
            {
                Loadbrowser.ChangeProgress(e.ProgressPercentage, Convert.ToInt32(e.UserState.ToString()));
            }
        }

        #endregion

        #region Events

        #region Button Events

        private void PshSearchFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string fileName = dlg.FileName;

                    if (!File.Exists(fileName)) throw new FileNotFoundException("Datei wurde nicht gefunden");

                    FileName = fileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PshStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(FileName)) throw new Exception("Es wurde keine Datei zur Verarbeitung angegeben");

                if (!BgWorker.IsBusy)
                {
                    Showloadbrowser();
                    BgWorker.RunWorkerAsync(FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PshClose_Click(object sender, EventArgs e)
        {
            if (BgWorker.IsBusy)
            {
                if (MessageBox.Show(
                        $"Es wird aktuell noch eine Datei verarbeitet.{Environment.NewLine}" +
                        $"Möchten Sie den Vorgang abbrechen und die Applikation beenden?",
                        "Beenden",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            Application.Exit();
        }

        #endregion

        private void MainWorker_WorkerChangedProgress(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (Loadbrowser == null) return;

                if (this.InvokeRequired)
                {
                    ReportProgress(e);
                }
                else
                {
                    ReportProgress(e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Loadbrowser_KillProcessEvent(object sender, EventArgs e)
        {
            if (BgWorker.IsBusy)
            {
                BgWorker.CancelAsync();
                MainWorker.CancelWorker();
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            DetectColumnWidth();
        }

        #region BackgroundWorker Events

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Closeloadbrowser();

                if (e.Cancelled)
                {
                    MessageBox.Show("Verarbeitung wurde abgebrochen", "Abbruch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                List<WordCounterObject> objList = e.Result as List<WordCounterObject>;
                if (objList == null) return;

                listView.Items.Clear();

                foreach (WordCounterObject obj in objList.OrderByDescending(item => item.Count).ToList())
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = obj.Word;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, $"{obj.Count}"));
                    listView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string fileName = e.Argument.ToString();
                e.Result = MainWorker.GetWords(fileName);

                e.Cancel = BgWorker.CancellationPending;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion
    }
}
