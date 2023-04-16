using ConsultorioMedico.Modelo;

namespace ConsultorioMedico
{
    public partial class Form1 : Form
    {
        BaseDatos baseDatos = null;
        static List<AsignacionCitas> asignacionCitas1 = new List<AsignacionCitas>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbxTipoDocumento.SelectedIndex = 1;
            cbxGenero.SelectedIndex = 0;
            cbxEspecialidad.SelectedIndex = 0;
            cbxMedico.SelectedIndex = 0;

            ConsultarCitas();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            baseDatos = new BaseDatos();
            AsignacionCitas asignacionCitas = new AsignacionCitas();

            asignacionCitas.Nombres = txtNombres.Text;
            asignacionCitas.Apellidos = txtApellidos.Text;
            asignacionCitas.TipoDocumento = cbxTipoDocumento.SelectedItem.ToString();
            asignacionCitas.NroDocumento = txtNroDocumento.Text;
            asignacionCitas.CorreoElectronico = txtCorreoElectronico.Text;
            asignacionCitas.Edad = Convert.ToInt32(txtEdad.Text);
            asignacionCitas.Genero = cbxGenero.SelectedItem.ToString();
            asignacionCitas.Especialidad = cbxEspecialidad.SelectedItem.ToString();
            asignacionCitas.Medico = cbxMedico.SelectedItem.ToString();
            asignacionCitas.FechaCita = dtpFecha.Value.ToShortDateString();
            asignacionCitas.Observaciones = txtObservaciones.Text;

            baseDatos.insertRecord(asignacionCitas);
            LimpiarFormulario();

        }


        private void LimpiarFormulario()
        {
            txtNombres.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtNroDocumento.Text = String.Empty;
            txtCorreoElectronico.Text = String.Empty;
            txtEdad.Text = String.Empty;
            txtObservaciones.Text = String.Empty;
            cbxTipoDocumento.SelectedIndex = 1;
            cbxGenero.SelectedIndex = 0;
            cbxEspecialidad.SelectedIndex = 0;
            cbxMedico.SelectedIndex = 0;
        }

        private void ConsultarCitas()
        {
            baseDatos = new BaseDatos();
            asignacionCitas1 = new List<AsignacionCitas>();
            asignacionCitas1 = baseDatos.consultTable();
            DgCitas.DataSource = null;
            DgCitas.DataSource = asignacionCitas1;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            DgCitas.DataSource = asignacionCitas1.Where(x => x.NroDocumento.Contains(txtFiltrar.Text)).ToList();
        }

        private void btnLimpiarConsultar_Click(object sender, EventArgs e)
        {
            ConsultarCitas();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}