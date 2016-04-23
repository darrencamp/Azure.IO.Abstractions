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

    public class AzureFileInfoFactory : IFileInfoFactory
    {
        private readonly CloudStorageAccount _account;
        public AzureFileInfoFactory(CloudStorageAccount account)
        {
            _account = account;
        }

        public FileInfoBase FromFileName(string fileName)
        {
            return new Azure.IO.Abstractions.AzureFileInfoWrapper(fileName, _account);
        }
    }
}
