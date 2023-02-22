using LLVM.LLVM_Structures;
using static LLVM.Binding;

namespace LLVM.Wrapper;

public class Call : WrapBase
{
    public static ValueRef Func(BuilderRef builder, Function func, ValueRef[] args)
    {
        return BuildCall2(builder, func.sig, func.func, args, (uint)args.Length);
    }
    public static TypeRef[] ValueRefsToTypes(ValueRef[] args )
    {
        List<TypeRef> types = new();

        foreach (var a in args)
            types.Add(TypeOf(a));

        return types.ToArray();
    }
    public static ValueRef OriginalCall(BuilderRef builder, TypeRef ret, ValueRef func, ValueRef[] args) { 
        var types = ValueRefsToTypes(args);
        var sig = FunctionType(ret, types, (uint)types.Length);

        return BuildCall2(builder, sig, func, args, (uint)args.Length);
    }
}