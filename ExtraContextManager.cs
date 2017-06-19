using LuisBot.CommonTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LuisBot.CommonTypes.CommonTypes;

namespace LuisBot
{
    public class ExtraContextManager
    {
        private static ExtraContextManager _instance;

        private Dictionary<string, ActionItem> _intentsLst = new Dictionary<string, ActionItem>();

        private string _currentlyHandledIntent = string.Empty;

        private ActionItem _infoHolder = new ActionItem();

        public Dictionary<string, ActionItem> IntentsLst { get => _intentsLst; set => _intentsLst = value; }

    public string CurrentlyHandledIntent { get => _currentlyHandledIntent; set => _currentlyHandledIntent = value; }

        public ExtraContextManager()
        {
            IntentsLst = LoadIntentsFromDB();

        }

        public static ExtraContextManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExtraContextManager();
                }

                return _instance;
            }
        }

        public ActionItem InfoHolder { get => _infoHolder; set => _infoHolder = value; }

        private Dictionary<string, ActionItem> LoadIntentsFromDB()
        {
            Dictionary<string, ActionItem> intentsLst = new Dictionary<string, ActionItem>();

            try
            {
                intentsLst.Add("ApproveCourseEnrollment", new ActionItem()
                {
                    //  ActionItemMask = ActionItemMask.None,
                    ActionToTake = ActionToTake.Approve,//"ApproveCourseEnrollment",
                    MethodName = "ApproveCourseEnrollment",
                    ParametersList = new List<ActionParameters>
                                       {
                                     new ActionParameters { ParameterName = "EnrollmentRequestID", ParameterType = "Int"

                                         }
                                  },
                    SystemName = "CoursesEnrollmentSystem",
                    WsUrl = "https://somekindOfWebAddress/blabla.asmx" //TODO: Replace with url

                });
                intentsLst.Add("GreetingIntent", new ActionItem());
                intentsLst.Add("Weather", new ActionItem());
                intentsLst.Add("OpenFaultTicket", new ActionItem());
                intentsLst.Add("Help", new ActionItem());
                intentsLst.Add("None", new ActionItem());
                intentsLst.Add("EnquireCourses", new ActionItem()
                {
                    ActionToTake = ActionToTake.Enquire,//"ApproveCourseEnrollment",
                    MethodName = "GetCourseDetailsByID",
                    ParametersList = new List<ActionParameters>
                    {
                        new ActionParameters { ParameterName = "EnrollmentRequestID", ParameterType = "Int"}
                    },
                    SystemName = "CoursesEnrollmentSystem",
                    WsUrl = "https://somekindOfWebAddress/blabla.asmx" //TODO: Replace with url

                });
                //intentsLst.Add("");
                //intentsLst.Add("");
                intentsLst.Add("Todovum", new ActionItem());
            }
            catch (Exception ex)
            {

                System.Diagnostics.Trace.TraceError(ex.Message);
            }
            return intentsLst;
        }
    }
}