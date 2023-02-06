using LLVM.LLVM_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLVM
{
    [StructLayout(LayoutKind.Explicit)]
    public struct ContextRef : IEquatable<ContextRef>
    {
        [FieldOffset(0)]
        private readonly IntPtr handle;

        public ContextRef(IntPtr handle)
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
}
