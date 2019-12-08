using System;
using System.Collections.Generic;

using System.Text;
using System.Threading;

namespace OxyData.Data 
{
    public class DbStatementModificationManager
    {
        #region constants 
        public const string KEY_MODIFICATIONSTORE = "BA070BEAE3354321A8D42EBC1E23A568";
        #endregion

        public static void ExposeModificationInfoDataProvider(StatementModificationInfo smi)
        {
            LocalDataStoreSlot modificationData = Thread.GetNamedDataSlot(KEY_MODIFICATIONSTORE);
            Thread.SetData(modificationData, smi);
        }


        internal static StatementModificationInfo GetModificationInfo()
        {
            LocalDataStoreSlot modificationData = Thread.GetNamedDataSlot(KEY_MODIFICATIONSTORE);
            StatementModificationInfo smi = (StatementModificationInfo)Thread.GetData(modificationData);

            return smi;
        }

        internal static string ModifyDbStatement(string statementName, string originalStatement)
        {
            string val=originalStatement;

            StatementModificationInfo smi = GetModificationInfo();
            if (smi != null && smi.Modifiers != null && smi.Modifiers.Count > 0 )
            {
                foreach (DbStatementModifierBase modifier in smi.Modifiers.Values)
                {
                    if (statementName.Equals(modifier.StatementName, StringComparison.Ordinal))
                    {
                        val = modifier.ProcessStatement(val);
                    }
                }
            }

            return val;
        }

    }
}
