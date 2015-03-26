﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class CompanyPlanDetail
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
        private int _carCountInCompany;

        public int CarCountInCompany
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

        public DateTime DepatureTime
        {
            get { return _depatureTime; }
            set { _depatureTime = value; }
        }
        private bool _hasOrder;

        public bool HasOrder
        {
            get { return _hasOrder; }
            set { _hasOrder = value; }
        }
        private string _conditionOfOtherBrands;

        public string ConditionOfOtherBrands
        {
            get { return _conditionOfOtherBrands; }
            set { _conditionOfOtherBrands = value; }
        }
        private string _preparedBy;

        public string PreparedBy
        {
            get { return _preparedBy; }
            set { _preparedBy = value; }
        }
        private string _checkedBy;

        public string CheckedBy
        {
            get { return _checkedBy; }
            set { _checkedBy = value; }
        }
        private string _approvedBy;

        public string ApprovedBy
        {
            get { return _approvedBy; }
            set { _approvedBy = value; }
        }

        private List<int> _ownBrandList;

        public List<int> OwnBrandList
        {
            get { return _ownBrandList; }
            set { _ownBrandList = value; }
        }

        private List<int> _otherBrandList;

        public List<int> OtherBrandList
        {
            get { return _otherBrandList; }
            set { _otherBrandList = value; }
        }

        private DateTime _arrivedDate;

        public DateTime ArrivedDate
        {
            get { return _arrivedDate; }
            set { _arrivedDate = value; }
        }

        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private bool hasService;

        public bool HasService
        {
            get { return hasService; }
            set { hasService = value; }
        }

        private DateTime _servicedDate;

        public DateTime ServicedDate
        {
            get { return _servicedDate; }
            set { _servicedDate = value; }
        }
    }
}