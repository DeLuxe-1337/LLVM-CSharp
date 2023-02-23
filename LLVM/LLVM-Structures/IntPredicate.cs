using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLVM.LLVM_Structures
{
    public enum IntPredicate
    {
        IntEQ = 32,
        IntNE,
        IntUGT,
        IntUGE,
        IntULT,
        IntULE,
        IntSGT,
        InstSGE,
        InstSLT,
        IntSLE
    }
}
