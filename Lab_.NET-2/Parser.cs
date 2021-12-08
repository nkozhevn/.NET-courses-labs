using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_.NET_2
{
    class Parser
    {
        public static IEnumerable<Threat> EnumerateMetrics(string xlsxpath)
        {
            int i = 0;
            using (var workbook = new XLWorkbook(xlsxpath))
            {
                var worksheet = workbook.Worksheets.Worksheet(1);
                var rows = worksheet.RangeUsed().RowsUsed();
                foreach (var row in rows)
                {
                    if (i > 1)
                    {
                        Threat metric = new Threat()
                        {
                            Id = row.Cell(1).GetValue<int>(),
                            Name = row.Cell(2).GetValue<string>(),
                            Info = row.Cell(3).GetValue<string>(),
                            Source = row.Cell(4).GetValue<string>(),
                            Obj = row.Cell(5).GetValue<string>(),
                            Confidentiality = row.Cell(6).GetValue<bool>(),
                            Reliability = row.Cell(7).GetValue<bool>(),
                            Integrity = row.Cell(8).GetValue<bool>()
                        };

                        metric.FormatId = "УБИ." + String.Format("{0:d3}", metric.Id);
                        yield return metric;
                    }
                    i++;
                }
                worksheet.Clear();
            }
        }
    }
}
