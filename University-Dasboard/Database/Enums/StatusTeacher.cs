using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Dasboard.Database.Enums
{
    public enum StatusTeacher
    {
        [Display(Name = "Уволен")]
        Уволен = 0,

        [Display(Name = "Работает")]
        Работает = 1,

        [Display(Name = "В отпуске")]
        ВОтпуске = 2,

        [Display(Name = "На испытательном сроке")]
        НаИспытательномСроке = 3,
    }
}
