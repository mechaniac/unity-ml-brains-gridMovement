using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGrid_NS1
{
    public class MyGrid : MonoBehaviour
    {

        [SerializeField]
        Cell cellPrefab;

        [SerializeField]
        GameObject wallPrefab;

        [SerializeField]
        Unit enemyPrefab;

        [SerializeField]
        Unit playerPrefab;

        [SerializeField]
        int width, height;


        public Unit[] playerUnits;
        public Unit[] enemyUnits;

        public Cell[,] cells;


        private void Awake()
        {

        }
        public void InitializeBoard()
        {
            ClearGrid();
            Debug.Log("Initializing Board");
            //---------- CELLS ----------
            cells = new Cell[width, height];
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    Cell c = cells[w, h] = Instantiate(cellPrefab, transform, false);
                    c.transform.localPosition = new Vector3(w, 0, h);
                    c.transform.localRotation = Quaternion.Euler(90, 0, 90);
                    //Cell c = cells[w, h] = Instantiate(cellPrefab, new Vector3(w, 0, h), Quaternion.Euler(90, 0, 0));
                    //c.transform.SetParent(transform);
                    c.cellType = CellType.empty;
                    c.w = w;
                    c.h = h;

                }
            }

            //---------- WALLS ----------

            int numberOfWalls = 2;

            for (int i = 0; i < numberOfWalls; i++)
            {
                Cell c = GetRandomCell();
                while (c.cellType != CellType.empty) c = GetRandomCell();
                InstantiateWall(c);

            }

            //---------- UNITS ----------

            int numberOfUnits = 2;

            playerUnits = new Unit[numberOfUnits];
            enemyUnits = new Unit[numberOfUnits];

            for (int i = 0; i < numberOfUnits; i++)
            {
                Cell c = GetRandomCell();
                while (c.cellType != CellType.empty) c = GetRandomCell();
                InstantiateUnit(c, playerPrefab, CellType.player, i);

            }

            for (int i = 0; i < numberOfUnits; i++)
            {
                Cell c = GetRandomCell();
                while (c.cellType != CellType.empty) c = GetRandomCell();
                InstantiateUnit(c, enemyPrefab, CellType.enemy, i);
            }
        }


        Cell GetRandomCell()
        {
            Vector2 r = new Vector2(Random.Range(0, width), Random.Range(0, height));
            //Debug.Log($"Random w, h: {r}");
            return cells[(int)r.x, (int)r.y];
        }
        internal float TryExecuteAttack(Unit u)
        {
            Debug.Log($"ATTACK from {u}");
            List<Unit> l = GetAllSurroundingEnemies(u);
            if (l.Count <= 0) return -1f;

            float r = 0;
            foreach (Unit un in l)
            {
                u.Attack(un);
                r += .1f;
                Debug.Log($"HIT!! {un.currentCell.w}, {un.currentCell.h}");

            }
            return r;
        }

        internal bool DoesCellExistAndIsEmpty(int w, int h)
        {
            if (!DoesCellExist(w, h)) return false;

            if (cells[w, h].cellType == CellType.empty) return true;
            else return false;
        }
        internal bool DoesCellExist(int w, int h)
        {
            return (w > -1 && w < width) && (h > -1 && h < height);
        }


        internal Cell GetCell(int w, int h)
        {
            return cells[w, h];
        }

        void InstantiateWall(Cell c)
        {
            GameObject w = Instantiate(wallPrefab, transform,false);
            w.transform.localPosition = new Vector3(c.w, 0.5f, c.h);

            //GameObject w = Instantiate(wallPrefab, new Vector3(c.w, 0.5f, c.h), Quaternion.identity);
            //w.transform.SetParent(transform);
            c.cellType = CellType.wall;
        }
        void InstantiateUnit(Cell c, Unit prefab, CellType cT, int unitArrayIndex)
        {
            Unit u = Instantiate(prefab, transform, false);
            u.transform.localPosition = new Vector3(c.w, 0f, c.h);
            //Unit u = Instantiate(prefab, new Vector3(c.w, 0f, c.h), Quaternion.identity);
            //u.transform.SetParent(transform);
            
            u.currentCell = c;
            c.SetCellType(u);

            if (cT == CellType.enemy)
            {
                u.faction = FACTION.enemy;
                enemyUnits[unitArrayIndex] = u;
            }
            else if (cT == CellType.player)
            {
                u.faction = FACTION.player;
                playerUnits[unitArrayIndex] = u;
            }
        }

        void ClearGrid()
        {
            foreach(Transform t in transform)
            {
                Destroy(t.gameObject);
            }
        }
        internal static (int w, int h) GetVectorFromDirection(DIRECTION d)
        {
            switch (d)
            {
                case DIRECTION.UP:
                    return (0, 1);
                case DIRECTION.LEFT:
                    return (-1, 0);
                case DIRECTION.DOWN:
                    return (0, -1);
                case DIRECTION.RIGHT:
                    return (1, 0);
                default:
                    return (0, 0);
            }
        }

        public float TryMoveInDirection(Unit u, DIRECTION d)
        {
            Cell oldCell = u.currentCell;
            int wD = GetVectorFromDirection(d).w + u.currentCell.w;
            int hD = GetVectorFromDirection(d).h + u.currentCell.h;

            Debug.Log($"moving in direction {d}");

            if (DoesCellExistAndIsEmpty(wD, hD))
            {
                Debug.Log("Can move");
                Cell c = cells[wD, hD];
                u.MoveToCell(c);
                oldCell.cellType = CellType.empty;
                oldCell.currentUnit = null;
                return -.01f;
            }
            return -1f;
        }

        public List<Cell> GetAllSurroundingCells(Cell c)
        {
            (int w, int h) = (c.w, c.h);
            var l = new List<Cell>();

            for (int wD = -1; wD <= 1; wD++)
            {
                for (int hD = -1; hD <= 1; hD++)
                {
                    
                    if (DoesCellExist(w + wD, h + hD))
                    {
                        l.Add(cells[w + wD, h + hD]);
                        //Debug.Log($"currentCell added: {cells[w + wD, h + hD].w}, {cells[w + wD, h + hD].h}");
                    }

                }
            }
            return l;
        }
        public List<Unit> GetAllSurroundingEnemies(Unit me)
        {
            var lR = new List<Unit>();
            var l = GetAllSurroundingCells(me.currentCell);

            foreach (Cell cell in l)
            {
                if (cell.currentUnit != null)
                {
                    //Debug.Log($"Faction: {cell.currentUnit.faction}");
                    if (cell.currentUnit.faction != me.faction)
                    {
                        lR.Add(cell.currentUnit);
                        //Debug.Log($"currentUnit added: {cell.w}, {cell.h}");
                    }

                }
            }
            return lR;
        }

        internal bool CheckGameState()
        {
            //Debug.Log("Checking game state: now");
            if (!IsFactionStillAlive(FACTION.player)) return false;

            if (!IsFactionStillAlive(FACTION.enemy)) return false;
            //Debug.Log("Still alive");
            return true;
        }

        internal bool IsFactionStillAlive(FACTION f)
        {
            //Debug.Log("is faction still alive");
            Unit[] us;
            if (f == FACTION.player)
            {
                us = playerUnits;
            }
            else
            {
                us = enemyUnits;
            }

            foreach (Unit u in us)
            {
                if (u.IsAlive) return true;
            }
            return false;
        }


    }



    public enum CellType
    {
        empty,
        wall,
        player,
        enemy,
        X

    }

    public enum DIRECTION
    {
        UP,
        LEFT,
        DOWN,
        RIGHT,
        X
    }
}