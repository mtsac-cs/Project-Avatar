using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGrid : MonoBehaviour
{
    public Transform player;
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    LocationNode[,] grid;
    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = 2 * nodeRadius;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }
    void CreateGrid()
    {
        grid = new LocationNode[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.up * gridWorldSize.y/2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x*nodeDiameter+nodeRadius) + Vector3.up * (y*nodeDiameter+nodeRadius);
                //may need to change later if it lags?
                //Vector2 box = new Vector2(nodeDiameter - 0.1f, nodeDiameter - 0.1f);
                bool walkable = !(Physics2D.OverlapBox(worldPoint, Vector2.one*nodeDiameter, 90, unwalkableMask));
                grid[x,y] = new LocationNode(walkable,worldPoint, x, y);
            }
        }
    }

    public LocationNode NodeFromWorldPoint(Vector3 worldPosition){
        float percentX = (worldPosition.x + gridWorldSize.x/2) / gridWorldSize.x;
        float percentY = (worldPosition.y + gridWorldSize.y/2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);
        int x = Mathf.FloorToInt(Mathf.Clamp(gridSizeX*percentX,0,gridSizeX-1));
        int y = Mathf.FloorToInt(Mathf.Clamp(gridSizeY*percentY,0,gridSizeY-1));
        return grid[x,y];
    }

    public List<LocationNode> GetNeighbors(LocationNode node){
        List<LocationNode> neighbors = new List<LocationNode>();
        for(int x = -1; x <= 1; x++){
            for(int y = -1; y <= 1; y++){
                if(x==0 && y==0){
                    continue;
                }

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if(checkX >= 0 && checkX < gridSizeX && checkY >=0 && checkY < gridSizeY){
                    neighbors.Add(grid[checkX,checkY]);
                }
            }
        }

        return neighbors;
    }
    public List<LocationNode> path;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, gridWorldSize);
        if(grid!=null){
            // LocationNode playerNode = NodeFromWorldPoint(player.position);
            foreach(LocationNode n in grid){
                Gizmos.color = (n.walkable)?Color.white:Color.red;
                // if(playerNode==n){
                //     Gizmos.color = Color.cyan;
                // }
                if(path!=null){
                    if(path.Contains(n)){
                        Gizmos.color = Color.black;
                        Debug.Log("Logged");
                    }
                }
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.0f));
            }
        }
    }
}
