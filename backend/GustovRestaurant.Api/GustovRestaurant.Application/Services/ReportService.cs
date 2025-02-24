//using GustovRestaurant.Domain.Dtos;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace GustovRestaurant.Application.Services
//{
//    public class ReportService
//    {
//        public byte[] GenerateDailySalesReport(string filterDate)
//        {
//            // Aquí puedes hacer la lógica para obtener los datos que necesitas para el reporte
//            // Usualmente se pasan como parámetros, por ejemplo, las ventas del día

//            // Crea el objeto LocalReport
//            LocalReport report = new LocalReport();

//            // Carga el archivo RDLC como un recurso incrustado
//            string reportPath = "GustovRestaurant.Reports.Reports.DailySalesReport.rdlc";
//            Stream reportStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(reportPath);

//            if (reportStream == null)
//                throw new Exception("No se pudo encontrar el archivo RDLC como recurso incrustado.");

//            report.LoadReportDefinition(reportStream);

//            // Puedes pasarle los datos para llenar el reporte, por ejemplo:
//            var reportData = GetSalesData(filterDate);  // Método que recupera los datos de ventas
//            report.DataSources.Add(new ReportDataSource("SalesDataSet", reportData));

//            // Renderizar el reporte como PDF
//            byte[] pdfBytes = report.Render("PDF");

//            return pdfBytes;
//        }

//        private object GetSalesData(string filterDate)
//        {
//            // Este es un ejemplo, debes integrar la lógica para obtener los datos de ventas según el filtro
//            // Devuelve los datos que deseas mostrar en el reporte, puede ser desde tu base de datos
//            return new List<SaleDetailDto>
//            {
//                new SaleDetailDto { SaleId = 1, ProductName = "Producto 1", Quantity = 10, TotalAmount = 100 },
//                new SaleDetailDto { SaleId = 2, ProductName = "Producto 2", Quantity = 5, TotalAmount = 50 }
//            };
//        }
//    }
//}
