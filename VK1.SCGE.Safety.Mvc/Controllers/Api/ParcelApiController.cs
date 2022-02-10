using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VK1.SCGE.Safety.Models.ViewModels;
using VK1.SCGE.Safety.Services;

namespace VK1.SCGE.Safety.Mvc.Controllers.Api {
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelApiController : ControllerBase {
        private readonly App app;

        public ParcelApiController(App app) {
            this.app = app;
        }

        [HttpGet("overallCustQty")]
        public IActionResult GetOverallCustQty() {
            //var parcels = await app.Parcels.AllAsync();
            //if (parcels == null) {
            //    return NotFound();
            //}

            ////  List<ChartParcelViewModel> list = new List<ChartParcelViewModel>();
            //var result = parcels.Select(x => new ChartParcelViewModel {
            //    Date = $"{x.Date:dd-MM-yyyy}",
            //    OldQty = x.OldCustomerQty,
            //    NewQty = x.NewCustomerQty
            //}).ToList();

            var root = new Root() {
                Cols = new List<Col>() {
                    new Col{Id="",Label="Topping",Pattern="",Type="string"},
                    new Col{Id="",Label="Slices",Pattern="",Type="number"},
                },
                Rows = new List<Row>() {
                     new Row {
                         C= new List<C> {
                             new C{V="1-1-2020",F=null},
                             new C{V=3,F=null},
                             new C{V=1,F=null},
                         }
                     },
                     new Row {
                         C= new List<C> {
                             new C{V="2-1-2020",F=null},
                             new C{V=1,F=null}
                         }
                     },
                     new Row {
                         C= new List<C> {
                             new C{V="3-1-2020",F=null},
                             new C{V=1,F=null}
                         }
                     },
                     new Row {
                         C= new List<C> {
                             new C{V="4-1-2020",F=null},
                             new C{V=1,F=null}
                         }
                     },
                     new Row {
                         C= new List<C> {
                             new C{V="5-1-2020",F=null},
                             new C{V=1,F=null}
                         }
                     }
                }
            };


            return Ok(root);

        }

        [HttpGet("allCustQty")]
        public async Task<IActionResult> AllCustomerQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldCustomerQty),
                            NewQty = g.Sum(x => x.NewCustomerQty)
                        }).OrderBy(x=>x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldCustomer",
                "NewCustomer"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("centralCustQty")]
        public async Task<IActionResult> CentralCustomerQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName== "Central & West"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldCustomerQty),
                            NewQty = g.Sum(x => x.NewCustomerQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldCustomer",
                "NewCustomer"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("eastCustQty")]
        public async Task<IActionResult> EastCustomerQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName == "East"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldCustomerQty),
                            NewQty = g.Sum(x => x.NewCustomerQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldCustomer",
                "NewCustomer"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("metroCustQty")]
        public async Task<IActionResult> MetroCustomerQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName == "Metro"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldCustomerQty),
                            NewQty = g.Sum(x => x.NewCustomerQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldCustomer",
                "NewCustomer"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("northCustQty")]
        public async Task<IActionResult> NorthCustomerQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName == "North"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldCustomerQty),
                            NewQty = g.Sum(x => x.NewCustomerQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldCustomer",
                "NewCustomer"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("northEastCustQty")]
        public async Task<IActionResult> NorthEastCustomerQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName == "NorthEast"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldCustomerQty),
                            NewQty = g.Sum(x => x.NewCustomerQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldCustomer",
                "NewCustomer"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("southCustQty")]
        public async Task<IActionResult> SouthCustomerQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName == "South"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldCustomerQty),
                            NewQty = g.Sum(x => x.NewCustomerQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldCustomer",
                "NewCustomer"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("allParcelQty")]
        public async Task<IActionResult> AllParcelQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldOrderQty),
                            NewQty = g.Sum(x => x.NewOrderQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldParcel",
                "NewParcel"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("centralParcelQty")]
        public async Task<IActionResult> CentralParcelQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName == "Central & West"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldOrderQty),
                            NewQty = g.Sum(x => x.NewOrderQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldParcel",
                "NewParcel"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("eastParcelQty")]
        public async Task<IActionResult> EastParcelQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName == "East"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldOrderQty),
                            NewQty = g.Sum(x => x.NewOrderQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldParcel",
                "NewParcel"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("metroParcelQty")]
        public async Task<IActionResult> MetroParcelQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName == "Metro"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldOrderQty),
                            NewQty = g.Sum(x => x.NewOrderQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldParcel",
                "NewParcel"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("northParcelQty")]
        public async Task<IActionResult> NorthParcelQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName == "North"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldOrderQty),
                            NewQty = g.Sum(x => x.NewOrderQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldParcel",
                "NewParcel"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("northEastParcelQty")]
        public async Task<IActionResult> NorthEastParcelQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName == "NorthEast"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldOrderQty),
                            NewQty = g.Sum(x => x.NewOrderQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldParcel",
                "NewParcel"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }

        [HttpGet("southParcelQty")]
        public async Task<IActionResult> SouthParcelQty() {
            var parcels = await app.Parcels.AllAsync();
            if (parcels == null) {
                return NotFound();
            }

            //group by date
            var data = (from x in parcels.ToList()
                        where x.RegionName == "South"
                        group x by x.Date into g
                        select new ChartParcelViewModel {
                            Date = $"{g.Key:dd-MM-yyyy}",
                            OldQty = g.Sum(x => x.OldOrderQty),
                            NewQty = g.Sum(x => x.NewOrderQty)
                        }).OrderBy(x => x.Date).ToList();

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Date",
                "OldParcel",
                "NewParcel"
            };

            int j = 0;
            foreach (var i in data) {
                j++;
                chartData[j] = new object[] { i.Date, i.OldQty, i.NewQty };
            }

            return Ok(chartData);
        }


    }
}
