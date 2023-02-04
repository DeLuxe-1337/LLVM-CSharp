using LLVM.LLVM_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static LLVM.Binding;

namespace LLVM.Wrapper
{
    public class Constant : WrapBase
    {
        public static ValueRef String(BuilderRef builder, string str)
        {
            return LLVMBuildPointerCast(builder, LLVMBuildGlobalString(builder, str, "String"), LLVMPointerType(LLVMInt8Type(), 0), "0");
        }
    }
}
