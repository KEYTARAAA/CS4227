using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Memento
{
    interface Originator
    {
        public IMemento createMemento();

        public void restore(IMemento memento);
    }
}
