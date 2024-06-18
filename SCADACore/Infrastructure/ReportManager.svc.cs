using SCADACore.Infrastructure.Contract;
using SCADACore.Infrastructure.Service;
using System.Collections.Generic;
using System.Linq;
using SCADACore.Infrastructure.Repository;

namespace SCADACore.Infrastructure
{
    public class ReportManager : IReportManager
    {
        public IEnumerable<string> GetSomeReport()
        {
            return TagRepository.Tags.Values.Select(p => p.TagName);
        }
    }
}
