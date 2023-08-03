using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoStatusLineChart.Model;

namespace AutoStatusLineChart.Extension
{
    public static class QueryResultExtension
    {
        public static IEnumerable<QueryResultModel> ToQueryResult(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {

                var columns = line.Split(',');

                yield return new QueryResultModel
                {
                    Owner = columns[0],
                    State = columns[1]                    
                };
            }
        }
    }
}
