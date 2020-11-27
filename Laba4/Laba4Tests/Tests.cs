using System;
using System.Collections.Generic;
using Laba4;
using Laba4.Cleaners;
using NUnit.Framework;

namespace TestLab4
{
    public class Tests
    {
        [Test]
        public void TestCase1()
        {
            List<string> filesPath = new List<string>() {"/path/file", "/path/file2"};
            Backup backup = new Backup(2345, filesPath, DateTime.Now);
            FolderStorageAlgo storage = new FolderStorageAlgo();
            var copies = storage.Save(backup.FilesPath);
            FullRestoreCreationPoint pointCreation = new FullRestoreCreationPoint();
            var point = pointCreation.Create(copies);
            backup.AddRestorePoint(point);
            CountLimitClear cleaner = new CountLimitClear(1);
            cleaner.Clear(backup);
            Assert.AreEqual(1, backup.RestorePoints.Count);
        }

        [Test]
        public void TestCase2()
        {
            List<string> filesPath = new List<string>() {"/path/file1", "/path/file2", "/path/file3"};
            Backup backup = new Backup(2345, filesPath, DateTime.Now);
            FolderStorageAlgo storage = new FolderStorageAlgo();
            var copies1 = storage.Save(backup.FilesPath);
            FullRestoreCreationPoint pointCreation1 = new FullRestoreCreationPoint();
            var point1 = pointCreation1.Create(copies1);
            backup.AddRestorePoint(point1);

            var copies2 = storage.Save(backup.FilesPath);
            FullRestoreCreationPoint pointCreation2 = new FullRestoreCreationPoint();
            var point2 = pointCreation2.Create(copies2);
            backup.AddRestorePoint(point2);


            List<ICleaner> cleaners = new List<ICleaner>()
                {new CountLimitClear(1), new SizeLimitClear(400)};

            HybridAllLimitClear cleaner = new HybridAllLimitClear(cleaners);
            cleaner.Clear(backup);
            Assert.AreEqual(300, backup.Size);
        }
    }
}