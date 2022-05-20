using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCodeTests
{
    public class AddTwoNumbersV2Tests
    {
        [Fact]
        public void Should_add_two_linked_list()
        {
            // l1 = [2,4,3], l2 = [5,6,4]
            // var l1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            var l1 = new ListNode(2);
            AddNodes(l1, new[] { 4, 3 });

            var l2 = new ListNode(5);
            AddNodes(l2, new[] { 6, 4 });

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
            AddNodes(l1, new[] { 9, 9, 9, 9, 9, 9, });

            var l2 = new ListNode(9);
            AddNodes(l2, new[] { 9, 9, 9 });

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
            var dummyHead = new ListNode();
            var p = l1;
            var q = l2;
            var curr = dummyHead;
            var carry = 0;

            while (p != null || q != null)
            {
                var x = p?.val ?? 0;
                var y = q?.val ?? 0;
                var sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;

                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }

            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }

            return dummyHead.next;
        }

        private static void AddNodes(ListNode node, IEnumerable<int> values)
        {
            if (!values.Any()) return;

            node.next = new ListNode(values.First());
            AddNodes(node.next, values.Skip(1));
        }


    }

}