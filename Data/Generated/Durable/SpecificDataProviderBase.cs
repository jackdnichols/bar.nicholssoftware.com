/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using OxyData.Data;

namespace OxyData.Data
{
    /// <summary>
    /// Encapsulates data packaging and transformation tasks needed to send data to, and receive data from the database.
    /// </summary>
    public abstract class SpecificDataProviderBase:CommonDataProviderBase
    {

        #region Properties 
        /// <summary>
        /// The name of the DBMS Provider Factory.
        /// Change this to read from a config file if you want to point to a different DBMS
        /// </summary>
        protected override string DBMSProviderFactoryName
        {
            get
            {
                return "System.Data.SqlClient";
            }
        }
        #endregion

        #region Methods 

        /// <summary>
        /// A Provider specific call to return an XmlReader.
        /// Extend the implementation for different providers
        /// </summary>
        protected override System.Xml.XmlReader ExecuteCommandXmlReader(DbCommand cmd)
        {
            System.Xml.XmlReader xr = ((SqlCommand)cmd).ExecuteXmlReader();
            return xr;
        }

        /// <summary>
        /// Returns a Provider specific DbParameter object.
        /// </summary>
        /// <param name="parameterName">The provider specific name of the parameter</param>
        /// <param name="dbType">The System.Data.DbType representation of the type</param>
        /// <param name="length">The length</param>
        protected override DbParameter GetDbParameter(string parameterName, DbType dbType, int length)
        {
            SqlParameter dbParam = new SqlParameter();
            dbParam.ParameterName = parameterName;
            dbParam.DbType = dbType;
            dbParam.Size = length;
            return dbParam;
        }
        /// <summary>
        /// Returns a Provider specific DbParameter object, the type is inferred from the value. 
        /// You need to change this manually if you change providers
        /// </summary>
        /// <param name="parameterName">The provider specific name of the parameter</param>
        /// <param name="length">The length</param>
        protected override DbParameter GetDbParameter(string parameterName, int length)
        {
            SqlParameter dbParam = new SqlParameter();
            dbParam.ParameterName = parameterName;
            dbParam.Size = length;
            return dbParam;
        }

        /// <summary>
        /// Returns a Provider specific DbParameter object.
        /// </summary>
        /// <param name="parameterName">The provider specific name of the parameter</param>
        /// <param name="dbType">The provider specific db type as an int</param>
        /// <param name="length">The length</param>
        protected override DbParameter GetDbParameter(string parameterName, CommonDbType dbType, int length)
        {
            return new SqlParameter(parameterName, GetDbType(dbType), length);
        }

        /// <summary>
        /// Returns a Provider specific DbParameter object. The DbParameter is created specifically for User Defined Types
        /// </summary>
        protected override DbParameter GetDbParameterForUdt(string parameterName, CommonDbType dbType, string userDefinedName, int length)
        {
            SqlParameter dbParam = new SqlParameter();
            dbParam.ParameterName = parameterName;
            dbParam.Size = length;

            dbParam.SqlDbType = GetDbType(dbType);
            dbParam.UdtTypeName = userDefinedName;

            return dbParam;
        }

        /// <summary>
        /// Returns a Provider specific DbParameter object. The DbParameter is created specifically for Structured types (i.e., Table-Valued Parameters)
        /// </summary>
        protected override DbParameter GetDbParameterForStructured(string parameterName, CommonDbType dbType, string userDefinedName)
        {
            SqlParameter dbParam = new SqlParameter();
            dbParam.ParameterName = parameterName;

            dbParam.SqlDbType = GetDbType(dbType);
            dbParam.TypeName = userDefinedName;

            return dbParam;
        }

        /// <summary>
        /// Returns a Provider specific DbParameter object. The DbParameter is created specifically for User Defined Types
        /// </summary>
        protected override DbParameter GetDbParameterForUdt(string parameterName, CommonDbType dbType, string userDefinedName)
        {
            SqlParameter dbParam = new SqlParameter();
            dbParam.ParameterName = parameterName;

            dbParam.SqlDbType = GetDbType(dbType);
            dbParam.UdtTypeName = userDefinedName;

            return dbParam;
        }

