using System;
namespace WC.Model
{
    public class FileSystemItem
    {
        private string _Name;
        private string _FullName;
        private DateTime _CreationDate;
        private DateTime _LastAccessDate;
        private DateTime _LastWriteDate;
        private bool _IsFolder;
        private long _Size;
        private long _FileCount;
        private long _SubFolderCount;
        private string _Version;
        private string _WebName;
        public string WebName
        {
            get
            {
                return this._WebName;
            }
            set
            {
                this._WebName = value;
            }
        }
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }
        public string FullName
        {
            get
            {
                return this._FullName;
            }
            set
            {
                this._FullName = value;
            }
        }
        public DateTime CreationDate
        {
            get
            {
                return this._CreationDate;
            }
            set
            {
                this._CreationDate = value;
            }
        }
        public bool IsFolder
        {
            get
            {
                return this._IsFolder;
            }
            set
            {
                this._IsFolder = value;
            }
        }
        public long Size
        {
            get
            {
                return this._Size;
            }
            set
            {
                this._Size = value;
            }
        }
        public DateTime LastAccessDate
        {
            get
            {
                return this._LastAccessDate;
            }
            set
            {
                this._LastAccessDate = value;
            }
        }
        public DateTime LastWriteDate
        {
            get
            {
                return this._LastWriteDate;
            }
            set
            {
                this._LastWriteDate = value;
            }
        }
        public long FileCount
        {
            get
            {
                return this._FileCount;
            }
            set
            {
                this._FileCount = value;
            }
        }
        public long SubFolderCount
        {
            get
            {
                return this._SubFolderCount;
            }
            set
            {
                this._SubFolderCount = value;
            }
        }
        public string Version()
        {
            if (this._Version == null)
            {
                this._Version = base.GetType().Assembly.GetName().Version.ToString();
            }
            return this._Version;
        }
    }
}
