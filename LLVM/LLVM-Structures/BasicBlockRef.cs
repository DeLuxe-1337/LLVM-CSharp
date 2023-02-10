using System.Runtime.InteropServices;

namespace LLVM
{
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct BasicBlockRef : IEquatable<BasicBlockRef>
    {
        [FieldOffset(0)]
        private readonly IntPtr handle;

        public BasicBlockRef(IntPtr handle)
        {
            this.handle = handle;
        }

        public bool Equals(BasicBlockRef other)
        {
            return handle == other.handle;
        }

        public override bool Equals(object obj)
        {
            return obj is BasicBlockRef other && Equals(other);
        }

        public override int GetHashCode()
        {
            return handle.GetHashCode();
        }

        public static bool operator ==(BasicBlockRef left, BasicBlockRef right)
        {
            return left.handle.Equals(right.handle);
        }

        public static bool operator !=(BasicBlockRef left, BasicBlockRef right)
        {
            return !(left.handle == right.handle);
        }
    }
}
