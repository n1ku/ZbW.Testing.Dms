using System.Windows.Forms;

namespace ZbW.Testing.Dms.Client.Repositories
{
    public class RepositorySettings
    {
        private string _repoLocationPath;

        public string RepoLocationPath
        {
            get => _repoLocationPath;
            set => _repoLocationPath = value;
        }

        public RepositorySettings()
        {
            var folderDialog = new FolderBrowserDialog();
            RepoLocationPath = folderDialog.SelectedPath;
        }
    }
}