using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

// 「参照」->「参照の追加...」
//  ->「アセンブリ」->「フレームワーク」
//  -> Checked 「Microsoft.VisualBasic」
using Microsoft.VisualBasic.FileIO;

namespace ConsoleApp
{
    public class CSVReader : IDataReader
    {
        private TextFieldParser parser_;
        private DataTable table_;
        private string line_;
        private bool closed_;
        private string[] fields_;
        private string[] values_;

        public CSVReader(string fileName, DataTable table)
        {
            parser_ = new TextFieldParser(fileName, System.Text.Encoding.UTF8);
            parser_.TextFieldType = FieldType.Delimited;
            parser_.SetDelimiters(",");
            parser_.HasFieldsEnclosedInQuotes = false;

            fields_ = parser_.ReadFields();

            table_ = table;

            closed_ = false;
        }

        int IDataReader.Depth
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool IDataReader.IsClosed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        int IDataReader.RecordsAffected
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        int IDataRecord.FieldCount
        {
            get
            {
                return fields_.Length;
            }
        }

        object IDataRecord.this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object IDataRecord.this[int i]
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        void IDataReader.Close()
        {
            throw new NotImplementedException();
        }

        DataTable IDataReader.GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        bool IDataReader.NextResult()
        {
            throw new NotImplementedException();
        }

        bool IDataReader.Read()
        {
            if (parser_.EndOfData)
            {
                return false;
            }
            values_ = parser_.ReadFields();
            return true;
        }

        void IDisposable.Dispose()
        {
            if (parser_ != null)
            {
                parser_.Dispose();
            }
        }

        string IDataRecord.GetName(int i)
        {
            throw new NotImplementedException();
        }

        string IDataRecord.GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        Type IDataRecord.GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        object IDataRecord.GetValue(int i)
        {
            if (table_.Columns[i].DataType == typeof(string)) {
                return values_[i];
            }
            else if (table_.Columns[i].DataType == typeof(float))
            {
                return float.Parse(values_[i]);
            }
            else if (table_.Columns[i].DataType == typeof(Int32))
            {
                return Int32.Parse(values_[i]);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        int IDataRecord.GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        int IDataRecord.GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        bool IDataRecord.GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        byte IDataRecord.GetByte(int i)
        {
            throw new NotImplementedException();
        }

        long IDataRecord.GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        char IDataRecord.GetChar(int i)
        {
            throw new NotImplementedException();
        }

        long IDataRecord.GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        Guid IDataRecord.GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        short IDataRecord.GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        int IDataRecord.GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        long IDataRecord.GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        float IDataRecord.GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        double IDataRecord.GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        string IDataRecord.GetString(int i)
        {
            throw new NotImplementedException();
        }

        decimal IDataRecord.GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        DateTime IDataRecord.GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        IDataReader IDataRecord.GetData(int i)
        {
            throw new NotImplementedException();
        }

        bool IDataRecord.IsDBNull(int i)
        {
            throw new NotImplementedException();
        }
    }
}
