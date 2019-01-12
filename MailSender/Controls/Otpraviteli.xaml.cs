using System;
using System.Collections;
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

namespace MailSender.Controls
{
    /// <summary>
    /// Логика взаимодействия для Otpraviteli.xaml
    /// </summary>
    public partial class Otpraviteli : UserControl
    {
        public Otpraviteli()
        {
            InitializeComponent();
        }

        #region PanelText
        public static readonly DependencyProperty PanelTextProperty = DependencyProperty.Register(
            "PanelText", typeof(string), typeof(Otpraviteli), new PropertyMetadata("Текст панели"));

        public string PanelText
        {
            get { return (string)GetValue(PanelTextProperty); }
            set { SetValue(PanelTextProperty, value); }
        }
        #endregion
        #region ItemsSource 
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof(IEnumerable), typeof(Otpraviteli), new PropertyMetadata(default(IEnumerable)));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        #endregion
        #region ItemTemplate

        public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(
            "ItemTemplate", typeof(DataTemplate), typeof(Otpraviteli), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate) GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
        #endregion
        #region SelectedIndex

        public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register(
            "SelectedIndex", typeof(int), typeof(Otpraviteli), new PropertyMetadata(default(int)));

        public int SelectedIndex
        {
            get { return (int) GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }


        #endregion
        #region SelectedItem
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof(object), typeof(Otpraviteli), new PropertyMetadata(default(object)));

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        #endregion

        #region CreateItemCommand

        public static readonly DependencyProperty CreateItemCommandProperty = DependencyProperty.Register(
            "CreateItemCommand", typeof(ICommand), typeof(Otpraviteli), new PropertyMetadata(default(ICommand)));

        public ICommand CreateItemCommand
        {
            get { return (ICommand) GetValue(CreateItemCommandProperty); }
            set { SetValue(CreateItemCommandProperty, value); }
        }
        #endregion
        #region RemoveItemCommand

        public static readonly DependencyProperty RemoveItemCommandProperty = DependencyProperty.Register(
            "RemoveItemCommand", typeof(ICommand), typeof(Otpraviteli), new PropertyMetadata(default(ICommand)));

        public ICommand RemoveItemCommand
        {
            get { return (ICommand) GetValue(RemoveItemCommandProperty); }
            set { SetValue(RemoveItemCommandProperty, value); }
        }
        #endregion
        #region EditItemCommand
        public static readonly DependencyProperty EditItemCommandProperty = DependencyProperty.Register(
            "EditItemCommand", typeof(ICommand), typeof(Otpraviteli), new PropertyMetadata(default(ICommand)));

        public ICommand EditItemCommand
        {
            get { return (ICommand) GetValue(EditItemCommandProperty); }
            set { SetValue(EditItemCommandProperty, value); }
        }
        #endregion
    }
}
