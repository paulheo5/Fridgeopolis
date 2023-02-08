
using Newtonsoft.Json;

namespace Fridgeopolis.Models
{

    public class Root
    {
        public string name { get; set; }
        public List<Step> steps { get; set; }
    }

    public class Step
    {

        public string step { get; set; }
 
    }

    public class Temperature
    {
        public double number { get; set; }
        public string unit { get; set; }
    }
}

