using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsDemo {
    class ProgramClass {
        static async Task Main () {

            Console.WriteLine ("------Collections Example--------");

            //ListClass.listOperation();
            //ArrayListClass.arrayListOperation();
            //HashTableClass.hashTableOperation();

            // CollectionClass collectionClass = new CollectionClass ("We know what is a collection class.");
            // foreach (string collection in collectionClass) {
            //     Console.WriteLine (collection);
            // }

            try {
                await AddTakeDemo.BC_AddTakeCompleteAdding ();
                TryTakeDemo.BC_TryTake ();
                FromToAnyDemo.BC_FromToAny ();
                ConsumingEnumerableDemo.BC_GetConsumingEnumerable ();

            } catch (Exception ex) {
                Console.WriteLine (ex);
            }

        }

    }
}