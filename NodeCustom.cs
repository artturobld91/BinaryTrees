using System.Collections;

public class NodeT
{
    public string value;
    public NodeT left;
    public NodeT right;

    public NodeT(string value)
    {
        this.value = value;
        this.left = null;
        this.right = null;
    }
}


//       A
//      / \
//     B   C
//    / \   \
//   D   E   F

public class BinaryTreeExcercises
{
    public void BinaryTreeDemo()
    {
        NodeT a = new NodeT("a");
        NodeT b = new NodeT("b");
        NodeT c = new NodeT("c");
        NodeT d = new NodeT("d");
        NodeT e = new NodeT("e");
        NodeT f = new NodeT("f");

        a.left = b;
        a.right = c;
        b.left = d;
        b.right = e;
        c.right = f;

        BinaryDepthFirstTraversalDemo(a);
        BinaryDepthFirstTraversalRecursiveDemo(a);
        BinaryBreadthFirstTraversalDemo(a);
    }

    public List<NodeT> BinaryDepthFirstTraversalDemo(NodeT root)
    {
        Console.WriteLine("Binary Depth First");
        List<NodeT> results = new List<NodeT>();
        if(root == null)
            return results;

        Stack stack = new Stack();
        stack.Push(root);

        while(stack.Count > 0)
        {
            NodeT current = (NodeT)stack.Pop();
            Console.WriteLine(current.value);
            results.Add(current);

            if(current.right != null) { stack.Push(current.right); }

            if(current.left != null) { stack.Push(current.left); }
        }

        return results;
    }

    public List<NodeT> BinaryDepthFirstTraversalRecursiveDemo(NodeT root)
    {
        Console.WriteLine("Binary Depth First Recursive");
        if(root == null)
            return new List<NodeT>();
        
        List<NodeT> leftValues = BinaryDepthFirstTraversalRecursiveDemo(root.left);
        List<NodeT> rightValues = BinaryDepthFirstTraversalRecursiveDemo(root.right);

        List<NodeT> results = new List<NodeT>(){ root };

        leftValues.ForEach(node => results.Add(node));
        rightValues.ForEach(node => results.Add(node));

        Console.WriteLine("Recursive result");
        results.ForEach(node => Console.WriteLine(node.value));

        return results;
    }

    public List<NodeT> BinaryBreadthFirstTraversalDemo(NodeT root)
    {
        Console.WriteLine("Binary Breadth First");
        List<NodeT> results = new List<NodeT>();
        if(root == null)
            return results;

        Queue queue = new Queue();
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            NodeT current = (NodeT)queue.Dequeue();
            Console.WriteLine(current.value);
            results.Add(current);

            if(current.left != null) { queue.Enqueue(current.left); }
            if(current.right != null) { queue.Enqueue(current.right); }

        }

        return results;
    }

    public int getBinaryTreeHeight(NodeT root){
        if (root == null) {
            return -1;
        }

        int lefth = getBinaryTreeHeight(root.left);
        int righth = getBinaryTreeHeight(root.right);

        if (lefth > righth) {
            return lefth + 1;
        } else {
            return righth + 1;
        }
    }
}