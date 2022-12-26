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
    public partial class Statements
    {
        public Statements nextStatements => m_NextStatements;

        private Statements m_NextStatements = null;

        public Statements()
        { 
        }

        public virtual void SetNextStatements(Statements ms )
        {
            m_NextMetaStatements = ms;
        }
    }
}
