namespace TreeCollection;

public class Node
{
    private int key;
    private int value;
    private Node? left;
    private Node? right;

    Node(int _key, int _value)
    {
        key = _key;
        value = _value;
    }

    public void Insert(int key,int value)
    {
        if (key < this.key)
        {
            if (this.left == null)  this.left = new Node(key,value);
            else left.Insert(key,value);
        }
        else if(key>this.key)
        {
            if (this.right is null) this.right = new Node(key,value);
            else right.Insert(key,value);
        }
    }
    public int? Search(int key)
    {
        if (this is null) return null;
        if (this.key == key) return this.value;
        return (this.key < this.key) ? left.Search(key) : right.Search(key);
    }
}