using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace spisok_pokupok_1
{
    public class Food : BindableObject
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                
                if (_quantity == value) return;
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private Color _clr;
        public Color Clr
        {
            get => _clr;
            set
            {
                if (_clr == value) return;
                _clr = value;
                OnPropertyChanged(nameof(Clr));
            }
        }

        private bool _checked;
        public bool Checked
        {
            get => _checked;
            set
            {
                if (_checked == value) return;
                _checked = value;
                OnPropertyChanged(nameof(Checked));
            }
        }

    }

    public class ViewModel : BindableObject
    {
        public ViewModel()
        {
            AddCommand = new Command<string>(ItemName =>
            {
                var Food = new Food
                {
                    Name = ItemName,
                    Quantity = Quantity,
                    Clr = Clr
                };
                Foods.Add(Food);
            }, x => string.IsNullOrWhiteSpace(x) == false);


            ChangeColor = new Command<Color>(newClr =>
            {
                Clr = newClr;
            }, x => x != Clr);

            Foods = new ObservableCollection<Food>();

            DeleteChoosed = new Command(() =>
            {
                foreach (var Food in Foods.ToList())
                {
                    if (Food.Checked == true)
                    {
                        Foods.Remove(Food);
                    }
                }
            }, () => true);
        }

        int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                
                if (_quantity == value) return;
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private Color _clr = Color.Gainsboro;
        public Color Clr
        {
            get => _clr;
            set
            {
                if (_clr == value) return;
                _clr = value;
                OnPropertyChanged(nameof(Clr));
            }
        }





        public ObservableCollection<Food> Foods { get; }

        public ICommand
            AddCommand
        { get; }

        public ICommand
            ChangeColor
        { get; }

        public ICommand
            DeleteChoosed
        { get; }


    }
}