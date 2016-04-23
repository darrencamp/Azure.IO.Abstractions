using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Abstractions;
using Microsoft.WindowsAzure.Storage;
using System.IO;
using System.Security.AccessControl;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure.IO.Abstractions
{
    public class AzureDirectoryBase : DirectoryBase
    {
        private readonly CloudStorageAccount _account;
        public AzureDirectoryBase(CloudStorageAccount account)
        {
            _account = account;
        }

        public override DirectoryInfoBase CreateDirectory(string path)
        {
            var fullPath = path.Trim('/') + "/";
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref fullPath);
            if (!Exists(fullPath))
            {
                var blob = container.GetBlockBlobReference(fullPath);
                blob.UploadFromByteArray(new byte[0], 0, 0);
            }
            return new DirectoryInfo(fullPath);
        }

        public override DirectoryInfoBase CreateDirectory(string path, DirectorySecurity directorySecurity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string path)
        {
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);

            container.EnsureDirectoryExists(path);
            foreach (var blob in container.GetDirectoryReference(path).ListBlobs())
            {
                if (blob is CloudBlockBlob)
                    ((CloudBlockBlob)blob).Delete();

                //if (blob is CloudBlobDirectory)
                //    Delete(blob.);
            }
        }

        public override void Delete(string path, bool recursive)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> EnumerateDirectories(string path)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> EnumerateDirectories(string path, string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> EnumerateFiles(string path)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> EnumerateFiles(string path, string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> EnumerateFileSystemEntries(string path)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override bool Exists(string path)
        {
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);
            return container.GetDirectoryReference(path).ListBlobs().Count() > 0;
        }

        public override DirectorySecurity GetAccessControl(string path)
        {
            throw new NotImplementedException();
        }

        public override DirectorySecurity GetAccessControl(string path, AccessControlSections includeSections)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetCreationTime(string path)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetCreationTimeUtc(string path)
        {
            throw new NotImplementedException();
        }

        public override string GetCurrentDirectory()
        {
            throw new NotImplementedException();
        }

        public override string[] GetDirectories(string path)
        {
            throw new NotImplementedException();
        }

        public override string[] GetDirectories(string path, string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override string GetDirectoryRoot(string path)
        {
            throw new NotImplementedException();
        }

        public override string[] GetFiles(string path)
        {
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);
            return container.GetDirectoryReference(path).ListBlobs().Select(x => string.Format("{0}/{1}", path, x.Uri.ToString().Split('/').Last())).ToArray();
        }

        public override string[] GetFiles(string path, string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            throw new NotImplementedException();
        }

        public override string[] GetFileSystemEntries(string path)
        {
            throw new NotImplementedException();
        }

        public override string[] GetFileSystemEntries(string path, string searchPattern)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetLastAccessTime(string path)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetLastAccessTimeUtc(string path)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetLastWriteTime(string path)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetLastWriteTimeUtc(string path)
        {
            throw new NotImplementedException();
        }

        public override string[] GetLogicalDrives()
        {
            throw new NotImplementedException();
        }

        public override DirectoryInfoBase GetParent(string path)
        {
            throw new NotImplementedException();
        }

        public override void Move(string sourceDirName, string destDirName)
        {
            throw new NotImplementedException();
        }

        public override void SetAccessControl(string path, DirectorySecurity directorySecurity)
        {
            throw new NotImplementedException();
        }

        public override void SetCreationTime(string path, DateTime creationTime)
        {
            throw new NotImplementedException();
        }

        public override void SetCreationTimeUtc(string path, DateTime creationTimeUtc)
        {
            throw new NotImplementedException();
        }

        public override void SetCurrentDirectory(string path)
        {
            throw new NotImplementedException();
        }

        public override void SetLastAccessTime(string path, DateTime lastAccessTime)
        {
            throw new NotImplementedException();
        }

        public override void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc)
        {
            throw new NotImplementedException();
        }

        public override void SetLastWriteTime(string path, DateTime lastWriteTime)
        {
            throw new NotImplementedException();
        }

        public override void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
        {
            throw new NotImplementedException();
        }
    }
}
