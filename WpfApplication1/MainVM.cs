using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using JetBrains.Annotations;
using MahApps.Metro.Controls;
using NetLib.WPF;
using NetLib.WPF.Converters;
using Image = System.Windows.Controls.Image;

namespace WpfApplication1
{
    public class MainVM : BaseViewModel
    {
        public MainVM()
        {
            Items = Enumerable.Range(0, 5).Select((s,i) => new Item
            {
                Name = $"Тест {i}",
                Image = new BitmapImage(new Uri("tree.jpg", UriKind.Relative))
            }).ToList();
        }

        public List<Item> Items { get; set; }
        public Item SelectedItem { get; set; }
    }

    public class Item
    {
        public ImageSource Image { get; set; }
        public string Name { get; set; }
    }
}