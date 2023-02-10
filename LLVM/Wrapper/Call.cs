using LLVM.LLVM_Structures;
using static LLVM.Binding;

namespace LLVM.Wrapper
{
    public class Call : WrapBase
    {
        public static ValueRef Func(BuilderRef builder, Function func, ValueRef[] args)
        {
            return BuildCall2(builder, func.sig, func.func, args, (uint)args.Length);
        }
    }
}
