//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StatNav.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PackageContainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PackageContainer()
        {
            this.MarketingAssetPackages = new HashSet<MarketingAssetPackage>();
        }
    
        public int Id { get; set; }
        public string PackageContainerName { get; set; }
        public string Type { get; set; }
        public int MetricModelStageId { get; set; }
        public string Notes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketingAssetPackage> MarketingAssetPackages { get; set; }
    }
}
