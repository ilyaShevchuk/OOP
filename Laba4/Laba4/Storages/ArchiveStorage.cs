using System;
using System.Collections.Generic;
using System.IO;
using Laba4.Properties;

namespace Laba4
{
    public class ArchiveStorage : IStorage
    {
        protected override FileCopyInfo CreateFileCopyInfo(string filePath, long size)
        {
            string fileName = System.IO.Path.GetFileName(filePath);
            return new FileCopyInfo("Archive." + fileName, 100, DateTime.Now);
        }

        public override List<FileCopyInfo> Save(List<string> filesPath)
        {
            long archiveSize = 0;
            foreach (var filePath in filesPath)
            {
                archiveSize += CreateFileCopyInfo(filePath, 100).Size;
            }

            return new List<FileCopyInfo>() {CreateFileCopyInfo("BigArch", archiveSize)};
        }
    }
}