using System.Text.RegularExpressions;
using static LLVM.Binding;

namespace LLVM.Wrapper;

public class Function : WrapBase
{
    public static List<Function> functions = new();
    private readonly ModuleRef module;
    public TypeRef[] args;
    public ValueRef func;
    public string name;
    public string realName;
    public TypeRef sig;
    public bool vararg;

    public Function(ModuleRef module, TypeRef[] args, TypeRef sig, string name)
    {
        this.module = module;
        this.name = name;
        this.sig = sig;
        this.args = args;

        func = AddFunction(module, name, sig);

        realName = GetName();

        functions.Add(this);
    }

    public Function(ValueRef function, TypeRef[] args, TypeRef sig, string name)
    {
        func = function;
        this.sig = sig;
        this.args = args;

        this.name = GetName();
        realName = this.name;
        vararg = true;

        functions.Add(this);
    }

    public static void FixFunctionReferences(ModuleRef module)
    {
        foreach (var f in functions) functions[functions.IndexOf(f)].func = GetNamedFunction(module, f.realName);
    }

    public static Function GetFromNameAndArg(string name, TypeRef[] args)
    {
        foreach (var f in functions)
            if (f.name == name && (f.args.SequenceEqual(args) || f.vararg))
                return f;

        return null;
    }

    public static Function GetFromName(string name)
    {
        foreach (var f in functions)
            if (f.name == name)
                return f;

        return null;
    }

    public string GetName()
    {
        //For some reason GetValueName wasn't working. came up with this alternative.
        return Regex.Match(PrintValueToString(func), "(?<=@)[\\w\\.]+").Value;
    }

    public ValueRef GetParameter(int param)
    {
        return GetParam(func, (uint)param);
    }
    public static TypeRef CreateSignature(TypeRef[] args, TypeRef ret = default)
    {
        if (ret == default)
            ret = VoidType();

        return FunctionType(ret, args, (uint)args.Length);
    }
    public static TypeRef CreateSignature(ValueRef[] args, TypeRef ret = default)
    {
        if (ret == default)
            ret = VoidType();

        return FunctionType(ret, Call.ValueRefsToTypes(args), (uint)args.Length);
    }
}