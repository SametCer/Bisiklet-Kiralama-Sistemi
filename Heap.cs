using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje_3
{
    class Heap
    {
        public List<HeapNode> heapList;
        private int maxSize; 
        private int currentSize; 
        public Heap(int mx) 
        {
            maxSize = mx;
            currentSize = 0;
            heapList = new List<HeapNode>(); 
        }
       
        public Boolean isEmpty()
        { return currentSize == 0; }
        
        public Boolean insert(Durak key)
        {
            if (currentSize == maxSize)
                return false;
            HeapNode newNode = new HeapNode(key);
            heapList.Add(newNode);
            trickleUp(currentSize++);
            return true;
        } 
        public void trickleUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapNode bottom = heapList[index];
            while (index > 0 && heapList[parent].getKey() < bottom.getKey())
            {
                heapList[index] = heapList[parent]; 
                index = parent;
                parent = (parent - 1) / 2;
            } 
            heapList[index] = bottom;
        } 

        public HeapNode remove() 
        { 
            HeapNode root = heapList[0];
            heapList[0] = heapList[--currentSize];
            trickleDown(0);
            return root;
        } 
        public void trickleDown(int index)
        {
            int largerChild;
            HeapNode top = heapList[index]; 
            while (index < currentSize / 2) 
            { 
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                
                if (rightChild < currentSize && heapList[leftChild].getKey() < heapList[rightChild].getKey())
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                
                if (top.getKey() >= heapList[largerChild].getKey())
                    break;
               
                heapList[index] = heapList[largerChild];
                index = largerChild; 
            } 
            heapList[index] = top; 
        } 
    }
}
