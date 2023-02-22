using System.Runtime.InteropServices;

namespace LLVM;

[StructLayout(LayoutKind.Explicit)]
public readonly struct MemoryBufferRef : IEquatable<MemoryBufferRef>
{
    [FieldOffset(0)] private readonly nint handle;

    public MemoryBufferRef(nint handle)
    {
        this.handle = handle;
    }

    public bool Equals(MemoryBufferRef other)
    {
        return handle == other.handle;
    }

    public override bool Equals(object obj)
    {
        return obj is MemoryBufferRef other && Equals(other);
    }

    public override int GetHashCode()
    {
        return handle.GetHashCode();
    }

    public static bool operator ==(MemoryBufferRef left, MemoryBufferRef right)
    {
        return left.handle.Equals(right.handle);
    }

    public static bool operator !=(MemoryBufferRef left, MemoryBufferRef right)
    {
        return !(left.handle == right.handle);
    }
}