using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseLinq
{
    public class TreeNode<T>
    {
        public T Data { get; }

        public List<TreeNode<T>> Child { get; set; }

        public TreeNode(T data)
        {
            this.Data = data;
            this.Child = new List<TreeNode<T>>();
        }

        //public IEnumerable<TreeNode<T>> DepthFirstTraversal(List<T> tree)
        //{
        //    return (x=>)
        //    // your code here

        //}

        //public IEnumerable<TreeNode<T>> BreadthFirstTraversal()
        //{
        //    // your code here
        //}
    }


 
}
