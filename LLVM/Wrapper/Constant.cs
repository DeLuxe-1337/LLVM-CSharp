using LLVM.LLVM_Structures;
using static LLVM.Binding;

namespace LLVM.Wrapper
{
    public class Constant : WrapBase
    {
        public static ValueRef String(BuilderRef builder, string str)
        {
            return BuildPointerCast(builder, BuildGlobalString(builder, str, "String"), PointerType(Int8Type(), 0), "0");
        }
        public static ValueRef Int32(BuilderRef builder, int val)
        {
            return ConstInt(Int32Type(), (ulong)val);
        }
        public static ValueRef Bool(BuilderRef builder, bool val)
        {
            return ConstInt(Int1Type(), (ulong)(val ? 1 : 0));
        }
    }
}
