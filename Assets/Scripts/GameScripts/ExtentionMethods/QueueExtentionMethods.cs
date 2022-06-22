using System.Collections.Generic;

namespace GameScripts.ExtentionMethods{
    public static class QueueExtentionMethods{
        public static bool IsSameValues <T>(this Queue<T> queue1,Queue<T> queue2) {
            foreach (var item in queue1) {
                if (!item.Equals(queue2.Dequeue())) {
                    return false;
                }
            }
            return true;
        }
    }
}