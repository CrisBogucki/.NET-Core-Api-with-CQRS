using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;

namespace Events.Core.Api.CQRS.Tools
{
    public class Performance<T> : IDisposable
    {
        private Stopwatch performTime;
        private T properties;
        
        public Performance()
        {
            performTime = new Stopwatch();
            performTime.Start();
        }

        public void Dispose()
        {
            double totalTime = performTime.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Handler: {typeof(T).ShortDisplayName()} Time:{totalTime}ms");
            //Console.WriteLine($"Time:{totalTime}ms");
        }
    }
}