        /// <summary>
        /// Returns a Provider specific DbParameter object.
        /// </summary>
        /// <param name="parameterName">The provider specific name of the parameter</param>
        /// <param name="dbType">The provider specific db type as an int</param>
        protected override DbParameter GetDbParameter(string parameterName, CommonDbType dbType)
        {
            return new SqlParameter(parameterName, GetDbType(dbType));
        }

        /// <summary>
        /// Returns a Provider specific DbParameter object, the type is inferred from the value. You need to change this manually if you change providers
        /// </summary>
        /// <param name="parameterName">The provider specific name of the parameter</param>
        protected override DbParameter GetDbParameter(string parameterName)
        {
            SqlParameter dbParam = new SqlParameter();
            dbParam.ParameterName = parameterName;
            return dbParam;
        }

        /// <summary>
        /// Converts the CommonDbType to the Provider Specific DbType
        /// </summary>
        protected internal SqlDbType GetDbType(CommonDbType dbType)
        {
            SqlDbType val;
            switch (dbType)
            {
                case CommonDbType.UserDefinedType:
                    val = SqlDbType.Udt;
                    break;
                case CommonDbType.StructuredUdt:
                    val = SqlDbType.Structured;
                    break;

                case CommonDbType.Date:
                    val = SqlDbType.Date;
                    break;

                case CommonDbType.Time:
                    val = SqlDbType.Time;
                    break;

                case CommonDbType.SqlGeography:
                    val = SqlDbType.Udt;
                    break;

                case CommonDbType.SqlGeometry:
                    val = SqlDbType.Udt;
                    break;

                case CommonDbType.SqlHierarchyId:
                    val = SqlDbType.Udt;
                    break;

                case CommonDbType.AnsiString:
                    val = SqlDbType.VarChar;
                    break;

                case CommonDbType.AnsiStringFixedLength:
                    val = SqlDbType.Char;
                    break;

                case CommonDbType.AnsiText:
                    val = SqlDbType.Text;
                    break;

                case CommonDbType.Binary:
                    val = SqlDbType.Binary;
                    break;

                case CommonDbType.Boolean:
                    val = SqlDbType.Bit;
                    break;

                case CommonDbType.Byte:
                    val = SqlDbType.TinyInt;
                    break;

                case CommonDbType.Currency:
                    val = SqlDbType.Money;
                    break;

                case CommonDbType.DateTime:
                    val = SqlDbType.DateTime;
                    break;

                case CommonDbType.DateTime2:
                    val = SqlDbType.DateTime2;
                    break;

                case CommonDbType.DateTimeOffset:
                    val = SqlDbType.DateTimeOffset;
                    break;

                case CommonDbType.Decimal:
                    val = SqlDbType.Decimal;
                    break;

                case CommonDbType.Float:
                    val = SqlDbType.Float;
                    break;

                case CommonDbType.Guid:
                    val = SqlDbType.UniqueIdentifier;
                    break;

                case CommonDbType.Int16:
                    val = SqlDbType.SmallInt;
                    break;

                case CommonDbType.Int32:
                    val = SqlDbType.Int;
                    break;

                case CommonDbType.Int64:
                    val = SqlDbType.BigInt;
                    break;

                case CommonDbType.Image:
                    val = SqlDbType.Image;
                    break;

                case CommonDbType.Single:
                    val = SqlDbType.Real;
                    break;

                case CommonDbType.SmallDateTime:
                    val = SqlDbType.SmallDateTime;
                    break;

                case CommonDbType.SmallCurrency:
                    val = SqlDbType.SmallMoney;
                    break;

                case CommonDbType.String:
                    val = SqlDbType.NVarChar;
                    break;

                case CommonDbType.StringFixedLength:
                    val = SqlDbType.NChar;
                    break;

                case CommonDbType.Object:
                    val = SqlDbType.Variant;
                    break;

                case CommonDbType.UnicodeText:
                    val = SqlDbType.NText;
                    break;

                case CommonDbType.TimeStamp:
                    val = SqlDbType.Timestamp;
                    break;

                case CommonDbType.VarBinary:
                    val = SqlDbType.VarBinary;
                    break;

                case CommonDbType.VarNumeric:
                    val = SqlDbType.Variant;
                    break;

                case CommonDbType.Xml:
                    val = SqlDbType.Xml;
                    break;

                case CommonDbType.None:
                    throw new ArgumentException("dbType was not specified", "dbType");

                default:
                    throw new InvalidOperationException(string.Format("Type {0} is unknown", dbType));
            }

            return val;
        }


