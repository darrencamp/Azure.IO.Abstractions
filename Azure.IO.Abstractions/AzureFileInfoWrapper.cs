using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Abstractions;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Security.AccessControl;

namespace Azure.IO.Abstractions
{
    public class AzureFileInfoWrapper : FileInfoBase
    {

        private readonly CloudStorageAccount _account;
        private readonly string _path;
        private readonly string _absolutePath;
        private CloudBlobContainer _container;
        private CloudBlockBlob _blob;

        public AzureFileInfoWrapper(string path, CloudStorageAccount account)
        {
            _absolutePath = path;
            _path = path;
            _account = account;
            _container = _account.EnsurePathIsRelativeAndEnsureContainer(ref _path);
            _blob = _container.GetBlockBlobReference(_path);
            _blob.FetchAttributes();
        }

        public override FileAttributes Attributes
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override DateTime CreationTime
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override DateTime CreationTimeUtc
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override DirectoryInfoBase Directory
        {
            get { return new Azure.IO.Abstractions.AzureDirectoryInfoFactory(_account).FromDirectoryName(_absolutePath); }
        }

        public override string DirectoryName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool Exists
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Extension
        {
            get
            {
                var extensionIndex = Name.IndexOf('.');
                return extensionIndex > -1 ? Name.Substring(extensionIndex, Name.Length - extensionIndex) : string.Empty;
            }
        }

        public override string FullName
        {
            get
            {
                return _path;
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override DateTime LastAccessTime
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override DateTime LastAccessTimeUtc
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override DateTime LastWriteTime
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override DateTime LastWriteTimeUtc
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override long Length
        {
            get
            {
                return _blob.Properties.Length;
            }
        }

        public override string Name
        {
            get { return _path.Split('/').Last(); }
        }

        public override StreamWriter AppendText()
        {
            throw new NotImplementedException();
        }

        public override FileInfoBase CopyTo(string destFileName)
        {
            throw new NotImplementedException();
        }

        public override FileInfoBase CopyTo(string destFileName, bool overwrite)
        {
            throw new NotImplementedException();
        }

        public override Stream Create()
        {
            throw new NotImplementedException();
        }

        public override StreamWriter CreateText()
        {
            throw new NotImplementedException();
        }

        public override void Decrypt()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Encrypt()
        {
            throw new NotImplementedException();
        }

        public override FileSecurity GetAccessControl()
        {
            throw new NotImplementedException();
        }

        public override FileSecurity GetAccessControl(AccessControlSections includeSections)
        {
            throw new NotImplementedException();
        }

        public override void MoveTo(string destFileName)
        {
            throw new NotImplementedException();
        }

        public override Stream Open(FileMode mode)
        {
            throw new NotImplementedException();
        }

        public override Stream Open(FileMode mode, FileAccess access)
        {
            throw new NotImplementedException();
        }

        public override Stream Open(FileMode mode, FileAccess access, FileShare share)
        {
            throw new NotImplementedException();
        }

        public override Stream OpenRead()
        {
            return _blob.OpenRead();
        }

        public override StreamReader OpenText()
        {
            throw new NotImplementedException();
        }

        public override Stream OpenWrite()
        {
            throw new NotImplementedException();
        }

        public override void Refresh()
        {
            throw new NotImplementedException();
        }

        public override FileInfoBase Replace(string destinationFileName, string destinationBackupFileName)
        {
            throw new NotImplementedException();
        }

        public override FileInfoBase Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors)
        {
            throw new NotImplementedException();
        }

        public override void SetAccessControl(FileSecurity fileSecurity)
        {
            throw new NotImplementedException();
        }
    }
}
