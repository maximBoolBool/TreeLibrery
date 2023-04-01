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
        UpdateHeight(node);
        Balance(node);
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
        if (root is not null)
        {
            UpdateHeight(root);
            Balance(root);
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
    public int GetHeight(Node? node)
    {
        return (node is null) ? -1 : node.height;
    }
    public void UpdateHeight(Node node)
    {
        node.height = Math.Max(GetHeight(node.left),GetHeight(node.right))+1;
    }
    public void Swap(Node a,Node b)
    {
        int a_key = a.key;
        a.key = b.key;
        b.key = a_key;
        int a_value = a.value;
        a.value = b.value;
        b.value = a_value;
    }
    public int GetBalance(Node node)
    {
        return (node == null) ? 0 : GetHeight(node.right) - GetHeight(node.left);
    }
    void RightRotate(Node node)
    {
        Swap(node,node.left);
        Node buffer = node.right;
        node.right = node.left;
        node.left = node.right.left;
        node.right.left = node.right.right;
        node.right.right = buffer;
        UpdateHeight(node.right);
        UpdateHeight(node);
    }
    void LeftRotate(Node node)
    {
        Swap(node,node.right);
        Node buffer = node.left;
        node.left = node.left;
        node.right = node.left.right;
        node.right.left = node.right.right;
        node.left.right = node.left.left;
        node.left.left = buffer;
        UpdateHeight(node.left);
        UpdateHeight(node);
    }
    public void Balance(Node node)
    {
        int balance = GetBalance(node);
        if (balance == 2)
        {
            if(GetBalance(node.left)==1) LeftRotate(node.left);
            RightRotate(node);
        }
        if (balance == -2)
        {
            if(GetBalance(node.right)==-1) RightRotate(node.right);
            LeftRotate(node);
        }
    }
}