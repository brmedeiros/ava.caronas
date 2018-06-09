using System;
using System.Collections.Generic;
using System.Text;

namespace ava.caronas.domain {
    interface IBlockable {
        void Block();
        void Unblock();
        bool IsBlocked();
    }
}
