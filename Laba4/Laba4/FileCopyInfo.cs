using System;

namespace Laba4.Properties
{
    public class FileCopyInfo
    {
        private string FilePath { get; }
        public long Size { get; }
        private DateTime TimeOfCreate { get; }
        
        
        
        public FileCopyInfo(string filePath, long size, DateTime timeOfCreate)
        {
            FilePath = filePath;
            Size = size;
            TimeOfCreate = timeOfCreate;
        }

        
        
    }
}