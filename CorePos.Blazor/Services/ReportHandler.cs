using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePos.Blazor.Services
{
    public class ReportHandler
    {
        public CorePOSApi.Model.report.ReportResponse report;

        public ReportHandler(CorePOSApi.Model.report.ReportResponse report )
        {
            this.report = report;
        }
        
        public IDictionary<string,string> GetRow(int i)
        {
            IDictionary<string, string> item = new Dictionary<string, string>();
            for (int j= 0;j<report.header.cells.Count();j++)
            {
                item.Add(report.header.cells[j], report.rows[i].cells[j] );
            }
            return item;
        }

        public int Count
        {
            get
            {
                return report.rows.Count;
            }
        }
    }
}
