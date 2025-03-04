namespace WinApp
{
    public class FormList : Form
    {
        private DataGridView dgvEstudiantes;
        private Button btnMatricular;
        private Button btnSalir;

        public FormList()
        {
            this.Text = "Lista de Estudiantes Inscritos";
            this.Size = new Size(800, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            InitializeControls();
        }

        private void InitializeControls()
        {
            dgvEstudiantes = new DataGridView()
            {
                Location = new Point(30, 30),
                Size = new Size(720, 250),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            btnMatricular = new Button()
            {
                Text = "Matricular",
                Location = new Point(30, 300),
                Size = new Size(100, 30)
            };
            btnMatricular.Click += (sender, e) =>
            {
                FormMain formMain = new FormMain();
                formMain.ShowDialog();
                RefreshData();
            };

            btnSalir = new Button()
            {
                Text = "Salir",
                Location = new Point(150, 300),
                Size = new Size(100, 30)
            };
            btnSalir.Click += (sender, e) =>
            {
                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            };

            this.Controls.Add(dgvEstudiantes);
            this.Controls.Add(btnMatricular);
            this.Controls.Add(btnSalir);
        }

        public void RefreshData()
        {
            dgvEstudiantes.DataSource = null;
            dgvEstudiantes.DataSource = Program.Estudiantes;
        }
    }
}