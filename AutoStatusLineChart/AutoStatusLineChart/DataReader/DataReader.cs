using AutoStatusLineChart.Extension;
using AutoStatusLineChart.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoStatusLineChart.DataReader
{
    public class DataReader
    {
        public IList<QueryResultModel> GetAllQueryResult()
        {

            string path = $"Data/QueryResult.csv";
            var query =

                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToQueryResult();

            return query.ToList();
        }
    }
}
