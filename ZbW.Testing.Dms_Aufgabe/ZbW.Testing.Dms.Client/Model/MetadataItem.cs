using System;
using Prism.Mvvm;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem : BindableBase
    {
        private string _username;
        private string _tags;
        private string _type;
        private DateTime _creationDate;
        private DateTime _valuta;
        private bool _isRemoveOn;
        private string _filePath;

        public MetadataItem(string username = null, string tags = null, string type = null, 
            DateTime creationDate = default(DateTime), DateTime valuta = default(DateTime),
            bool isRemoveOn = false, string filePath = null)
        {
            _username = username;
            _tags = tags;
            _type = type;
            _creationDate = creationDate;
            _valuta = valuta;
            _isRemoveOn = isRemoveOn;
            _filePath = filePath;
        }

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Tags
        {
            get => _tags;
            set => SetProperty(ref _tags,value);
        }

        public string Type
        {
            get => _type;
            set => SetProperty(ref _type,value);
        }

        public DateTime CreationDate
        {
            get => _creationDate;
            set => SetProperty(ref _creationDate,value);
        }

        public DateTime Valuta
        {
            get => _valuta;
            set => SetProperty(ref _valuta,value);
        }

        public bool IsRemoveOn
        {
            get => _isRemoveOn;
            set => SetProperty(ref _isRemoveOn,value);
        }

        public string FilePath
        {
            get => _filePath;
            set => SetProperty(ref _filePath,value);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}