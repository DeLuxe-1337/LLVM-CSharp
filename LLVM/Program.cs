﻿using LLVM;
using LLVM.Wrapper;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static LLVM.Binding;

Stopwatch sw = new();
sw.Start();

var context = LLVMContextCreate();
var module = LLVMModuleCreateWithNameInContext("MyModule", context);
LLVMSetDataLayout(module, "e-m:e-p:32:32-i64:64-n32:64-S128");

var builder = LLVMCreateBuilderInContext(context);

LLVMSetTarget(module, "wasm32-unknown-unknown");

var voidType = LLVMVoidType();
var i8 = LLVMInt8Type();
var strType = LLVMPointerType(i8, 0);

var printf = new Function(module, "printf", LLVMFunctionType(LLVMInt32Type(), new TypeRef[] { strType }, 1));
var mainFunc = new Function(module, "run", LLVMFunctionType(voidType, null, 0));

LLVMSetLinkage(mainFunc.func, LLVMLinkage.LLVMExternalLinkage);

var block = LLVMAppendBasicBlockInContext(context, mainFunc.func, "onInvoke");
LLVMPositionBuilderAtEnd(builder, block);

var parms = new ValueRef[] { LLVMBuildPointerCast(builder, LLVMBuildGlobalString(builder, "Hello, World!", "hello"), strType, "0") };
LLVMBuildCall2(builder, printf.sig, printf.func, parms, 1, "call");
LLVMBuildRetVoid(builder);

Console.WriteLine($"It took {sw.ElapsedMilliseconds} to build module.");

IntPtr output;
LLVMWriteBitcodeToFile(module, "MyModule.o");
LLVMPrintModuleToFile(module, "MyModule.ll", out output);

sw.Stop();

Console.WriteLine($"It took {sw.ElapsedMilliseconds} to build EVERYTHING.");

LLVMDumpModule(module);
LLVMDisposeModule(module);