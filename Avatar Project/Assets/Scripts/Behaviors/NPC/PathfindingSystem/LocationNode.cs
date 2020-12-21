using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationNode
{
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;

    public LocationNode parent;

    public LocationNode(bool walkable, Vector3 worldPosition, int gridX, int gridY){
        this.walkable = walkable;
        this.worldPosition = worldPosition;
        this.gridX = gridX;
        this.gridY = gridY;
    }

    public int fCost{
        get{
            return gCost+hCost;
        }
    }
}
