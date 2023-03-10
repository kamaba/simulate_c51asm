//****************************************************************************
//  File:      MetaStatements.cs
// ------------------------------------------------
//  Copyright (c) kamaba233@gmail.com
//  DateTime: 2022/8/12 12:00:00
//  Description: 
//****************************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAsm.Statements
{
    public partial class StatementsBase
    {
        public StatementsBase nextStatements => m_NextStatements;

        private StatementsBase m_NextStatements = null;

        public StatementsBase()
        { 
        }

        public virtual void SetNextStatements(StatementsBase ms )
        {
            m_NextStatements = ms;
        }
    }
}
