using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;

using ADS.LAPEM.Web.Areas.Reporte.Models;
using ADS.LAPEM.Services.Catalogo;
using ADS.LAPEM.Web.Controllers;


namespace ADS.LAPEM.Web.Areas.Reporte.Controllers
{
    public class ReporteadorController : BaseController
    {
        protected IResultadoService ResultadoService { get; set; }
        protected IResultadoDetalleService ResultadoDetalleService { get; set; }
        protected IAtributoDService AtributoDService { get; set; }
        protected IProductoService ProductoService { get; set; }
        protected INormaEnsayoService NormaEnsayoService { get; set; } 
        
        //
        // GET: /Reporte/Reporteador/

        public ActionResult Index()
        {
            
            ReporteadorViewModel model = new ReporteadorViewModel()
            {
                columnas = new List<columnas>()
                {
                    new columnas(){ grupo="Encabezado", col="FechaPrueba", selected=true },
                    new columnas(){ grupo="Encabezado", col="FechaProduccion", selected=true },
                    new columnas(){ grupo="Encabezado", col="NombreTurno", selected=true },
                    new columnas(){ grupo="Encabezado", col="ValorMm", selected=true },
                    new columnas(){ grupo="Encabezado", col="Codigo", selected=true },
                    new columnas(){ grupo="Encabezado", col="Aprobado", selected=true },

                    new columnas(){ grupo="Detalle", col="MuestraNum", selected=true },
                    new columnas(){ grupo="Detalle", col="NombreAtributo", selected=true },
                    new columnas(){ grupo="Detalle", col="Valor", selected=true },
                    new columnas(){ grupo="Detalle", col="Aprobado", selected=true },

                },
                Productos = ProductoService.ReadProducto(),
                Normas = NormaEnsayoService.ReadNormaEnsayo()

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ReporteExcel(ReporteadorViewModel model)
        {

            //Query Late binding
            IQueryable<Entities.Resultado> R1 = ResultadoService.ReadResultado();

            //Filtros
            if (model.ProductoId.HasValue)
            {
                R1 = R1.Where(x => x.Lote.ProductoId == model.ProductoId.Value);
            }
            if (model.NormaEnsayoId.HasValue)
            {
                R1 = R1.Where(x => x.NormaEnsayoId == model.NormaEnsayoId);
            }
            if(!String.IsNullOrEmpty(model.Identificador)){
                R1=R1.Where(x=>x.Lote.Identificador==model.Identificador);
            }
            if (model.FiltraFecha)
            {
                R1 = R1.Where(x => x.Lote.FechaProduccion == model.FechaProduccion);
            }
            
            
            //Select
            var R1List= R1.ToList().Select(x => new
            {
                x.Id,
                x.FechaPrueba,
                x.Lote.FechaProduccion,
                x.Lote.Turno.NombreTurno,
                x.Lote.Producto.MedidaDiametro.ValorMm,
                x.Lote.Producto.Codigo,
                x.Lote.Aprobado
            });


            //buscar detalle
            List<Entities.ResultadoDetalle> RD = new List<Entities.ResultadoDetalle>();
            foreach (var itm in R1List)
            {
                var R2 = ResultadoDetalleService.ReadResultadoDetalleByResultadoId(itm.Id);
                RD.AddRange(R2.ToList());             
            }

            //lista que se envia a excel
            List<excelDetalle> detalle = new List<excelDetalle>();
            foreach (var itm in RD)
            {

                var atributosDetalles = AtributoDService.ReadAtributoDetalleByResultadoId(itm.Id).ToList();
                foreach (var atributoD in atributosDetalles)
                {
                    detalle.Add(new excelDetalle
                    {
                        MuestraNum = itm.MuestraNum,
                        NombreAtributo = atributoD.Atributo.NombreAtributo,
                        Valor = atributoD.Valor,
                        Aprobado = itm.Resultado.Aprobado == 1
                    });
                }
                
            }
                


            var sel = model.columnas.Where(c => c.grupo == "Encabezado").Where(c => c.selected).Select(c => c.col).ToArray();
            var selDetalle = model.columnas.Where(c => c.grupo == "Detalle").Where(c => c.selected).Select(c => c.col).ToArray();
            ExcelFile excelFile = new ExcelFile();

            excelFile.createFile("REPORTE AGRIETAMIENTO", R1List, sel); //primera lista encabezado
            excelFile.createFile("REPORTE Detalle", detalle, selDetalle); //segunda lista detalle
            excelFile.Close();


            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "Reporte.xlsx", //document.FileName, 

                Inline = true,
            };

            excelFile.MemoryStream.Position = 0;
            var ret = File(excelFile.MemoryStream, "application/xlsx");
            Response.AppendHeader("Content-Disposition", cd.ToString());
            Response.ContentType = "application/vnd.ms-excel";
            //var ret = File(excelFile.MemoryStream, "application/vnd.ms-excel");

            return ret;
        }


        

        public class dato
        {
            public string nombre { get; set; }
            public string nombre2 { get; set; }
            public decimal numero { get; set; }
            public DateTime fecha { get; set; }


        }

        

        public class ExcelFile
        {


            private MemoryStream _MemoryStream = new MemoryStream();

            public MemoryStream MemoryStream
            {
                get { return _MemoryStream; }
            }


            private SpreadsheetDocument spreadsheetDocument;
            private WorkbookPart workbookpart;
            private WorksheetPart worksheetPart;
            private Sheets sheets;
            private SharedStringTablePart shareStringPart;


            public ExcelFile()
            {
                spreadsheetDocument = SpreadsheetDocument.Create(_MemoryStream, SpreadsheetDocumentType.Workbook);
                workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();


                // Add Sheets to the Workbook.
                sheets = spreadsheetDocument.WorkbookPart.Workbook.
                    AppendChild<Sheets>(new Sheets());



                WorkbookStylesPart wbsp = workbookpart.AddNewPart<WorkbookStylesPart>();

                wbsp.Stylesheet = CreateStylesheet();
                wbsp.Stylesheet.Save();
            }

            public void Close()
            {
                // Close the document.
                spreadsheetDocument.Close();
            }

            public void createFile<T>(string SheetName, IEnumerable<T> list, string[] propiedades)
            {
                // Add a WorksheetPart to the WorkbookPart.
                worksheetPart = workbookpart.AddNewPart<WorksheetPart>();

                var SheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(SheetData);
                SharedStringTablePart shareStringPart;

                UInt32Value sheetid = new UInt32Value();
                sheetid.Value = (uint)sheets.Count() + 1;

                // Append a new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.
                        GetIdOfPart(worksheetPart),
                    SheetId = sheetid,
                    Name = SheetName
                };
                sheets.Append(sheet);

                ////Datos:
                var props = typeof(T).GetProperties().Where(prop => propiedades.Contains(prop.Name));

                Row rowH = AddRow(SheetData, 1);
                foreach (var prop in props)
                {
                    var cell = AddCellValue(rowH, prop.Name);
                    //cell.StyleIndex = (UInt32Value)2U;
                }

                UInt32Value rowid = 2;


                foreach (T item in list)
                {

                    Row row = AddRow(SheetData, rowid);
                    foreach (var prop in props)
                    {
                        AddCellValue(row, prop.GetValue(item));
                    }

                    rowid++;
                }

                workbookpart.Workbook.Save();

            }






            private Row AddRow(SheetData sheetData, UInt32Value rowIndex)
            {
                Row row;

                if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
                {
                    row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
                }
                else
                {
                    row = new Row() { RowIndex = rowIndex };
                    sheetData.Append(row);
                }

                return row;
            }

            private Cell AddCellValue<T>(Row row, T value)
            {
                Cell newCell = new Cell() { };
                if (value is int || value is long|| value is decimal || value is float || value is double)
                {
                    newCell.CellValue = new CellValue(Convert.ToString(value));
                    newCell.DataType = new EnumValue<CellValues>(CellValues.Number);

                }



                if (value is string)
                {

                    if (spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                    {
                        shareStringPart = spreadsheetDocument.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                    }
                    else
                    {
                        shareStringPart = spreadsheetDocument.WorkbookPart.AddNewPart<SharedStringTablePart>();
                    }


                    int idshareditme = InsertSharedStringItem(value as string, shareStringPart);
                    // Set the value of cell A1.
                    newCell.CellValue = new CellValue(idshareditme.ToString());
                    newCell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                }


                if (value is DateTime)
                {
                    DateTime valuedate = Convert.ToDateTime(value);

                    newCell.CellValue = new CellValue(valuedate.ToOADate().ToString());
                    newCell.DataType = new EnumValue<CellValues>(CellValues.Number);
                    newCell.StyleIndex = (UInt32Value)1U;

                }

                if (value is bool)
                {
                    newCell.CellValue = new CellValue(Convert.ToInt16(value).ToString());
                    newCell.DataType = CellValues.Boolean;
                    //Cell cell1 = new Cell() { CellReference = "E2", DataType = CellValues.Boolean };
                    //CellValue cellValue1 = new CellValue();
                    //cellValue1.Text = "1";

                }

                row.InsertBefore(newCell, null);
                return newCell;
            }

            private static Stylesheet CreateStylesheet()
            {
                Stylesheet stylesheet1 = new Stylesheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
                stylesheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
                stylesheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");

                Fonts fonts1 = new Fonts() { Count = (UInt32Value)1U, KnownFonts = true };

                Font font1 = new Font();
                FontSize fontSize1 = new FontSize() { Val = 11D };
                Color color1 = new Color() { Theme = (UInt32Value)1U };
                FontName fontName1 = new FontName() { Val = "Calibri" };
                FontFamilyNumbering fontFamilyNumbering1 = new FontFamilyNumbering() { Val = 2 };
                FontScheme fontScheme1 = new FontScheme() { Val = FontSchemeValues.Minor };

                font1.Append(fontSize1);
                font1.Append(color1);
                font1.Append(fontName1);
                font1.Append(fontFamilyNumbering1);
                font1.Append(fontScheme1);

                fonts1.Append(font1);

                Fills fills1 = new Fills() { Count = (UInt32Value)2U };

                Fill fill1 = new Fill();
                PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };

                fill1.Append(patternFill1);

                Fill fill2 = new Fill();
                PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };

                fill2.Append(patternFill2);

                fills1.Append(fill1);
                fills1.Append(fill2);

                Borders borders1 = new Borders() { Count = (UInt32Value)1U };

                Border border1 = new Border();
                LeftBorder leftBorder1 = new LeftBorder();
                RightBorder rightBorder1 = new RightBorder();
                TopBorder topBorder1 = new TopBorder();
                BottomBorder bottomBorder1 = new BottomBorder();
                DiagonalBorder diagonalBorder1 = new DiagonalBorder();

                border1.Append(leftBorder1);
                border1.Append(rightBorder1);
                border1.Append(topBorder1);
                border1.Append(bottomBorder1);
                border1.Append(diagonalBorder1);

                borders1.Append(border1);

                CellStyleFormats cellStyleFormats1 = new CellStyleFormats() { Count = (UInt32Value)1U };
                CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U };

