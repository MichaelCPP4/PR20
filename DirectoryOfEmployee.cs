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
    
    public partial class DirectoryOfEmployee
    {
        public int ID { get; set; }
        public int ServiceNumber { get; set; }
        public string Surname { get; set; }
        public string Category { get; set; }
        public string Workshop { get; set; }
    
        public virtual ListOfWorkshop ListOfWorkshop { get; set; }
        public virtual ReportCard ReportCard { get; set; }
        public virtual TariffReference TariffReference { get; set; }
    }
}
