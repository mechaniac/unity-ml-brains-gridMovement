using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyGrid_NS1
{
    public class Unit : MonoBehaviour
    {
        public Cell currentCell;
        public FACTION faction;
        public bool IsAlive = true;

        public GameObject attackEffectPrefab;

        internal void MoveInDirection(DIRECTION d)
        {
            
        }
        public void MoveToCell(Cell c)
        {
            if (IsAlive)
            {
                Debug.Log($"Moving from cell {currentCell.w}, {currentCell.h} to cell {c.w}, {c.h}");
                currentCell = c;
                transform.localPosition = c.transform.localPosition;
                c.SetCellType(this);
            }
        }
        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public void Attack(Unit op)
        {
            op.GetAttacked();

            
            var aF = Instantiate(attackEffectPrefab, transform, false);
            aF.transform.localPosition = new Vector3(0, .1f, 0);
            aF.transform.localRotation = Quaternion.Euler(90, 0, 0);
            //Debug.Log($"af = {aF.transform.localPosition}");
            StartCoroutine(AttackAnimation(.3f));

            IEnumerator AttackAnimation(float duration)
            {
               

                float t = 0f;
                while (t < duration)
                {
                    t += Time.deltaTime;
                    
                    //aF.transform.localScale = aF.transform.localScale * Mathf.Sin(t / duration);
                    aF.transform.localRotation = Quaternion.Euler(90, Mathf.Sin(t / duration) * 360, 0);
                    //Debug.Log($"rotating: {aF.transform.localRotation}, t: {t}, duration: {duration}, Sign: {Mathf.Sin(t/duration)}");
                    yield return null;
                }
                Destroy(aF);
            }
        }

        public void GetsSelected()
        {
            StartCoroutine(SelectionAnimation(.2f));

            IEnumerator SelectionAnimation(float duration)
            {
                float t = 0f;
                while (t < duration)
                {
                    t += Time.deltaTime;

                    transform.localScale = Vector3.one * Mathf.Sin(t / duration);

                    yield return null;
                }
            }
        }
        

        public void GetAttacked()
        {
            IsAlive = false;
            transform.position += new Vector3(0, 5, 0);
            currentCell.cellType = CellType.empty;
        }
    }

    public enum FACTION
    {
        player,
        enemy
    }

}