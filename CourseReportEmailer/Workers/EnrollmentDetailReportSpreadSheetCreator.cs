using CourseReportEmailer.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseReportEmailer.Workers
{
    public class EnrollmentDetailReportSpreadSheetCreator
    {
        public void Create(string fileName, IList<EnrollmentDetailReportModel> enrollmentModels)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                var json = JsonConvert.SerializeObject(enrollmentModels);
                DataTable enrollmentsTable = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));

                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();
                
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                Sheets sheetlist = document.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                Sheet singleSheet = new Sheet()
                {
                    Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Report Sheet" 
                };

                sheetlist.Append(singleSheet);

                Row excelTitleRow = new Row();

                foreach (DataColumn column in enrollmentsTable.Columns)
                {
                    Cell cell = new Cell()
                    {
                        DataType = CellValues.String,
                        CellValue = new CellValue(column.ColumnName)
                    };
                    
                    excelTitleRow.Append(cell);
                }
                
                sheetData.AppendChild(excelTitleRow);

                foreach (DataRow row in enrollmentsTable.Rows)
                {
                    Row excelRow = new Row();
                    foreach (DataColumn column in enrollmentsTable.Columns)
                    {
                        Cell cell = new Cell()
                        {
                            DataType = CellValues.String,
                            CellValue = new CellValue(row[column.ColumnName].ToString())
                        };
                        excelRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(excelRow);
                }

                workbookPart.Workbook.Save();
            }
        }
    }
}
