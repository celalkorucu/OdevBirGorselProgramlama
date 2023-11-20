using OdevBirGorselProgramlama.Views;

namespace OdevBirGorselProgramlama
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout();

            #region Main Page
           
                var image = new Image
                {
                    Source = "Resources/Images/image.jpg",
                    WidthRequest = 200,
                    HeightRequest = 200,
                    Margin = 50 ,
                    
                    Aspect = Aspect.AspectFill,
                };

           
                layout.Children.Add(image);



            var nameLabel = new Label
            {
                Text = "Celal KORUCU",
                FontSize = 30,
                TextColor = Colors.Orange,
                Margin = 10 ,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            layout.Children.Add(nameLabel);

            var universityLabel = new Label
            {
                Text = "Bartın Üniversitesi",
                FontSize = 30,
                TextColor = Colors.Orange,
                Margin = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            layout.Children.Add(universityLabel);
            var bolumLabel = new Label
            {
                Text = "Bilgisayar Mühendisliği",
                FontSize = 25,
                TextColor = Colors.Orange,
                Margin = 4,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            layout.Children.Add(bolumLabel);

            var assignmentLabel = new Label
            {
                Text = "Ödev-1",
                FontSize = 40,
                TextColor = Colors.Orange,
                Margin = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            layout.Children.Add(assignmentLabel);

            Content = new ScrollView
            {
                Content = layout,
            };
            #endregion

            #region Menus
            var pageMainMenuItem = new ToolbarItem
            {
                //Text = "Ana Sayfa",
                IconImageSource= ImageSource.FromFile("Images/home.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };

            pageMainMenuItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new MainPage());
            };

            ToolbarItems.Add(pageMainMenuItem);

            var pageBodyIndexMenuItem = new ToolbarItem
            {
                //Text = "Vücud İndeksi Hesaplama",
                IconImageSource = ImageSource.FromFile("Images/body.png"),
                Order = ToolbarItemOrder.Primary,
               
                Priority = 1
            };

            pageBodyIndexMenuItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new BodyIndex());
            };

            ToolbarItems.Add(pageBodyIndexMenuItem);

            var pageColorPickerMenuItem = new ToolbarItem
            {
                //Text = "Renk Oluşturma",
                IconImageSource = ImageSource.FromFile("Images/color.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 1
            };

            pageColorPickerMenuItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ColorPicker());
            };

            ToolbarItems.Add(pageColorPickerMenuItem);

            var pageLoanMenuItem = new ToolbarItem
            {
                // Text = "Kredi Hesaplama",
                IconImageSource = ImageSource.FromFile("Images/credit.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 1
            };

            pageLoanMenuItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Loan());
            };

            ToolbarItems.Add(pageLoanMenuItem);

            var pageTodoMenuItem = new ToolbarItem
            {
               // Text = "Yapılacaklar Listesi",
                IconImageSource = ImageSource.FromFile("Images/todo.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 1
            };

            pageTodoMenuItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Todo());
            };

            ToolbarItems.Add(pageTodoMenuItem);
            #endregion
        }
    }

}
