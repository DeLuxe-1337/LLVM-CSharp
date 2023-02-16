using System.Runtime.InteropServices;

namespace LLVM.LLVM_Structures;

[StructLayout(LayoutKind.Explicit)]
public readonly struct BuilderRef : IEquatable<BuilderRef>
{
    [FieldOffset(0)] private readonly nint handle;

    public BuilderRef(nint handle)
    {
        this.handle = handle;
    }

    public bool Equals(BuilderRef other)
    {
        return handle == other.handle;
    }

    public override bool Equals(object obj)
    {
        return obj is BuilderRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return handle.GetHashCode();
    }

    public static bool operator ==(BuilderRef left, BuilderRef right)
    {
        return left.handle.Equals(right.handle);
    }

    public static bool operator !=(BuilderRef left, BuilderRef right)
    {
        return !(left.handle == right.handle);
    }
}