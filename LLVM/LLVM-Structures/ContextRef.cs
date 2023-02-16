using System.Runtime.InteropServices;

namespace LLVM;

[StructLayout(LayoutKind.Explicit)]
public readonly struct ContextRef : IEquatable<ContextRef>
{
    [FieldOffset(0)] private readonly nint handle;

    public ContextRef(nint handle)
    {
        this.handle = handle;
    }

    public bool Equals(ContextRef other)
    {
        return handle == other.handle;
    }

    public override bool Equals(object obj)
    {
        return obj is ContextRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return handle.GetHashCode();
    }

    public static bool operator ==(ContextRef left, ContextRef right)
    {
        return left.handle.Equals(right.handle);
    }

    public static bool operator !=(ContextRef left, ContextRef right)
    {
        return !(left.handle == right.handle);
    }
}