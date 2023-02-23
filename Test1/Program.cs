using System;
using System.Collections.Generic;
using System.Linq;

namespace Test1
{
    class Solution
    {
        static void Main(string[] args)
        {
            Console.WriteLine((int)'a');

            YiWeiShuZuDongTaiHe y1 = new YiWeiShuZuDongTaiHe();
            int[] y11 = y1.RunningSum(new int[] { 1, 2, 3, 4 });
            foreach (int item in y11)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Console.WriteLine(CanConstruct("aabbc", "saabcb"));

            string str = "absbab";
            Console.WriteLine(str.Contains("a"));

            Console.WriteLine(str.ToCharArray());

            //Sum函数可以计算数组中所有数字的和,需要引用命名空间 System.Linq
            int[] arr1 = new int[] { 1, 4 };
            int[] arr2 = new int[] { 1, 1 };
            Console.WriteLine(Math.Max(arr1.Sum(), arr2.Sum()));

            FizzBuzz(6);

            Test1 t1 = new Test1();
            Console.WriteLine(t1.NumberOfSteps(14));

            //二维数组
            int[,] arr3 = new int[,] { { 3, 2 }, { 1, 2 } };
            //交错数组
            int[][] arr4 = new int[][] { new int[]{1, 2, 3},
                                         new int[]{3, 2, 1} };

            Test2 t2 = new Test2();
            Console.WriteLine(t2.MaximumWealth(arr4));

            Test4 t4 = new Test4();
            Console.WriteLine(t4.RemoveDuplicates(new int[] { 1, 1, 2 }));
        }

        //1480
        public class YiWeiShuZuDongTaiHe//一维数组动态和
        {
            public int[] RunningSum(int[] nums)
            {
                for (int i = 1; i < nums.Length; i++)
                {
                    nums[i] += nums[i - 1];
                }
                return nums;
            }
        }

        //383
        public static bool CanConstruct(string ransomNote, string magazine)//赎金信
        {
            if (ransomNote.Length > magazine.Length)
            {
                return false;
            }
            int[] cnt = new int[26];
            foreach (char c in magazine)
            {
                cnt[c - 'a']++;
            }
            foreach (char c in ransomNote)
            {
                cnt[c - 'a']--;
                if (cnt[c - 'a'] < 0)
                {
                    return false;
                }
            }
            return true;
        }

        //412
        public static IList<string> FizzBuzz(int n)//Fizz Buzz
        {
            IList<string> list = new List<string>();
            string[] answer = new string[n];
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    answer[i - 1] = "FizzBuzz";
                }
                else if (i % 3 == 0 && i % 5 != 0)
                {
                    answer[i - 1] = "Fizz";
                }
                else if (i % 3 != 0 && i % 5 == 0)
                {
                    answer[i - 1] = "Buzz";
                }
                else
                {
                    answer[i - 1] = i.ToString();
                }
            }

            for (int i = 0; i < answer.Length; i++)
            {
                list.Add(answer[i]);
            }

            return list;
        }

        //876
        public class Test//链表的中间节点
        {
            public ListNode MiddleNode(ListNode head)
            {
                ListNode slow = head;
                ListNode fast = head;
                while (fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }
                return slow;
            }
        }

        public class ListNode//声明链表
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        //1342
        public class Test1//将数字变为0的操作次数
        {
            public int index = 0;

            public int NumberOfSteps(int num)
            {
                while (num != 0)
                {
                    if (num % 2 == 0)
                    {
                        num = num / 2;
                        index++;
                    }
                    else
                    {
                        num -= 1;
                        index++;
                    }
                }
                return index;
            }
        }

        //1672
        public class Test2//最富有客户的资产总量
        {
            int[] count = new int[50];
            int max = 0;
            int b = 0;


            public int MaximumWealth(int[][] accounts)
            {
                for (int i = 0; i < accounts.GetLength(0); i++)
                {
                    for (int j = 0; j < accounts[i].Length; j++)
                    {
                        b += accounts[i][j];
                    }
                    count[i] += b;
                    b = 0;
                }

                for (int i = 0; i < count.Length; i++)
                {
                    max = count[i] > max ? count[i] : max;
                }

                return max;
            }
        }

        //2236
        public class Test3//判断根结点是否等于子结点之和
        {
            public bool CheckTree(TreeNode root)
            {
                if (root.val == root.left.val + root.right.val)
                    return true;
                return false;
            }
        }

        public class TreeNode//声明二叉树
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        //26. 删除有序数组中的重复项
        public class Test4
        {
            public int a = 0;
            public int RemoveDuplicates(int[] nums)
            {
                int t = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i == 0 || nums[i] != nums[i - 1]) nums[t++] = nums[i];
                }
                return t;
            }
        }
    }
}
