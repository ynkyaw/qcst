﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProvenCashCollectionUpdater.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ProvenCashCollectionUpdater.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT TOP 1 ID,BALANCE_AMT
        ///FROM(
        ///SELECT I.ID,SUM(I2.BalanceAmt) AS BALANCE_AMT
        ///FROM Invoice I INNER JOIN Invoice I2
        ///ON I.CusID=I2.CusID
        ///AND I.Paid=I2.Paid
        ///AND I.SaleType=I2.SaleType
        ///AND I.ID &lt;= I2.ID
        ///WHERE I.CusID= {0}
        ///AND I.SaleType=0
        ///AND I.Paid=0
        ///GROUP BY I.ID
        ///HAVING SUM(I2.BalanceAmt)&gt; {1}
        ///) AS BAL
        ///ORDER BY ID DESC.
        /// </summary>
        internal static string InvoiceSelectQuery {
            get {
                return ResourceManager.GetString("InvoiceSelectQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE Invoice
        ///SET Paid=1,LastModified=GETDATE()
        ///WHERE ID &lt; {0}.
        /// </summary>
        internal static string UpdatePreviousInvoice {
            get {
                return ResourceManager.GetString("UpdatePreviousInvoice", resourceCulture);
            }
        }
    }
}
