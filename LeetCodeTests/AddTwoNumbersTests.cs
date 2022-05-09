using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCodeTests
{
    public class AddTwoNumbersTests
    {
        [Fact]
        public void Should_add_two_linked_list()
        {
            // l1 = [2,4,3], l2 = [5,6,4]
            // var l1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            var l1 = new ListNode(2);
            AddNodes(l1, new []{4, 3});
            
            var l2 = new ListNode(5);
            AddNodes(l2, new []{6, 4});

            var l3 = AddTwoNumbers(l1, l2);
            
            Assert.Equal(7, l3.val);
            Assert.Equal(0, l3.next.val);
            Assert.Equal(8, l3.next.next.val);
        }

        [Fact]
        public void Should_add_two_zeros()
        {
            // l1 = [0], l2 = [0]
            var l1 = new ListNode(0);
            var l2 = new ListNode(0);

            var l3 = AddTwoNumbers(l1, l2);
            
            Assert.Equal(0, l3.val);
        }

        [Fact]
        public void Should_add_two_list_with_different_length()
        {
            // l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
            var l1 = new ListNode(9);
            AddNodes(l1, new []{9,9,9,9,9,9,});
            
            var l2 = new ListNode(9);
            AddNodes(l2, new[]{9,9,9});

            var l3 = AddTwoNumbers(l1, l2);
            
            Assert.Equal(8, l3.val);
            Assert.Equal(9, l3.next.val);
            Assert.Equal(9, l3.next.next.val);
            Assert.Equal(9, l3.next.next.next.val);
            Assert.Equal(0, l3.next.next.next.next.val);
            Assert.Equal(0, l3.next.next.next.next.next.val);
            Assert.Equal(0, l3.next.next.next.next.next.next.val);
            Assert.Equal(1, l3.next.next.next.next.next.next.next.val);
        }

        private ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var (newNode, overflow) = Add(l1, l2, 0);
            AddNode(newNode, l1.next, l2.next, overflow);

            return newNode;
        }

        private static void AddNode(ListNode node, ListNode l1, ListNode l2, int overflow)
        {
            if (l1 == null && l2 == null && overflow == 0) return;
            int newOverflow;
            (node.next, newOverflow) = Add(l1, l2, overflow);
            AddNode(node.next, l1?.next, l2?.next, newOverflow);
        }
        
        public static (ListNode node, int newOverflow) Add(ListNode l1, ListNode l2, int overflow)
        {
            var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + overflow;
            var adjustedSum = sum >= 10
                ? sum - 10
                : sum;
            var newOverflow = sum >= 10
                ? 1
                : 0;
            return (new ListNode(adjustedSum), newOverflow);
        }
        
        private static void AddNodes(ListNode node, IEnumerable<int> values)
        {
            if (!values.Any()) return;

            node.next = new ListNode(values.First());
            AddNodes(node.next, values.Skip(1));
        }

        
    }

    public class ListNode
    {
        public int val { get; }
        public ListNode next { get; set; }
        
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}