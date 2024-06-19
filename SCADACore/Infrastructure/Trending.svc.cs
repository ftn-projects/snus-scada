using System.ServiceModel;
using SCADACore.Infrastructure.Contract;
using SCADACore.Infrastructure.Domain.Tag;

namespace SCADACore.Infrastructure
{
    public class Trending : ITrending
    {
        private ITrendingCallback Callback { get; set; }
        
        public void InitTrending()
        {
            Callback = OperationContext.Current.GetCallbackChannel<ITrendingCallback>();

            Processing.OnValueRead += (tag, value, timestamp) => 
               Callback.OnTrendingTagPrint(new InputTagValue(tag.TagName, tag.DriverType, value, timestamp, tag.GetType().Name));
        }
    }
}
