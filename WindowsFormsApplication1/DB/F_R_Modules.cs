//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication1.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class F_R_Modules
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public F_R_Modules()
        {
            this.F_nn_FlatModules = new HashSet<F_nn_FlatModules>();
        }
    
        public int ID_MODULE { get; set; }
        public string NAME_MODULE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<F_nn_FlatModules> F_nn_FlatModules { get; set; }
    }
}
