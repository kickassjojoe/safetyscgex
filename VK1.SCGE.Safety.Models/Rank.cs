using System;
using System.Collections.Generic;
using System.Text;

namespace VK1.SCGE.Safety.Models {
    public enum Rank {
        L0เล็กน้อยไม่เข้าเกณฑ์เฉี่ยวชนเล็กน้อยไม่มีคนบาดเจ็บ = 1,
        L1ขั้นปฐมพยาบาลรถใช้งานต่อไปได้ = 2,
        L2ขั้นรักษาพยาบาลเปลี่ยนงานไม่หยุดงานรถถูกลาก = 3,
        L3หยุดงานรถไม่สามารถซ่อมได้คืนซากรถ = 4,
        L3เสียชีวิตรถไม่สามารถซ่อมได้คืนซากรถ = 5,
    }
}
