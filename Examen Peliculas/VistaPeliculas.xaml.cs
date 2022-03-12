using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_Peliculas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaPeliculas : ContentPage
    {
        MainPage Mainpage;
        MovieModel Pelicula = new MovieModel();

        public VistaPeliculas(MainPage mainpage)
        {
            InitializeComponent();
            Mainpage = mainpage;
            
        }
        public VistaPeliculas(MainPage mainpage, MovieModel pelicula)
        {
            InitializeComponent();
            
            this.Mainpage = mainpage;

        }

        private void btn_Guardar_Clicked(object sender, EventArgs e)
        {
            if(this.Pelicula.idPelicula > 0)
            {
                for(int i = 0; i < this.Mainpage.listaPeliculas.Count; i++)
                {
                    if(this.Mainpage.listaPeliculas[i].idPelicula == this.Pelicula.idPelicula)
                    {
                        this.Mainpage.listaPeliculas[i].nombrePelicula = entryNombre.Text;
                        this.Mainpage.listaPeliculas[i].categoriaPelicula = entryCategoria.Text;
                        this.Mainpage.listaPeliculas[i].precioPelicula = int.Parse(entryPrecio.Text);
                        this.Mainpage.listaPeliculas[i].fotoPelicula = entryImg.Text;
                   
                        break;
                    }
                    
                }
                
            }
            else
            {
                Pelicula.nombrePelicula = entryNombre.Text;
                Pelicula.categoriaPelicula = entryCategoria.Text;
                Pelicula.precioPelicula = int.Parse(entryPrecio.Text);
                Pelicula.idPelicula = int.Parse(entryId.Text);
                Pelicula.fotoPelicula = entryImg.Text;
                this.Mainpage.listaPeliculas.Add(Pelicula);

            }
            
            this.Mainpage.ActualizarLista();
            Navigation.PopAsync();
        }

        private void btn_cancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}