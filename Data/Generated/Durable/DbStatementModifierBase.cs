using System;
using System.Collections.Generic;

using System.Text;

namespace OxyData.Data 
{
    public abstract class  DbStatementModifierBase
    {
        public abstract string ModificationTypeKey { get; }
        public abstract string ProcessStatement(string originalStatement);
        public abstract bool IsValid { get; }

        private string _StatementName;
        public string StatementName
        {
            get { return _StatementName; }
            set { _StatementName = value; }
        }

        public void AddToModificationManager()
        {
            if (IsValid)
            {
                StatementModificationInfo smInfo = DbStatementModificationManager.GetModificationInfo();
                if (smInfo == null)
                {
                    smInfo = new StatementModificationInfo();
                }

                smInfo.Modifiers[ModificationTypeKey] = this;
                DbStatementModificationManager.ExposeModificationInfoDataProvider(smInfo);
            }
        }
    }
}