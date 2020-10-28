
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DatabaseContractor
{
    [ExcludeFromCodeCoverage]
    public class FilterModel
    {
        public List<string> DisplayType { get; set; }
        public Limits DisplaySize { get; set; }
        public Limits Weight { get; set; }
        public bool TouchScreen { get; set; }

        
    }
    [ExcludeFromCodeCoverage]
        public class Limits
        {
            
            public string Max { get; set; }
            public string Min { get; set; }
        }
    

       
    
}