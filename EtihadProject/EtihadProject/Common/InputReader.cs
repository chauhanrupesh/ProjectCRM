using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ExcelDataReader;


namespace EtihadProject
{
    public class InputReader
    {
        /*
        private static string CurrentDir = Environment.CurrentDirectory;
        private static readonly string LoginFile = CurrentDir.Substring(0, CurrentDir.LastIndexOf("bin")) + "Test Data\\Login.csv";
        private static readonly string SalesFile = CurrentDir.Substring(0, CurrentDir.LastIndexOf("bin")) + "Test Data\\Sales.csv";
        private static readonly string SalesHubFile = CurrentDir.Substring(0, CurrentDir.LastIndexOf("bin")) + "Test Data\\Contact.csv";
        private static readonly string SharedCalendarFile = CurrentDir.Substring(0, CurrentDir.LastIndexOf("bin")) + "Test Data\\Account.csv";

        private static DataTableCollection ConvertData(string FileName)
        {
            FileStream fs = File.Open(FileName, FileMode.Open, FileAccess.Read);
            IExcelDataReader ExcelReader = ExcelReaderFactory.CreateCsvReader(fs);
            //Make First row as header
            //DataSet ResultSet = ExcelReader.AsDataSet();
            DataSet ResultSet = ExcelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            //DataTableCollection table = ResultSet.Tables;
            ExcelReader.Close();
            ExcelReader.Dispose();
            ExcelReader = null;
            fs.Close();
            //return table;
        }

        public class DataCollection
        {
            public int RowNumber { get; set; }
            public string ColumnName { get; set; }
            public string ColumnValue { get; set; }
        }

        static List<DataCollection> EnvironmentData = new List<DataCollection>();
        static List<DataCollection> LoginData = new List<DataCollection>();
        static List<DataCollection> SalesData = new List<DataCollection>();
        static List<DataCollection> SalesHubData = new List<DataCollection>();
        static List<DataCollection> SharedCalendarData = new List<DataCollection>();
        static readonly int RowCount = 0;

        public static int GetRowCount()
        {
            return RowCount;
        }

        public static void PopulateExcelData()
        {
            DataTableCollection LoginCollection = ConvertData(LoginFile);
            DataTable LoginTable = LoginCollection["Table1"];
             for (int row = 1; row <= LoginTable.Rows.Count; row++)
             {
                 for (int col = 0; col < LoginTable.Columns.Count; col++)
                 {
                     DataCollection dtTable2 = new DataCollection()
                     {
                         RowNumber = row,
                         ColumnName = LoginTable.Columns[col].ColumnName,
                         ColumnValue = LoginTable.Rows[row - 1][col].ToString()
                     };
                     LoginData.Add(dtTable2);
                 }
             }
             DataTableCollection SalesCollection = ConvertData(SalesFile);
             DataTable SalesTable = SalesCollection["Table1"];
             for (int row = 1; row <= SalesTable.Rows.Count; row++)
             {
                 for (int col = 0; col < SalesTable.Columns.Count; col++)
                 {
                     DataCollection dtTable3 = new DataCollection()
                     {
                         RowNumber = row,
                         ColumnName = SalesTable.Columns[col].ColumnName,
                         ColumnValue = SalesTable.Rows[row - 1][col].ToString()
                     };
                     SalesData.Add(dtTable3);
                 }
             }
             DataTableCollection SalesHubCollection = ConvertData(SalesHubFile);
             DataTable SalesHubTable = SalesHubCollection["Table1"];
             for (int row = 1; row <= SalesHubTable.Rows.Count; row++)
             {
                 for (int col = 0; col < SalesHubTable.Columns.Count; col++)
                 {
                     DataCollection dtTable4 = new DataCollection()
                     {
                         RowNumber = row,
                         ColumnName = SalesHubTable.Columns[col].ColumnName,
                         ColumnValue = SalesHubTable.Rows[row - 1][col].ToString()
                     };
                     SalesHubData.Add(dtTable4);
                 }
             }
             DataTableCollection SharedCalendarCollection = ConvertData(SalesHubFile);
             DataTable SharedCalendarTable = SharedCalendarCollection["Table1"];
             for (int row = 1; row <= SharedCalendarTable.Rows.Count; row++)
             {
                 for (int col = 0; col < SharedCalendarTable.Columns.Count; col++)
                 {
                     DataCollection dtTable5 = new DataCollection()
                     {
                         RowNumber = row,
                         ColumnName = SharedCalendarTable.Columns[col].ColumnName,
                         ColumnValue = SharedCalendarTable.Rows[row - 1][col].ToString()
                     };
                     SalesHubData.Add(dtTable5);
                 }
             }
         }

         private static int GetSalesHubRowNumber(string PrimaryKey, string TestCaseID)
         {
             int rowNum = (from rowData in SalesHubData where rowData.ColumnName == PrimaryKey && rowData.ColumnValue == TestCaseID select rowData.RowNumber).SingleOrDefault();
             return rowNum;
         }

         public static string ReadSalesHubData(string PrimaryKeyValue, string TestCaseID, string ColumnName)
         {
             try
             {
                 string InputData = (from ColumnData in SalesHubData where ColumnData.ColumnName == ColumnName && ColumnData.RowNumber == GetSalesHubRowNumber(PrimaryKeyValue, TestCaseID) select ColumnData.ColumnValue).SingleOrDefault();
                 return InputData;
             }
             catch(Exception)
             {
                 return null;
             }
         }

         private static int GetSalesRowNumber(string PrimaryKey, string TestCaseID)
         {
             int rowNum = (from rowData in SalesData where rowData.ColumnName == PrimaryKey && rowData.ColumnValue == TestCaseID select rowData.RowNumber).SingleOrDefault();
             return rowNum;
         }

         public static string ReadSalesData(string PrimaryKeyValue, string TestCaseID, string ColumnName)
         {
             try
             {
                 string InputData = (from ColumnData in SalesData where ColumnData.ColumnName == ColumnName && ColumnData.RowNumber == GetSalesRowNumber(PrimaryKeyValue, TestCaseID) select ColumnData.ColumnValue).SingleOrDefault();
                 return InputData;
             }
             catch (Exception)
             {
                 return null;
             }
         }

         private static int GetLoginRowNumber(string PrimaryKey, string TestCaseID)
         {
             int rowNum = (from rowData in LoginData where rowData.ColumnName == PrimaryKey && rowData.ColumnValue == TestCaseID select rowData.RowNumber).SingleOrDefault();
             return rowNum;
         }

         public static string ReadLoginData(string PrimaryKeyValue, string Responsibility, string ColumnName)
         {
             try
             {
                 string InputData = (from ColumnData in LoginData where ColumnData.ColumnName == ColumnName && ColumnData.RowNumber == GetLoginRowNumber(PrimaryKeyValue, Responsibility) select ColumnData.ColumnValue).SingleOrDefault();
                 return InputData;
             }
             catch (Exception)
             {
                 return null;
             }
         }

         private static int GetSharedCalendarRowNumber(string PrimaryKey, string TestCaseID)
         {
             int rowNum = (from rowData in SalesHubData where rowData.ColumnName == PrimaryKey && rowData.ColumnValue == TestCaseID select rowData.RowNumber).SingleOrDefault();
             return rowNum;
         }

         public static string ReadSharedCalendarData(string PrimaryKeyValue, string TestCaseID, string ColumnName)
         {
             try
             {
                 string InputData = (from ColumnData in SalesHubData where ColumnData.ColumnName == ColumnName && ColumnData.RowNumber == GetSharedCalendarRowNumber(PrimaryKeyValue, TestCaseID) select ColumnData.ColumnValue).SingleOrDefault();
                 return InputData;
             }
             catch (Exception)
             {
                 return null;
             }
         }

         private static int GetEnvRowNumber(string PrimaryKey, string TestCaseID)
         {
             int rowNum = (from rowData in EnvironmentData where rowData.ColumnName == PrimaryKey && rowData.ColumnValue == TestCaseID select rowData.RowNumber).SingleOrDefault();
             return rowNum;
         }

         public static string ReadEnvironmentData(string PrimaryKeyValue, string Environment, string ColumnName)
         {
             try
             {
                 string InputData = (from ColumnData in EnvironmentData where ColumnData.ColumnName == ColumnName && ColumnData.RowNumber == GetEnvRowNumber(PrimaryKeyValue, Environment) select ColumnData.ColumnValue).SingleOrDefault();
                 return InputData;
             }
             catch (Exception)
             {
                 return null;
             }
         }
        }*/
    }
    }
