using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Examen_Peliculas
{
    public partial class MainPage : ContentPage
    {
        public List<MovieModel> listaPeliculas;
         



        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            IndicadorPeliculas.IsRunning = false;
            InsertarPeliculas.IsEnabled = true;
            listaPeliculas = new List<MovieModel>
            {
                new MovieModel
                {
                    idPelicula = 1,
                    precioPelicula = 120,
                    categoriaPelicula = "Suspenso",
                    nombrePelicula = "The killing of the sacred deer",
                    fotoPelicula = "https://ca-times.brightspotcdn.com/dims4/default/191fe68/2147483647/strip/true/crop/2048x1152+0+0/resize/840x473!/format/webp/quality/90/?url=https%3A%2F%2Fcalifornia-times-brightspot.s3.amazonaws.com%2Ff2%2Ff3%2Fd9320c1ee0d3169e2b9b33c9a786%2Fla-1508449100-jyzq6r6sez-snap-image"
                },

                new MovieModel
                {
                    idPelicula = 2,
                    precioPelicula = 220,
                    categoriaPelicula = "Comedia",
                    nombrePelicula = "Emojis",
                    fotoPelicula = "https://cdn.forbes.com.mx/2020/09/Emoji-La-peli-640x360.jpg"
                },
                new MovieModel
                {
                    idPelicula = 3,
                    precioPelicula = 320,
                    categoriaPelicula = "Suspenso",
                    nombrePelicula = "The Batman",
                    fotoPelicula = "https://s03.s3c.es/imag/_v0/770x420/f/9/6/batman-80-anos-20-datos.jpg"
                },
            };
            PeliculasLista.ItemsSource = listaPeliculas;
            

            DisplayAlert("EXITO", "Peliculas insertadas", "Siguiente");
        }

        private void NuevaPelicula_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VistaPeliculas(this));
        }
        public void ActualizarLista()
        {
            PeliculasLista.ItemsSource = null;
            PeliculasLista.ItemsSource = listaPeliculas;

        }

        private void PeliculasLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MovieModel movieSelected = e.CurrentSelection.FirstOrDefault() as MovieModel;
            if(movieSelected != null)
            {
                Navigation.PushAsync(new VistaPeliculas(this, movieSelected));
            }
        }
    }
}
