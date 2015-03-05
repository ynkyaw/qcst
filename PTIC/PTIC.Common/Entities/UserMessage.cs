using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Common.Entities
{
    [HasSelfValidation]
    public class UserMessage
    {
        #region Porperties
        public int ID { get; set; }
        public string MsgNoPrefix { get; set; }
        public int MsgNoInt { get; set; }
        public string MsgNo { get; set; }        
        public int MessageID { get; set; }
        public int MessageThreadID { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "UserMessage_SenderID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Common.ErrorMessages))]
        public int? SenderID { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "UserMessage_ReceiverID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Common.ErrorMessages))]
        public int? ReceiverID { get; set; }

        [ValidatorComposition(
            CompositionType.Or,
            MessageTemplateResourceName = "UserMessage_Sender_Require",
            MessageTemplateResourceType = typeof(PTIC.Common.ErrorMessages))]
        [NotNullValidator(Negated = true)]
        [StringLengthValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
            MessageTemplateResourceName = "UserMessage_Sender_Require",
            MessageTemplateResourceType = typeof(PTIC.Common.ErrorMessages))]
        public string Sender { get; set; }

        [ValidatorComposition(
            CompositionType.Or,
            MessageTemplateResourceName = "UserMessage_Receiver_Require",
            MessageTemplateResourceType = typeof(PTIC.Common.ErrorMessages))]
        [NotNullValidator(Negated = true)]
        [StringLengthValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
            MessageTemplateResourceName = "UserMessage_Receiver_Require",
                    MessageTemplateResourceType = typeof(PTIC.Common.ErrorMessages))]
        public string Receiver { get; set; }

        [RangeValidator(0, RangeBoundaryType.Inclusive, 3, RangeBoundaryType.Inclusive,
                    MessageTemplateResourceName = "UserMessage_MessageBox_Require",
                    MessageTemplateResourceType = typeof(PTIC.Common.ErrorMessages))]
        public int MessageBox { get; set; } // Draft = 0, Inbox = 1, Sentbox = 2, Trash = 3

        public int MsgSenderReceiverID { get; set; } // ?
        public bool IsRead { get; set; }

        [RangeValidator(0, RangeBoundaryType.Inclusive, 2, RangeBoundaryType.Inclusive,
                    MessageTemplateResourceName = "UserMessage_Status_Require",
                    MessageTemplateResourceType = typeof(PTIC.Common.ErrorMessages))]
        public int Status { get; set; } // Pending = 0, Confirmed = 1, Rejected = 2

        [RangeValidator(0, RangeBoundaryType.Inclusive, 2, RangeBoundaryType.Inclusive,
                    MessageTemplateResourceName = "UserMessage_SenderAction_Require",
                    MessageTemplateResourceType = typeof(PTIC.Common.ErrorMessages))]
        public int SenderAction { get; set; } // Send = 0, Reply = 1, Forward = 2

        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        [SelfValidation]
        public void Check(ValidationResults results)
        {
            if (!string.IsNullOrEmpty(Sender) && Sender.Length > 0 && SenderID.HasValue)
                results.AddResult(new ValidationResult("More senders!", this, "", "", null));
            else if (!string.IsNullOrEmpty(Receiver) && Receiver.Length > 0 && ReceiverID.HasValue)
                results.AddResult(new ValidationResult("More receivers!", this, "", "", null));
        }

    }
}
