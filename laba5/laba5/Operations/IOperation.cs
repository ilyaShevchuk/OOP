using System;

namespace laba5.Operations
{
    public abstract class IOperation
    {
        public int Id { get; }

        public DateTime? Date;
        public IOperation(int id)
        {
            Id = id;
        }
        
        public abstract void DoOperation(DateTime operationDate);
        public abstract void DoOperation();
        public abstract void UndoOperation();
    }
}