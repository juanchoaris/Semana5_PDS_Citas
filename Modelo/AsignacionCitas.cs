namespace ConsultorioMedico.Modelo
{
    public  class AsignacionCitas
    {

        public AsignacionCitas()
        {
            Id = 0;
            Nombres = String.Empty;
            Apellidos = String.Empty;
            TipoDocumento = String.Empty;
            NroDocumento = String.Empty;
            CorreoElectronico = String.Empty;
            Edad =0 ;
            Genero = String.Empty;
            Especialidad = String.Empty;
            Medico = String.Empty;
            FechaCita = String.Empty;
            Observaciones = String.Empty;
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string CorreoElectronico { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Especialidad { get; set; }
        public string Medico { get; set; }
        public string FechaCita { get; set; }
        public string Observaciones { get; set; }      
    }
}
