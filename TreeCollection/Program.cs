using TreeCollection;
Tree tree = new Tree();
Node root = new Node(23,23);
tree.Insert(22,22,root);
tree.Insert(24,24,root);
tree.Insert(1,1,root);
tree.PrintTree(root);
Console.WriteLine();

tree.Delete(1, root);
tree.PrintTree(root);