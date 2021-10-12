using System;

namespace Algorithms {
    public static class FisherYates
    {
        public static void Shuffle(this object[] objs) {
            // Version 1 of the Fisher-Yates Shuffle
            // iterates backwards through object array
            // chooses random index and swaps object at that index
            // with object at for-loop's current index

            var rnd = new Random();

            // terminate loop at i == 0 so as not to swap objs[0] and objs[1] twice
            for (int i = objs.Length - 1; i > 0; i--) {
                objs.SwapAtIndices(i, rnd.Next(i + 1)); // Random.Next(max) is non-inclusive

                // did not create separate method for generating random index
                // as it seemed wasteful and obfuscated Random.Next's default behavior
            }
        }

        public static void SwapAtIndices(this object[] objs, int i, int j) {
            // swaps objects at the two given indices
            // kept this method in FisherYates class for ease of reading

            var tmp = objs[j];
            objs[j] = objs[i];
            objs[i] = tmp;
        }
    }
}
