using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje_3
{
    class SelectionSort
    {
        public long[] a; 
        public int nElems; 
        public SelectionSort(int max) 
        {
            a = new long[max]; 
            nElems = 0; 
        }
        
        public void insert(long value) 
        {
            a[nElems] = value; 
            nElems++; 
        }
        
        public void display() 
        {
            for (int j = 0; j < nElems; j++) 
                Console.Write(a[j] + " "); 
            Console.WriteLine("");
        }
        
        public void selectionSort()
        {
            int cıkıs;
            int giris;
            int min;
            for (cıkıs = 0; cıkıs < nElems - 1; cıkıs++) 
            {
                min = cıkıs;
                for (giris = cıkıs + 1; giris < nElems; giris++) 
                    if (a[giris] < a[min]) 
                         min = giris; 
                swap(cıkıs, min); 
            } 
        } 
        private void swap(int one, int two)
        {
            long temp = a[one];
            a[one] = a[two];
            a[two] = temp;
        }
    }
}
