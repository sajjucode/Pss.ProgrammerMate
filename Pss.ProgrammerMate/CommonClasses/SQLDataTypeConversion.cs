using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pss.ProgrammerMate.CommonClasses
{
    /// <summary>
    /// use to Convert SQL Data Type to C# Types
    /// </summary>
    public class SQLDataTypeConversion
    {
        public static string getType(string SQl_DataType)
        {
            try
            {

                switch (SQl_DataType.ToLower())
                {
                    case "int":
                        return "int";
                    case "bigint":
                        return "Int64";
                    case "decimal":
                        return "Decimal";
                    case "sigle":
                        return "Single";
                    case "varchar":
                        return "string";
                    case "datetime":
                        return "DateTime";
                    case "nvarchar":
                        return "string";
                    case "text":
                        return "string";
                    case "bit":
                        return "Boolean";
                    case "image":
                        return "Byte[]";
                    default:
                        return SQl_DataType;

                }
            }
            catch (Exception ex)
            {
                return SQl_DataType;
            }
        }

        public static string getDataType(string DataType)
        {
            try
            {
                switch (DataType.ToLower())
                {
                    case "int":
                        return "int?";
                    case "bigint":
                        return "Int64?";
                    case "single":
                        return "Single?";
                    case "decimal":
                        return "Decimal?";
                    case "datetime":
                        return "DateTime?";
                    case "bit":
                        return "Boolean?";
                    case "image":
                        return "Byte[]?";
                    default:
                        return DataType;

                }
            }
            catch (Exception ex)
            {
                return DataType;
            }
        }

        public static string getParametersDataType_MsSql(string DataType)
        {
            try
            {
                switch (DataType.ToLower())
                {
                    case "nvarchar":
                        return "NVarChar";
                    case "bigint":
                        return "BigInt";
                    case "int":
                        return "Int";
                    case "decimal":
                        return "Decimal";
                    case "datetime":
                        return "DateTime";
                    case "bit":
                        return "Bit";
                    case "varchar":
                        return "VarChar";
                    case "binary":
                        return "Binary";
                    case "char":
                        return "Char";
                    case "date":
                        return "Date";
                    case "float":
                        return "Float";
                    case "image":
                        return "Image";
                    case "read":
                        return "Real";
                    case "text":
                        return "Text";
                    case "timestamp":
                        return "TimeStamp";
                    case "tinyint":
                        return "TinyInt";
                    case "xml":
                        return "Xml";
                    default:
                        return DataType;

                }
            }
            catch (Exception ex)
            {
                return DataType;
            }
        }
    }
}
