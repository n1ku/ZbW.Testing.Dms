using System.Windows;
using System.Windows.Controls;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Views;
using System.IO;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Win32;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Model;
    internal class DocumentDetailViewModel : BindableBase
    {
        private readonly Action _navigateBack;

        private string _benutzer;

        private string _bezeichnung;

        private DateTime _erfassungsdatum;

        private string _filePath;

        private bool _isRemoveFileEnabled;

        private string _selectedTypItem;

        private string _stichwoerter;

        private List<string> _typItems;

        private DateTime? _valutaDatum;

        private Configuration _config;

        private FileAgent _fileAgent;

        public DocumentDetailViewModel(string benutzer, Configuration config ,Action navigateBack)
        {
            _navigateBack = navigateBack;
            
            Benutzer = benutzer;
            Erfassungsdatum = DateTime.Now;
            TypItems = ComboBoxItems.Typ;
            this.Config = config;
            CmdDurchsuchen = new DelegateCommand(OnCmdDurchsuchen);
            CmdSpeichern = new DelegateCommand(OnCmdSpeichern);
        }



        public Configuration Config
        {
            get => _config;
            set => SetProperty(ref _config, value);
        }

        public string Stichwoerter
        {
            get
            {
                return _stichwoerter;
            }

            set
            {
                SetProperty(ref _stichwoerter, value);
            }
        }

        public string Bezeichnung
        {
            get
            {
                return _bezeichnung;
            }

            set
            {
                SetProperty(ref _bezeichnung, value);
            }
        }

        public List<string> TypItems
        {
            get
            {
                return _typItems;
            }

            set
            {
                SetProperty(ref _typItems, value);
            }
        }

        public string SelectedTypItem
        {
            get
            {
                return _selectedTypItem;
            }

            set
            {
                SetProperty(ref _selectedTypItem, value);
            }
        }

        public DateTime Erfassungsdatum
        {
            get
            {
                return _erfassungsdatum;
            }

            set
            {
                SetProperty(ref _erfassungsdatum, value);
            }
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

        public DelegateCommand CmdDurchsuchen { get; }

        public DelegateCommand CmdSpeichern { get; }

        public DateTime? ValutaDatum
        {
            get
            {
                return _valutaDatum;
            }

            set
            {
                SetProperty(ref _valutaDatum, value);
            }
        }

        public bool IsRemoveFileEnabled
        {
            get
            {
                return _isRemoveFileEnabled;
            }

            set
            {
                SetProperty(ref _isRemoveFileEnabled, value);
            }
        }
        /// Um den Ursprungspfad der Datei ins Metafile schreiben zu können muss _filePath readable sein von <see cref="MetadataItem"/> aus.
        public string FilePath
        {
            get => _filePath;
        }
        private void OnCmdDurchsuchen()
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();

            if (result.GetValueOrDefault())
            {
                _filePath = openFileDialog.FileName;
            }
        }

        private void OnCmdSpeichern()
        {
            if (string.IsNullOrEmpty(Config.RepoLocationPath))
            {
                string msg = "Bitte Repositorypfad definieren. \n Klicken Sie dafür auf das schwarze Ordnersymbol unten rechs.\n"+
                    "Wollen Sie den Pfad gleich definieren?";
                string header = "Repository unbekannt";
                MessageBoxButton btns = MessageBoxButton.YesNo;
                if (MessageBox.Show(msg, header, btns) == MessageBoxResult.Yes)
                {
                    Config.DefineRepositoryPathDialog();
                    OnCmdSpeichern();
                }
            }
            else
            {
                if (ChkMandatoryFlds())
                {
                    var metafile = new MetadataItem(this);
                    metafile.GenerateMetaFile();
                    _navigateBack();
                    var fa = new FileAgent();
                    fa.MoveFile(_filePath, Config.RepoLocationPath);
                }
                else
                {
                    string msg = "\nBitte befüllen Sie alle Mussfelder.\n \nMussfelder sind mit '*' markiert.";
                    string header = "Felder nicht befüllt.";
                    MessageBoxButton btns = MessageBoxButton.OK;
                    MessageBox.Show(msg, header, btns);
                }
            }

        }

        private bool ChkMandatoryFlds()
        {
            bool isValid = !string.IsNullOrEmpty(FilePath) && !string.IsNullOrEmpty(Bezeichnung) &&
                           ValutaDatum.HasValue &&
                           !string.IsNullOrEmpty(SelectedTypItem) && !string.IsNullOrEmpty(Stichwoerter) &&
                           !string.IsNullOrEmpty(Erfassungsdatum.ToString());

            return isValid;
        }
    }
}