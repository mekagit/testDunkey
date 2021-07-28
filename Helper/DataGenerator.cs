using System;
using System.Threading;

namespace DunkeyItTest.Helper
{
    public static class DataGenerator
    {
        public static string UniqueValue()
        {
            var unixTimeStampSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var threadId = Thread.CurrentThread.ManagedThreadId;
            return $"{unixTimeStampSeconds}{threadId}";
        }
    }
}
