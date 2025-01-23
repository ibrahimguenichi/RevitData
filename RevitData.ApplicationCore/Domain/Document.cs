using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitData.ApplicationCore.Domain
{
    public class Document
    {
        public bool IsValidObject { get; set; }
        public string WorksharingProjectGUID { get; set; }
        public string CloudModelGUID { get; set; }
        public string WorksharingCentralGUID { get; set; }
        public bool IsModelInCloud { get; set; }
        public bool IsDetached { get; set; }
        public bool IsCentralModel { get; set; }
        public bool IsLocalModel { get; set; }
        public bool IsWorkShared { get; set; }
        public bool IsLinked { get; set; }
        public bool IsReadOnlyFile { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsModified { get; set; }
        public bool IsModifiable { get; set; }
        public string Title { get; set; }
        public string PathName { get; set; }
        public Application Application { get; set; }
        public Family OwnerFamily { get; set; }
        public bool IsFamilyDocument { get; set; }
        public PrintManager PrintManager { get; set; }
        public SiteLocation SiteLocation { get; set; }
        public ProjectLocation ActiveProjectLocation { get; set; }
        public ProjectLocationSet ProjectLocations { get; set; }
        public View ActiveView { get; set; }
        public FamilyManager FamilyManager { get; set; }
        public PlanTopologySet PlanTopologies { get; set; }
        public PlanTopology PlanTopology { get; set; }
        public ProjectInfo ProjectInformation { get; set; }
        public bool ReactionsAreUpToDate { get; set; }
        public PhaseArray Phases { get; set; }
        public PanelTypeSet PanelTypes { get; set; }
        public MullionTypeSet MyProperty { get; set; }
        public BindingMap ParameterBindings { get; set; }
        public DisplayUnit DisplayUnitSystem { get; set; }
        public Settings Settings { get; set; }
        public StorageType TypeOfStorage { get; set; }

    }
}
