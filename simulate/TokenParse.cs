//****************************************************************************
//  File:      TokenParse.cs
// ------------------------------------------------
//  Copyright (c) kamaba233@gmail.com
//  DateTime: 2022/12/26 12:00:00
//  Description: 
//****************************************************************************

using SimpleAsm.Statements;
using System;
using System.Collections.Generic;

namespace SimpleAsm.Parse
{
    /// <summary> 解析token </summary>
    public class TokenParse
    {
        List<Token> m_TokensList = null;
        private int m_TokenIndex = 0;
        private int m_TokenCount = 0;

        List<StatementsBase> m_Statements = new List<StatementsBase>();
        public TokenParse(List<Token> list)
        {
            m_TokensList = list;
        }
        public void BuildStruct()
        {
            ParseToken();

            BuildEnd();
        }
        void ParseToken()
        {
            while (true)
            {
                var tempToken = m_TokensList[m_TokenIndex];
                if (tempToken.type == ETokenType.Finished) { break; }
                ParseDetailToken(tempToken);
            }
        }
        public void BuildEnd()
        {
            // Console.WriteLine(m_RootNode.ToFormatString());
            Console.WriteLine("----------------------------------------");
        }
        void ParseDetailToken(Token token)
        {
            switch (token.type)
            {
                case ETokenType.Org: 
                    {
                        Token valToken = m_TokensList[++m_TokenIndex];
                        ValueData vd = new ValueData(valToken);

                        AddressOpStatements aos = new AddressOpStatements(EAddrOp.Org, vd);

                        m_Statements.Add(aos);
                    }
                    break;
                case ETokenType.AJmp:
                case ETokenType.SJmp:
                case ETokenType.LJmp:
                    {
                        EJumpOp ejo = EJumpOp.AJmp;
                        Token valToken = m_TokensList[++m_TokenIndex];
                        ValueData vd = new ValueData(valToken);
                        if ( token.type == ETokenType.SJmp )
                        {
                            ejo = EJumpOp.SJmp;
                        }
                        else if( token.type == ETokenType.LJmp )
                        {
                            ejo = EJumpOp.LJmp;
                        }
                        else
                        {

                        }
                        JumpStatements js = new JumpStatements(ejo, vd);
                        m_Statements.Add(js);
                    }
                    break;
                case ETokenType.Label:
                    {
                        LabelStatements ls = new LabelStatements(token);
                        m_Statements.Add(ls);
                    }
                    break;
                case ETokenType.Nop:
                    {
                        NopStatements ns = new NopStatements(token);
                        m_Statements.Add(ns);
                    }
                    break;
                default:
                    {
                        Console.WriteLine("不支持的语法: Line:{0} Source: {1}", token.sourceBeginLine,
                            token.sourceBeginChar);
                        throw new Exception("不支持的语法 ");
                    }
            }
        }
    }
}
