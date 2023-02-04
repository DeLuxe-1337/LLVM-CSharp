using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LLVM
{
    [StructLayout(LayoutKind.Explicit)]
    public struct TypeRef : IEquatable<TypeRef>
    {
        [FieldOffset(0)]
        public readonly IntPtr handle;

        public TypeRef(IntPtr handle)
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
    }
}
