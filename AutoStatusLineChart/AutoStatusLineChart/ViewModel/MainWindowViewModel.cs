using AutoStatusLineChart.Model;
using AutoStatusLineChart.DataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AutoStatusLineChart.Extension;
using System.Windows.Controls.DataVisualization.Charting;
using Microsoft.Win32;

namespace AutoStatusLineChart.ViewModel
{
    public class MainWindowViewModel
    {
        private IList<QueryResultModel> _usersCq;

        private IList<CqGraphData> _cqGraphData;

        private string fileOnlyName;
        public IList<string> _cqUsers { get; set; }
        public MainWindowViewModel()
        {
            OpenDilog();
            _cqGraphData = new List<CqGraphData>();
            _cqUsers = new List<string>();
            _usersCq = GetAllQueryResult();

            _cqUsers = _usersCq.Select(x => x.Owner).Distinct().ToList();

            CqGraphData = GetGraphData(_cqUsers, _usersCq);

           
        }
        public IList<QueryResultModel> UsersCq
        {
            get { return _usersCq; }
            set { _usersCq = value; }
        }

        public IList<CqGraphData> CqGraphData
        {
            get { return _cqGraphData; }
            set { _cqGraphData = value; }
        }

        public IList<string> CqUsers
        {
            get { return _cqUsers; }
            set { _cqUsers = value; }
        }

        public IList<QueryResultModel> GetAllQueryResult()
        {

            //string path = $"Data/QueryResult.csv";
            string path = fileOnlyName;

            
            var query =

                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToQueryResult();

            return query.ToList();
        }



        public IList<CqGraphData> GetGraphData(IList<string> cqUsersName, IList<QueryResultModel> cqData)
        {
            foreach (string cquser in cqUsersName)
            {
                _cqGraphData.Add(new Model.CqGraphData()
                {
                    Owner = cquser,
                    AnalysedCount = cqData.Where(x => x.State == "Analysed" && x.Owner == cquser).Count(),
                    AssignedCount = cqData.Where(x => x.State == "Assigned" && x.Owner == cquser).Count(),
                    RealisedCount = cqData.Where(x => x.State == "Realised" && x.Owner == cquser).Count(),
                    RecoredCount = cqData.Where(x => x.State == "Recorded" && x.Owner == cquser).Count(),
                    Validation_FailedCount = cqData.Where(x => x.State == "Validation_failed" && x.Owner == cquser).Count(),

                });
            }

            return _cqGraphData;

        }

        public void OpenDilog()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            var newDestination = Environment.CurrentDirectory;

            if (dialog.ShowDialog() == true)
            {
                fileOnlyName = dialog.FileName;
               // fileOnlyName = Path.GetFileName(fullPath);
                //File.Copy(fullPath, Path.Combine(newDestination, fileOnlyName));
            }
        }
    }
}
