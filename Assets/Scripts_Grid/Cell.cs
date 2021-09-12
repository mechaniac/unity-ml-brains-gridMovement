using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGrid_NS1
{
    public class Cell : MonoBehaviour
    {
        public int w, h;
        public CellType cellType;

        public Unit currentUnit;

        public void SetCellType(Unit u)
        {

            currentUnit = u;
            //Debug.Log($"Set current unit: {u}");

            if (u.faction == FACTION.player)
            {
                cellType = CellType.player;
            }
            else if (u.faction == FACTION.enemy)
            {
                cellType = CellType.enemy;
            }

        }
    }
}