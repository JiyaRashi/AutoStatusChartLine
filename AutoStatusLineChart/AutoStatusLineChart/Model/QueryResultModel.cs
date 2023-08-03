using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoStatusLineChart.Model
{
    public class QueryResultModel
    {
        public string Owner { get; set; }
        //public string Id { get; set; }
        //public string Headline { get; set; }
        //public string Scheduled_version { get; set; }
        public string State { get; set; }
        //public string Realised_item { get; set; }
        //public string Record_type { get; set; }

    }

    public class CqOwner
    {
        public string Owner { get; set; }
    }

    public class CqGraphData
    {
        public string Owner { get; set; }

        public int RecoredCount { get; set; }

        public int AssignedCount { get; set; }

        public int AnalysedCount { get; set; }

        public int RealisedCount { get; set; }

        public int Validation_FailedCount { get; set; }


    }
}
