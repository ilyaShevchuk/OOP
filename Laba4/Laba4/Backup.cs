using System;
using System.Collections.Generic;
using Laba4.RestorePoints;

namespace Laba4
{
    public class Backup
    {
        private int Id { get; }
        private DateTime CreateTime { get; }
        public List<IRestorePoint> RestorePoints { get; }
        public List<string> FilesPath { get; }

        public long Size
        {
            get
            {
                long res = 0;
                foreach (var restorePoint in RestorePoints)
                {
                    res += restorePoint.Size;
                }

                return res;
            }
        }
        public Backup(int id, List<string> filesPath, DateTime createTime)
        {
            FilesPath = filesPath;
            CreateTime = createTime;
            Id = id;
            RestorePoints = new List<IRestorePoint>();
        }
        
        public void AddRestorePoint(IRestorePoint restorePoint)
        {
            RestorePoints.Add(restorePoint);
        }

        public void RemoveRestorePoint(IRestorePoint restorePoint)
        {
            RestorePoints.Remove(restorePoint);
        }

        public void AddFilePath(string filePath)
        {
            FilesPath.Add(filePath);
        }

        public void RemoveFilePath(string filePath)
        {
            FilesPath.Remove(filePath);
        }

    }
}