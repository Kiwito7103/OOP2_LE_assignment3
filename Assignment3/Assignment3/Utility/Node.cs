using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.ProblemDomain;

namespace Assignment3.Utility
{
    [Serializable]
    public class Node
    {
        public User value;

        public User Data { get; set; }
        public Node Next { get; set; }

        public Node(User data)
        {
            Data = data;
            Next = null;
        }
    }
}
