//****************************************************************************
//  File:      LexerParse.cs
// ------------------------------------------------
//  Copyright (c) kamaba233@gmail.com
//  DateTime: 2022/5/12 12:00:00
//  Description: 
//****************************************************************************

using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAsm.Parse
{
    //词法解析
    public class LexerParse
    {
        public List<Token> listTokens => m_ListTokens;
        public List<Token> GetListTokensWidthEnd()
        {
            List<Token> withEndList = new List<Token>(m_ListTokens);
            withEndList.Add(new Token(m_Path, ETokenType.Finished, END_CHAR, m_SourceLine, m_SourceChar));
            return withEndList;
        }

        const char END_CHAR = char.MaxValue;    //结尾字符

        private char m_CurChar;                              //当前字符
        private char m_TempChar;                             //临时字符
        private StringBuilder m_Builder = new StringBuilder();
        private List<Token> m_ListTokens = new List<Token>();
        private string m_Buffer;                    
        private int m_Length = 0;                      
        private int m_SourceLine = 0;                  //解析到当前的行数
        private int m_SourceChar = 0;                  //解析到当前行中的位置
        private int m_Index = 0;                       
        private string m_Path;
        public LexerParse( string path, string buffer )
        {
            m_Path = path;
            m_Buffer = buffer;
            m_Length = buffer.Length;
        }
        public void SetSourcePosition( int line, int _char )
        {
            m_SourceLine = line;
            m_SourceChar = _char;
        }
        char ReadChar()
        {
            ++m_Index;
            ++m_SourceChar;
            if (m_Index < m_Length)
            {
                return m_Buffer[m_Index];
            }
            else if (m_Index == m_Length)
            {
                return END_CHAR;
            }

            return char.MinValue;
            
        }
        char PeekChar()
        {
            int index = m_Index + 1;
            if (index < m_Length)
            {
                return m_Buffer[index];
            }
            else if (index == m_Length)
            {
                return END_CHAR;
            }
            return char.MinValue;
            //throw new LexerException(this, "End of source reached.");
        }
        void UndoChar()
        {
            if (m_Index == 0)
            {
                //CompileManager.instance.AddCompileError("Error Cannot undo char beyond start of source.");
                return;
            }
            --m_Index;
            --m_SourceChar;
        }
        void AddLine()
        {
            m_SourceChar = 0;
            ++m_SourceLine;
        }
        void AddToken( ETokenType type)
        {
            AddToken(type, m_CurChar);
        }
        void AddToken( ETokenType type, object lexeme)
        {
            AddToken(type, lexeme, m_SourceLine, m_SourceChar);
        }
        void AddToken( ETokenType type, object lexeme, object extend )
        {
            AddToken(type, lexeme, extend, m_SourceLine, m_SourceChar );
        }
        void AddToken( ETokenType type, object lexeme, int sourceLine, int sourceChar)
        {
            m_ListTokens.Add(new Token(m_Path, type, lexeme, sourceLine, sourceChar));
            m_Builder.Length = 0;
        }
        void AddToken( ETokenType type, object lexeme, object extend, int sourceLine, int sourceChar )
        {
            m_ListTokens.Add(new Token(m_Path, type, lexeme, sourceLine, sourceChar, extend));
            m_Builder.Clear();
        }
        bool IsHexDigit(char c)
        {
            if (char.IsDigit(c))
                return true;
            if ('a' <= c && c <= 'f')
                return true;
            if ('A' <= c && c <= 'F')
                return true;
            return false;
        }
        private bool IsIdentifier(char ch)
        {
            return (ch == '.' || char.IsLetterOrDigit(ch));
        }     
        /// <summary> 读取数字 </summary>
        void ReadNumber()
        {
            m_Builder.Append(m_CurChar);

            do 
            {
                m_TempChar = ReadChar();
                if (char.IsLetterOrDigit(m_TempChar)) 
                {
                    m_Builder.Append(m_TempChar);
                    continue;
                } 
                else
                {
                    break;
                }
            } while (true);

            m_Index++;
            m_SourceChar++;
        } 
        void ReadComment()
        {
            m_Builder.Clear();
            while ( true )
            {
                m_TempChar = ReadChar();
                if ( (m_TempChar == '\n') || m_TempChar == END_CHAR )
                {
                    break;
                }
                
                m_Builder.Append(m_TempChar);
            }
            AddToken(ETokenType.Comment, m_Builder.ToString(), ";");
            m_Index++;
            m_SourceChar++;
            m_SourceLine++;
            m_Builder.Clear();
        }
        /// <summary> 读取关键字 </summary>
        void ReadIdentifier()
        {
            m_Builder.Append(m_CurChar);
            do 
            {
                m_TempChar = ReadChar();
                if (IsIdentifier(m_TempChar)) 
                {
                    m_Builder.Append(m_TempChar);
                }                
                else
                {
                    UndoChar();
                    break;
                }
            } while (true);


            m_TempChar = ReadChar();
            if( m_TempChar == ':' )
            {
                AddToken( ETokenType.Label, m_Builder.ToString() );
                m_Index++;
                m_SourceChar++;
            }
            else
            {
                ETokenType tokenType;
                object extend = null;
                switch (m_Builder.ToString())
                {
                    case "ORG":
                        tokenType = ETokenType.Org;
                        break;

                    case "A":
                        tokenType = ETokenType.A;
                        return;
                    case "B":
                        tokenType = ETokenType.B;
                        return;
                    case "C":
                        tokenType = ETokenType.C;
                        return;
                    case "DPTR":
                        tokenType = ETokenType.Dptr;
                        return;                        
                    case "SP":
                        tokenType = ETokenType.Sp;
                        return;


                    case "MOV":
                        tokenType = ETokenType.Mov;
                        break;
                    case "MOVC":
                        tokenType = ETokenType.MovC;
                        break;
                    case "MOVX":
                        tokenType = ETokenType.MovX;
                        break;
                    case "XCH":
                        tokenType = ETokenType.Xch;
                        break;
                    case "XCHD":
                        tokenType = ETokenType.XchD;
                        break;

                    case "PUSH":
                        tokenType = ETokenType.Push;
                        break;
                    case "POP":
                        tokenType = ETokenType.Pop;
                        break;

                    case "ADD":
                        tokenType = ETokenType.Add;
                        break;
                    case "INC":
                        tokenType = ETokenType.Inc;
                        break;
                    case "ADDC":
                        tokenType = ETokenType.AddC;
                        break;
                    case "SUB":
                        tokenType = ETokenType.Sub;
                        break;
                    case "DEC":
                        tokenType = ETokenType.Dec;
                        break;
                    case "MUL":
                        tokenType = ETokenType.Mul;
                        break;
                    case "DIV":
                        tokenType = ETokenType.Div;
                        break;


                    case "AJMP":
                        tokenType = ETokenType.AJmp;
                        break;
                    case "LJMP":
                        tokenType = ETokenType.LJmp;
                        break;
                    case "SJmp":
                        tokenType = ETokenType.SJmp;
                        break;
                    case "SETB":
                        tokenType = ETokenType.SetB;
                        return;

                    case "R0":
                        tokenType = ETokenType.R0;
                        break;
                    case "R1":
                        tokenType = ETokenType.R1;
                        break;
                    case "R2":
                        tokenType = ETokenType.R2;
                        break;
                    case "R3":
                        tokenType = ETokenType.R3;
                        break;
                    case "R4":
                        tokenType = ETokenType.R4;
                        break;
                    case "R5":
                        tokenType = ETokenType.R5;
                        break;
                    case "R6":
                        tokenType = ETokenType.R6;
                        break;
                    case "R7":
                        tokenType = ETokenType.R7;
                        break;


                    case "EX":
                        tokenType = ETokenType.EX;
                        break;
                    case "EX0":
                        tokenType = ETokenType.EX0;
                        break;
                    case "EX1":
                        tokenType = ETokenType.EX1;
                        break;


                    case "IT0":
                        tokenType = ETokenType.IT0;
                        break;
                    case "IT1":
                        tokenType = ETokenType.IT1;
                        break;

                    default:
                        tokenType = ETokenType.Identifier;
                        break;
                }

                AddToken(tokenType, m_Builder.ToString(), extend, m_SourceLine, m_SourceChar);
            }
        }
        /// <summary> 解析字符串 </summary>
        public void ParseToTokenList() 
        {
            m_SourceChar = 0;
            m_SourceLine = 0;      
            m_CurChar = END_CHAR;
            m_Builder.Clear();
            m_ListTokens.Clear();
            m_Index = 0;
            while ( m_Index < m_Length )
            {
                m_CurChar = m_Buffer[m_Index];
                if (m_CurChar == '\n') 
                {
                    m_Index++;
                    AddLine();
                    continue;
                }
                else if( m_CurChar == ' ' || m_CurChar == '\t' || m_CurChar == '\r' )
                {
                    m_Index++;
                    m_SourceChar++;
                    continue;
                }
                else if( m_CurChar == ',' )
                {
                    AddToken(ETokenType.Comma, m_CurChar);
                    m_Index++;
                    m_SourceChar++;
                    continue;
                }
                else if(m_CurChar == ';')
                {
                    ReadComment();
                }
                else
                {
                    switch (m_CurChar)
                    {
                        case '#':
                        case '$':
                            ReadNumber();
                            break;
                        default:
                            if (char.IsDigit(m_CurChar))
                            {
                                ReadNumber();
                            }
                            else if (IsIdentifier(m_CurChar))
                            {
                                ReadIdentifier();
                            }
                            else
                            {
                                Console.WriteLine("Error 解析错误，无法解析这种类型的字符: + " + m_CurChar );
                            }
                            break;
                    }
                }
            }
        }
        public void PrintString()
        {
            StringBuilder sb = new StringBuilder();
            for( int i = 0; i < m_ListTokens.Count; i++ )
            {
                sb.Append(m_ListTokens[i].lexeme);
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
