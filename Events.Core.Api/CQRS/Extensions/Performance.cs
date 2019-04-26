using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Internal;

namespace Events.Core.Api.CQRS.Extensions
{
    public class Performance<T> : IDisposable
    {
        private readonly Stopwatch performTime;
        
        public Performance()
        {
            performTime = new Stopwatch();
            performTime.Start();
        }

        public void Dispose()
        {
            double totalTime = performTime.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Handler: {typeof(T).ShortDisplayName()} Time:{totalTime}ms");
        }
    }
}