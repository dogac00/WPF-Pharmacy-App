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
    }
}
