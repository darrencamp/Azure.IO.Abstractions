using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.IO.Abstractions;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Security.AccessControl;
using System.Text;

namespace Azure.IO.Abstractions
{
    public class AzureFileBase : FileBase
    {
        private readonly CloudStorageAccount _account;

        public AzureFileBase(CloudStorageAccount account)
        {
            _account = account;
        }

        public override bool Exists(string path)
        {
            var storage = _account.CreateCloudBlobClient();
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);
            return container
                .GetBlockBlobReference(path)
                .Exists();
        }

        public override void AppendAllLines(string path, IEnumerable<string> contents)
        {
            throw new NotImplementedException();
        }

        public override void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        public override void AppendAllText(string path, string contents)
        {
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);
            var blob = container.GetBlockBlobReference(path);

            string oldContent;
            if (!blob.Exists())
            {
                oldContent = "";
            }
            else
            {
                using (var reader = new StreamReader(blob.OpenRead()))
                {
                    oldContent = reader.ReadToEnd();
                }
            }

            using (var writer = new StreamWriter(blob.OpenWrite()))
            {
                writer.Write(oldContent);
                writer.Write(contents);
            }
        }

        public override void AppendAllText(string path, string contents, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        public override StreamWriter AppendText(string path)
        {
            throw new NotImplementedException();
        }

        public override void Copy(string sourceFileName, string destFileName)
        {
            var sourceContainer = _account.EnsurePathIsRelativeAndEnsureContainer(ref sourceFileName);
            var destContainer = _account.EnsurePathIsRelativeAndEnsureContainer(ref destFileName);

            sourceContainer.EnsureBlobExists(sourceFileName);
            destContainer.EnsureBlobDoesNotExist(destFileName);

            var blob = sourceContainer.GetBlockBlobReference(sourceFileName);
            var newBlob = destContainer.GetBlockBlobReference(destFileName);
            newBlob.StartCopy(blob);
        }

        public override void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            throw new NotImplementedException();
        }

        public override Stream Create(string path)
        {
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);
            var blob = container.GetBlockBlobReference(path);
            if (blob.Exists())
                throw new InvalidOperationException("file " + path + " already exists");

            blob.UploadFromByteArray(new byte[] { }, 0, 0);
            return blob.OpenWrite();
        }

        public override Stream Create(string path, int bufferSize)
        {
            throw new NotImplementedException();
        }

        public override Stream Create(string path, int bufferSize, FileOptions options)
        {
            throw new NotImplementedException();
        }

        public override Stream Create(string path, int bufferSize, FileOptions options, FileSecurity fileSecurity)
        {
            throw new NotImplementedException();
        }

        public override StreamWriter CreateText(string path)
        {
            throw new NotImplementedException();
        }

        public override void Decrypt(string path)
        {
            //throw new NotImplementedException();
        }

        public override void Delete(string path)
        {
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);

            var blob = container.GetBlockBlobReference(path);
            if (blob.Exists())
            {
                blob.Delete();
            }
        }

        public override void Encrypt(string path)
        {
            //throw new NotImplementedException();
        }

        public override FileSecurity GetAccessControl(string path)
        {
            throw new NotImplementedException();
        }

        public override FileSecurity GetAccessControl(string path, AccessControlSections includeSections)
        {
            throw new NotImplementedException();
        }

        public override FileAttributes GetAttributes(string path)
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

        public override void Move(string sourceFileName, string destFileName)
        {
            throw new NotImplementedException();
        }

        public override Stream Open(string path, FileMode mode)
        {
            throw new NotImplementedException();
        }

        public override Stream Open(string path, FileMode mode, FileAccess access)
        {
            throw new NotImplementedException();
        }

        public override Stream Open(string path, FileMode mode, FileAccess access, FileShare share)
        {
            throw new NotImplementedException();
        }

        public override Stream OpenRead(string path)
        {
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);

            container.EnsureBlobExists(path);

            var blob = container.GetBlockBlobReference(path);
            blob.FetchAttributes();
            var b = new byte[blob.Properties.Length];
            return blob.OpenRead();
        }

        public override StreamReader OpenText(string path)
        {
            throw new NotImplementedException();
        }

        public override Stream OpenWrite(string path)
        {
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);

            container.EnsureBlobExists(path);

            var blob = container.GetBlockBlobReference(path);
            blob.FetchAttributes();
            return blob.OpenWrite();
        }

        public override byte[] ReadAllBytes(string path)
        {
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);

            container.EnsureBlobExists(path);

            var blob = container.GetBlockBlobReference(path);
            blob.FetchAttributes();
            var b = new byte[blob.Properties.Length];
            blob.DownloadToByteArray(b, 0);

            return b;
        }

        public override string[] ReadAllLines(string path)
        {
            throw new NotImplementedException();
        }

        public override string[] ReadAllLines(string path, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        public override string ReadAllText(string path)
        {
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);

            container.EnsureBlobExists(path);

            var blob = container.GetBlockBlobReference(path);
            blob.FetchAttributes();
            return blob.DownloadText();
        }

        public override string ReadAllText(string path, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> ReadLines(string path)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> ReadLines(string path, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        public override void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName)
        {
            throw new NotImplementedException();
        }

        public override void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors)
        {
            throw new NotImplementedException();
        }

        public override void SetAccessControl(string path, FileSecurity fileSecurity)
        {
            throw new NotImplementedException();
        }

        public override void SetAttributes(string path, FileAttributes fileAttributes)
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

        public override void WriteAllBytes(string path, byte[] bytes)
        {
            var container = _account.EnsurePathIsRelativeAndEnsureContainer(ref path);
            var blob = container.GetBlockBlobReference(path);
            if (blob.Exists())
                throw new InvalidOperationException("file " + path + " already exists");

            blob.UploadFromByteArray(bytes, 0, bytes.Length);
        }

        public override void WriteAllLines(string path, IEnumerable<string> contents)
        {
            throw new NotImplementedException();
        }

        public override void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        public override void WriteAllLines(string path, string[] contents)
        {
            throw new NotImplementedException();
        }

        public override void WriteAllLines(string path, string[] contents, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        public override void WriteAllText(string path, string contents)
        {
            throw new NotImplementedException();
        }

        public override void WriteAllText(string path, string contents, Encoding encoding)
        {
            throw new NotImplementedException();
        }
    }
}
