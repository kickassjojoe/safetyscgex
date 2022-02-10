using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public class LogEmployeeAccident {
        [Key, StringLength(11)]
        [Required]
        public string EmployeeCode { get; set; }

        public int MaxNumber { get; private set; }

        public DateTime UpdateDate { get; set; } = DateTime.Today;

        //2021-02-19 จำนวนครั้งกรณีหักเงิน
        public int IncaseOfDeduction { get; private set; }

        //กรณี สร้างใหม่
        public void SetMaxNumber() {
            bool isSameYear = UpdateDate.Year.CompareTo(DateTime.Now.Year) == 0;
            MaxNumber = isSameYear ? ++MaxNumber : 1;
        }

        //กรณี สร้างใหม่
        public void SetIncaseOfDeductionCreate(bool isDamage) {
            bool isSameYear = UpdateDate.Year.CompareTo(DateTime.Now.Year) == 0;
            if (isDamage) {
                IncaseOfDeduction = isSameYear ? ++IncaseOfDeduction : 1;
            }
        }

        //กรณี แก้ไข
        public void SetIncaseOfDedcutionEdit(bool isDamage, bool previousDamage) {
            if (previousDamage == true && isDamage == false) {
                if (isDamage == false) {
                    IncaseOfDeduction -= 1;
                }
            } else if(previousDamage==false) {
                if (isDamage == true) {
                    IncaseOfDeduction += 1;
                }
            }
        }

        //กรณีลบ investigate card
        public void SetCaseDelete(bool previousDamage) {
            MaxNumber -= 1;
            if (previousDamage == true) {
                IncaseOfDeduction -= 1;
            }
        }
    }
}

