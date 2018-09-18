//url:https://leetcode.com/problems/reverse-nodes-in-k-group/description/

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        
                  
            if (k == 0 || k == 1)
                return head;

            ListNode first = head;

            ListNode prev = first;
            var count = 0;
            while (prev != null)
            {
                prev = prev.next;
                ++count;

            }


            ListNode fakeNode = new ListNode(0);
            fakeNode.next = first;


            var groupsCount = count / k;

            var tmp = fakeNode;

            for (var i = 0; i < groupsCount; ++i)
            {

                reverceNodes(tmp, k);
                tmp = skeepNodes(tmp, k);
                

                if (tmp == null)
                {

                }
            }




            //K = 2
            // | 1 2| | 3  4 | 5 
            // 2 1 3 4
            //  
            //
            //
            //4 3 2 1 5 6
            return fakeNode.next;


    }
    
     
            static ListNode moveNextNodeForward(ListNode node_1_2)
        {
            if (node_1_2.next == null)
                return null;

            var node_2_3 = node_1_2.next;

            if (node_2_3.next == null)
                return null;

            var node_3_4 = node_2_3.next;
            //


            node_1_2.next = node_3_4;

            node_2_3.next = node_3_4.next;

            node_3_4.next = node_2_3;

            return node_1_2.next;

        }

        static ListNode skeepNodes(ListNode nodeBoforeGroup, int count)
        {
            var res = nodeBoforeGroup;
            while (count > 0)
            {
                if (res == null)
                    return null;

                res = res.next;
                --count;
            }
            return res;
        }
          static void reverceNodes(ListNode pNodeBoforeGroup, int pCount)
        {

            if (pCount == 2)
            {
                moveNextNodeForward(pNodeBoforeGroup);

            }
            else
            {

                var arr = new ListNode[pCount];
                var tmp = pNodeBoforeGroup;
                for (var i = 0; i < arr.Length; ++i)
                {
                    tmp = arr[i] = tmp.next;

                }

                var nodeAfterGroup = arr[arr.Length - 1].next;

                Array.Reverse(arr);

                //restore chain
                ListNode prev = pNodeBoforeGroup;//first
                foreach (var n in arr)
                {
                    prev.next = n;
                    prev = n;
                }


                arr[arr.Length - 1].next = nodeAfterGroup;//last

            }
 
        }

 

}
