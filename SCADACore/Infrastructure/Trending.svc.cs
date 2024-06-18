using System.ServiceModel;
using SCADACore.Infrastructure.Contract;
using SCADACore.Infrastructure.Domain.Tag;

namespace SCADACore.Infrastructure
{
    public class Trending : ITrending
    {
        public void InitTrending()
        {
            Processing.OnValueRead += (tag, value, timestamp) => 
                OperationContext.Current.GetCallbackChannel<ITrendingCallback>()
                    .OnTrendingTagPrint(new InputTagValue(tag.TagName, tag.DriverType, value, timestamp));
        }
    }
}
