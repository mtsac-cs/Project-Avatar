using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Transform seeker, target;
    NodeGrid grid;
    private void Awake()
    {
        grid = GetComponent<NodeGrid>();
    }
    private void Update()
    {
        FindPath(seeker.position, target.position);
    }
    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        LocationNode startNode = grid.NodeFromWorldPoint(startPos);
        LocationNode targetNode = grid.NodeFromWorldPoint(targetPos);

        List<LocationNode> openSet = new List<LocationNode>();
        HashSet<LocationNode> closedSet = new HashSet<LocationNode>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            LocationNode currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost)
                {
                    if (openSet[i].hCost < currentNode.hCost)
                    {
                        currentNode = openSet[i];
                    }
                }
            }


            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (LocationNode neighbor in grid.GetNeighbors(currentNode))
            {
                if (!neighbor.walkable || closedSet.Contains(neighbor))
                {
                    continue;
                }

                int newCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);
                if (newCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newCostToNeighbor;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }
    }

    void RetracePath(LocationNode startNode, LocationNode endNode)
    {
        List<LocationNode> path = new List<LocationNode>();
        LocationNode curNode = endNode;

        while (curNode != startNode)
        {
            path.Add(curNode);
            curNode = curNode.parent;
        }
        path.Reverse();

        grid.path = path;
    }

    int GetDistance(LocationNode nodeA, LocationNode nodeB)
    {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (distX > distY)
        {
            return 10 * distY + 10 * (distX - distY);
        }
        return 10 * distX + 10 * (distY - distX);
    }
}
