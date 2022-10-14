using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ebenberger_Sample.Forms
{
    public partial class Loadbrowser : Form
    {
        #region Properties

        #region TopText
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string TopText
        {
            get { return _toptext; }
            set
            {
                if (_toptext != value)
                {
                    _toptext = value;
                    OnTopTextChanged();
                }
            }
        }
        private string _toptext;
        protected virtual void OnTopTextChanged()
        {
            ChangeTopText();
        }
        #endregion
        #region ShowKillProcessButton
        private bool ShowKillProcessButton
        {
            get { return _showkillprocessbutton; }
            set
            {
                if (_showkillprocessbutton != value)
                {
                    _showkillprocessbutton = value;
                    OnShowKillProcessButtonChanged();
                }
            }
        }
        private bool _showkillprocessbutton;
        protected virtual void OnShowKillProcessButtonChanged()
        {
            pshCancel.Visible = ShowKillProcessButton;
        }

        #endregion

        #endregion

        #region EventHandler

        public event EventHandler KillProcessEvent;

        #endregion

        #region Konstruktor

        public Loadbrowser() : this(string.Empty) { }
        public Loadbrowser(string topText)
        {
            InitializeComponent();

            TopText = (string.IsNullOrEmpty(topText)) ? "Daten werden geladen..." : topText;
            lblMaxCount.Text = string.Empty;
        }

        #endregion        

        #region OnEvents

        protected override void OnLoad(EventArgs e)
        {
            if (DesignMode) return;

            base.OnLoad(e);

            InitializeControls();
            RegisterEvents();
        }

        protected override void OnShown(EventArgs e)
        {
            try
            {
                if (this.Owner != null)
                {
                    SetLoadbrowserLocation();
                    this.Owner.LocationChanged += Owner_LocationChanged;
                }
                base.OnShown(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Methoden

        private void InitializeControls()
        {

        }

        private void RegisterEvents()
        {
            pshCancel.Click += PshCancel_Click;
        }

        /// <summary>
        /// Ändert den TopText des Loadbrowsers
        /// </summary>
        private void ChangeTopText()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate { lblTopText.Text = (string.IsNullOrEmpty(TopText)) ? "Daten werden geladen" : TopText; });
                }
                else
                {
                    lblTopText.Text = (string.IsNullOrEmpty(TopText)) ? "Daten werden geladen" : TopText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ändert den SubText des Loadbrowsers
        /// </summary>
        public void ChangeProgress(int von, int bis)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        progressBar.Maximum = bis;
                        progressBar.Value = von;

                        if (string.IsNullOrEmpty(lblMaxCount.Text)) lblMaxCount.Text = $"Anzahl Einträge:{Environment.NewLine}{bis}";
                    });
                }
                else
                {
                    progressBar.Maximum = bis;
                    progressBar.Value = von;

                    if (string.IsNullOrEmpty(lblMaxCount.Text)) lblMaxCount.Text = $"Anzahl Einträge:{Environment.NewLine}{bis}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Setzt den Loadbrowser in die Mitte der Owner Form
        /// </summary>
        private void SetLoadbrowserLocation()
        {
            try
            {
                if (this.Owner == null) return;

                Location = new Point(
                       Owner.Location.X + Owner.Width / 2 - Width / 2,
                       Owner.Location.Y + Owner.Height / 2 - Height / 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Events

        private void PshCancel_Click(object sender, EventArgs e)
        {
            KillProcessEvent?.Invoke(this, e);
        }

        private void Owner_LocationChanged(object sender, EventArgs e)
        {
            SetLoadbrowserLocation();
        }

        #endregion
    }
}
