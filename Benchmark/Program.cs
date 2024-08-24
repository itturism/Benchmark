using BenchmarkDotNet.Running;
using Benchmarks.Collection;
using Benchmarks.ThreadLock;

///Тестирование коллекций
BenchmarkRunner.Run<ListTest>();
BenchmarkRunner.Run<HashSetTest>();
BenchmarkRunner.Run<ConcurrentStackTest>();
BenchmarkRunner.Run<ArrayListTest>();
BenchmarkRunner.Run<ConcurrentBagTest>();
BenchmarkRunner.Run<QueueTest>();
BenchmarkRunner.Run<PriorityQueueTest>();
BenchmarkRunner.Run<LinkedListTest>();
BenchmarkRunner.Run<DictionaryTest>();
BenchmarkRunner.Run<ConcurrentDictionaryTest>();
BenchmarkRunner.Run<SortedListTest>();
BenchmarkRunner.Run<StackTest>();

///Тестирование примитивов синхронизации потоков
BenchmarkRunner.Run<ThreadLocksTest>();
