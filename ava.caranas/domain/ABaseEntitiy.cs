using System;

namespace ava.caronas.domain {
    public abstract class ABaseEntitiy {
        public int ID { get; set; }
        public DateTime CreationDateTime { get; set; }

        public ABaseEntitiy() {
            CreationDateTime = DateTime.Now;
        }
    }
}
