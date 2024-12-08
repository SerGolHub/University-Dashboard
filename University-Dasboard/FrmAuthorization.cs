namespace University_Dasboard
{
    public partial class FrmAuthorization : Form
    {
        public FrmAuthorization()
        {
            InitializeComponent();
            FormLoader.loadForm(pnlLoadAuthForms, new FrmLogin(pnlLoadAuthForms, this));
        }

        private void btnMininizeWindow_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveWindow.ReleaseCapture();
                MoveWindow.SendMessage(Handle, MoveWindow.WM_NLCBUTTONDOWN, MoveWindow.HT_CAPTION, 0);
            }
        }
    }
}
