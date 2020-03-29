using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrcticePKMN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnBack.IsEnabled = false;
            btnFront.IsEnabled = false;
            string url = "https://pokeapi.co/api/v2/pokemon?offset=0&1limit=1000";

            AllPokemonAPI pokemonStuff;

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                pokemonStuff = JsonConvert.DeserializeObject<AllPokemonAPI>(json);
            }
            
            foreach (var pokemon in pokemonStuff.results)
            {
                lstPokemen.Items.Add(pokemon);
            }
        }
        private void LstPokemen_SelectionChanged (object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            AllPokemonResult selectedPokemon = (AllPokemonResult)lstPokemen.SelectedItem; // cast it to the data type of what we put in the listbox



            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(selectedPokemon.url).Result;

                PokemonInfo = JsonConvert.DeserializeObject<PokemonAPI>(json);
            }

            lblDescription.Content = $"{PokemonInfo.name} is {PokemonInfo.height}' tall and weights {PokemonInfo.weight} pounds";
            imgPokemon.Source = new BitmapImage(new System.Uri(PokemonInfo.sprites.front_default));
            btnBack.IsEnabled = true;
            btnFront.IsEnabled = true;
        }

        private void BtnFront_Click(object sender, RoutedEventArgs e)
        {
            imgPokemon.Source = new BitmapImage(new System.Uri(PokemonInfo.sprites.front_default));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            imgPokemon.Source = new BitmapImage(new System.Uri(PokemonInfo.sprites.back_default));

        }
    }
}
