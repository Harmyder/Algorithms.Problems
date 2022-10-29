namespace SDK
{
    // 1. Every node is either red or black.
    // 2. The root is black.
    // 3. Every leaf is black.
    // 4. If a node is red, then both its children are black.
    // 5. For each node, all simple paths from the node to descendant leaves contain the the same number of black nodes.

    public class RedBlackTree
    {
        private Node Root = null;

        public void Insert(int key)
        {
            if (Root == null)
            {
                Root = new Node(false, Node.Nil, Node.Nil, Node.Nil, key);
            }
            else
            {
                var curr = Root;
                while (true)
                {
                    if (key < curr.Key)
                    {
                        if (curr.Left != null)
                        {
                            curr = curr.Left;
                        }
                        else
                        {
                            curr.Left = new Node(true, curr, Node.Nil, Node.Nil, key);
                            InsertFixup(curr.Left);
                            break;
                        }
                    }
                    else
                    {
                        if (curr.Right != null)
                        {
                            curr = curr.Right;
                        }
                        else
                        {
                            curr.Right = new Node(true, curr, Node.Nil, Node.Nil, key);
                            InsertFixup(curr.Right);
                            break;
                        }
                    }
                }
            }
        }

        public void Delete(int key)
        {
            var node = Find(key);
            var (isRemovedRed, replacementNode) = Delete_Internal(node);
            if (!isRemovedRed)
            {
                DeleteFixup(replacementNode);
            }
        }

        private (bool IsRemovedRed, Node ReplacementNode) Delete_Internal(Node node)
        {
            if (node.Left == Node.Nil)
            {
                var isRemovedRed = node.IsRed;
                var replacementNode = node.Right;
                Transplant(node, replacementNode);
                return (isRemovedRed, replacementNode);
            }
            else if (node.Right == Node.Nil)
            {
                var isRemovedRed = node.IsRed;
                var replacementNode = node.Left;
                Transplant(node, replacementNode);
                return (isRemovedRed, replacementNode);
            }
            else
            {
                var min = Minimimum(node.Right);
                var isRemovedRed = min.IsRed;
                var replacementNode = min.Right;
                if (min != node.Right)
                {
                    Transplant(min, min.Right);
                    min.Right = node.Right;
                    min.Right.Parent = min;
                }
                else
                {
                    replacementNode.Parent = min; // In case replacementNode is Nil
                }
                Transplant(node, replacementNode);
                min.Left = node.Left;
                min.Left.Parent = min;
                min.IsRed = node.IsRed;
                return (isRemovedRed, replacementNode);
            }
        }

        private void InsertFixup(Node node)
        {
            while (node.Parent.IsRed)
            {
                if (node.Parent == node.Parent.Parent.Left)
                {
                    var uncle = node.Parent.Parent.Right;
                    if (uncle.IsRed)
                    {
                        node.Parent.IsRed = false;
                        uncle.IsRed = false;
                        node.Parent.Parent.IsRed = true;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            node = node.Parent;
                            LeftRotate(node);
                        }
                        node.Parent.IsRed = false;
                        node.Parent.Parent.IsRed = true;
                        RightRotate(node);
                    }
                }
                else
                {

                }
            }
        }

        private void DeleteFixup(Node node)
        {
            while (node != Root && !node.IsRed)
            {

            }
            node.IsRed = false;
        }

        private Node Find(int key)
        {
            var curr = Root;
            while (curr != Node.Nil)
            {
                curr = key < curr.Key ? curr.Left : curr.Right;
            }
            return curr;
        }

        private Node Minimimum(Node node)
        {
            while (node.Left != Node.Nil)
            {
                node = node.Left;
            }
            return node;
        }

        private void Transplant(Node before, Node after)
        {
            if (before.Parent == Node.Nil)
            {
                Root = after;
            }
            else if (before == before.Parent.Left)
            {
                before.Parent.Left = after;
            }
            else
            {
                before.Parent.Right = after;
            }
            after.Parent = before.Parent;
        }

        private void LeftRotate(Node left) => Rotate_Internal(left, NodeSideSwitcher.Straight);

        private void RightRotate(Node right) => Rotate_Internal(right, NodeSideSwitcher.Switched);

        private void Rotate_Internal(Node left, NodeSideSwitcher switcher)
        {
            var right = switcher.GetRight(left);
            left.Right = switcher.GetLeft(right);
            if (switcher.GetLeft(right) != Node.Nil)
            {
                switcher.GetLeft(right).Parent = left;
            }
            right.Parent = left.Parent;
            if (left.Parent == Node.Nil)
            {
                Root = right;
            }
            else if (switcher.GetLeft(left.Parent) == left)
            {
                switcher.SetLeft(left.Parent, right);
            }
            else
            {
                switcher.SetRight(left.Parent, left);
            }
            switcher.SetLeft(right, left);
            left.Parent = right;
        }

        private class NodeSideSwitcher
        {
            private static Node _GetLeft(Node node) => node.Left;
            private static void _SetLeft(Node node, Node left) => node.Left = left;
            private static Node _GetRight(Node node) => node.Right;
            private static void _SetRight(Node node, Node right) => node.Right = right;

            private readonly Func<Node, Node> _getLeft;
            private readonly Action<Node, Node> _setLeft;
            private readonly Func<Node, Node> _getRight;
            private readonly Action<Node, Node> _setRight;

            private NodeSideSwitcher(
                Func<Node, Node> getLeft,
                Action<Node, Node> setLeft,
                Func<Node, Node> getRight,
                Action<Node, Node> setRight)
            {
                _getLeft = getLeft;
                _setLeft = setLeft;
                _getRight = getRight;
                _setRight = setRight;
            }

            public static NodeSideSwitcher Straight { get; } = new NodeSideSwitcher(_GetLeft, _SetLeft, _GetRight, _SetRight);
            public static NodeSideSwitcher Switched { get; } = new NodeSideSwitcher(_GetRight, _SetRight, _GetLeft, _SetRight);

            public Node GetLeft(Node node) => _getLeft(node);
            public void SetLeft(Node node, Node left) => _setLeft(node, left);
            public Node GetRight(Node node) => _getRight(node);
            public void SetRight(Node node, Node right) => _setRight(node, right);
        }

        private class Node
        {
            public static Node Nil = new Node(false, null, null, null, 0);

            public Node(bool isRed, Node parent, Node left, Node right, int key)
            {
                IsRed = isRed;
                Parent = parent;
                Left = left;
                Right = right;
                Key = key;
            }

            public bool IsRed;
            public Node Parent;
            public Node Left;
            public Node Right;
            public int Key;
        }

        public interface IIterator
        {
            public int Key { get; }
            public IIterator Next();
            public IIterator Prev();
        }
    }
}