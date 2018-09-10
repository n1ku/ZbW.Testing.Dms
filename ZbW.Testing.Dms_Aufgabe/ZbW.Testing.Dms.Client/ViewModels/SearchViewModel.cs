﻿namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Collections.Generic;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Model;

    internal class SearchViewModel : BindableBase
    {
        private List<MetadataItemXml> _filteredMetadataItems;

        private MetadataItemXml _selectedMetadataItemXml;

        private string _selectedTypItem;

        private string _suchbegriff;

        private List<string> _typItems;

        private Configuration _config;

        public SearchViewModel()
        {
            TypItems = ComboBoxItems.Typ;

            CmdSuchen = new DelegateCommand(OnCmdSuchen);
            CmdReset = new DelegateCommand(OnCmdReset);
            CmdOeffnen = new DelegateCommand(OnCmdOeffnen, OnCanCmdOeffnen);
            
            Config = new Configuration();

        }

        public Configuration Config
        {
            get => _config;
            set => SetProperty(ref _config, value);
        }

        public DelegateCommand CmdOeffnen { get; }

        public DelegateCommand CmdSuchen { get; }

        public DelegateCommand CmdReset { get; }

        public string Suchbegriff
        {
            get
            {
                return _suchbegriff;
            }

            set
            {
                SetProperty(ref _suchbegriff, value);
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

        public List<MetadataItemXml> FilteredMetadataItems
        {
            get
            {
                return _filteredMetadataItems;
            }

            set
            {
                SetProperty(ref _filteredMetadataItems, value);
            }
        }

        public MetadataItemXml SelectedMetadataItemXml
        {
            get
            {
                return _selectedMetadataItemXml;
            }

            set
            {
                if (SetProperty(ref _selectedMetadataItemXml, value))
                {
                    CmdOeffnen.RaiseCanExecuteChanged();
                }
            }
        }

        private bool OnCanCmdOeffnen()
        {
            return SelectedMetadataItemXml != null;
        }

        private void OnCmdOeffnen()
        {
            // TODO: Add your Code here
        }

        private void OnCmdSuchen()
        {
            // TODO: Add your Code here
        }

        private void OnCmdReset()
        {
            // TODO: Add your Code here
        }


    }
}