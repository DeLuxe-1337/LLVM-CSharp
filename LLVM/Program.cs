using LLVM;
using LLVM.Wrapper;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static LLVM.Binding;

Stopwatch sw = new();
sw.Start();

var context = ContextCreate();
var module = ModuleCreateWithNameInContext("MyModule", context);
SetDataLayout(module, "e-m:e-p:32:32-i64:64-n32:64-S128");

var builder = CreateBuilderInContext(context);

//SetTarget(module, "wasm32-unknown-unknown");

var voidType = VoidType();
var i8 = Int8Type();
var strType = PointerType(i8, 0);

var printf = new Function(module, "printf", FunctionType(Int32Type(), new TypeRef[] { strType }, 1, 1));
var mainFunc = new Function(module, "main", FunctionType(voidType, null, 0));

SetLinkage(mainFunc.func, Linkage.ExternalLinkage);

var block = AppendBasicBlockInContext(context, mainFunc.func, "onInvoke");
PositionBuilderAtEnd(builder, block);

Call.Func(builder, printf, new ValueRef[] { Constant.String(builder, "Hello, world") });

Call.Func(builder, printf, new ValueRef[]{ Constant.String(builder, "%s"), Constant.String(builder, "Hello, world") });

BuildRetVoid(builder);

Console.WriteLine($"It took {sw.ElapsedMilliseconds} to build module.");

IntPtr output;
WriteBitcodeToFile(module, "MyModule.o");
PrintModuleToFile(module, "MyModule.ll", out output);

sw.Stop();

Console.WriteLine($"It took {sw.ElapsedMilliseconds} to build EVERYTHING.");

DumpModule(module);
DisposeModule(module);