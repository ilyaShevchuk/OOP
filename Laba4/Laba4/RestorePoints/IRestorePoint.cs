using System;
using System.Collections.Generic;
using Laba4.Properties;

namespace Laba4.RestorePoints
{
    public abstract class IRestorePoint
    {
        public DateTime CreationTime { get; }
        public List<FileCopyInfo> FileCopyInfos { get; }
        
        public long Size
        {
            get
            {
                long res = 0;
                foreach (var fileCopyInfo in FileCopyInfos)
                {
                    res += fileCopyInfo.Size;
                }

                return res;
            }
        }

        public IRestorePoint(List<FileCopyInfo> fileCopyInfos, DateTime dateTime)
        {
            CreationTime = dateTime;
            FileCopyInfos = fileCopyInfos;
        }

        public void AddFileCopyInfo(FileCopyInfo fileCopyInfo)
        {
            FileCopyInfos.Add(fileCopyInfo);
        }
    }
}