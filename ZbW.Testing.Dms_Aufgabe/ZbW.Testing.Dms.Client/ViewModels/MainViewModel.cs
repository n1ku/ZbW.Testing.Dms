using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Windows.Controls;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Views;

    internal class MainViewModel : BindableBase
    {
        private string _benutzer;

        private UserControl _content;

        private Configuration _appConfig;

        

        public MainViewModel(string benutzername)
        {
            Benutzer = benutzername;
            AppConfig = new Configuration(Benutzer);
            CmdNavigateToSearch = new DelegateCommand(OnCmdNavigateToSearch);
            CmdNavigateToDocumentDetail = new DelegateCommand(OnCmdNavigateToDocumentDetail);

            CmdSetRepoPath = new DelegateCommand(OnSetRepoPathUser);


        }

        public Configuration AppConfig
        {
            get => _appConfig;
            set => SetProperty(ref _appConfig, value);
        }

        public string Benutzer
        {
            get
            {
                return _benutzer;
            }

            set
            {
                SetProperty(ref _benutzer, value);
            }
        }

        public UserControl Content
        {
            get
            {
                return _content;
            }

            set
            {
                SetProperty(ref _content, value);
            }
        }

        public DelegateCommand CmdNavigateToSearch { get; }

        public DelegateCommand CmdNavigateToDocumentDetail { get; }

        public DelegateCommand CmdEnableSaveBtn { get; }

        public DelegateCommand CmdNavigateToSettings { get; }

        public DelegateCommand CmdSetRepoPath { get; }

        private void OnCmdNavigateToSearch()
        {
            NavigateToSearch();
        }

        private void OnCmdNavigateToDocumentDetail()
        {
            Content = new DocumentDetailView(Benutzer, AppConfig,  NavigateToSearch);
        }

        private void NavigateToSearch()
        {
            Content = new SearchView();
        }

        private void NavigateToSettings()
        {
            //Content = new SettingsView();
        }

        private void OnSetRepoPathUser()
        {
            AppConfig.DefineRepositoryPathDialog();
            
        }
    }
}