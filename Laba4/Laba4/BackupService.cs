using Laba4.Cleaners;
using Laba4.Exceptions;

namespace Laba4
{
    public class BackupService
    {
        public void Manage(Backup backup, ICleaner cleaner,
            IStorage storage, ICreationPoint pointCreation)
        {
            var filesCopyInfo = storage.Save(backup.FilesPath);
            if (pointCreation is IncRestoreCreationPoint && backup.RestorePoints.Count == 0)
            {
                throw new UnavaliableIncPointCreation("No parent point");
            } 
            var restorePoint = pointCreation.Create(filesCopyInfo);
            backup.AddRestorePoint(restorePoint);
            cleaner.Clear(backup);
        }
    }
}