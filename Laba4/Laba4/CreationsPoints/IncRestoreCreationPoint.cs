using System;
using System.Collections.Generic;
using Laba4.Properties;
using Laba4.RestorePoints;

namespace Laba4
{
    public class IncRestoreCreationPoint:ICreationPoint
    {
        public override IRestorePoint Create(List<FileCopyInfo> fileCopyInfos)
        {
            return new IncRestorePoint(fileCopyInfos, DateTime.Now);
        }
    }
}