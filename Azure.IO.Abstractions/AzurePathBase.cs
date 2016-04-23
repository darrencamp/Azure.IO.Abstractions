using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.Abstractions;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace Azure.IO.Abstractions
{

    public class AzurePathBase : PathBase
    {
        private readonly CloudStorageAccount _account;
        private readonly string _tempPath;
        public AzurePathBase(CloudStorageAccount account)
        {
            _account = account;
            _tempPath = "temp/";
        }

        public AzurePathBase(CloudStorageAccount account, string tempPath)
            : this(account)
        {
            _tempPath = tempPath;
        }

        public override char AltDirectorySeparatorChar
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override char DirectorySeparatorChar
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override char[] InvalidPathChars
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override char PathSeparator
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override char VolumeSeparatorChar
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ChangeExtension(string path, string extension)
        {
            throw new NotImplementedException();
        }

        public override string Combine(params string[] paths)
        {
            throw new NotImplementedException();
        }

        public override string Combine(string path1, string path2)
        {
            if (path1 == null)
            {
                throw new ArgumentNullException("path1");
            }

            if (path2 == null)
            {
                throw new ArgumentNullException("path2");
            }

            if (String.IsNullOrEmpty(path2))
            {
                return path1;
            }

            if (String.IsNullOrEmpty(path1))
            {
                return path2;
            }

            if (path2.StartsWith("http://") || path2.StartsWith("https://"))
            {
                return path2;
            }

            var ch = path1[path1.Length - 1];

            if (ch != '/')
            {
                return (path1.TrimEnd('/') + '/' + path2.TrimStart('/'));
            }

            return (path1 + path2);
        }

        public override string Combine(string path1, string path2, string path3)
        {
            throw new NotImplementedException();
        }

        public override string Combine(string path1, string path2, string path3, string path4)
        {
            throw new NotImplementedException();
        }

        public override string GetDirectoryName(string path)
        {
            throw new NotImplementedException();
        }

        public override string GetExtension(string path)
        {
            var fileNameWithExtension = path.Split('/').Last();
            var dotPosition = fileNameWithExtension.IndexOf('.');
            return dotPosition > -1 ? fileNameWithExtension.Substring(dotPosition, fileNameWithExtension.Length - dotPosition) : string.Empty;
        }

        public override string GetFileName(string path)
        {
            return path.Split('/').Last();
        }

        public override string GetFileNameWithoutExtension(string path)
        {
            var fileNameWithExtension = path.Split('/').Last();
            var dotposition = fileNameWithExtension.IndexOf('.');
            return dotposition > -1 ? fileNameWithExtension.Substring(0, dotposition) : fileNameWithExtension;
        }

        public override string GetFullPath(string path)
        {
            throw new NotImplementedException();
        }

        public override char[] GetInvalidFileNameChars()
        {
            throw new NotImplementedException();
        }

        public override char[] GetInvalidPathChars()
        {
            throw new NotImplementedException();
        }

        public override string GetPathRoot(string path)
        {
            throw new NotImplementedException();
        }

        public override string GetRandomFileName()
        {
            throw new NotImplementedException();
        }

        public override string GetTempFileName()
        {
            return string.Format("{0}/{1}", GetTempPath(), Guid.NewGuid());
        }

        public override string GetTempPath()
        {
            return _tempPath;
        }

        public override bool HasExtension(string path)
        {
            throw new NotImplementedException();
        }

        public override bool IsPathRooted(string path)
        {
            throw new NotImplementedException();
        }
    }
}
