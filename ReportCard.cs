//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_BD_PR10
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReportCard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReportCard()
        {
            this.DirectoryOfEmployees = new HashSet<DirectoryOfEmployee>();
        }
    
        public int ServiceNumber { get; set; }
        public int TimeWorkedInHours { get; set; }
        public int MonthNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DirectoryOfEmployee> DirectoryOfEmployees { get; set; }
    }
}
