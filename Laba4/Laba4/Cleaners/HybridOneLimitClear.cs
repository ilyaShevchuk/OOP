using System.Collections.Generic;

namespace Laba4.Cleaners
{
    public class HybridOneLimitClear:ICleaner
    {
        public List<ICleaner> PointClearAlgorithms { get; }

        public HybridOneLimitClear(List<ICleaner> pointClearAlgorithms)
        {
            PointClearAlgorithms = pointClearAlgorithms;
        }


        public override bool IsLimitExceeded(Backup backup)
        {
            foreach (var algorithm in PointClearAlgorithms)
            {
                if (algorithm.IsLimitExceeded(backup)) return true;
            }

            return false;
        }
    }
}