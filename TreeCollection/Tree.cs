using TreeCollection;

public class Tree
{
    public void Insert(int key,int value,Node node)
    {
        if(key < node.key)
        {
            if (node.left is null) node.left = new Node(key,value);
            else Insert(key,value,node.left);
        }
        if (key > node.key)
        {
            if (node.right is null) node.right = new Node(key, value);
            else Insert(key,value,node.right);
        }
    }
    
    public int? Search(int key,Node? node)
    {
        if (node.key == key) return node.value;
        return (key < node.key) ? Search(key,node.left):Search(key,node.right);
    }
    
    public Node? GetMin(Node node)
    {
        if (node is null) return null;
        if (node.left is null) return node;
        return GetMin(node.left);
    }
    
    public Node GetMax(Node node)
    {
        if (node is null) return null;
        if (node.right is null) return node;
        return GetMax(node.right);
    }

    public Node? Delete(int key,Node? root)
    {
        if (root is null) return null;
        else if (key < root.key)
            root.left = Delete(key, root.left);
        else if (key > root.key)
            root.right = Delete(key, root.right);
        else
        {
            if (root.left is null || root.right is null)
                root = (root.left is null) ? root.right : root.left;
            else
            {
                Node maxInLeft = GetMax(root.left);
                root.key = maxInLeft.key;
                root.value = maxInLeft.value;
                root.right = Delete(maxInLeft.key, root.right);
            }
        }
        return root;
    }
    public void PrintTree(Node root)
    {
        if (root is null) return;
        PrintTree(root.left);
        Console.WriteLine(root.key);
        PrintTree(root.right);
    }
}