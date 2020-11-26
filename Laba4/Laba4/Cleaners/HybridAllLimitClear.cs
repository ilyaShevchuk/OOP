using System.Collections.Generic;

namespace Laba4.Cleaners
{
    public class HybridAllLimitClear:ICleaner
    {
        public List<ICleaner> PointClearAlgorithms { get; }

        public HybridAllLimitClear(List<ICleaner> pointClearAlgorithms)
        {
            PointClearAlgorithms = pointClearAlgorithms;
        }

        public override bool IsLimitExceeded(Backup backup)
        {
            foreach (var algorithm in PointClearAlgorithms)
            {
                if (!algorithm.IsLimitExceeded(backup)) return false;
            }

            return true;
        }
    }
}