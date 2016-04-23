using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace Azure.IO.Abstractions
{
    public static class AzureCloudStorageExtensions
    {
        public static bool BlobExists(this CloudBlobContainer container, string path)
        {
            if (String.IsNullOrEmpty(path) || path.Trim() == String.Empty)
                throw new ArgumentException("Path can't be empty");

            return container.GetBlockBlobReference(path.Replace("\\", "/")).Exists();
        }

        public static void EnsureBlobExists(this CloudBlobContainer container, string path)
        {
            if (!BlobExists(container, path))
            {
                throw new ArgumentException("File " + path + " does not exist");
            }
        }

        public static void EnsureBlobDoesNotExist(this CloudBlobContainer container, string path)
        {
            if (BlobExists(container, path))
            {
                throw new ArgumentException("File " + path + " already exists");
            }
        }

        public static bool DirectoryExists(this CloudBlobContainer container, string path)
        {
            if (String.IsNullOrEmpty(path) || path.Trim() == String.Empty)
                throw new ArgumentException("Path can't be empty");

            return container.GetDirectoryReference(path).ListBlobs().Count() > 0;
        }

        public static void EnsureDirectoryExists(this CloudBlobContainer container, string path)
        {
            if (!DirectoryExists(container, path))
            {
                throw new ArgumentException("Directory " + path + " does not exist");
            }
        }

        public static void EnsureDirectoryDoesNotExist(this CloudBlobContainer container, string path)
        {
            if (DirectoryExists(container, path))
            {
                throw new ArgumentException("Directory " + path + " already exists");
            }
        }

        public static CloudBlobContainer EnsurePathIsRelativeAndEnsureContainer(this CloudStorageAccount account, ref string path)
        {
            var containerName = path.Split('/').First();

            if (path.StartsWith("/") || path.StartsWith("http://") || path.StartsWith("https://"))
                throw new ArgumentException("Path must be relative");

            path = string.Join("/", path.Split('/').Skip(1));

            var container = account.CreateCloudBlobClient().GetContainerReference(containerName);
            container.CreateIfNotExists();
            return container;
        }
    }
}
