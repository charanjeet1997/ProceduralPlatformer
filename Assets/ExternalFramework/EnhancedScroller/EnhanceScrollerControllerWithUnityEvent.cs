using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EnhancedUI.EnhancedScroller
{
    [Serializable]
    public class EnhanceScrollerControllerWithUnityEvent<T,U>  : IEnhancedScrollerDelegate where U : EnhancedScrollerCellView  
    {
        [SerializeField] private EnhancedScroller myEnhancedScroller;
        [SerializeField] private U cellViewPrefab;
        [SerializeField] private float cellViewSize;
        [SerializeField] private UnityEvent[] _events;
        private EnhancedScrollerCellView _enhancedScrollerCellView;
        private List<T> cellViewData;
        
        
        public void LoadData(List<T> cellViewData)
        {
            this.cellViewData = cellViewData;
            this.myEnhancedScroller.Delegate = this;
            this.myEnhancedScroller.ReloadData();
        }
        
        public void AddDataAt(int index, List<T> data)
        {
            //Add list of item at the specified index to cellViewData
            cellViewData.InsertRange(index, data);
            this.myEnhancedScroller.Delegate = this;
            this.myEnhancedScroller.ReloadData();
        }
        public void RemoveDataAt(int index,List<T> data)
        {
            //Remove list of item at the specified index to cellViewData
            cellViewData.RemoveRange(index, data.Count); 
            this.myEnhancedScroller.Delegate = this;
            this.myEnhancedScroller.ReloadData();
        }

        public bool IsDataExist(List<T> data)
        {
            return cellViewData.Contains(data[0]);
        }
        
        
        public int GetNumberOfCells(EnhancedScroller scroller)
        {
            return cellViewData.Count;
        }

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
        {
            return cellViewSize;
        }

        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            _enhancedScrollerCellView = myEnhancedScroller.GetCellView(cellViewPrefab);
            _enhancedScrollerCellView.SetData(cellViewData[dataIndex],_events);
            return _enhancedScrollerCellView;
        }
    }
}