                cellStyleFormats1.Append(cellFormat1);

                CellFormats cellFormats1 = new CellFormats() { Count = (UInt32Value)2U };
                CellFormat cellFormat2 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U };
                CellFormat cellFormat3 = new CellFormat() { NumberFormatId = (UInt32Value)22U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true };

                cellFormats1.Append(cellFormat2);
                cellFormats1.Append(cellFormat3);

                CellStyles cellStyles1 = new CellStyles() { Count = (UInt32Value)1U };
                CellStyle cellStyle1 = new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U };

                cellStyles1.Append(cellStyle1);
                DifferentialFormats differentialFormats1 = new DifferentialFormats() { Count = (UInt32Value)0U };
                TableStyles tableStyles1 = new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium2", DefaultPivotStyle = "PivotStyleLight16" };

                StylesheetExtensionList stylesheetExtensionList1 = new StylesheetExtensionList();

                StylesheetExtension stylesheetExtension1 = new StylesheetExtension() { Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}" };
                stylesheetExtension1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
                //X14.SlicerStyles slicerStyles1 = new X14.SlicerStyles() { DefaultSlicerStyle = "SlicerStyleLight1" };

                //stylesheetExtension1.Append(slicerStyles1);

                stylesheetExtensionList1.Append(stylesheetExtension1);

                stylesheet1.Append(fonts1);
                stylesheet1.Append(fills1);
                stylesheet1.Append(borders1);
                stylesheet1.Append(cellStyleFormats1);
                stylesheet1.Append(cellFormats1);
                stylesheet1.Append(cellStyles1);
                stylesheet1.Append(differentialFormats1);
                stylesheet1.Append(tableStyles1);
                stylesheet1.Append(stylesheetExtensionList1);
                return stylesheet1;
            }

            private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
            {
                // If the part does not contain a SharedStringTable, create one.
                if (shareStringPart.SharedStringTable == null)
                {
                    shareStringPart.SharedStringTable = new SharedStringTable();
                }

                int i = 0;

                // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
                foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
                {
                    if (item.InnerText == text)
                    {
                        return i;
                    }

                    i++;
                }

                // The text does not exist in the part. Create the SharedStringItem and return its index.
                shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
                shareStringPart.SharedStringTable.Save();

                return i;
            }
        }

    }
}
