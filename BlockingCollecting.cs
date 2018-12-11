using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace CollectionsDemo {
    //https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.blockingcollection-1?view=netframework-4.7.2

    class AddTakeDemo {

        // Demonstrates:
        //      BlockingCollection<T>.Add()
        //      BlockingCollection<T>.Take()
        //      BlockingCollection<T>.CompleteAdding()
        public static async Task BC_AddTakeCompleteAdding () {
            using (BlockingCollection<int> bc = new BlockingCollection<int> ()) {

                // Spin up a Task to populate the BlockingCollection 
                using (Task t1 = Task.Factory.StartNew (() => {
                    bc.Add (1);
                    bc.Add (2);
                    bc.Add (3);
                    bc.CompleteAdding();
                })) {

                    // Spin up a Task to consume the BlockingCollection
                    using (Task t2 = Task.Factory.StartNew (() => {
                        try {
                            // Consume consume the BlockingCollection
                            while (true) Console.WriteLine (bc.Take ());
                        } catch (InvalidOperationException) {
                            // An InvalidOperationException means that Take() was called on a completed collection
                            Console.WriteLine ("That's All!");
                        }
                    }))
                    await Task.WhenAll (t1, t2);
                }

            }
        }
    }
    //
    class TryTakeDemo {
        public static void BC_TryTake () {
            using (BlockingCollection<int> bc = new BlockingCollection<int> ()) {
                int NUMITEMS = 10000;
                for (int i = 0; i < NUMITEMS; i++)
                    bc.Add (i);
                bc.CompleteAdding ();
                int outerSum = 0;

                Action action = () => {
                    int localItem;
                    int localSum = 0;

                    while (bc.TryTake (out localItem)) localItem += localItem;
                    Interlocked.Add (ref outerSum, localSum);
                };

                Parallel.Invoke (action, action, action);

                Console.WriteLine ("Sum[0..{0}) = {1}, should be {2}", NUMITEMS, outerSum, ((NUMITEMS * (NUMITEMS - 1)) / 2));
                Console.WriteLine ("bc.IsCompleted = {0} (should be true)", bc.IsCompleted);
            }
        }
    }

    class FromToAnyDemo {
        public static void BC_FromToAny () {
            BlockingCollection<int>[] bcs = new BlockingCollection<int>[2];
            bcs[0] = new BlockingCollection<int> (5); // collection bounded to 5 items
            bcs[1] = new BlockingCollection<int> (5); // collection bounded to 5 items

            int numFailures = 0;
            for (int i = 0; i < 10; i++) {
                if (BlockingCollection<int>.TryAddToAny (bcs, i) == -1) numFailures++;
            }

            Console.WriteLine ("TryAddToAny: {0} failures (should be 0)", numFailures);

            // Should be able to retrieve 10 items
            int numItems = 0;
            int item;
            while (BlockingCollection<int>.TryTakeFromAny (bcs, out item) != -1) numItems++;
            Console.WriteLine ("TryTakeFromAny: retrieved {0} items (should be 10)", numItems);
        }
    }

    class ConsumingEnumerableDemo {
        // Demonstrates:
        //      BlockingCollection<T>.Add()
        //      BlockingCollection<T>.CompleteAdding()
        //      BlockingCollection<T>.GetConsumingEnumerable()
        public static void BC_GetConsumingEnumerable () {
            using (BlockingCollection<int> bc = new BlockingCollection<int> ()) {

                // Kick off a producer task
                Task.Factory.StartNew (async () => {
                    for (int i = 0; i < 10; i++) {
                        bc.Add (i);
                        await Task.Delay (100); // sleep 100 ms between adds
                    }

                    // Need to do this to keep foreach below from hanging
                    bc.CompleteAdding ();
                });

                // Now consume the blocking collection with foreach.
                // Use bc.GetConsumingEnumerable() instead of just bc because the
                // former will block waiting for completion and the latter will
                // simply take a snapshot of the current state of the underlying collection.
                foreach (var item in bc.GetConsumingEnumerable ()) {
                    Console.WriteLine (item);
                }
            }
        }
    }
}