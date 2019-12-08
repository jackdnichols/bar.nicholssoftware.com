using System;
using System.Collections.Generic;

using System.Text;

namespace OxyData.Data
{
    [Serializable]
    public class StatementModificationInfo
    {
        #region Fields
        private string _StatementName;
        private Dictionary<string, DbStatementModifierBase> _Modifiers;
        #endregion

        #region Properties
        public Dictionary<string, DbStatementModifierBase> Modifiers
        {
            get { return _Modifiers; }
            set { _Modifiers = value; }
        }

        public string StatementName
        {
            get { return _StatementName; }
            set { _StatementName = value; }
        }
        #endregion

        #region Constructors
        public StatementModificationInfo()
        {
            _Modifiers = new Dictionary<string, DbStatementModifierBase>(1);
        }
        #endregion

    }
}
