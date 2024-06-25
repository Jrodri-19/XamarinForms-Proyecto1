using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace AplicacionDBP1.miApp
{
    public partial class CV : ContentPage
    {
        public CV()
        {
            InitializeComponent();
        }

        private void OnGenerateClicked(object sender, EventArgs e)
        {
            // Capturar los datos del formulario
            string nombre = nombreEditor.Text;
            string apellido = apellidoEditor.Text;
            string descripcion = descripcionEditor.Text;
            string estudio = estudioEditor.Text;
            string contacto = contactoEntry.Text;
            string idiomas = idiomasEditor.Text;
            string habilidades = habilidadesEditor.Text;

            // Crear contenido del CV
            string cvContent = $"Nombre: {nombre}\n" +
                               $"Apellido: {apellido}\n" +
                               $"Descripción: {descripcion}\n" +
                               $"Estudios: {estudio}\n" +
                               $"Contacto: {contacto}\n" +
                               $"Idiomas: {idiomas}\n" +
                               $"Habilidades: {habilidades}\n";

            // Mostrar el contenido en el cuadro blanco
            cvContentLabel.Text = cvContent;
            cvFrame.IsVisible = true;
        }

        private async void OnExportClicked(object sender, EventArgs e)
        {
            // Capturar el contenido del CV
            string cvContent = cvContentLabel.Text;

            // Guardar el contenido en un archivo .txt
            string filePath = Path.Combine(FileSystem.CacheDirectory, "CV.txt");
            File.WriteAllText(filePath, cvContent);

            // Compartir el archivo .txt
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Curriculum Vitae",
                File = new ShareFile(filePath, "text/plain")
            });
        }
    }
}

