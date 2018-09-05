namespace ZbW.Testing.Dms.Client.Views
{
    using System;
    using System.Windows.Controls;

    using ZbW.Testing.Dms.Client.ViewModels;
    using ZbW.Testing.Dms.Client.Model;

    /// <summary>
    /// Interaction logic for NewDocumentView.xaml
    /// </summary>
    public partial class DocumentDetailView : UserControl
    {
        public DocumentDetailView(string benutzer, Configuration configs ,Action navigateBack)
        {
            InitializeComponent();
            DataContext = new DocumentDetailViewModel(benutzer, configs ,navigateBack);
        }

        private void btnCmpSpeichern_click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

    }
}