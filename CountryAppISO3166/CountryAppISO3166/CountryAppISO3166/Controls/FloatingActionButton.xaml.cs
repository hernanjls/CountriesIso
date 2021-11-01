using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CountryAppISO3166.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingActionButton : Button
    {
        public static BindableProperty ButtonColorProperty = BindableProperty.Create(nameof(ButtonColor), typeof(Color), typeof(FloatingActionButton), Color.Accent);
        public Color ButtonColor
        {
            get
            {
                return (Color)GetValue(ButtonColorProperty);
            }
            set
            {
                SetValue(ButtonColorProperty, value);
            }
        }
        public FloatingActionButton()
        {
            this.Style = (Style)Application.Current.Resources["FloatingBtn"];
            InitializeComponent();
        }
    }
}