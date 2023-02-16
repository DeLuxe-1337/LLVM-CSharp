using System.Runtime.InteropServices;

namespace LLVM;

[StructLayout(LayoutKind.Explicit)]
public readonly struct ExecutionEngineRef : IEquatable<ExecutionEngineRef>
{
    [FieldOffset(0)] private readonly nint handle;

    public ExecutionEngineRef(nint handle)
    {
        this.handle = handle;
    }

    public bool Equals(ExecutionEngineRef other)
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

    public static bool operator ==(ExecutionEngineRef left, ExecutionEngineRef right)
    {
        return left.handle.Equals(right.handle);
    }

    public static bool operator !=(ExecutionEngineRef left, ExecutionEngineRef right)
    {
        return !(left.handle == right.handle);
    }
}