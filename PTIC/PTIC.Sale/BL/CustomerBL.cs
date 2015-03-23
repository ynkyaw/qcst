/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Customer business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace PTIC.Sale.BL
{
    /// <summary>
    /// Customer business logic
    /// </summary>
    public class CustomerBL : BaseBusinessLogic
    {
        /// <summary>
        /// Field validation factory
        /// </summary>
        private ValidatorFactory _validatorFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();

        #region SERACHING        
      
        public DataTable SearchByCustomerName(String CustomerName)
        {
            return CustomerDA.SearchByCustomer(CustomerName);
        }

        public DataTable SearchAllRoute()
        {
            return CustomerDA.SearchAllRoute();
        }
        public DataTable SearchAllTrip()
        {
            return CustomerDA.SearchAllTrip();
        }
        #endregion

        #region SELECT
        /// <summary>
        /// Get all customersType
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCustomerType()
        {
            return CustomerDA.SelectAllCusType();
        }
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns></returns>
        /// 
        public DataTable GetAllCustomer()
        {
            return CustomerDA.SelectAllCustomer();
        }


        public DataTable GetAllCustomerByCustomerType(string custType)
        {
            return CustomerDA.GetAllCustomerByCustomerType(custType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetCusTypeInTownship()
        {
            return CustomerDA.SelectCusTypeInTownship();
        }

        public DataTable GetCusTypeInTown() 
        {
            return CustomerDA.SelectCusTypeInTown();
        }

        /// <summary>
        /// Get all customers from system
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all customers</returns>
        public DataTable GetAll()
        {
            return CustomerDA.SelectAll();
        }        
        
        /// <summary>
        /// Get all customers from system
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all customers</returns>
        public DataTable GetAllByCusID(int CusID)
        {
            return CustomerDA.SelectAllByCusID(CusID);
        }

        public DataTable GetByRoutID(int routeID)
        {
            return CustomerDA.SelectByRoutID(routeID);
        }

        public DataTable GetByTripID(int tripID)
        {
            return CustomerDA.SelectByTripID(tripID);
        }

        /// <summary>
        /// Get photos of a specific customer
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <returns>DataTable containing photos</returns>
        public DataTable GetPhotos(int customerID)
        {
            return CustomerDA.SelectPhotos(customerID);
        }

        public int GetTownByCustomerId(int customerId)
        {
            return CustomerDA.GetTownByCustomerId(customerId);
        }

        #endregion

        #region INSERT
        /// <summary>
        /// Add a new customer into system
        /// </summary>
        /// <param name="newCustomer">New customer entity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return inserted customer ID</returns>
        public int? Add(
            Customer newCustomer, 
            Address newAddress,
            ContactPerson contactPerson,
            Address contactAddress,
            Owner owner,
            Address ownerAddress)
        {
            if (newCustomer == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Customer အချက်အလက် ဖြည့်သွင်းပေးပါရန်။",
                        null, "CustomerBL", null, null));
                return null;
            }
            else if (newAddress == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Customer လိပ်စာ ဖြည့်သွင်းပေးပါရန်။",
                        null, "CustomerBL", null, null));
                return null;
            }

            try
            {
                // clear leading and trailing while spaces
                newCustomer.CusName = newCustomer.CusName.Trim();

                // Customer validation
                Validator<Customer> cusValidator = _validatorFactory.CreateValidator<Customer>();
                ValidationResults vCusResults = cusValidator.Validate(newCustomer);
                base.ValidationResults = vCusResults;
                if (!vCusResults.IsValid)
                    return null;
                // Address validation
                Validator<Address> addrValidator = _validatorFactory.CreateValidator<Address>();
                ValidationResults vAddrResults = addrValidator.Validate(newAddress);
                base.ValidationResults = vAddrResults;
                if (!vAddrResults.IsValid)
                    return null;
                // Save into db
                return CustomerDA.Insert(newCustomer, newAddress, contactPerson, contactAddress, owner, ownerAddress);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "CustomerBL", null, null));
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <param name="newAddress"></param>
        /// <param name="newContactPerson"></param>
        /// <param name="conn"></param>
        /// <returns>A new inserted customer ID</returns>
        public int Add(Customer newCustomer, 
            Address newAddress, 
            ContactPerson newContactPerson)
        {
            return CustomerDA.Insert(newCustomer, newAddress, newContactPerson);
        }
        #endregion
        
        #region UPDATE
        /// <summary>
        /// Update an existing customer in system by customer ID
        /// </summary>
        /// <param name="mdCustomer">Customer to be updated</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int? UpdateByCustomerID(
            Customer mdCustomer,
            Address address,
            Owner owner,
            Address ownerAddress,
            ContactPerson contactPerson,
            Address contactAddress)
        {
            if (mdCustomer == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Customer အချက်အလက် ဖြည့်သွင်းပေးပါရန်။",
                        null, "CustomerBL", null, null));
                return null;
            }
            else if (address == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult("Customer လိပ်စာ ဖြည့်သွင်းပေးပါရန်။",
                        null, "CustomerBL", null, null));
                return null;
            }

            try
            {
                // clear leading and trailing while spaces
                mdCustomer.CusName = mdCustomer.CusName.Trim();

                // Customer validation
                Validator<Customer> cusValidator = _validatorFactory.CreateValidator<Customer>();
                ValidationResults vCusResults = cusValidator.Validate(mdCustomer);
                base.ValidationResults = vCusResults;
                if (!vCusResults.IsValid)
                    return null;
                // Address validation
                Validator<Address> addrValidator = _validatorFactory.CreateValidator<Address>();
                ValidationResults vAddrResults = addrValidator.Validate(address);
                base.ValidationResults = vAddrResults;
                if (!vAddrResults.IsValid)
                    return null;
                // Update data from db
                return CustomerDA.UpdateByCustomerID(mdCustomer, address, owner, ownerAddress, contactPerson, contactAddress);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "CustomerBL", null, null));
                return null;
            }            
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Delete customer from system by customer ID
        /// </summary>
        /// <param name="customerID">Customer ID</param>
        /// <returns>Return affected row count</returns>
        public int DeleteByID(int customerID)
        {
            return CustomerDA.DeleteByCustomerID(customerID);
        }

        /// <summary>
        /// Set NULL to value of a specific field by customer ID
        /// </summary>
        /// <param name="columnName">To column</param>
        /// <param name="customerID">By Customer ID</param>
        /// <returns>Return number of rows affected</returns>
        public int DeletePhotoBy(string columnName, int customerID)
        {
            return CustomerDA.DeletePhotoBy(columnName, customerID);
        }
        #endregion

    }
}
