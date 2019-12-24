/*------------------------------------------------------------------------------
// <copyright company="TECH-IS INC.">
//     Copyright (c) TECH-IS INC.  All rights reserved.
//     Please read license file: http://www.OxyGenCode.com/licence/TECH-IS%20INC%20PUBLIC%20LICENCE.rtf
// </copyright>
//----------------------------------------------------------OCG Version: 3.7.0.0*/
using System;
using System.Collections.Generic;
using System.Text;

namespace OxyData.Data.Caching
{
    public partial class SQLStatementInfo
    {
        #region Fields 
        private string          _Text;
        private string          _TableName;
        private string[]        _ColumnNames;
        private Guid            _Key;
        #endregion

        #region Properties 
        public Guid Key
        {
            get 
            { 
                return _Key; 
            }
            set 
            { 
                _Key = value; 
            }
        }

        public string[] ColumnNames
        {
            get 
            { 
                return _ColumnNames; 
            }
            set 
            { 
                _ColumnNames = value; 
            }
        }

        public string TableName
        {
            get 
            { 
                return _TableName; 
            }
            set 
            { 
                _TableName = value; 
            }
        }

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        #endregion

        #region Constructors
        public SQLStatementInfo(SQLStatementInfo sqlStatementInfo)
        {
            if (sqlStatementInfo==null)
            {
                throw new ArgumentException("sqlStatementInfo");
            }

            if (string.IsNullOrEmpty(sqlStatementInfo.Text))
                throw new ArgumentException("sqlStatementInfo.Text");

            if (string.IsNullOrEmpty(sqlStatementInfo.TableName))
                throw new ArgumentException("sqlStatementInfo.TableName");

            if (sqlStatementInfo.Key == Guid.Empty)
                throw new ArgumentException("sqlStatementInfo.Key");

            if (sqlStatementInfo.ColumnNames == null)
                throw new ArgumentException("sqlStatementInfo.ColumnNames");

            _Text           = sqlStatementInfo.Text;
            _TableName      = sqlStatementInfo.TableName;
            _Key            = sqlStatementInfo.Key;
            _ColumnNames    = sqlStatementInfo.ColumnNames;

        }

        public SQLStatementInfo(string text, string tableName, Guid key, string[] columnNames)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("text");

            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentException("tableName");

            if (Guid.Empty == key)
                throw new ArgumentException("key");

            if (columnNames == null)
                throw new ArgumentException("columnNames");

            _Text           = text;
            _TableName      = tableName;
            _Key            = key;
            _ColumnNames    = columnNames;

        }
        #endregion
    }
}