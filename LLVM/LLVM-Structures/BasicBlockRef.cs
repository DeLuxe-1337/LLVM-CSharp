using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLVM
{
    [StructLayout(LayoutKind.Explicit)]
    public struct BasicBlockRef : IEquatable<BasicBlockRef>
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
    }
}
