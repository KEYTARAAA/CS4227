using System;
using System.Collections.Generic;
using System.Text;
using CS4227.Interceptors;
using CS4227.Commands;


namespace CS4227.Dispatchers
{
    class Dispatcher
    {
        List<Interceptor> interceptors;

        public Dispatcher()
        {
            interceptors = new List<Interceptor>();
        }

        public void dispatch()
        {
            foreach (Interceptor interceptor in interceptors)
            {
                interceptor.event_callback();
            }

        }
        public void register(Interceptor interceptor)
        {
            interceptors.Add(interceptor);
        }
        public void remove(Interceptor interceptor)
        {
            interceptors.Remove(interceptor);

        }

    }
}