namespace WinApp
{
    public class FormMain : Form
    {
        private Label lblIdentificacion;
        private TextBox txtIdentificacion;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblTecnicaArtistica;
        private ComboBox cmbTecnicaArtistica;
        private Label lblGenero;
        private RadioButton rbtnMasculino;
        private RadioButton rbtnFemenino;
        private Label lblNumeroClases;
        private NumericUpDown nudNumeroClases;
        private Button btnGuardar;
        private Button btnVolver;

        private Dictionary<string, int> tecnicaArtisticaValores;

        public FormMain()
        {
            this.Text = "Ingreso Datos";
            this.Size = new Size(700, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            InitializeControls();
        }

        private void InitializeControls()
        {
            // Inicializar valores de técnicas artísticas
            tecnicaArtisticaValores = new Dictionary<string, int>
            {
                { "Dibujo", 70000 },
                { "Pintura", 85000 },
                { "Escritura", 100000 },
                { "Fotografía", 90000 },
                { "Grabado", 75000 }
            };

            // Identificación
            lblIdentificacion = new Label()
            {
                Text = "Identificación:",
                Location = new Point(30, 30),
                AutoSize = true
            };
            txtIdentificacion = new TextBox()
            {
                Location = new Point(150, 30),
                Width = 200
            };
            txtIdentificacion.KeyPress += (sender, e) =>
            {
                // Permitir solo números
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            // Nombre
            lblNombre = new Label()
            {
                Text = "Nombre:",
                Location = new Point(30, 70),
                AutoSize = true
            };
            txtNombre = new TextBox()
            {
                Location = new Point(150, 70),
                Width = 200
            };

            // Técnica Artística
            lblTecnicaArtistica = new Label()
            {
                Text = "Técnica Artística:",
                Location = new Point(30, 110),
                AutoSize = true
            };
            cmbTecnicaArtistica = new ComboBox()
            {
                Location = new Point(150, 110),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTecnicaArtistica.Items.AddRange(tecnicaArtisticaValores.Keys.ToArray());

            // Género
            lblGenero = new Label()
            {
                Text = "Género:",
                Location = new Point(30, 150),
                AutoSize = true
            };
            rbtnMasculino = new RadioButton()
            {
                Text = "Masculino",
                Location = new Point(150, 150),
                AutoSize = true
            };
            rbtnFemenino = new RadioButton()
            {
                Text = "Femenino",
                Location = new Point(250, 150),
                AutoSize = true
            };

            // Número de Clases
            lblNumeroClases = new Label()
            {
                Text = "Número de Clases:",
                Location = new Point(30, 190),
                AutoSize = true
            };
            nudNumeroClases = new NumericUpDown()
            {
                Location = new Point(150, 190),
                Width = 200,
                Minimum = 1,
                Maximum = 100
            };

            // Botones
            btnGuardar = new Button()
            {
                Text = "Guardar",
                Location = new Point(150, 230),
                Width = 100
            };
            btnGuardar.Click += BtnGuardar_Click;

            btnVolver = new Button()
            {
                Text = "Volver",
                Location = new Point(260, 230),
                Width = 100
            };
            btnVolver.Click += (sender, e) => { this.Close(); };

            // Agregar controles al formulario
            this.Controls.Add(lblIdentificacion);
            this.Controls.Add(txtIdentificacion);
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblTecnicaArtistica);
            this.Controls.Add(cmbTecnicaArtistica);
            this.Controls.Add(lblGenero);
            this.Controls.Add(rbtnMasculino);
            this.Controls.Add(rbtnFemenino);
            this.Controls.Add(lblNumeroClases);
            this.Controls.Add(nudNumeroClases);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(btnVolver);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                MessageBox.Show("Por favor, ingrese la identificación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTecnicaArtistica.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una técnica artística.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbtnMasculino.Checked && !rbtnFemenino.Checked)
            {
                MessageBox.Show("Por favor, seleccione el género.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudNumeroClases.Value == 0)
            {
                MessageBox.Show("Por favor, ingrese el número de clases.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calcular el costo total
            string tecnicaSeleccionada = cmbTecnicaArtistica.SelectedItem.ToString();
            int valorTecnica = tecnicaArtisticaValores[tecnicaSeleccionada];
            int numeroClases = (int)nudNumeroClases.Value;
            int costoTotal = valorTecnica * numeroClases;

            // Obtener el género seleccionado
            string genero = rbtnMasculino.Checked ? "Masculino" : "Femenino";

            // Crear un nuevo objeto Estudiante y agregarlo a la lista
            Estudiante estudiante = new Estudiante
            {
                Identificacion = txtIdentificacion.Text,
                Nombre = txtNombre.Text,
                Genero = genero,
                TecnicaArtistica = tecnicaSeleccionada,
                NumeroClases = numeroClases,
                ValorClase = valorTecnica,
                CostoTotal = costoTotal
            };
            Program.Estudiantes.Add(estudiante);

            // Redirigir a FormResumen
            FormResumen formResumen = new FormResumen(txtNombre.Text, txtIdentificacion.Text, genero, tecnicaSeleccionada, numeroClases, valorTecnica, costoTotal);
            formResumen.ShowDialog();

            // Cerrar el formulario actual
            this.Close();
        }
    }
}