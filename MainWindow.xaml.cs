using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiDemos
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        const int rowCount = 30;
        const int columnCount = 30;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void ClearGrid_Clicked(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            contentGrid.Children.Clear();

            sw.Stop();

            info.Text = $"Clearing grid took: {sw.ElapsedMilliseconds} ms";
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            contentGrid.Children.Clear();

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    TextBlock label = new() { Text = $"[{columnIndex}x{rowIndex}]" };
                    contentGrid.Children.Add(label);
                }
            }

            sw.Stop();
            info.Text = $"Grid was created in: {sw.ElapsedMilliseconds} ms";
        }        
        
        private void BatchGenerate_Clicked(object sender, RoutedEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            int batchSize = int.Parse(BatchSize.Text);

            for (int i = 0; i < batchSize; i++)
            {
                contentGrid.Children.Clear();

                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        TextBlock label = new() { Text = $"[{columnIndex}x{rowIndex}]" };
                        // contentGrid.Add(label, column: columnIndex, row: rowIndex);
                        contentGrid.Children.Add(label);
                    }
                }
            }

            sw.Stop();
            info.Text = $"Grid was created {batchSize} times and it took {sw.ElapsedMilliseconds} ms in total. Avg run took {Math.Round(sw.ElapsedMilliseconds / (double)batchSize, 2)} ms";
        }
    }
}
