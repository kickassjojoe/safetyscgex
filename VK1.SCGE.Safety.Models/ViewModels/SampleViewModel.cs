using System;
using System.Collections.Generic;
using System.Text;

namespace VK1.SCGE.Safety.Models.ViewModels {

    public class Root {
        public List<Col> Cols { get; set; }
        public List<Row> Rows { get; set; }
    }

    public class Col {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Pattern { get; set; }
        public string Type { get; set; }
    }

    public class Row {
        public List<C> C { get; set; }
    }

    public class C {
        public object V { get; set; }
        public object F { get; set; }
    }

}
