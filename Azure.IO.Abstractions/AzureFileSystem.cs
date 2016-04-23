using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Abstractions;
using Microsoft.WindowsAzure.Storage;

namespace Azure.IO.Abstractions
{
    public class AzureFileSystem : IFileSystem
    {
        private readonly CloudStorageAccount _account;

        public AzureFileSystem(string connectionString)
        {
            _account = CloudStorageAccount.Parse(connectionString);
        }

        Azure.IO.Abstractions.AzureDirectoryBase directory;
        public DirectoryBase Directory
        {
            get { return directory ?? (directory = new Azure.IO.Abstractions.AzureDirectoryBase(_account)); }
        }

        Azure.IO.Abstractions.AzureDirectoryInfoFactory directoryInfoFactory;
        public IDirectoryInfoFactory DirectoryInfo
        {
            get { return directoryInfoFactory ?? (directoryInfoFactory = new Azure.IO.Abstractions.AzureDirectoryInfoFactory(_account)); }
        }

        public IDriveInfoFactory DriveInfo
        {
            get { throw new NotImplementedException(); }
        }

        Azure.IO.Abstractions.AzureFileBase file;
        public FileBase File
        {
            get { return file ?? (file = new Azure.IO.Abstractions.AzureFileBase(_account)); }
        }

        Azure.IO.Abstractions.AzureFileInfoFactory fileInfoFactory;
        public IFileInfoFactory FileInfo
        {
            get { return fileInfoFactory ?? (fileInfoFactory = new Azure.IO.Abstractions.AzureFileInfoFactory(_account)); }
        }

        Azure.IO.Abstractions.AzurePathBase path;
        public PathBase Path
        {
            get { return path ?? (path = new Azure.IO.Abstractions.AzurePathBase(_account)); }
        }
    }
}
