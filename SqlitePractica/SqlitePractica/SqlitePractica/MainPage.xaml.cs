using PracticaSQLite.Modelo;
using PracticaSQLite.Services;
using PracticaSQLite.View;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PracticaSQLite
{
    public partial class MainPage : ContentPage
    {

        public SQLiteConnection conn;

        public MainPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLitePlatform>().GetConnection();
            conn.CreateTable<Usuario>();
           // btnLogin.Clicked
            var user = new Usuario()
            {
                nombreusuario = "prueba",
                password = "123456"
            };

            SaveItemAsync(user);
        }

        public List<Usuario> GetItemsAsync()
        {
            return conn.Table<Usuario>().ToList();
        }

        public List<Usuario> GetItemsQuery(string user, string pass)
        {
           return conn.Query<Usuario>("SELECT * FROM Usuario WHERE nombreusuario = ? and password = ?", new string[2] {user,pass} );
        }

        public Usuario GetItem(int id)
        {
            return conn.Table<Usuario>().Where(i => i.Id == id).FirstOrDefault();
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

        public int DeleteItemAsync(Usuario item)
        {
            return conn.Delete(item);
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var usuario = txtusuario.Text;
            var pass = txtpass.Text;

            var user = GetItemsQuery(usuario, pass);

            if (!string.IsNullOrEmpty(user[0].nombreusuario))
            {
               // Application.Current.MainPage.Navigation.PushAsync(new Pantalla2View());
                Application.Current.MainPage = new NavigationPage(new Pantalla2View());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("alerta", "El usuario no fue encontrado", "Ok");
            }

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new RegistroPage());
        }

    }
}
