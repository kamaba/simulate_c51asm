
using System;

namespace SimpleAsm
{
    //token类型
    public enum ETokenType
    {
        /// <summary>  </summary>
        None = 0,
        /// <summary> ORG </summary>
        Org,
        /// <summary> NOP </summary>
        Nop,
        /// <summary> Comma </summary>
        Comma,



        /// <summary> A </summary>
        A,
        /// <summary> B </summary>
        B,
        /// <summary> C </summary>
        C,
        /// <summary> SP </summary>
        Sp,
        /// <summary> SP_MAX </summary>
        Sp_Max,
        /// <summary> DPTR </summary>
        Dptr,
        /// <summary> SETB </summary>
        SetB,
        /// <summary> Label </summary>
        Label,

        /// <summary> Mov </summary>
        Mov,
        /// <summary> Movc </summary>
        MovC,
        /// <summary> MovX </summary>
        MovX,
        /// <summary> XCH </summary>
        Xch,
        /// <summary> XCHD </summary>
        XchD,
        /// <summary> PUSH </summary>
        Push,
        /// <summary> POP </summary>
        Pop,

        /// <summary> ADD </summary>
        Add,
        /// <summary> ADDC </summary>
        AddC,
        /// <summary> SUB </summary>
        Sub,
        /// <summary> SUBB </summary>
        SubB,
        /// <summary> DA </summary>
        Da,
        /// <summary> INC </summary>
        Inc,
        /// <summary> DEC </summary>
        Dec,
        /// <summary> MUL </summary>
        Mul,
        /// <summary> DIV </summary>
        Div,

        /// <summary> RL A </summary>
        Rla,
        /// <summary> RLC </summary>
        Rlc,
        /// <summary> RR </summary>
        Rra,
        /// <summary> RRCA </summary>
        RrcA,

        /// <summary> AJMP </summary>
        ACall,
        /// <summary> AJMP </summary>
        LCall,
        /// <summary> AJMP </summary>
        Ret,
        /// <summary> AJMP </summary>
        Reti,
        /// <summary> SJMP </summary>
        SJmp,
        /// <summary> AJMP </summary>
        AJmp,
        /// <summary> LJMP </summary>
        LJmp,
        /// <summary> AJMP </summary>
        CJne,
        /// <summary> AJMP </summary>
        DJnz,


        /// <summary> AJMP </summary>
        Jz,
        /// <summary> AJMP </summary>
        Jnz,
        /// <summary> AJMP </summary>
        Jc,
        /// <summary> AJMP </summary>
        Jnc,
        /// <summary> AJMP </summary>
        Jb,

        /// <summary> DB </summary>
        Db,
        /// <summary> DW </summary>
        Dw,
        /// <summary> DW </summary>
        XData,
        /// <summary> Bit </summary>
        Bit,


        /// <summary> EX </summary>
        EX,
        /// <summary> EX0 </summary>
        EX0,
        /// <summary> EX1 </summary>
        EX1,

        /// <summary> IT0 </summary>
        IT0,
        /// <summary> IT1 </summary>
        IT1,

        /// <summary> R0 </summary>
        R0,
        /// <summary> R1 </summary>
        R1,
        /// <summary> R2 </summary>
        R2,
        /// <summary> R3 </summary>
        R3,
        /// <summary> R4 </summary>
        R4,
        /// <summary> R5 </summary>
        R5,
        /// <summary> R6 </summary>
        R6,
        /// <summary> R7 </summary>
        R7,
        /// <summary> CPL </summary>
        Cpl,
        /// <summary> END </summary>
        End,
        /// <summary> Comment </summary>
        Comment,
        /// <summary> 标识符 </summary>
        Identifier,
        /// <summary> 结束 </summary>
        Finished,
    }

    class Define
    {

    }
    public class Global
    {
        public const string tabChar = "    ";
    }
}
