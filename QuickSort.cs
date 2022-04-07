using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje_3
{
    class QuickSort
    {
        private long[] theArray; 
        private int nElems; 
        public QuickSort(int max) 
        {
            theArray = new long[max]; 
            nElems = 0; 
        }
        
        public void insert(long value) 
        {
            theArray[nElems] = value; 
            nElems++; 
        }
        
        public void display() 
        {
            for (int j = 0; j < nElems; j++) 
                Console.Write(theArray[j] +" "); 
            Console.WriteLine(" ");
        }
        
        public void quickSort()
        {
            recQuickSort(0, nElems - 1);
        }
        
        public void recQuickSort(int left, int right)
        {
            if (right - left <= 0) 
                return; 
            else 
            {
                long pivot = theArray[right]; 
                int partition = partitionIt(left, right, pivot);
                recQuickSort(left, partition - 1); 
                recQuickSort(partition + 1, right);
            }
        } 
        public int partitionIt(int left, int right, long pivot)
        {
            int leftPtr = left - 1; 
            int rightPtr = right; 
            while (true)
            { 
                while (theArray[++leftPtr] < pivot)
                    ;
                while (rightPtr > 0 && theArray[--rightPtr] > pivot)
                    ; 
                if (leftPtr >= rightPtr) 
                    break; 
                else 
                    swap(leftPtr, rightPtr); 
            } 
            swap(leftPtr, right); 
            return leftPtr; 
        } 
        public void swap(int dex1, int dex2) 
        {
            long temp = theArray[dex1]; 
            theArray[dex1] = theArray[dex2]; 
            theArray[dex2] = temp; 
        } 
    }
}
