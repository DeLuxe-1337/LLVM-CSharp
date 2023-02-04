using LLVM.LLVM_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LLVM.Binding;

namespace LLVM.Wrapper
{
    public class Call : WrapBase
    {
        public static ValueRef Func(BuilderRef builder, Function func, ValueRef[] args)
        {
            return BuildCall2(builder, func.sig, func.func, args, (uint)args.Length, "call");
        }
    }
}
