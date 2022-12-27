//****************************************************************************
//  File:      StackStatements.cs
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
    public enum EAddrOp
    {
        Org,
    }
    public class AddressOpStatements : StatementsBase
    {
        public AddressOpStatements(EAddrOp eAddrOp, ValueData vd )
        {

        }
    }
}
