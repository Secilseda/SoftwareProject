using SoftwareProject.Associate.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareProject.Kernel.BaseResponce
{
    public class KernelResponse
    {
        public KernelResponse()
        {
            Messages = new List<string>();
        }

        public KernelResponse(bool isSuccess, string message = null)
        {
            IsSuceess = isSuccess;
            Messages = new List<string>();

            if (string.IsNullOrEmpty(message))
            {
                message = isSuccess ? "İşlem Başarılı" : "İşlem başarısız";
            }

            Messages.Add(message);
        }

        public bool IsSuceess { get; set; }
        public List<string> Messages { get; set; }

        public void SelectValidationMessage(bool errCondition, string field)
        {
            if (errCondition)
            {
                Messages.Add(ProjectConstants.ValidationSelectFormat.FormatWith(field));
            }
        }

        public void SelectCustomValidationMessage(bool errCondition, string msg)
        {
            if (errCondition)
            {
                Messages.Add(msg);
            }
        }
    }
}
