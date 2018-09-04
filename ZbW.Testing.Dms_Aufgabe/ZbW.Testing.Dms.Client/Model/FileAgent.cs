
using System;
using System.IO;

namespace ZbW.Testing.Dms.Client.Repositories
{
    /// <summary>
    /// File worker, contains all the logic which is needed by <see cref="ZbW.Testing.Dms.Client.ViewModels.DocumentDetailViewModel"/>
    /// </summary>
    internal class FileAgent
    {
        // file & folder metas
        private DateTime _startTime;
        private string _issuer;
        private int _jobId;
        private string _srcDirectory;
        private string _targetDir;
        private string _itemType;
        private string _itemFullName;
        private long _itemLength;
    }
}