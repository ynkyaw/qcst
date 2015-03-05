/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/03/21 (yyyy/mm/dd)
 * Description: Report Manager Form
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;

namespace PTIC
{
    public partial class frmReportManager : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private string _reportFilePath = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        private DataTable _dataTable = null;

        /// <summary>
        /// 
        /// </summary>
        private PageSettings _pageSetting = null;

        #region Event
        private void frmReportManager_Load(object sender, EventArgs e)
        {
            //// Make reporting process and render by local engine
            //reportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //// Set report file path as embedded resource path
            //reportViewer.LocalReport.ReportEmbeddedResource = _reportFilePath;
            //// Set page setting if present
            //if(_pageSetting != null)
            //    this.reportViewer.SetPageSettings(_pageSetting);
            
            //// Clear report datasource
            //this.reportViewer.LocalReport.DataSources.Clear();
            //// Add datasource
            //ReportDataSource rpDatasource = new ReportDataSource(_dataTable.TableName, _dataTable);
            //this.reportViewer.LocalReport.DataSources.Add(rpDatasource);
            //// Make report viewer process and render
            //this.reportViewer.RefreshReport();
        }
        #endregion

        #region Constructor
        private frmReportManager()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construct a report with the supply of a report file and values
        /// </summary>
        /// <param name="reportFilePath">Embedded-resource report fie path.</param>
        /// <param name="dataTable">Datasource.</param>
        public frmReportManager(string reportFilePath, DataTable dataTable) : this()
        {
            this._reportFilePath = reportFilePath;
            this._dataTable = dataTable;
        }

        /// <summary>
        /// Construct a report with the supply of a report file, values and page setting
        /// </summary>
        /// <param name="reportFilePath">Embedded-resource report fie path.</param>
        /// <param name="dataTable">Datasource.</param>
        /// <param name="pageSetting">Page setting</param>
        public frmReportManager(string reportFilePath, DataTable dataTable, PageSettings pageSetting)
            : this()
        {
            this._reportFilePath = reportFilePath;
            this._dataTable = dataTable;
            this._pageSetting = pageSetting;
        }
        #endregion

        private void reportViewer_Load(object sender, EventArgs e)
        {

        }


        
    }
}
