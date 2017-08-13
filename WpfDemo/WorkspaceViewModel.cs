using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFDemo
{
    public class WorkspaceViewModel : INotifyPropertyChanged
    {
        /**********************************************************************/
        #region Properties

        public byte RedColorValue
        {
            get { return RedColorValueProperty; }
            set
            {
                if(RedColorValueProperty != value)
                {
                    RedColorValueProperty = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RedColorValue)));

                    SelectedColorProperty = Color.FromRgb(RedColorValueProperty, GreenColorValueProperty, BlueColorValueProperty);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedColor)));
                }
            }
        }
        private byte RedColorValueProperty = 0;

        public byte GreenColorValue
        {
            get { return GreenColorValueProperty; }
            set
            {
                if (GreenColorValueProperty != value)
                {
                    GreenColorValueProperty = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GreenColorValue)));

                    SelectedColorProperty = Color.FromRgb(RedColorValueProperty, GreenColorValueProperty, BlueColorValueProperty);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedColor)));
                }
            }
        }
        private byte GreenColorValueProperty = 0;

        public byte BlueColorValue
        {
            get { return BlueColorValueProperty; }
            set
            {
                if (BlueColorValueProperty != value)
                {
                    BlueColorValueProperty = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BlueColorValue)));

                    SelectedColorProperty = Color.FromRgb(RedColorValueProperty, GreenColorValueProperty, BlueColorValueProperty);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedColor)));
                }
            }
        }
        private byte BlueColorValueProperty = 0;

        public Color SelectedColor
        {
            get { return SelectedColorProperty; }
            set
            {
                if(SelectedColorProperty != value)
                {
                    SelectedColorProperty = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedColor)));

                    RedColorValueProperty = value.R;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RedColorValue)));

                    GreenColorValueProperty = value.G;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GreenColorValue)));

                    BlueColorValueProperty = value.B;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BlueColorValue)));
                }
            }
        }
        private Color SelectedColorProperty = Color.FromRgb(0, 0, 0);

        public ObservableCollection<Color> SavedColors { get; } = new ObservableCollection<Color>();

        #endregion Properties

        /**********************************************************************/
        #region Commands

        public ICommand SaveColorCommand => new DelegateCommand(
            (color) => SavedColors.Add((Color)color),
            (color) => (color is Color) && (!SavedColors.Contains((Color)color)));

        public ICommand RestoreColorCommand => new DelegateCommand(
            (color) => SelectedColor = (Color)color,
            (color) => (color is Color));

        public ICommand DeleteColorCommand => new DelegateCommand(
            (color) => SavedColors.Remove((Color)color),
            (color) => (color is Color) && (SavedColors.Contains((Color)color)));

        #endregion Commands

        /**********************************************************************/
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion INotifyPropertyChanged
    }
}
