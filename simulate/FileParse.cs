//****************************************************************************
//  File:      FileParse.cs
// ------------------------------------------------
//  Copyright (c) kamaba233@gmail.com
//  DateTime: 2022/5/12 12:00:00
//  Description: 
//****************************************************************************

using System;
using System.IO;

namespace SimpleAsm.Parse
{
    public enum ECodeFileParseState
    {
        Null,
        Init,
        LoadBegin,
        LoadEnd,
    }

    public class FileParse
    {
        LexerParse lexerParse;
        TokenParse tokenParse;
        //private FileMeta m_File = null;

        public string m_FilePath;
        public long fileSize;
        
        public string content;

        public Action structParseComplete { get; set; } = null;
        public Action buildParseComplete = null;
        public Action grammerParseComplete = null;

        public FileParse( string path )
        {
            m_FilePath = path;
           // m_File = new FileMeta(filePath);
        }
        public bool IsExists()
        {
            return File.Exists(m_FilePath);
        }
        public bool LoadFile()
        {
            //m_FileCompileState.SetLoadState( FileCompileState.ELoadState.LoadStart );
            using (var stream = File.OpenRead(m_FilePath))
            {
            //    m_FileCompileState.SetLoadState(FileCompileState.ELoadState.Loading );
                fileSize = stream.Length;
                int count = (int)fileSize;
                var buffer = new byte[fileSize];
                int numRead = 0;
                while (true)
                {
                    int n = stream.Read(buffer, numRead, count);
                    if (n == 0) break;
                    numRead += n;
                    count -= n;
                    if (count <= 0) break;
                }
                stream.Close();
                content = System.Text.Encoding.Default.GetString(buffer);
            }
            //m_FileCompileState.SetLoadState( FileCompileState.ELoadState.LoadEnd );
            return true;
        }
        public void StructParse()
        {
            if( LoadFile() )
            {
                lexerParse = new LexerParse(m_FilePath, content);
                content = string.Empty;

                lexerParse.ParseToTokenList();
                lexerParse.PrintString();

                tokenParse = new TokenParse( lexerParse.GetListTokensWidthEnd() );
                tokenParse.BuildStruct();

                if (structParseComplete != null )
                {
                    structParseComplete();
                }
            }
            else
            {
                Console.WriteLine("读取文件出错 FileParse Parse LoadFile !!!");
            }
        }
        public void CreateNamespace()
        {
            //m_File.CreateNamespace();
        }
        public void CombineFileMeta()
        {
            //m_File.CombineFileMeta();
        }
        public void CheckExtendAndInterface()
        {
            //m_File.CheckExtendAndInterface();
        }
        public string ToFormatString()
        {
            return "";// m_File.ToFormatString();
        }
        public void PrintFormatString()
        {
            //Console.Write(m_File.ToFormatString());
        }
    }
}