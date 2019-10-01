using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ReactiveUI;

namespace ReproTreeView
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }
    }

    public class MainPageViewModel : ReactiveObject
    {
        private List<Item> _items;
        public List<Item> Items
        {
            get => _items;
            private set => this.RaiseAndSetIfChanged(ref _items, value);
        }

        public MainPageViewModel()
        {
            //Items = GetDessertData();
            GetDesertDataSync();
        }

        private async Task GetDesertDataSync()
        {
            await Task.Delay(2000);
            Items = GetDessertData();
        }

        private List<Item> GetDessertData() => new List<Item>
            { 
                new Item("Flavors", new List<Item>
                {
                    new Item("Vanilla", null),
                    new Item("Strawberry", null),
                    new Item("Chocolate", null)
                }),
                new Item("Toppings", new List<Item>
                {
                    new Item("Candy", new List<Item>
                    {
                        new Item("Chocolate", null),
                        new Item("Mint", null),
                        new Item("Sprinkles", null)
                    }),
                    new Item("Fruits", new List<Item>
                    {
                        new Item("Mango", null),
                        new Item("Peach", null),
                        new Item("Kiwi", null)
                    }),
                    new Item("Berries", new List<Item>
                    {
                        new Item("Strawberry", null),
                        new Item("Blueberry", null, true),
                        new Item("Blackberry",null, true)
                    })
                })
            };
    }

    public class Item : ReactiveObject
    {
        private bool _isSelected;
        public string Name { get; }
        public List<Item> Children { get; }

        public bool IsSelected
        {
            get => _isSelected;
            set => this.RaiseAndSetIfChanged(ref _isSelected, value);
        }

        public Item(string name, List<Item> children, bool isSelected = false)
        {
            Name = name;
            Children = children;
            IsSelected = isSelected;
        }
    }
}
