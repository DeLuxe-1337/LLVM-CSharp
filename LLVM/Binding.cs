using LLVM.LLVM_Structures;
using System.Runtime.InteropServices;

namespace LLVM
{
    public static class Binding
    {
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBasicBlockAsValue")]
        public static extern ValueRef BasicBlockAsValue(BasicBlockRef BB);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMValueIsBasicBlock")]
        public static extern bool ValueIsBasicBlock(ValueRef Val);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMValueAsBasicBlock")]
        public static extern BasicBlockRef ValueAsBasicBlock(ValueRef Val);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetBasicBlockName")]
        public static extern string GetBasicBlockName(BasicBlockRef BB);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetBasicBlockParent")]
        public static extern ValueRef GetBasicBlockParent(BasicBlockRef BB);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetBasicBlockTerminator")]
        public static extern ValueRef GetBasicBlockTerminator(BasicBlockRef BB);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMCountBasicBlocks")]
        public static extern uint CountBasicBlocks(ValueRef Fn);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetBasicBlocks")]
        public static extern void GetBasicBlocks(ValueRef Fn, out BasicBlockRef[] BasicBlocks);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetFirstBasicBlock")]
        public static extern BasicBlockRef GetFirstBasicBlock(ValueRef Fn);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetLastBasicBlock")]
        public static extern BasicBlockRef GetLastBasicBlock(ValueRef Fn);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetNextBasicBlock")]
        public static extern BasicBlockRef GetNextBasicBlock(BasicBlockRef BB);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetPreviousBasicBlock")]
        public static extern BasicBlockRef GetPreviousBasicBlock(BasicBlockRef BB);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetEntryBasicBlock")]
        public static extern BasicBlockRef GetEntryBasicBlock(ValueRef Fn);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMInsertExistingBasicBlockAfterInsertBlock")]
        public static extern void InsertExistingBasicBlockAfterInsertBlock(BuilderRef Builder, BasicBlockRef BB);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMAppendExistingBasicBlock")]
        public static extern void AppendExistingBasicBlock(ValueRef Fn, BasicBlockRef BB);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildAggregateRet")]
        public static extern ValueRef BuildAggregateRet(BuilderRef b, ValueRef[] RetVals, uint N);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildBr")]
        public static extern ValueRef BuildBr(BuilderRef b, BasicBlockRef Dest);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildCondBr")]
        public static extern ValueRef BuildCondBr(BuilderRef b, ValueRef If, BasicBlockRef Then, BasicBlockRef Else);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildSwitch")]
        public static extern ValueRef BuildSwitch(BuilderRef b, ValueRef V, BasicBlockRef Else, uint NumCases);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildIndirectBr")]
        public static extern ValueRef BuildIndirectBr(BuilderRef B, ValueRef Addr, uint NumDests);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildInvoke2")]
        public static extern ValueRef BuildInvoke2(BuilderRef b, TypeRef Ty, ValueRef Fn, ValueRef[] Args, uint NumArgs, BasicBlockRef Then, BasicBlockRef Catch, string Name);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildUnreachable")]
        public static extern ValueRef BuildUnreachable(BuilderRef b);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildResume")]
        public static extern ValueRef BuildResume(BuilderRef B, ValueRef Exn);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildLandingPad")]
        public static extern ValueRef BuildLandingPad(BuilderRef B, TypeRef Ty, ValueRef PersFn, uint NumClauses, string Name);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildCleanupRet")]
        public static extern ValueRef BuildCleanupRet(BuilderRef B, ValueRef CatchPad, BasicBlockRef BB);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildCatchRet")]
        public static extern ValueRef BuildCatchRet(BuilderRef B, ValueRef CatchPad, BasicBlockRef BB);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildCatchPad")]
        public static extern ValueRef BuildCatchPad(BuilderRef B, ValueRef ParentPad, ValueRef[] Args, uint NumArgs, string Name);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildCleanupPad")]
        public static extern ValueRef BuildCleanupPad(BuilderRef B, ValueRef ParentPad, ValueRef[] Args, uint NumArgs, string Name);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildCatchSwitch")]
        public static extern ValueRef BuildCatchSwitch(BuilderRef B, ValueRef ParentPad, BasicBlockRef UnwindBB, uint NumHandlers, string Name);
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
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMPositionBuilder")]
        public static extern void PositionBuilder(BuilderRef Builder, BasicBlockRef Block, ValueRef instr);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMPositionBuilderBefore")]
        public static extern void PositionBuilderBefore(BuilderRef Builder, ValueRef instr);

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
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMConstNull")]
        public static extern ValueRef ConstNull(TypeRef typRef);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMShutdown")]
        public static extern void Dispose();
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMIsNull")]
        public static extern BoolRef IsNull(ValueRef val);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMLinkModules2")]
        public static extern BoolRef LinkModules(ModuleRef dest, ModuleRef source);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMCreateExecutionEngineForModule")]
        public static extern BoolRef CreateExecutionEngineForModule(out ExecutionEngineRef outee, ModuleRef m, out string error);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMDisposeExecutionEngine")]
        public static extern void DisposeExecutionEngine(ExecutionEngineRef e);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMRunFunction")]
        public static extern int RunFunction(ExecutionEngineRef e, ValueRef func, uint numargs, GenericValueRef[] args);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetInsertBlock")]
        public static extern BasicBlockRef GetInsertBlock(BuilderRef Builder);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMClearInsertionPosition")]
        public static extern void ClearInsertionPosition(BuilderRef Builder);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMInsertIntoBuilder")]
        public static extern void InsertIntoBuilder(BuilderRef Builder, ValueRef instr);

        [DllImport("LLVM-C.dll", EntryPoint = "LLVMInsertIntoBuilderWithName")]
        public static extern void InsertIntoBuilderWithName(BuilderRef Builder, ValueRef instr, string Name);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildPointerCast")]
        public static extern ValueRef BuildPointerCast(BuilderRef Builder, ValueRef val, TypeRef DestTy, BoolRef signed, string name = "");
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMInt1Type")]
        public static extern TypeRef Int1Type();
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMBuildAnd")]
        public static extern ValueRef BuildAnd(BuilderRef builder, ValueRef left, ValueRef right, string name = "");
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMGetValueName2", ExactSpelling = true)]
        public static extern string GetValueName(ValueRef va);
        [DllImport("LLVM-C.dll", EntryPoint = "LLVMPrintValueToString", ExactSpelling = true)]
        public static extern string PrintValueToString(ValueRef va);
    }

}
