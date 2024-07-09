using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConsoleApp1
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("path");

            var a = Console.ReadLine();

            var data = ExcelToDataTable(a).DataTableToList<StudentAnswer>();
            var StatusError = data.Where(s => int.Parse(s.StudentFinalStatus) < 41).Select(s => s.StudentCode);
            Console.WriteLine("Status Error not final status student code is:");
            Console.WriteLine(string.Join(';', StatusError));
            Console.WriteLine("");

            var StatusError2 = data.Where(s => (int.Parse(s.StudentFinalStatus) == 91 && int.Parse(s.Status) != 2)).Select(s => s.StudentCode);
            Console.WriteLine("Status Error paper not submit student code is:");
            Console.WriteLine(string.Join(';', StatusError2));
            Console.WriteLine("");

            var dicCount = data.Where(s => int.Parse(s.StudentFinalStatus) == 61).Select(s => new { ResponseCount = int.Parse(s.ResponseCount), s.ModuleCode }).GroupBy(s => s.ModuleCode).Select(s => new { s.Key, maxResponseCount = s.Select(s => s.ResponseCount).Max(), minResponseCount = s.Select(s => s.ResponseCount).Min() }).ToDictionary(s => s.Key, s => new { s.maxResponseCount, s.minResponseCount });

            var modulecodes = new List<string>();

            foreach (var item in dicCount)
            {
                if (item.Value.maxResponseCount - item.Value.minResponseCount > 1)
                {
                    modulecodes.Add(item.Key);
                }
            }

            Console.WriteLine("Answer Count Error module code is:");

            Console.WriteLine(string.Join(';', modulecodes.Distinct()));

            Main(args);
        }

        public class StudentAnswer
        {
            public string StudentResponseId { get; set; }
            public string ResponseCount { get; set; }
            public string Student { get; set; }
            public string StudentCode { get; set; }
            public string ModuleCode { get; set; }
            public string Venue { get; set; }
            public string ModuleManager { get; set; }
            public string StudentFinalStatus { get; set; }
            public string IsSpecialNeeds { get; set; }
            public string IsSpecialNeedsForTaking { get; set; }
            public string Status { get; set; }
            public string submissiontime { get; set; }
            public string AutoMarkResponseId { get; set; }

        }

        // <summary>
        /// 传入路径，返回 DataTable
        /// </summary>
        /// <param name="path">Excel 路径，例如：@"E:\C#导入Excel测试数据.xlsx"</param>
        /// <returns>一个 DataTable 的数据</returns>
        public static DataTable ExcelToDataTable(string path)
        {
            DataTable dataTable = new DataTable();
            Workbook book = new Workbook(path);
            // Excel 中 sheets 数量必须大于 0
            if (book.Worksheets.Count > 0)
            {
                // 导入 Excel 文件中的第一个 sheets 工作表
                Cells cells = book.Worksheets[0].Cells;
                // sheets 中的数据必须存在
                if (cells.MaxDataRow != -1 && cells.MaxDataColumn != -1)
                {
                    // 方法 ExportDataTable 的参数说明
                    //  要导出的第一个单元格的行号。
                    //  要导出的第一个单元格的列号。
                    //  要导入的行数。
                    //  要导入的列数。
                    //  指示第一行的数据是否导出到DataTable的列名。
                    dataTable = cells.ExportDataTable(0, 0, cells.MaxDataRow + 1, cells.MaxDataColumn + 1, true);
                }
            }
            return dataTable;
        }


        public static List<TResult> DataTableToList<TResult>(this DataTable dt) where TResult : class, new()
        {
            //创建一个属性的列表
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            //获取TResult的类型实例  反射的入口
            Type t = typeof(TResult);
            //获得TResult 的所有的Public 属性 并找出TResult属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });
            //创建返回的集合
            List<TResult> oblist = new List<TResult>();
            foreach (DataRow row in dt.Rows)
            {
                //创建TResult的实例
                TResult ob = new TResult();
                //找到对应的数据  并赋值
                prlist.ForEach(p => { if (row[p.Name] != DBNull.Value) p.SetValue(ob, row[p.Name], null); });
                //放入到返回的集合中.
                oblist.Add(ob);
            }
            return oblist;
        }

    }
}