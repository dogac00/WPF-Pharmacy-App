using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace PharmacyApp.Extensions
{
    static class DataGridExtensions
    {
        public static void AddButtonColumn(this DataGrid grid, string content, RoutedEventHandler handler)
        {
            var buttonTemplate = new FrameworkElementFactory(typeof(Button));

            buttonTemplate.SetValue(ContentControl.ContentProperty, content);
            buttonTemplate.SetBinding(UIElement.IsEnabledProperty, new Binding("Status"));

            buttonTemplate.AddHandler(
                ButtonBase.ClickEvent,
                new RoutedEventHandler(handler)
            );

            grid.Columns.Add(
                new DataGridTemplateColumn()
                {
                    Header = content,
                    CellTemplate = new DataTemplate() { VisualTree = buttonTemplate }
                }
            );
        }

        public static void HideColumn(this DataGrid dataGrid, string colunmHeader)
        {
            var col = GetColumn(dataGrid, colunmHeader);

            col.Visibility = Visibility.Collapsed;
        }

        public static void RenameColumn(this DataGrid dataGrid, string initialHeader, string newHeader)
        {
            var col = GetColumn(dataGrid, initialHeader);

            col.Header = newHeader;
        }

        public static DataGridColumn GetColumn(this DataGrid dataGrid, string columnName)
        {
            foreach (DataGridColumn column in dataGrid.Columns)
            {
                string header = column.Header as string;

                if (header == columnName)
                    return column;
            }

            return null;
        }
    }
}
