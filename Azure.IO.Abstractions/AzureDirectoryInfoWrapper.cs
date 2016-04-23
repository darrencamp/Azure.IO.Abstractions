using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Abstractions;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using System.Security.AccessControl;

namespace Azure.IO.Abstractions
{
    public class AzureDirectoryInfoWrapper : DirectoryInfoBase
    {

        private readonly string _directory;
        private readonly CloudStorageAccount _account;

        public override DirectoryInfoBase Parent
        {
            get
            {
                var path = string.Join("/", _directory.Split('/').Skip(1));
                return new Azure.IO.Abstractions.AzureDirectoryInfoFactory(_account).FromDirectoryName(path);
            }
        }

        public override DirectoryInfoBase Root
        {
            get
            {
                return new Azure.IO.Abstractions.AzureDirectoryInfoFactory(_account).FromDirectoryName(_directory.Split('/').First());
            }
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
                throw new NotImplementedException();
            }
        }

        public override string FullName
        {
            get
            {
                return _directory;
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

        public override string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public AzureDirectoryInfoWrapper(CloudStorageAccount account, string directory)
        {
            _account = account;
            _directory = directory;
        }

        public override void Create()
        {
            throw new NotImplementedException();
        }

        public override void Create(DirectorySecurity directorySecurity)
        {
            throw new NotImplementedException();
        }

        public override DirectoryInfoBase CreateSubdirectory(string path)
        {
            throw new NotImplementedException();
        }

        public override DirectoryInfoBase CreateSubdirectory(string path, DirectorySecurity directorySecurity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(bool recursive)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<DirectoryInfoBase> EnumerateDirectories()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<DirectoryInfoBase> EnumerateDirectories(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<DirectoryInfoBase> EnumerateDirectories(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<FileInfoBase> EnumerateFiles()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<FileInfoBase> EnumerateFiles(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<FileInfoBase> EnumerateFiles(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<FileSystemInfoBase> EnumerateFileSystemInfos()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<FileSystemInfoBase> EnumerateFileSystemInfos(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<FileSystemInfoBase> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override DirectorySecurity GetAccessControl()
        {
            throw new NotImplementedException();
        }

        public override DirectorySecurity GetAccessControl(AccessControlSections includeSections)
        {
            throw new NotImplementedException();
        }

        public override DirectoryInfoBase[] GetDirectories()
        {
            throw new NotImplementedException();
        }

        public override DirectoryInfoBase[] GetDirectories(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override DirectoryInfoBase[] GetDirectories(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override FileInfoBase[] GetFiles()
        {
            throw new NotImplementedException();
        }

        public override FileInfoBase[] GetFiles(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override FileInfoBase[] GetFiles(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override FileSystemInfoBase[] GetFileSystemInfos()
        {
            throw new NotImplementedException();
        }

        public override FileSystemInfoBase[] GetFileSystemInfos(string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override FileSystemInfoBase[] GetFileSystemInfos(string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override void MoveTo(string destDirName)
        {
            throw new NotImplementedException();
        }

        public override void SetAccessControl(DirectorySecurity directorySecurity)
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
