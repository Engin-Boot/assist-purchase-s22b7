using System.Collections.Generic;

namespace DatabaseContractor
{
    public class FilterModel
    {
        public List<string> DisplayType { get; set; }
        public IntLimits DisplaySize { get; set; }
        public DoubleLimits Weight { get; set; }
        public bool TouchScreen { get; set; }

        public class IntLimits
        {
            public int Max { get; set; }
            public int Min { get; set; }
        }

        public class DoubleLimits
        {
            public double Max { get; set; }
            public double Min { get; set; }
        }
    }
}
