﻿using ForControllers.VatanArayüz;
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

namespace VatanArayüz.UserControls2
{
    /// <summary>
    /// ProductButton.xaml etkileşim mantığı
    /// </summary>
    public partial class ProductButton : UserControl
    {
        public Product product;
        public ProductButton()
        {
            InitializeComponent();
        }
    }
}
