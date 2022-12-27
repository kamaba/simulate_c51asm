
using System;

namespace SimpleAsm
{
    //token类型
    public enum ETokenType
    {
        /// <summary>  </summary>
        None = 0,
        //--------------------伪指令区-----------------------
        /// <summary> ORG </summary>
        Org,
        /// <summary> DB </summary>
        Db,
        /// <summary> DW </summary>
        Dw,
        /// <summary> DS </summary>
        Ds,
        /// <summary> EQU </summary>
        Equ,
        /// <summary> DATA </summary>
        Data,
        /// <summary> XDATA </summary>
        XData,
        /// <summary> BIT </summary>
        Bit,
        /// <summary> END </summary>
        End,
        /// <summary> Comma </summary>
        Comma,

        //----------------临时栈定义------------------------
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
        /// <summary> Label </summary>
        Label,

        //--------------------地址操作指令----------------------
        /// <summary> Mov </summary>
        Mov,
        /// <summary> Movc </summary>
        MovC,
        /// <summary> MovX </summary>
        MovX,
        /// <summary> SETB </summary>
        SetB,
        /// <summary> XCH </summary>
        Xch,
        /// <summary> XCHD </summary>
        XchD,
        /// <summary> PUSH </summary>
        Push,
        /// <summary> POP </summary>
        Pop,
        /// <summary> SWAP </summary>
        Swap,        

        //--------------------------数学运算指令----------------
        /// <summary> ADD </summary>
        Add,
        /// <summary> ADDC </summary>
        AddC,
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

        //--------------逻辑位指令-------------------------
        /// <summary> CLR </summary>
        Clr,
        /// <summary> CPL </summary>
        Cpl,
        /// <summary> RL </summary>
        Rl,
        /// <summary> RLC </summary>
        Rlc,
        /// <summary> RL A </summary>
        Rla,
        /// <summary> RR </summary>
        Rr,
        /// <summary> RR </summary>
        Rra,
        /// <summary> RRC </summary>
        Rrc,
        /// <summary> RRCA </summary>
        RrcA,
        /// <summary> ANL </summary>
        Anl,
        /// <summary> ORL </summary>
        Orl,
        /// <summary> XRL </summary>
        Xrl,

        //---------------------------远程调用-------------------------------
        /// <summary> ACALL </summary>
        ACall,
        /// <summary> LCALL </summary>
        LCall,
        /// <summary> RET </summary>
        Ret,
        /// <summary> RETI </summary>
        Reti,
        /// <summary> SJMP </summary>
        SJmp,
        /// <summary> AJMP </summary>
        AJmp,
        /// <summary> LJMP </summary>
        LJmp,
        /// <summary> JMP </summary>
        Jmp,
        /// <summary> NOP </summary>
        Nop,

        //-------------------判断跳转---------------------------
        /// <summary> JZ </summary>
        Jz,
        /// <summary> JNZ </summary>
        Jnz,
        /// <summary> JC </summary>
        Jc,
        /// <summary> JNC </summary>
        Jnc,
        /// <summary> CJne </summary>
        CJne,
        /// <summary> DJnz </summary>
        DJnz,
        /// <summary> JB </summary>
        Jb,

        //--------------------------寄存器区----------------------------
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
