//****************************************************************************
//  File:      JumpStatements.cs
// ------------------------------------------------
//  Copyright (c) kamaba233@gmail.com
//  DateTime: 2022/12/26 12:00:00
//  Description: 
//****************************************************************************

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SimpleAsm.Statements
{
    public class NopStatements : StatementsBase
    {
        Token m_Token = null;
        public NopStatements(Token token)
        {
            m_Token = token;
        }
    }
    public class LabelStatements : StatementsBase
    {
        Token m_Token = null;
        public LabelStatements(Token token)
        {
            m_Token = token;
        }
    }
    public enum EJumpOp
    {
        AJmp,
        SJmp,
        LJmp,
        Jmp,
        Jz,
        Jnz,
    }
    public class JumpStatements : StatementsBase
    {
        public JumpStatements(EJumpOp eJumpOp, ValueData vd)
        {

        }
    }
    public enum ECallOp
    {
        ACall,
        LCall,
    }
    public class CallStatements : StatementsBase
    {
        public CallStatements(ECallOp eCallOp, ValueData vd)
        {

        }
    }

    public enum ERetOp
    {
        Ret,
        RetI
    }
    public class RetStatements : StatementsBase
    {
        public RetStatements(ERetOp eRetOp, ValueData vd)
        {

        }
    }
}
