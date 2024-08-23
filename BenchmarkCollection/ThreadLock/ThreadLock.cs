using BenchmarkDotNet.Attributes;
using Microsoft.VSDiagnostics;
namespace Benchmarks.ThreadLock;

[ShortRunJob]
[MemoryDiagnoser]
[CPUUsageDiagnoser]
public class ThreadLocksTest
{
    readonly int _count = 1_000_000;
    [Benchmark]
    public void Lock()
    {
        var i = 0;
        var obj = new object();
        Parallel.For(0, _count, _ =>
        {
            lock (obj)
            {
                i++;
            }
        });
        if (i != _count)
            throw new Exception("Lock");
    }
    [Benchmark]
    public void ReaderWriterLockSlim()
    {
        var i = 0;
        using var obj = new ReaderWriterLockSlim();
        Parallel.For(0, _count, _ =>
        {
            obj.EnterWriteLock();
            i++;
            obj.ExitWriteLock();
        });
        if (i != _count)
            throw new Exception("ReaderWriterLockSlim");
    }
    [Benchmark]
    public void ReaderWriterLock()
    {
        var i = 0;
        var @lock = new object();
        var obj = new ReaderWriterLock();
        Parallel.For(0, _count, _ =>
        {
            obj.AcquireWriterLock(10_000);
            i++;
            obj.ReleaseWriterLock();
        });
        if (i != _count)
            throw new Exception("ReaderWriterLockSlim");
    }
    [Benchmark]
    public void Semaphore()
    {
        var i = 0;
        using var semaphore = new Semaphore(1, 1);
        Parallel.For(0, _count, _ =>
        {
            semaphore.WaitOne();
            i++;
            semaphore.Release();
        });
        if (i != _count)
            throw new Exception("Semaphore");
    }
    [Benchmark]
    public void Monitor()
    {
        var i = 0;
        var obj = new object();
        Parallel.For(0, _count, _ =>
        {
            System.Threading.Monitor.Enter(obj);
            i++;
            System.Threading.Monitor.Exit(obj);
        });
        if (i != _count)
            throw new Exception("Monitor");
    }
    [Benchmark]
    public void Mutex()
    {
        var i = 0;
        using var obj = new Mutex();
        Parallel.For(0, _count, _ =>
        {
            obj.WaitOne();
            i++;
            obj.ReleaseMutex();
        });
        if (i != 1_000_000)
            throw new Exception("Mutex");
    }
    [Benchmark]
    public void SpinLock()
    {
        var i = 0;
        var obj = new SpinLock();
        Parallel.For(0, _count, _ =>
        {
            bool gotLock = false;
            try
            {
                obj.Enter(ref gotLock);
                i++;
            }
            finally
            {
                if (gotLock) obj.Exit();
            }
        });
        if (i != _count)
            throw new Exception("Mutex");
    }
    [Benchmark]
    public void SemaphoreSlim()
    {
        var i = 0;
        using var obj = new SemaphoreSlim(1, 1);
        Parallel.For(0, _count, _ =>
        {
            obj.Wait();
            i++;
            obj.Release();
        });
        if (i != _count)
            throw new Exception("SemaphoreSlim");
    }
    [Benchmark]
    public void AutoResetEvent()
    {
        var i = 0;
        using var obj = new AutoResetEvent(true);
        Parallel.For(0, _count, _ =>
        {
            obj.WaitOne();
            i++;
            obj.Set();
        });
        if (i != _count)
            throw new Exception("Mutex");
    }
    [Benchmark]
    public void FreeLock()
    {
        var i = 0;
        Parallel.For(0, _count, _ =>
        {
            i++;
        });
    }
    [Benchmark]
    public void Interlock()
    {
        var i = 0;
        Parallel.For(0, _count, _ =>
        {
            Interlocked.Add(ref i, 1);
        });
    }
    [Benchmark]
    public void NoParallel()
    {
        var i = 0;
        for (; i < _count; i++) ;
        if (i != _count)
            throw new Exception("Mutex");
    }
}
