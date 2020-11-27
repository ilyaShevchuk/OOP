using System;
using System.Collections.Generic;
using Laba4.Properties;

namespace Laba4
{
    public class FolderStorageAlgo : IStorage
    {
        protected override FileCopyInfo CreateFileCopyInfo(string filePath, long size)
        {
            string fileName = System.IO.Path.GetFileName(filePath);
            return new FileCopyInfo("Directory:\\" + fileName, size, DateTime.Now);
        }

        public override List<FileCopyInfo> Save(List<string> filesPath)
        {
            List<FileCopyInfo> res = new List<FileCopyInfo>();
            foreach (var path in filesPath)
            {
                res.Add(CreateFileCopyInfo(path, 100));
            }

            return res;
        }
    }
}