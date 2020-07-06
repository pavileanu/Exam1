using System.Collections.Generic;
using System.Linq;

namespace GunvorRecruitment.Repository
{
    public class NodeManager
    {
        private readonly IRepository _nodeRepository;

        public List<Node> AllNodes;

        public NodeManager(IRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
            AllNodes = new List<Node>();
        }

        public Node GetNodeAndImmediateChildren(string name)
        {
            Node NewNode = _nodeRepository.GetNodeAndImmediateChildren(name);
           
            if (!IsNodeLoaded(NewNode))
            {
                AllNodes.Add(NewNode);
                foreach(var nodeItem in NewNode.ImmediateChildren)
                {
                    if (!IsNodeLoaded(nodeItem))
                        AllNodes.Add(nodeItem);
                }

                return NewNode;
            }    
            else
            {
                return GetNode(name);

            }           
        }

        public bool IsNodeLoaded(Node NewNode)
        {
            return AllNodes.Where(n => n.Name == NewNode.Name).Any();
        }

        public Node GetNode(string name)
        {
            return AllNodes.Where(n => n.Name == name).FirstOrDefault();
        }

    }
}
