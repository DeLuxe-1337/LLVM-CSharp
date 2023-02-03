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
        private string name;
        public TypeRef sig;
        private ModuleRef module;
        public ValueRef func;
        public Function(ModuleRef module, string name, TypeRef sig)
        {
            this.module = module;
            this.name = name;
            this.sig = sig;

            func = LLVMAddFunction(module, name, sig);
        }
    }
}
