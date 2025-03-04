namespace WinApp
{
    public class FormResumen : Form
    {
        private Label lblResumen;
        private Button btnRegresar;

        public FormResumen(string nombre, string identificacion, string genero, string tecnica, int numeroClases, int valorClase, int costoTotal)
        {
            this.Text = "Resumen de Inscripción";
            this.Size = new Size(700, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            InitializeControls(nombre, identificacion, genero, tecnica, numeroClases, valorClase, costoTotal);
        }

        private void InitializeControls(string nombre, string identificacion, string genero, string tecnica, int numeroClases, int valorClase, int costoTotal)
        {
            lblResumen = new Label()
            {
                Text = $"Fecha de registro: {DateTime.Now.ToShortDateString()}\n\n" +
                $"El estudiante {nombre}\n" +
                $"identificado con cédula de ciudadanía {identificacion}\n" +
                $"de género {genero}\n" +
                $"ha sido inscrito en el curso de la técnica {tecnica},\n" +
                $"el cual cursará en un lapso de {numeroClases} clases\n" +
                $"con un costo total por clase de {valorClase:C}\n" +
                $"para un total de costo de matrícula de {costoTotal:C}.",
                AutoSize = true,
                Location = new Point(30, 30)
            };

            btnRegresar = new Button()
            {
                Text = "Regresar",
                Location = new Point(300, 250),
                Width = 100
            };
            btnRegresar.Click += (sender, e) => { this.Close(); };

            this.Controls.Add(lblResumen);
            this.Controls.Add(btnRegresar);
        }
    }
}