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
        Преподаватель = 0,

        [Display(Name = "Ст. Преподаватель")]
        СтПреподаватель = 1,

        [Display(Name = "Ассистент")]
        Ассистент = 2,

        [Display(Name = "Зав. Кафедрой")]
        ЗавКафедрой = 3,

        [Display(Name = "Доцент")]
        Доцент = 4,

        [Display(Name = "Профессор")]
        Профессор = 5
    }
}
