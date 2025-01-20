using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Dasboard.Database.Enums
{
    public enum DegreeTeachers
    {
        [Display(Name = "Преподаватель")]
        Преподаватель,

        [Display(Name = "Ст. Преподаватель")]
        СтПреподаватель,

        [Display(Name = "Ассистент")]
        Ассистент,

        [Display(Name = "Зав. Кафедрой")]
        ЗавКафедрой,

        [Display(Name = "Доцент")]
        Доцент,

        [Display(Name = "Профессор")]
        Профессор
    }
}
