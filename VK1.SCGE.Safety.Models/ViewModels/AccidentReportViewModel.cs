using System;
using System.Collections.Generic;
using System.Text;

namespace VK1.SCGE.Safety.Models.ViewModels {
    public class AccidentReportViewModel {
        //Part one
        public DateTime CaseDate { get; set; }
        public string RegionName { get; set; }
        public string BranchCode { get; set; }
        public string CaseName { get; set; }
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; } //option
        public string YearExperience { get; set; } //option
        public string CompanyName { get; set; }
        public string Shift { get; set; } //option
        public string CaseType { get; set; } //ผิด=1,ถูก=2,ประมาทร่วม=3
        public string AccidentMode { get; set; }  //Transport =1, Other =2
        public string Rank { get; set; } //L0เล็กน้อยไม่เข้าเกณฑ์เฉี่ยวชนเล็กน้อยไม่มีคนบาดเจ็บ = 1,L1ขั้นปฐมพยาบาลรถใช้งานต่อไปได้ = 2,L2ขั้นรักษาพยาบาลเปลี่ยนงานไม่หยุดงานรถถูกลาก = 3,L3หยุดงานรถไม่สามารถซ่อมได้คืนซากรถ = 4,L3เสียชีวิตรถไม่สามารถซ่อมได้คืนซากรถ = 5,
        public string SolutionHour { get; set; } //option ระยะเวลาตั้งแต่เกิดจนแล้วเสร็จ

        //Part two
        public string LeisureHour { get; set; } //option เวลาพักผ่อน
        public string IncidentRoute { get; set; }  //option วิ่งประจำ = 1,เปลี่ยนเส้นทางวิ่งชั่วคราว = 2
        public string ProductDamage { get; set; } //option สินค้าหลังตู้รถขณะเกิดเหตุ

        public string CaseEffect { get; set; }   //option สามารถส่งต่อได้หลังเกิดเหตุ = 1,พัสดุเลื่อนส่ง = 2
        public string EmpInjure { get; set; }  //การบาดเจ็บของพนักงาน ไม่ได้รับบาดเจ็บ = 1,ได้รับบาดเจ็บ = 2,หยุดงาน = 3,เสียชีวิต = 4
        public string PartiesInjure { get; set; }  // option การบาดเจ็บของคู่กรณี ไม่ได้รับบาดเจ็บ = 1,ได้รับบาดเจ็บ = 2,หยุดงาน = 3,เสียชีวิต = 4
        public string ThirdPartiesInjure { get; set; }  // option การบาดเจ็บของบุคคลที่สาม ไม่ได้รับบาดเจ็บ = 1,ได้รับบาดเจ็บ = 2,หยุดงาน = 3,เสียชีวิต = 4
        public string TruckDamage { get; set; }  //  ไม่ได้รับความเสียหาย = 1,ได้รับความเสียหายกรณีเป็นฝ่ายผิดแจ้งหักเงิน = 2,ได้รับความเสียหาย = 3,
        public string PartiesDamage { get; set; }  //option ไม่ได้รับความเสียหาย = 1,ได้รับความเสียหายกรณีเป็นฝ่ายผิดแจ้งหักเงิน = 2,ได้รับความเสียหาย = 3,
        public string EquipmentDamage { get; set; }  // option ไม่ได้รับความเสียหาย = 1,ได้รับความเสียหายกรณีเป็นฝ่ายผิดแจ้งหักเงิน = 2,ได้รับความเสียหาย = 3,
        public string Camera { get; set; }   // บันทึกปกติใช้งานได้ = 1,ไม่บันทึกกล้องเสีย = 2,ไม่มีกล้อง = 3,
        public string TruckInspectionNormal { get; set; } //option ปกติ , ผิดปกติ ระบุ.....
        public string Gps { get; set; }  //option มีการติดตั้ง , ไม่มีการติดตั้ง
        public string GpsSpeed { get; set; }
        public string Cctv { get; set; } //option กล้องวงจรปิด มี, ไม่มี
        public string SafetyCourse { get; set; } //option อบรมความปลอดภัย ผ่าน/ไม่ผ่าน
        public string SdcCourse { get; set; } //option อบรมSDC ผ่าน/ไม่ผ่าน
        public string AlcoholCheck { get; set; } //option ตรวจแอลกอฮอล ผ่าน/ไม่ผ่าน

        //part threee
        public string IncidentDescription { get; set; }

        //part foure
        public string AreaConditon { get; set; }
        public string Weather { get; set; }
        public string Traffic { get; set; }
        public string IncidentArea { get; set; }
        public string Incident { get; set; }

        //part five
        public List<UnsafeActViewModel> UnsafeActs { get; set; }
        public List<UnsafeActViewModel> UnsafeCons { get; set; }
        public List<string> Solutions { get; set; }

    }

    public class UnsafeActViewModel {
        public string Name { get; set; }
    }
    //public class SolutionViewModel {
    //    public string Name { get; set; }
    //}
}
