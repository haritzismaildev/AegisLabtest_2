using Microsoft.AspNetCore.Mvc;
using SourceTest2.Repositories;
using System.Collections.Generic;
using SourceTest2.Models;

using ClosedXML.Excel;
using System.IO;

using Rotativa.AspNetCore;

namespace SourceTest2.Controllers
{
    public class DataController : Controller
    {
        private readonly DataRepository _dataRepo;

        public DataController()
        {
            _dataRepo = new DataRepository();
        }

        public IActionResult Index()
        {
            List<DataModel> dataList = _dataRepo.GetAllData();
            return View(dataList);
        }

        public IActionResult ExportExcel()
        {
            List<DataModel> dataList = _dataRepo.GetAllData();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Data");
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Nama";
                worksheet.Cell(1, 3).Value = "Tanggal";

                int row = 2;
                foreach (var data in dataList)
                {
                    worksheet.Cell(row, 1).Value = data.Id;
                    worksheet.Cell(row, 2).Value = data.Nama;
                    worksheet.Cell(row, 3).Value = data.Tanggal.ToString("dd-MM-yyyy");
                    row++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Data.xlsx");
                }
            }
        }

        public IActionResult ExportPdf()
        {
            List<DataModel> dataList = _dataRepo.GetAllData();
            return new ViewAsPdf("ExportPdf", dataList)
            {
                FileName = "Data.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }
    }
}
