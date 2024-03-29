﻿using System.Runtime.InteropServices;
using static LLVM.Binding;

namespace LLVM;

[StructLayout(LayoutKind.Explicit)]
public readonly struct ModuleRef : IEquatable<ModuleRef>
{
    [FieldOffset(0)] private readonly nint handle;

    public ModuleRef(nint handle)
    {
        this.handle = handle;
    }

    public void Link(ModuleRef module)
    {
        _ = LinkModules(this, module);
    }

    public bool Equals(ModuleRef other)
    {
        return handle == other.handle;
    }

    public override bool Equals(object obj)
    {
        return obj is ModuleRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return handle.GetHashCode();
    }

    public static bool operator ==(ModuleRef left, ModuleRef right)
    {
        return left.handle.Equals(right.handle);
    }

    public static bool operator !=(ModuleRef left, ModuleRef right)
    {
        return !(left.handle == right.handle);
    }
}