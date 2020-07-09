using System.Collections.Generic;

namespace Artisoft.OnBase.Montepio.FileLoader.Pocos.Config
{
    public class FileConfig
    {
        public string FileNameSuffix { get; set; }
        public string AuditClassName { get; set; }
        public string ObservationClassName { get; set; }
        public List<AttributeConfig> Fields { get; set; }
        public List<ClassNameConfig> ClassNames { get; set; }
    }
}