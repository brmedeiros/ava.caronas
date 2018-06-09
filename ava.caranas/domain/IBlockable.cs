using System;
using System.Collections.Generic;
using System.Text;

namespace ava.caranas.domain {
    interface IBlockable {
        void Block();
        void Unblock();
        bool IsBlocked();
    }
}
