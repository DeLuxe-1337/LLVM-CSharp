using LLVM.LLVM_Structures;
using static LLVM.Binding;

namespace LLVM.Wrapper;

public class Constant : WrapBase
{
    private static readonly Dictionary<string, ValueRef> StringPool = new();

    public static ValueRef String(BuilderRef builder, string str)
    {
        if (!StringPool.TryGetValue(str, out var cachedString))
        {
            cachedString = BuildPointerCast(builder, BuildGlobalString(builder, str, "String"),
                PointerType(Int8Type(), 0), "0");
            StringPool[str] = cachedString;
        }

        return cachedString;
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