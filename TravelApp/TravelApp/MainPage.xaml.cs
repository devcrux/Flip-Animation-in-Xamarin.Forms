using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            places = GetPlaces();
            this.BindingContext = this;
        }

        public ObservableCollection<Place> places;
        public ObservableCollection<Place> Places
        {
            get { return places; }
            set
            {
                places = value;
                OnPropertyChanged();
            }
        }

        private async Task Flip(VisualElement from, VisualElement to)
        {
            await from.RotateYTo(-90, 300, Easing.SpringIn);
            to.RotationY = 90;
            to.IsVisible = true;
            from.IsVisible = false;
            await to.RotateYTo(0, 300, Easing.SpringOut);
        }

        private async void FlipToBack(object sender, EventArgs e)
        {
            var front = sender as Grid;
            var back = front.Parent.FindByName<Grid>("BackView");
            await Flip(front, back);
        }

        private async void FlipToFront(object sender, EventArgs e)
        {
            var back = sender as Grid;
            var front = back.Parent.FindByName<Grid>("FrontView");
            await Flip(back, front);
        }

        private ObservableCollection<Place> GetPlaces()
        {
            return new ObservableCollection<Place>
            {
                new Place
                {
                    Name = "Costa Rica",
                    Caption = "Explore the peaceful escapes and jungles.",
                    Image = "Costa.jpg",
                    Description = $"Costa Rica flies the flag for sustainable tourism. This small country’s vast biodiversity attracts visitors keen to spot sleepy sloths in trees, red-eyed frogs paralysing their predators, and whales in the Pacific. {Environment.NewLine}{Environment.NewLine}Costa Ricans understand the importance of preserving their slice of tropical paradise and have found a way to invite others in while living in harmony with their neighbours – from leafcutter ants to jaguars. Ninety percent of the country’s energy is created by renewable sources, and it could become one of the first carbon-neutral countries in 2020. {Environment.NewLine}{Environment.NewLine}Adventure lovers can hike volcanoes or ride a zip line, while those craving ‘me time’ can enjoy yoga retreats and spa experiences. The catchphrase pura vida (pure life) is more than a saying, it’s a way of life."
                },
                new Place
                {
                    Name = "The Netherlands",
                    Caption = "Vibrant Amsterdam always deserves a visit.",
                    Image = "Netherlands.jpg",
                    Description = $"In the year that marks 75 years of freedom since the end of WWII, the Netherlands is ready to celebrate with events across the country. {Environment.NewLine}{Environment.NewLine}Vibrant Amsterdam always deserves a visit, but by making use of the excellent train network you can explore a host of celebrations in stunning cities and get more bang for your euros. April and May are the months to visit, as you can take in King's Day, Liberation Day and the Eurovision Song Contest, which will be hosted in the country this year. {Environment.NewLine}{Environment.NewLine}Set out on the ever-growing network of over 35,000km of cycling paths to explore attractions beyond the cities, such as Unesco World Heritage Site the Wadden Sea, and discover the wealth of nature that this tiny country has to offer."
                },
                new Place
                {
                    Name = "Morocco",
                    Caption = "Enjoy seasonal produce and coastal wellness retreats.",
                    Image = "Morocco.jpg",
                    Description = $"Morocco is having a moment, with time-honoured attractions complemented by sustainable-yet-stylish lodging, restaurants serving up seasonal produce and coastal wellness retreats mixing up yoga and surfing. {Environment.NewLine}{Environment.NewLine}And thanks to improved infrastructure it’s easier to get around by road, while Africa’s first high-speed train means that you can zip from Casablanca to Tangier in just two hours. Ancient medinas are getting a makeover in Fez, Essaouira, Meknes, Tetouan and Marrakesh, which will be crowned Africa’s first Capital of Culture in 2020 in celebration of its rich heritage. {Environment.NewLine}{Environment.NewLine}And you can still escape the crowds in Berber mountain villages, deserted Atlantic beaches and far-flung desert outposts."
                }
            };
        }

    }

    public class Place
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
