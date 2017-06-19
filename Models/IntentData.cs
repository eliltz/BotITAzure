using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuisBot.Models
{
    [Serializable]
    public class SystemActions
    {
        public Guid ID { get; set; }

        public int SystemID { get; set; }

        public double ActionName { get; set; }

        public string URL { get; set; }

        public string Method { get; set; }

        public string ApprovementText { get; set; }

        public string Tags { get; set; }

    }



    [Serializable]
    public class ActionParameters
    {
        public Guid ID { get; set; }

        public int ActionID { get; set; }

        public double ParameterName { get; set; }

        public string ParameterType { get; set; }

        public string ParameterValue { get; set; }
    }
   

 [Serializable]
    public class Systems
    {
        public Guid ID { get; set; }

        public string SystemNeme { get; set; }

        public double ParameterName { get; set; }

        public string ParameterType { get; set; }

        public string ParameterValue { get; set; }
    }
}