using System.IO;
using System.Linq;
using SCADACore.Infrastructure;
using SCADACore.Infrastructure.Domain.Tag.Abstraction;
using SCADACore.Infrastructure.Repository;
using SCADACore.Infrastructure.Utils;

namespace SCADACore
{
    public class Initializer
    {
        public static void AppInitialize()
        {
            if (!Directory.Exists(ApplicationConfig.DataFolder))
                Directory.CreateDirectory(ApplicationConfig.DataFolder);

            TagRepository.LoadTags();

            // For every input tag with scanning turned on, schedule scan job
            TagRepository.GetTypeOfTags<InputTag>()
                .Where(t => t.Scan).ToList()
                .ForEach(Processing.AddTagScan);

            // testing purposes
            TagValueRepository.Wipe();
            AlarmInvocationRepository.Wipe();
            AlarmInvocationLogger.Wipe();
        }
    }
}