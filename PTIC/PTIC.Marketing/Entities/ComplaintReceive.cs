using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Marketing.Entities
{
    public class ComplaintReceive
    {
        #region Properties
        public int ID { get; set; }

        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00", 
                        MessageTemplateResourceName = "ComplaintReceive_ReceivedDate_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public DateTime ReceivedDate { get; set; }

        public string MsgNo { get; set; }
        public int RefDigit { get; set; }
        public string RefNo { get; set; }

        [NotNullValidator(MessageTemplateResourceName = "ComplaintReceive_ReceivedVia_Invalid",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        //[DomainValidator(
        //            (int)PTIC.Common.Enum.ReceivedVia.Phone, (int)PTIC.Common.Enum.ReceivedVia.Mail,
        //            (int)PTIC.Common.Enum.ReceivedVia.People, (int)PTIC.Common.Enum.ReceivedVia.Own,
        [DomainValidator(
                    PTIC.Common.Enum.ReceivedVia.Phone, PTIC.Common.Enum.ReceivedVia.Mail,
                    PTIC.Common.Enum.ReceivedVia.People, PTIC.Common.Enum.ReceivedVia.Own,
                    MessageTemplateResourceName = "ComplaintReceive_ReceivedVia_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public PTIC.Common.Enum.ReceivedVia ReceivedVia { get; set; }

        public string ReceivedViaBy { get; set; }
       
        [NotNullValidator(MessageTemplateResourceName = "ComplaintReceive_Sender_Invalid",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        [StringLengthValidator(1, 200,
            MessageTemplateResourceName = "ComplaintReceive_Sender_Invalid",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public string Sender { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "ComplaintReceive_ReceiverID_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int ReceiverID { get; set; }

        public string ServiceNo { get; set; }
        public string UsageNature { get; set; }
        public string UsedPeriod { get; set; }
        public int? OutletCustomerID { get; set; }
        public string OtherCustomer { get; set; }
        public string UsingHour { get; set; }
        public bool IsChecked { get; set; }
        public string ActionByReseller { get; set; }
        public string ResellerRemark { get; set; }
        public string Remark { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "ComplaintReceive_ReceivedBy_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int ReceivedBy { get; set; }

        public int? RepairedBy { get; set; }
        public int? CheckedBy { get; set; }
        #endregion
    }
}
