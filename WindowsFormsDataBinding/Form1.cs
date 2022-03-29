using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;

namespace WindowsFormsDataBinding
{
    public partial class Form1 : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private bool _nonEmptyText;
        public bool NonEmptyText
        {
            get => _nonEmptyText;
            set
            {
                _nonEmptyText = value;
                NotifyPropertyChange();
            }
        }

        private BindingList<Person> _people;
        public BindingList<Person> People
        {
            get => _people;
            set
            {
                _people = value;
                NotifyPropertyChange();
            }
        }


        public Form1()
        {
            InitializeComponent();

            People = new BindingList<Person>
            {
                new Person(1, "Allan"),
                new Person(2, "Bob"),
                new Person(3, "Cole"),
                new Person(4, "Daniel"),
                new Person(5, "Eaton"),
            };

            label1.DataBindings.Add("Text", textBox1, "Text");

            button1.DataBindings.Add("Enabled",
                this, nameof(NonEmptyText));

            dataGridView1.DataSource = People;
        }

        private void NotifyPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            NonEmptyText = !string.IsNullOrWhiteSpace(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            People.Add(new Person(0, textBox1.Text));

            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(People)));

            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = People.ToList();
        }
    }

    public class NonBlankTextToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !string.IsNullOrWhiteSpace(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }

    public class Person
    {
        public Person(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; set; }

        public string Name { get; set; }
    }
}
