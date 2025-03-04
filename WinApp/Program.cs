namespace WinApp
{
    static class Program
    {
        public static List<Estudiante> Estudiantes = new List<Estudiante>();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }

    public class FormLogin : Form
    {
        private Label lblTitle;
        private Label lblStudentName;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnValidate;
        private Panel panel;

        public FormLogin()
        {
            this.Text = "Inicio de Sesión";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            InitializeControls();
        }

        private void InitializeControls()
        {
            panel = new Panel()
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            lblTitle = new Label()
            {
                Text = "Curso Estructura de Datos",
                AutoSize = true,
                Font = new Font("Arial", 18, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top
            };

            lblStudentName = new Label()
            {
                Text = "Edwin Camilo Orozco",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Padding = new Padding(0, 20, 0, 0)
            };

            lblPassword = new Label()
            {
                Text = "Contraseña",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Top,
                Padding = new Padding(0, 20, 0, 0)
            };

            txtPassword = new TextBox()
            {
                Font = new Font("Arial", 12, FontStyle.Regular),
                PasswordChar = '*',
                Dock = DockStyle.Top,
                Margin = new Padding(0, 10, 0, 0)
            };

            btnValidate = new Button()
            {
                Text = "Ingresar",
                Font = new Font("Arial", 12, FontStyle.Regular),
                Dock = DockStyle.Top,
                Margin = new Padding(0, 20, 0, 0)
            };
            btnValidate.Click += new EventHandler(ValidatePassword);

            panel.Controls.Add(btnValidate);
            panel.Controls.Add(txtPassword);
            panel.Controls.Add(lblPassword);
            panel.Controls.Add(lblStudentName);
            panel.Controls.Add(lblTitle);

            this.Controls.Add(panel);
        }

        private void ValidatePassword(object sender, EventArgs e)
        {
            if (txtPassword.Text == "123")
            {
                MessageBox.Show("Contraseña correcta", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FormList formList = new FormList();
                formList.Show();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}