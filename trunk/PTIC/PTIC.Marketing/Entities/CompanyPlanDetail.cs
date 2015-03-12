using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    class CompanyPlanDetail
    {
        private int _companyPlanDetailId;

        public int CompanyPlanDetailId
        {
            get { return _companyPlanDetailId; }
            set { _companyPlanDetailId = value; }
        }

        private int _companyPlanId;

        public int CompanyPlanId
        {
            get { return _companyPlanId; }
            set { _companyPlanId = value; }
        }
        private string _carCountInCompany;

        public string CarCountInCompany
        {
            get { return _carCountInCompany; }
            set { _carCountInCompany = value; }
        }

        private string _toyoComment;

        public string ToyoComment
        {
            get { return _toyoComment; }
            set { _toyoComment = value; }
        }

        private string _mainTopic;

        public string MainTopic
        {
            get { return _mainTopic; }
            set { _mainTopic = value; }
        }

        private int _targetedEmpId;

        public int TargetedEmpId
        {
            get { return _targetedEmpId; }
            set { _targetedEmpId = value; }
        }
        private DateTime _arrivedTime;

        public DateTime ArrivedTime
        {
            get { return _arrivedTime; }
            set { _arrivedTime = value; }
        }
        private DateTime _depatureTime;
        private bool _hasOrder;
        private string _conditionOfOtherBrands;
        private string _preparedBy;
        private string _checkedBy;
        private string _approvedBy;
        

        


    }
}
