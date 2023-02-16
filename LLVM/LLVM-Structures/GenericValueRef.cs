using System.Runtime.InteropServices;

namespace LLVM;

[StructLayout(LayoutKind.Explicit)]
public readonly struct GenericValueRef : IEquatable<GenericValueRef>
{
    [FieldOffset(0)] private readonly nint handle;

    public GenericValueRef(nint handle)
    {
        this.handle = handle;
    }

    public bool Equals(GenericValueRef other)
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

    public static bool operator ==(GenericValueRef left, GenericValueRef right)
    {
        return left.handle.Equals(right.handle);
    }

    public static bool operator !=(GenericValueRef left, GenericValueRef right)
    {
        return !(left.handle == right.handle);
    }
}