using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Visitor
{
    interface Visitable
    {
        public void accept(VisitorInterface visitor);
    }
}
