﻿using static LLVM.Binding;

namespace LLVM.Wrapper
{
    public class Function : WrapBase
    {
        public static Dictionary<string, Function> functions = new();
        public string name;
        public TypeRef sig;
        private readonly ModuleRef module;
        public ValueRef func;
        public Function(ModuleRef module, TypeRef sig, string name)
        {
            this.module = module;
            this.name = name;
            this.sig = sig;

            func = AddFunction(module, name, sig);

            functions.Add(name, this);
        }
        public Function(ValueRef function, TypeRef sig, string name)
        {
            func = function;
            this.sig = sig;

            functions.Add(name, this);
        }
        public ValueRef GetParameter(int param)
        {
            return GetParam(func, (uint)param);
        }
    }
}
