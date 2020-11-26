using System.Collections.Generic;
using System.IO;
using Laba4.Properties;

namespace Laba4
{
    public abstract class IStorage
    {
        protected abstract FileCopyInfo CreateFileCopyInfo(string filePath, long size);

        public abstract List<FileCopyInfo> Save(List<string> filesPath);
    }
}