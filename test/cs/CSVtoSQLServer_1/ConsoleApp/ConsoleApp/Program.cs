/*
 * CSV to SQLServer sample
 * 
 * CSVの読み込みは、TextFieldParserクラスを使用しています。
 * 
 * 2016.09.18
 */
/*
 * INSERTするSQLServerのテーブルは下記のもの。
CREATE TABLE [dbo].[Table_1](
	[NO] [int] NOT NULL,
	[col_name] [nvarchar](50) NOT NULL,
	[col_value] [real] NOT NULL,
	[col_null_value] [nchar](10) NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
*/ 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string conStr = @"Data Source=KATY-HOME-PC\SQLEXPRESS; Initial Catalog = TEST_ROBO; Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
 
                // INSERTするテーブルの定義を作成する。
                // DataTableである必要はありません。
                // 最小限にするなら、型の配列だけでも良い。
                DataTable table = new DataTable("Table_1");
                table.Columns.Add("NO", typeof(int));
                table.Columns.Add("col_name", typeof(string));
                table.Columns.Add("col_value", typeof(float));
                table.Columns.Add("col_null_value", typeof(string));

                using (CSVReader reader = new CSVReader(@"D:\test.txt", table))
                {
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(connection);
                    bulkCopy.DestinationTableName = "Table_1";
                    bulkCopy.BatchSize = 10000;

                    bulkCopy.WriteToServer(reader);

                    bulkCopy.Close();
                }

            }
        }
    }
}
