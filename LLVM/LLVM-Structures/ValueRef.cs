using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static LLVM.Binding;

namespace LLVM
{
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct ValueRef : IEquatable<ValueRef>
    {
        [FieldOffset(0)]
        private readonly IntPtr handle;

        public ValueRef(IntPtr handle)
        {
            this.handle = handle;
        }
        public string GetName()
        {
            //For some reason GetValueName wasn't working. came up with this alternative.
            return Regex.Match(PrintValueToString(this), "(?<=@)[\\w\\.]+").Value;
        }
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
    }
}
