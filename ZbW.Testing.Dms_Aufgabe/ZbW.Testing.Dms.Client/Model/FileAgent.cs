
using System;
using System.IO;
using System.Xml.Linq;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.Model
{
    /// <summary>
    /// File worker, contains all the logic which is needed by <see cref="ZbW.Testing.Dms.Client.ViewModels.DocumentDetailViewModel"/>
    /// </summary>
    internal class FileAgent
    {
        // file & folder metas
        private string _fileName;
        private string _sourcePath;
        private string _destinationPath;
        private DocumentDetailViewModel _doc;
        private XDocument[] _xmlDocs;
 
        public FileAgent(DocumentDetailViewModel doc = null)
        {
            _doc = doc;
        }

        public FileAgent(string fileName, string sourcePath, string destinationPath)
        {
            _fileName = fileName;
            _sourcePath = sourcePath;
            _destinationPath = destinationPath;
        }

        public string FileName
        {
            get => _fileName;
            set => _fileName = value;
        }

        public string SourcePath
        {
            get => _sourcePath;
            set => _sourcePath = value;
        }

        public string DestinationPath
        {
            get => _destinationPath;
            set => _destinationPath = value;
        }

        public DocumentDetailViewModel Doc
        {
            get => _doc;
            set => _doc = value;
        }

        public bool CopyFile(string sourcePath, string dstPath)
        {
            if (!string.IsNullOrWhiteSpace(sourcePath) &&
                !string.IsNullOrWhiteSpace(dstPath))
            {
                string fn = GetFileNameOf(sourcePath);
                string targetPath = dstPath + fn;
                File.Copy(sourcePath,targetPath);
                return true;
            }

            return false;
        }
        public bool MoveFile(string sourcePath, string dstPath)
        {
            if (!string.IsNullOrWhiteSpace(sourcePath) &&
                !string.IsNullOrWhiteSpace(dstPath))
            {
                string fn = GetFileNameOf(sourcePath);
                string targetPath = dstPath + fn;
                File.Move(sourcePath,targetPath);
                return true;
            }

            return false;
        }

        private string GetFileNameOf(string pathStr)
        {
            var indexOf = pathStr.LastIndexOf("\\");
            return pathStr.Substring(indexOf);
        }

        private Configuration GetConfigFile()
        {
            var cnfg = new Configuration();
            if (cnfg != null) return cnfg;
            return null;
        }
        
        //TODO add method to get all xml files from repo path

    }
}