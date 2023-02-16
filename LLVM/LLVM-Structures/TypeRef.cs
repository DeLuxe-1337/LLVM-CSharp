using System.Runtime.InteropServices;

namespace LLVM;

[StructLayout(LayoutKind.Explicit)]
public readonly struct TypeRef : IEquatable<TypeRef>
{
    [FieldOffset(0)] public readonly nint handle;

    public TypeRef(nint handle)
    {
        this.handle = handle;
    }

    public bool Equals(TypeRef other)
    {
        return handle == other.handle;
    }

    public override bool Equals(object obj)
    {
        return obj is TypeRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return handle.GetHashCode();
    }

    public static bool operator ==(TypeRef left, TypeRef right)
    {
        return left.handle.Equals(right.handle);
    }

    public static bool operator !=(TypeRef left, TypeRef right)
    {
        return !(left.handle == right.handle);
    }
}