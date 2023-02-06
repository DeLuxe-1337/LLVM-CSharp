using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using LLVM.LLVM_Structures;

namespace LLVM
{
    public class Binding
    {
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMDisposeModule")]
        public static extern void DisposeModule(ModuleRef module);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMWriteBitcodeToFile")]
        public static extern IntPtr WriteBitcodeToFile(ModuleRef Module, string Path, out IntPtr OutError);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMWriteBitcodeToFile")]
        public static extern void WriteBitcodeToFile(ModuleRef Module, string Path);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMPrintModuleToFile")]
        public static extern IntPtr PrintModuleToFile(ModuleRef Module, string Path, out IntPtr OutError);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMSetTarget")]
        public static extern void SetTarget(ModuleRef Module, string Triple);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMCreateBuilder")]
        public static extern BuilderRef CreateBuilder();

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMPositionBuilderAtEnd")]
        public static extern void PositionBuilderAtEnd(BuilderRef Builder, BasicBlockRef Block);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMAddFunction")]
        public static extern ValueRef AddFunction(ModuleRef M, string Name, TypeRef FunctionTy);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMFunctionType")]
        public static extern TypeRef FunctionType(TypeRef type, TypeRef[] args, uint paramcount, int varargs = 0);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMDisposeBuilder")]
        public static extern void DisposeBuilder(BuilderRef Builder);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMInt32Type")]
        public static extern TypeRef Int32Type();
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMVoidType")]
        public static extern TypeRef VoidType();
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMInt8Type")]
        public static extern TypeRef Int8Type();
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMInt8TypeInContext")]
        public static extern TypeRef Int8TypeInContext(ContextRef context);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMAppendBasicBlock")]
        public static extern BasicBlockRef AppendBasicBlock(ValueRef function, string name);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildRet")]
        public static extern void BuildRet(BuilderRef builder, ValueRef value);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMModuleCreateWithName")]
        public static extern ModuleRef ModuleCreateWithName(string name);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildRetVoid")]
        public static extern void BuildRetVoid(BuilderRef builder);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMContextCreate")]
        public static extern ContextRef ContextCreate();
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMModuleCreateWithNameInContext")]
        public static extern ModuleRef ModuleCreateWithNameInContext(string name, ContextRef context);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMCreateBuilderInContext")]
        public static extern BuilderRef CreateBuilderInContext(ContextRef context);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMAppendBasicBlockInContext")]
        public static extern BasicBlockRef AppendBasicBlockInContext(ContextRef context, ValueRef function, string name);
        public enum VerifierFailureAction
        {
            ReturnStatusAction,
            PrintMessageAction,
            PrintMessageActionAndAbort
        }
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMVerifyModule")]
        public static extern int VerifyModule(ModuleRef module, VerifierFailureAction Action, out IntPtr OutMessage);
        public enum Linkage
        {
            ExternalLinkage, AvailableExternallyLinkage, LinkOnceAnyLinkage, LinkOnceODRLinkage,
            LinkOnceODRAutoHideLinkage, WeakAnyLinkage, WeakODRLinkage, AppendingLinkage,
            InternalLinkage, PrivateLinkage, DLLImportLinkage, DLLExportLinkage,
            ExternalWeakLinkage, GhostLinkage, CommonLinkage, LinkerPrivateLinkage,
            LinkerPrivateWeakLinkage
        }
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMSetLinkage")]
        public static extern void SetLinkage(ValueRef function, Linkage kind);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildPointerCast")]
        public static extern ValueRef BuildPointerCast(BuilderRef builder, ValueRef value, TypeRef destty, string name);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildGlobalString")]
        public static extern ValueRef BuildGlobalString(BuilderRef builder, string str, string name);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMPointerType")]
        public static extern TypeRef PointerType(TypeRef elementty, uint addressspace);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetNamedFunction")]
        public static extern ValueRef GetNamedFunction(ModuleRef module, string name);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildCall2")]
        public static extern ValueRef BuildCall2(BuilderRef builder, TypeRef ty, ValueRef function, ValueRef[] args, uint argnum, string name = "");
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetVersion")]
        public static extern IntPtr GetVersion();
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMSetDataLayout")]
        public static extern void SetDataLayout(ModuleRef module, string triple);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMDumpModule")]
        public static extern void DumpModule(ModuleRef M);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetParam")]
        public static extern ValueRef GetParam(ValueRef function, uint parameter);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildAlloca")]
        public static extern ValueRef BuildAlloca(BuilderRef builder, TypeRef allocType, string name = "");
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildStore")]
        public static extern ValueRef BuildStore(BuilderRef builder, ValueRef target, ValueRef ptr);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildLoad2")]
        public static extern ValueRef BuildLoad2(BuilderRef builder, TypeRef ty, ValueRef pointerval, string name = "");
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMTypeOf")]
        public static extern TypeRef TypeOf(ValueRef value);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetReturnType")]
        public static extern TypeRef GetReturnType(TypeRef function);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMCountParams")]
        public static extern uint CountParams(TypeRef function);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildAdd")]
        public static extern ValueRef BuildAdd(BuilderRef builder, ValueRef lhs, ValueRef rhs, string name = "");

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildSub")]
        public static extern ValueRef BuildSub(BuilderRef builder, ValueRef lhs, ValueRef rhs, string name = "");

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildSDiv")]
        public static extern ValueRef BuildSDiv(BuilderRef builder, ValueRef lhs, ValueRef rhs, string name = "");

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildMul")]
        public static extern ValueRef BuildMul(BuilderRef builder, ValueRef lhs, ValueRef rhs, string name = "");
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMConstInt")]
        public static extern ValueRef ConstInt(TypeRef intType, ulong value, bool signExtend = true);
    }

}
