using static LLVM.Binding;
using LLVM.LLVM_Structures;
using System.Runtime.InteropServices;

namespace LLVM;

[StructLayout(LayoutKind.Explicit)]
public readonly struct ValueRef : IEquatable<ValueRef>
{
    private static readonly nint VNULL = -999999999;
    [FieldOffset(0)] private readonly nint handle;

    public ValueRef(nint handle)
    {
        this.handle = handle;
    }
    public static ValueRef AsNull()
    {
        return new ValueRef(VNULL);
    }
    public bool IsNull()
        => handle == VNULL;
    public bool Equals(ValueRef other)
    {
        return handle == other.handle;
    }
    public override bool Equals(object obj)
    {
        return obj is ValueRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return handle.GetHashCode();
    }

    public static bool operator ==(ValueRef left, ValueRef right)
    {
        return left.handle.Equals(right.handle);
    }
    public static bool operator !=(ValueRef left, ValueRef right)
    {
        return !(left.handle == right.handle);
    }

    public static bool operator ==(ValueRef left, OpCode right)
    {
        return GetInstructionOpcode(left) == right;
    }
    public static bool operator !=(ValueRef left, OpCode right)
    {
        Console.WriteLine(GetInstructionOpcode(left));
        return GetInstructionOpcode(left) != right;
    }
    public static bool operator !=(OpCode left, ValueRef right)
    {
        return GetInstructionOpcode(right) != left;
    }
    public static bool operator ==(OpCode left, ValueRef right)
    {
        return GetInstructionOpcode(right) == left;
    }
}