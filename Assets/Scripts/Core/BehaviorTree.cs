using System;
using System.Collections.Generic;

namespace Core
{
    public class BehaviorTree
    {
        /// <summary>
        /// 节点状态枚举
        /// </summary>
        public enum NodeState
        {
            Default,
            Success,
            Failure,
            Running,
        }

        /// <summary>
        /// 节点
        /// </summary>
        public abstract class Node
        {
            public abstract NodeState Tick();
            public abstract void Reset();
        }
        
        /// <summary>
        /// 复合节点
        /// </summary>
        public abstract class Composite : Node
        {
            protected readonly List<Node> _nodes = new List<Node>();

            public Node AddNodes(params Node[] nodes)
            {
                foreach (var node in nodes)
                {
                    _nodes.Add(node);
                }

                return this;
            }
        }
        
        /// <summary>
        /// 装饰节点
        /// </summary>
        public abstract class Decorator : Node
        {
            protected Node _node;

            public Node SetNode(Node node)
            {
                _node = node;
                return this;
            }
        }
        
        /// <summary>
        /// 条件节点
        /// </summary>
        public class Condition : Node
        {
            private Func<bool> _condition;

            public Condition(Func<bool> func)
            {
                _condition = func;
            }
        
            public override NodeState Tick()
            {
                return _condition.Invoke() ? NodeState.Success : NodeState.Failure;
            }

            public override void Reset()
            {
            }
        }
        
        /// <summary>
        /// 选择节点
        /// </summary>
        public class Selector : Composite
        {
            private Node _selectNode;

            public override NodeState Tick()
            {
                if (_selectNode == null)
                {
                    foreach (var node in _nodes)
                    {
                        if (node.Tick() != NodeState.Failure)
                        {
                            _selectNode = node;
                            break;
                        }
                    }

                    return _selectNode == null ? NodeState.Failure : NodeState.Running;
                }
                else
                {
                    return _selectNode.Tick();
                }
            }

            public override void Reset()
            {
                _selectNode = null;
                _nodes.ForEach(node =>
                {
                    node.Reset();
                });
            }
        }

        /// <summary>
        /// 顺序节点
        /// </summary>
        public class SequenceNode : Composite
        {
            private int _currentNodeIndex = 0;

            private Node GetCurrentNode()
            {
                if (_currentNodeIndex > _nodes.Count - 1)
                {
                    // 当前是最后一个节点
                    return null;
                }

                return _nodes[_currentNodeIndex];
            }

            private bool NextNode()
            {
                _currentNodeIndex++;
                if (_currentNodeIndex >= _nodes.Count)
                {
                    // 没有下一个节点
                    return false;
                }
                return true;
            }
            public override NodeState Tick()
            {
                var curNode = GetCurrentNode();
                if (curNode == null)
                {
                    // 没有可以执行的节点
                    return NodeState.Success;
                }

                switch (curNode.Tick())
                {
                    case NodeState.Success:
                        return NextNode() ? NodeState.Running : NodeState.Success;
                    case NodeState.Running:
                        return NodeState.Running;
                }

                return NodeState.Failure;
            }

            public override void Reset()
            {
                _currentNodeIndex = 0;
                _nodes.ForEach(node =>
                {
                    node.Reset();
                });
            }
        }

        /// <summary>
        /// 循环节点
        /// </summary>
        public class WhileNode : Decorator
        {
            private Func<bool> _condition;

            private bool _isCondition;

            public WhileNode(Func<bool> func)
            {
                _condition = func;
            }
        
            public override NodeState Tick()
            {
                if (!_isCondition)
                {
                    _isCondition = _condition.Invoke();
                }
                if (_isCondition)
                {
                    if (_node.Tick() != NodeState.Running)
                    {
                        _node.Reset();
                        _isCondition = false;
                    }
                    return NodeState.Running;
                }

                return NodeState.Success;
            }

            public override void Reset()
            {
                _node.Reset();
                _isCondition = false;
            }
        }
        
        public class ActionNode : Node
        {
            protected Func<bool> _func;

            public ActionNode(Func<bool> func)
            {
                _func = func;
            }

            public override NodeState Tick()
            {
                if (_func.Invoke())
                {
                    return NodeState.Success;
                }
                else
                {
                    return NodeState.Running;
                }
            }

            public override void Reset()
            {
            }
        }
        
        /// <summary>
        /// 条件行动节点
        /// </summary>
        public class ConditionAction : Decorator
        {
            private NodeState _result;
            private Condition _condition;
            
            public ConditionAction(Condition condition)
            {
                _condition = condition;
            }
            
            public override NodeState Tick()
            {
                if (_result == NodeState.Default)
                {
                    _result = _condition.Tick();
                    if (_result == NodeState.Failure)
                    {
                        return NodeState.Failure;
                    }
                }

                return _node.Tick();
            }
            
            public override void Reset()
            {
                _node.Reset();
                _result = default;
            }
        }
        
        public class WaitNode : Node
        {
            private readonly int _frame;
            private int _curFrame;

            public WaitNode(int frame)
            {
                _frame = frame;
                _curFrame = 0;
            }
        
            public override NodeState Tick()
            {
                _curFrame++;
                if (_curFrame >= _frame)
                {
                    return NodeState.Success;
                }
                else
                {
                    return NodeState.Running;
                }
            }

            public override void Reset()
            {
                _curFrame = 0;
            }
        }
    }
}