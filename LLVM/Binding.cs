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
        [DllImport("LLVM-C.dll")]
        public static extern ModuleRef LLVMModuleCreateWithName(string name);

        [DllImport("LLVM-C.dll")]
        public static extern void LLVMDisposeModule(ModuleRef module);

        [DllImport("LLVM-C.dll")]
        public static extern IntPtr LLVMWriteBitcodeToFile(ModuleRef Module, string Path, out IntPtr OutError);
        [DllImport("LLVM-C.dll")]
        public static extern void LLVMWriteBitcodeToFile(ModuleRef Module, string Path);
        [DllImport("LLVM-C.dll")]
        public static extern IntPtr LLVMPrintModuleToFile(ModuleRef Module, string Path, out IntPtr OutError);
        [DllImport("LLVM-C.dll")]
        public static extern void LLVMSetTarget(ModuleRef Module, string Triple);

        [DllImport("LLVM-C.dll")]
        public static extern BuilderRef LLVMCreateBuilder();

        [DllImport("LLVM-C.dll")]
        public static extern void LLVMPositionBuilderAtEnd(BuilderRef Builder, BasicBlockRef Block);

        [DllImport("LLVM-C.dll")]
        public static extern ValueRef LLVMAddFunction(ModuleRef M, string Name, TypeRef FunctionTy);

        [DllImport("LLVM-C.dll")]
        public static extern TypeRef LLVMFunctionType(TypeRef type, TypeRef[] args, uint paramcount, int varargs = 0);
        [DllImport("LLVM-C.dll")]
        public static extern void LLVMDisposeBuilder(BuilderRef Builder);
        [DllImport("LLVM-C.dll")]
        public static extern TypeRef LLVMInt32Type();
        [DllImport("LLVM-C.dll")]
        public static extern TypeRef LLVMVoidType();
        [DllImport("LLVM-C.dll")]
        public static extern TypeRef LLVMInt8Type();
        [DllImport("LLVM-C.dll")]
        public static extern TypeRef LLVMInt8TypeInContext(ContextRef context);
        [DllImport("LLVM-C.dll")]
        public static extern BasicBlockRef LLVMAppendBasicBlock(ValueRef function, string name);

        [DllImport("LLVM-C.dll")]
        public static extern void LLVMBuildRet(BuilderRef builder, ValueRef value);
        [DllImport("LLVM-C.dll")]
        public static extern void LLVMBuildRetVoid(BuilderRef builder);
        [DllImport("LLVM-C.dll")]
        public static extern ContextRef LLVMContextCreate();
        [DllImport("LLVM-C.dll")]
        public static extern ModuleRef LLVMModuleCreateWithNameInContext(string name, ContextRef context);
        [DllImport("LLVM-C.dll")]
        public static extern BuilderRef LLVMCreateBuilderInContext(ContextRef context);
        [DllImport("LLVM-C.dll")]
        public static extern BasicBlockRef LLVMAppendBasicBlockInContext(ContextRef context, ValueRef function, string name);
        public enum LLVMVerifierFailureAction
        {
            ReturnStatusAction,
            PrintMessageAction,
            PrintMessageActionAndAbort
        }
        [DllImport("LLVM-C.dll")]
        public static extern int LLVMVerifyModule(ModuleRef module, LLVMVerifierFailureAction Action, out IntPtr OutMessage);
        public enum LLVMLinkage
        {
            LLVMExternalLinkage, LLVMAvailableExternallyLinkage, LLVMLinkOnceAnyLinkage, LLVMLinkOnceODRLinkage,
            LLVMLinkOnceODRAutoHideLinkage, LLVMWeakAnyLinkage, LLVMWeakODRLinkage, LLVMAppendingLinkage,
            LLVMInternalLinkage, LLVMPrivateLinkage, LLVMDLLImportLinkage, LLVMDLLExportLinkage,
            LLVMExternalWeakLinkage, LLVMGhostLinkage, LLVMCommonLinkage, LLVMLinkerPrivateLinkage,
            LLVMLinkerPrivateWeakLinkage
        }

        [DllImport("LLVM-C.dll")]
        public static extern void LLVMSetLinkage(ValueRef function, LLVMLinkage kind);
        [DllImport("LLVM-C.dll")]
        public static extern ValueRef LLVMBuildPointerCast(BuilderRef builder, ValueRef value, TypeRef destty, string name);
        [DllImport("LLVM-C.dll")]
        public static extern ValueRef LLVMBuildGlobalString(BuilderRef builder, string str, string name);
        [DllImport("LLVM-C.dll")]
        public static extern TypeRef LLVMPointerType(TypeRef elementty, uint addressspace);
        [DllImport("LLVM-C.dll")]
        public static extern ValueRef LLVMGetNamedFunction(ModuleRef module, string name);
        [DllImport("LLVM-C.dll")]
        public static extern ValueRef LLVMBuildCall2(BuilderRef builder, TypeRef ty, ValueRef function, ValueRef[] args, uint argnum, string name);
        [DllImport("LLVM-C.dll")]
        public static extern IntPtr LLVMGetVersion();
        [DllImport("LLVM-C.dll")]
        public static extern void LLVMSetDataLayout(ModuleRef module, string triple);
        [DllImport("LLVM-C.dll")]
        public static extern void LLVMDumpModule(ModuleRef M);
        [DllImport("LLVM-C.dll")]
        public static extern ValueRef LLVMGetParam(ValueRef function, uint parameter);
        [DllImport("LLVM-C.dll")]
        public static extern ValueRef LLVMBuildAlloca(BuilderRef builder, TypeRef allocType, string name);

        [DllImport("LLVM-C.dll")]
        public static extern ValueRef LLVMBuildStore(BuilderRef builder, ValueRef target, ValueRef ptr);

        [DllImport("LLVM-C.dll")]
        public static extern ValueRef LLVMBuildLoad2(BuilderRef builder, TypeRef ty, ValueRef pointerval, string name);
        [DllImport("LLVM-C.dll")]
        public static extern ValueRef LLVMGetFunction(ModuleRef module, string name);
        [DllImport("LLVM-C.dll")]
        public static extern TypeRef LLVMTypeOf(ValueRef value);
        [DllImport("LLVM-C.dll")]
        public static extern TypeRef LLVMGetReturnType(ValueRef function);

    }

}
