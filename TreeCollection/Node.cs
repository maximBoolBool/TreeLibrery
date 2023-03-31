namespace TreeCollection;

public class Node
{
    public  int key;
    public   int value;
    public Node? left;
    public Node? right;

    public Node(int _key, int _value)
    {
        key = _key;
        value = _value;
    }
}