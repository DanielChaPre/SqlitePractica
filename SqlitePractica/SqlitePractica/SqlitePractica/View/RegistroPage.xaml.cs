using PracticaSQLite.Modelo;
using PracticaSQLite.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PracticaSQLite.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistroPage : ContentPage
	{
        public SQLiteConnection conn;

        public RegistroPage ()
		{
			InitializeComponent ();
            conn = DependencyService.Get<ISQLitePlatform>().GetConnection();
            conn.CreateTable<Usuario>();
        }

        public int SaveItemAsync(Usuario item)
        {
            if (item.Id != 0)
            {
                return conn.Update(item);
            }
            else
            {
                return conn.Insert(item);
            }
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            var usuario = new Usuario
            {
                nombreusuario = txtusuario.Text,
                password = txtpass.Text
            };

           var confirmacion = SaveItemAsync(usuario);

            Application.Current.MainPage = new NavigationPage(new Pantalla2View());

        }
    }
}