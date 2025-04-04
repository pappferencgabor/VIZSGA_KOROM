using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Windows;
using System.IO;

using autoapp.Models;

namespace autoform;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    ObservableCollection<Auto> autos = new ObservableCollection<Auto>();

    public MainWindow()
    {
        InitializeComponent();
    }

    public void LoadData(string path)
    {
        File.ReadAllLines(path).Skip(1).ToList().ForEach(x =>
        {
            autos.Add(new Auto(x));
        });

        dgAdatok.ItemsSource = autos;
    }

    private void btnLoad_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "CSV|*.csv";
        openFileDialog.ShowDialog();

        if (openFileDialog.FileName != "")
        {
            LoadData(openFileDialog.FileName);
        }
    }

    private void txtYear_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (txtYear.Text.Trim() != "")
        {
            lbAdatok.ItemsSource = autos.Where(x => x.gyartasiEv == int.Parse(txtYear.Text)).Select(x => $"{x.marka} {x.modell}");
        }
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        var res = MessageBox.Show("Biztos vagy a kilépésben?", "Kilépés", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (res == MessageBoxResult.Yes)
        {
            this.Close();
        }
    }
}