        /// <summary>
        /// Converts the CommonDbType to the System.Data.DbType
        /// </summary>
        protected internal DbType GetGenericDbType(CommonDbType dbType)
        {
            DbType val;
            switch (dbType)
            {
                case CommonDbType.UserDefinedType:
                    val = DbType.Object;
                    break;
                case CommonDbType.StructuredUdt:
                    val = DbType.Object;
                    break;

                case CommonDbType.Date:
                    val = DbType.Date;
                    break;

                case CommonDbType.Time:
                    val = DbType.Time;
                    break;

                case CommonDbType.SqlGeography:
                    val = DbType.Object;
                    break;

                case CommonDbType.SqlGeometry:
                    val = DbType.Object;
                    break;

                case CommonDbType.SqlHierarchyId:
                    val = DbType.Object;
                    break;

                case CommonDbType.AnsiString:
                    val = DbType.AnsiString;
                    break;

                case CommonDbType.AnsiStringFixedLength:
                    val = DbType.AnsiStringFixedLength;
                    break;

                case CommonDbType.AnsiText:
                    val = DbType.String;
                    break;

                case CommonDbType.Binary:
                    val = DbType.Binary;
                    break;

                case CommonDbType.Boolean:
                    val = DbType.Boolean;
                    break;

                case CommonDbType.Byte:
                    val = DbType.Byte;
                    break;

                case CommonDbType.Currency:
                    val = DbType.Currency;
                    break;

                case CommonDbType.DateTime:
                    val = DbType.DateTime;
                    break;

                case CommonDbType.DateTime2:
                    val = DbType.DateTime2;
                    break;

                case CommonDbType.DateTimeOffset:
                    val = DbType.DateTimeOffset;
                    break;

                case CommonDbType.Decimal:
                    val = DbType.Decimal;
                    break;

                case CommonDbType.Float:
                    val = DbType.Single;
                    break;

                case CommonDbType.Guid:
                    val = DbType.Guid;
                    break;

                case CommonDbType.Int16:
                    val = DbType.Int16;
                    break;

                case CommonDbType.Int32:
                    val = DbType.Int32;
                    break;

                case CommonDbType.Int64:
                    val = DbType.Int64;
                    break;

                case CommonDbType.Image:
                    val = DbType.Binary;
                    break;

                case CommonDbType.Single:
                    val = DbType.Single;
                    break;

                case CommonDbType.SmallDateTime:
                    val = DbType.DateTime;
                    break;

                case CommonDbType.SmallCurrency:
                    val = DbType.Currency;
                    break;

                case CommonDbType.String:
                    val = DbType.String;
                    break;

                case CommonDbType.StringFixedLength:
                    val = DbType.StringFixedLength;
                    break;

                case CommonDbType.Object:
                    val = DbType.Object;
                    break;

                case CommonDbType.UnicodeText:
                    val = DbType.String;
                    break;

                case CommonDbType.TimeStamp:
                    val = DbType.Object;
                    break;

                case CommonDbType.VarBinary:
                    val = DbType.Binary;
                    break;

                case CommonDbType.VarNumeric:
                    val = DbType.Object;
                    break;

                case CommonDbType.Xml:
                    val = DbType.Xml;
                    break;

                case CommonDbType.None:
                    throw new ArgumentException("dbType was not specified", "dbType");

                default:
                    throw new InvalidOperationException(string.Format("Type {0} is unknown", dbType));
            }

            return val;
        }
        #endregion

    }
}