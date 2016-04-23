using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Abstractions;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using System.Security.AccessControl;

namespace Azure.IO.Abstractions
{

    public class AzureDirectoryInfoFactory : IDirectoryInfoFactory
    {
        private readonly CloudStorageAccount _account;
        public AzureDirectoryInfoFactory(CloudStorageAccount account)
        {
            _account = account;
        }

        public DirectoryInfoBase FromDirectoryName(string directoryName)
        {
            return new Azure.IO.Abstractions.AzureDirectoryInfoWrapper(_account, directoryName);
        }
    }
}
