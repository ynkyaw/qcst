using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class CompanyPlan
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string _companyPlan;

        private DateTime? _targetedDate;

        public DateTime? TargetedDate
        {
            get { return _targetedDate; }
            set { _targetedDate = value; }
        }


        public string CompanyPanNo
        {
            get { return _companyPlan; }
            set { _companyPlan = value; }
        }
        private int _townshipID;

        public int TownshipID
        {
            get { return _townshipID; }
            set { _townshipID = value; }
        }
        private int _customerID;

        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }
        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private bool _isConfirmed;

        public bool IsConfirmed
        {
            get { return _isConfirmed; }
            set { _isConfirmed = value; }
        }
        private DateTime _createdDate;

        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private DateTime _lastModifiedDate;

        public DateTime LastModifiedDate
        {
            get { return _lastModifiedDate; }
            set { _lastModifiedDate = value; }
        }
        private bool _isDeleted;

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }





        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        




    }
}
