using System.Text.RegularExpressions;
using static LLVM.Binding;

namespace LLVM.Wrapper
{
    public class Function : WrapBase
    {
        public static List<Function> functions = new();
        public string name;
        public string realName;
        public TypeRef sig;
        public TypeRef[] args;
        private readonly ModuleRef module;
        public ValueRef func;
        public bool vararg = false;
        public static void FixFunctionReferences(ModuleRef module)
        {
            foreach (var f in functions)
            {
                functions[functions.IndexOf(f)].func = GetNamedFunction(module, f.realName);
            }
        }
        public static Function GetFromNameAndArg(string name, TypeRef[] args)
        {
            foreach (var f in functions)
            {
                if (f.name == name && (f.args.SequenceEqual(args) || f.vararg))
                    return f;
            }

            return null;
        }
        public string GetName()
        {
            //For some reason GetValueName wasn't working. came up with this alternative.
            return Regex.Match(PrintValueToString(func), "(?<=@)[\\w\\.]+").Value;
        }

        public Function(ModuleRef module, TypeRef[] args, TypeRef sig, string name)
        {
            this.module = module;
            this.name = name;
            this.sig = sig;
            this.args = args;

            func = AddFunction(module, name, sig);

            this.realName = this.GetName();

            functions.Add(this);
        }
        public Function(ValueRef function, TypeRef[] args, TypeRef sig, string name)
        {
            func = function;
            this.sig = sig;
            this.args = args;

            this.name = this.GetName();
            this.realName = this.name;
            this.vararg = true;

            functions.Add(this);
        }
        public ValueRef GetParameter(int param)
        {
            return GetParam(func, (uint)param);
        }
    }
}
