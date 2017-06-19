using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace LuisBot.Dialogs
{
    public class CoursesDialog : IDialog<object>
    {
        //public Task StartAsync(IDialogContext context)
        //{

        //}
        public async Task StartAsync(IDialogContext context)
        {
       //     await context.PostAsync($"{ this.name }, what is your age?");
            PromptDialog.Text(context, ResumeAfterConfirmationPrompt, "'האם אתה מעוניין לאשר את בקשת ההשתלמות בשם 'שם כלשהו שחזר מהשירות'? הקלד 'אשר' או 'דחה או 'ביטול פעולה' ' ");
        }

        private async Task ResumeAfterConfirmationPrompt(IDialogContext context, IAwaitable<string> result)
        {
            var userReply = await result;

            //if (userReply != "Which" && userReply != "Reject" && userReply != "Undo")
            //{
            //    PromptDialog.Text(context, ResumeAfterPrompt, "'האם אתה מעוניין לאשר את בקשת ההשתלמות בשם 'שם כלשהו שחזר מהשירות'? הקלד 'אשר' או 'דחה או 'ביטול פעולה' ' ");
            //}

            switch (userReply)
            {
                case "Which": //אשר
                    {

                        //send approval to the web service
                        //ActionItem infoToSend = new ActionItem()
                        //{
                        //    //  ActionItemMask = ActionItemMask.None,
                        //    ActionToTake = ActionToTake.Approve,//"ApproveCourseEnrollment",
                        //    MethodName = "ApproveCourseEnrollment",
                        //    ParametersList = new List<ActionParameters>
                        //               {
                        //             new ActionParameters { ParameterName = "EnrollmentRequestID", ParameterType = "Int",
                        //              ParameterValue = context.ConversationData.GetValue<string>(ContextConstants.CN_EnrollmentRequestID)
                        //                 }
                        //          },
                        //    SystemName = "CoursesEnrollmentSystem",
                        //    WsUrl = "https://somekindOfWebAddress/blabla.asmx" //TODO: Replace with url

                        //};

                        //send to the web service
                        await context.PostAsync($"פעולת האישור נשלחה ותטופל.");
                    }
                    break;

                case "Reject"://דחה
                    await context.PostAsync($"פעולת הדחייה נשלחה ותטופל.");
                    break;

                case "Undo"://ביטול פעולה
                    await context.PostAsync($"הבקשה בוטלה.");
                    break;
                default:
                    break;
            }
            context.Done("Ok");

        }
    }
}