using Xunit;

namespace LeetCodeTests
{
    public class AddTwoNumbersTests
    {
        [Fact]
        public void Should_add_two_linked_list()
        {
            // l1 = [2,4,3], l2 = [5,6,4]
            var l1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4, null)));

            var l3 = Add(l1, l2);
            
            Assert.Equal(7, l3.Val);
            Assert.Equal(10, l3.Next.Val);
            Assert.Equal(7, l3.Next.Next.Val);
        }

        [Fact]
        public void Should_add_two_zeros()
        {
            // l1 = [0], l2 = [0]
            var l1 = new ListNode(0);
            var l2 = new ListNode(0);

            var l3 = Add(l1, l2);
            
            Assert.Equal(0, l3.Val);
        }

        [Fact]
        public void Should_add_two_list_with_different_length()
        {
            // l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
            var l1 = new ListNode(0);
            var l2 = new ListNode(0);

            var l3 = Add(l1, l2);
            
            Assert.Equal(0, l3.Val);
        }

        private ListNode Add(ListNode l1, ListNode l2)
        {
            var node = new ListNode(l1.Val + l2.Val);
            SetNode(node, l1, l2);

            return node;
        }

        private static void SetNode(ListNode node, ListNode l1, ListNode l2)
        {
            if (l1.Next == null && l2.Next == null) return;
            
            var nextNode = new ListNode(l1.Next.Val + l2.Next.Val);
            node.Next = nextNode;
            SetNode(nextNode, l1.Next, l2.Next);
        }

        private static ListNode CreateNode(int[] values)
        {
            
        }
    }

    public class ListNode
    {
        public int Val { get; }
        public ListNode Next { get; set; }
        
        public ListNode(int val = 0, ListNode next = null)
        {
            Val = val;
            Next = next;
        }
    }
}