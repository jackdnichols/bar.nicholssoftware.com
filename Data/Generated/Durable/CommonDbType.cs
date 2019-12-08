/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System;
using System.Collections.Generic;
using System.Text;

namespace OxyData.Data
{
    /// <summary>
    /// Specifies a common database type system to enable more accurate typemapping
    /// </summary>
    public enum CommonDbType
    {
        None,
        /// <summary>
        /// A variable-length stream of non-Unicode characters ranging between 1 and 8,000 characters. For Varchar(MAX), the length should be -1
        /// </summary>
        AnsiString,

        /// <summary>
        /// A fixed-length stream of non-Unicode characters.
        /// </summary>
        AnsiStringFixedLength,

        /// <summary>
        /// A variable-length stream of non-Unicode characters with unknown length (SqlDbTypes: Text).
        /// </summary>
        AnsiText,

        /// <summary>
        /// Fixed length binary
        /// </summary>
        Binary,

        /// <summary>
        /// A simple type representing Boolean values of true or false.
        /// </summary>
        Boolean,

        /// <summary>
        /// An 8-bit unsigned integer ranging in value from 0 to 255.
        /// </summary>
        Byte,

        /// <summary>
        /// A currency value ranging from -2 63 (or -922,337,203,685,477.5808) to 2 63 -1 (or +922,337,203,685,477.5807) with an accuracy to a ten-thousandth of a currency unit.
        /// </summary>
        Currency,

        /// <summary>
        /// Date data ranging in value from January 1,1 AD through December 31, 9999 AD. 
        /// </summary>
        Date,

        /// <summary>
        /// A type representing a date and time value.
        /// </summary>
        DateTime,

        /// <summary>
        /// Date and time data. Date value range is from January 1,1 AD through December 31, 9999 AD. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds
        /// </summary>
        DateTime2,

        /// <summary>
        /// Date and time data with time zone awareness. Date value range is from January 1,1 AD through December 31, 9999 AD. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds. Time zone value range is -14:00 through +14:00
        /// </summary>
        DateTimeOffset,

        /// <summary>
        /// A simple type representing values ranging from 1.0 x 10 -28 to approximately 7.9 x 10 28 with 28-29 significant digits.
        /// </summary>
        Decimal,

        /// <summary>
        /// A floating point type representing values ranging from - 1.79E+308 to -2.23E-308, 0 and 2.23E-308 to 1.79E+308
        /// </summary>
        Float,

        /// <summary>
        /// A globally unique identifier (or GUID).
        /// </summary>
        Guid,

        /// <summary>
        /// An integral type representing signed 16-bit integers with values between -32768 and 32767.
        /// </summary>
        Int16,

        /// <summary>
        /// An integral type representing signed 32-bit integers with values between -2147483648 and 2147483647.
        /// </summary>
        Int32,

        /// <summary>
        /// An integral type representing signed 64-bit integers with values between -9223372036854775808 and 9223372036854775807
        /// </summary>
        Int64,

        /// <summary>
        /// Variable-length binary data (Sql Server 2000)
        /// </summary>
        Image,

        /// <summary>
        /// A floating point type representing values ranging from approximately 1.5 x 10 -45 to 3.4 x 10 38 with a precision of 7 digits.
        /// </summary>
        Single,

        /// <summary>
        /// A type representing a date and time value but with lower precision than 'DateTime'
        /// </summary>
        SmallDateTime,

        /// <summary>
        /// A currency value but with lower precision than 'Currency'
        /// </summary>
        SmallCurrency,

        /// <summary>
        /// SQL Server 2008 geography
        /// </summary>
        SqlGeography,

        /// <summary>
        /// SQL Server 2008 geometry
        /// </summary>
        SqlGeometry,

        /// <summary>
        /// SQL Server 2008 HierarchyId
        /// </summary>
        SqlHierarchyId,

        /// <summary>
        /// A type representing Unicode character strings.
        /// </summary>
        String,

        /// <summary>
        /// A fixed-length string of Unicode characters.
        /// </summary>
        StringFixedLength,

        /// <summary>
        /// A structured user defined type that the Db knows how to handle
        /// </summary>
        StructuredUdt,

        /// <summary>
        /// A general type representing any reference or value type not explicitly represented by another DbType value.
        /// </summary>
        Object,

        /// <summary>
        /// A variable-length stream of Unicode characters with unknown length (SqlDbTypes: NText).
        /// </summary>
        UnicodeText,

        /// <summary>
        /// An automatically generated, unique value. This is generally used as a mechanism for version-stamping table rows.
        /// </summary>
        TimeStamp,

        /// <summary>
        /// Time data based on a 24-hour clock. Time value range is 00:00:00 through 23:59:59.9999999 with an accuracy of 100 nanoseconds.
        /// </summary>
        Time,

        /// <summary>
        /// A generic user defined type
        /// </summary>
        UserDefinedType,

        /// <summary>
        /// Variable-length binary data of unknown length
        /// </summary>
        VarBinary,

        /// <summary>
        /// A variable-length numeric value.
        /// </summary>
        VarNumeric,

        /// <summary>
        /// A parsed representation of an XML document or fragment.
        /// </summary>
        Xml,

        /// <summary>
        /// An oracle timestamp
        /// </summary>
        OracleTimeStamp,

        /// <summary>
        /// An oracle timestamp with local time zone
        /// </summary>
        OracleTimeStampLTZ,

        /// <summary>
        /// An oracle timestamp with time zone
        /// </summary>
        OracleTimeStampTZ,

        /// <summary>
        /// Hexadecimal string representing the logical address of a row in its table.
        /// </summary>
        OracleURowId,

        /// <summary>
        /// Hexadecimal string representing the unique address of a row in its table.
        /// </summary>
        OracleRowId,
        /// <summary>
        /// A database cursor that is used to read individual rows directly from the database
        /// </summary>
        RowsetOutCursor
    }
}