using System;
using System.Collections.Generic;
using System.Text;

namespace ava.caranas.domain {
    public abstract class ABaseEntityBlockable : ABaseEntitiy, IBlockable {
        private bool _blocked { get; set; }
        public void Block() {
            _blocked = true;
        }
        public void Unblock() {
            _blocked = false;
        }
        public bool IsBlocked() {
            if (_blocked) return true;
            else return false;
        }
    }
}
