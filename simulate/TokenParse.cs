//****************************************************************************
//  File:      TokenParse.cs
// ------------------------------------------------
//  Copyright (c) kamaba233@gmail.com
//  DateTime: 2022/12/26 12:00:00
//  Description: 
//****************************************************************************

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
