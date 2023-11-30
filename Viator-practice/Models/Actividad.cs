namespace Viator_practice.Models
{
    public class Actividad
    {
        public String titulo { get; set; }
        public String descripcion { get; set; }
        public float precio {  get; set; }
        public List<String> fotosDelProducto { get; set; }

        public Actividad(string titulo, string descripcion, float precio, List<string> fotosDelProducto)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.precio = precio;
            this.fotosDelProducto = fotosDelProducto;
        }
    }
}
