using System.Collections.Generic;
using Laba4.Properties;
using Laba4.RestorePoints;

namespace Laba4
{
    public abstract class ICreationPoint
    {
        public abstract IRestorePoint Create(List<FileCopyInfo> fileCopyInfos);
    }
}