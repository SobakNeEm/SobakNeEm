//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagmentSudentsOIk.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Студенты
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Студенты()
        {
            this.Пропуски = new HashSet<Пропуски>();
        }
    
        public int СтудентаId { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public Nullable<System.DateTime> ДатаРождения { get; set; }
        public Nullable<int> Группа { get; set; }
        public Nullable<int> СтатусСтудента { get; set; }
        public Nullable<int> ФормаОбучения { get; set; }
        public Nullable<System.DateTime> ДатаЗачисления { get; set; }
        public Nullable<System.DateTime> ДатаВыбытия { get; set; }
        public string НомерТелефона { get; set; }
        public Nullable<int> ПосещаемостьСтудента { get; set; }
    
        public virtual Группы Группы { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Пропуски> Пропуски { get; set; }
        public virtual СтудентаСтатус СтудентаСтатус { get; set; }
    }
}
