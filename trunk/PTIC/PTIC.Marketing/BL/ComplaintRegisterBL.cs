using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using PTIC.Marketing.DA;
using System.Data;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Marketing.BL
{
    public class ComplaintRegisterBL : BaseBusinessLogic
    {
        #region SELECT
        public DataTable GetComplaintExplanationByComplaintRegisterID(int ComplaintRegisterID)
        {
            return ComplaintRegisterDA.SelectComplaintExplanationandActionByComplaintRegisterID(ComplaintRegisterID);
        }

        public DataTable GetComplaintCommentByComplaintRegisterID(int ComplaintRegisterID)
        {
            return ComplaintRegisterDA.SelectComplaintCommentByComplaintRegisterID(ComplaintRegisterID);
        }

         public DataTable GetSComplaintRegisteByReceiveDate(int ReceiveMonth,int ReceiveYear)
        {
            return ComplaintRegisterDA.SelectComplaintRegisteByReceiveDate(ReceiveMonth, ReceiveYear);
        }
        #endregion

        #region INSERT
        public int? AddComplaintRegister(
            ComplaintRegister newComplaintRegister, 
            List<ComplaintExplanation> newComplaintExplanations, 
            List<ComplaintComment> newComplaintComments)
        {            
            /*** Validation ***/
            if (newComplaintRegister != null)
            {
                // Validate ComplaintRegister
                Validator<ComplaintRegister> comRegisterValidator = ValidationManager.CreateValidator<ComplaintRegister>();
                ValidationResults vResults = comRegisterValidator.Validate(newComplaintRegister);
                base.ValidationResults = vResults;
                if (!vResults.IsValid)
                    return null;

                // Validate ComplaintExplanation
                if (newComplaintExplanations != null && newComplaintExplanations.Count > 0)
                {
                    Validator<ComplaintExplanation> explanationValidator = ValidationManager.CreateValidator<ComplaintExplanation>();
                    foreach (ComplaintExplanation explanation in newComplaintExplanations)
                    {
                        ValidationResults pResults = explanationValidator.Validate(explanation);
                        base.ValidationResults = pResults;
                        if (!pResults.IsValid)
                            return null;
                    }
                }

                // Validate ComplaintComment
                if (newComplaintComments != null && newComplaintComments.Count > 0)
                {
                    Validator<ComplaintComment> commentValidator = ValidationManager.CreateValidator<ComplaintComment>();
                    foreach (ComplaintComment comment in newComplaintComments)
                    {
                        ValidationResults pResults = commentValidator.Validate(comment);
                        base.ValidationResults = pResults;
                        if (!pResults.IsValid)
                            return null;
                    }
                }
            }
            else // if there is no parent field
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Some of fields are missing! \nPlease fill data correctly and try again.",
                        null, "ComplaintRegisterBL", null, null));
                return null;
            }
            
            // Save to database
            return ComplaintRegisterDA.InsertComplaintRegister(newComplaintRegister, newComplaintExplanations, newComplaintComments);
        }
        #endregion
    }
}
