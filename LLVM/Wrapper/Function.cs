using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static LLVM.Binding;
using System.Threading.Tasks;

namespace LLVM.Wrapper
{
    public class Function : WrapBase
    {
        public static Dictionary<string, Function> functions = new();
        public string name;
        public TypeRef sig;
        private ModuleRef module;
        public ValueRef func;
        public Function(ModuleRef module, string name, TypeRef sig)
        {
            this.module = module;
            this.name = name;
            this.sig = sig;

            func = LLVMAddFunction(module, name, sig);

            functions.Add(name, this);
        }
        public Function(ValueRef function, TypeRef sig, string name)
        {
            this.func = function;
            this.sig = sig;

            functions.Add(name, this);
        }
        public ValueRef GetParameter(int param)
        {
            return LLVMGetParam(func, (uint)param);
        }
    }
}
