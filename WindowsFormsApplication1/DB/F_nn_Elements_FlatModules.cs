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
    
    public partial class F_nn_Elements_FlatModules
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public F_nn_Elements_FlatModules()
        {
            this.F_nn_ElementParam_Value = new HashSet<F_nn_ElementParam_Value>();
        }
    
        public int ID_ELEMENT_IN_FM { get; set; }
        public int ID_FLAT_MODULE { get; set; }
        public int ID_ELEMENT { get; set; }
        public string LOCATION_POINT { get; set; }
        public string DIRECTION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<F_nn_ElementParam_Value> F_nn_ElementParam_Value { get; set; }
        public virtual F_nn_FlatModules F_nn_FlatModules { get; set; }
        public virtual F_S_Elements F_S_Elements { get; set; }
    }
}
