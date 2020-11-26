using System;
using System.Collections.Generic;
using Laba4.Properties;

namespace Laba4.RestorePoints
{
    public class IncRestorePoint:IRestorePoint
    {
        public IncRestorePoint(List<FileCopyInfo> fileCopyInfos, DateTime dateTime) : base(fileCopyInfos, dateTime)
        {
        }
    }
}