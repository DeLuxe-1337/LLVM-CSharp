using System.Runtime.InteropServices;

namespace LLVM.LLVM_Structures
{
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct BoolRef : IEquatable<BoolRef>
    {
        [FieldOffset(0)]
        private readonly byte value;

        public BoolRef(bool value)
        {
            this.value = value ? (byte)1 : (byte)0;
        }

        public bool Equals(BoolRef other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            return obj is BoolRef other && Equals(other);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(BoolRef left, BoolRef right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BoolRef left, BoolRef right)
        {
            return !left.Equals(right);
        }
    }
}
