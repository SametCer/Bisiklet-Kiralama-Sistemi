using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace proje_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] duraklar = { "İnciraltı,28,2,10","Sahilevleri,8,1,11","Doğal Yaşam Parkı,17,1,6","Bostanlı İskele,7,0,5","Bornova Metro,10,0,2","Karsıyaka İskele,10,0,8","Yunuslar,4,0,8","Alsancak Garı,9,0,6","Fahrettin Altay,7,0,5"};
            Durak[] tumDurak = new Durak[duraklar.Length];
            
            for (int i = 0; i < duraklar.Length; i++)
            {
                string[] durakBilgi= duraklar[i].Split(',');
                Durak durak = new Durak(durakBilgi[0],Convert.ToInt32(durakBilgi[1]), Convert.ToInt32(durakBilgi[2]), Convert.ToInt32(durakBilgi[3]));
                tumDurak[i] = durak;
            }
            BinaryTree durakAgacı = new BinaryTree();
            for (int i = 0; i <duraklar.Length; i++)
            {
                durakAgacı.Insert(tumDurak[i]);  
            }

            Console.WriteLine("DURAK VE MÜŞTERİ BİLGİLERİ\n");
            durakAgacı.InOrder(durakAgacı.GetRoot());
            durakAgacı.findAndWriteTreeInfo(durakAgacı.GetRoot());

            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("MÜŞTERİ ARAMA VE BİLGİLERİ YAZDIRMA\n");
            Console.Write("Musteri Id giriniz:");
            int kullanici = Convert.ToInt32(Console.ReadLine());
            durakAgacı.MusteriArama(durakAgacı.GetRoot(), kullanici);

            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("KİRALAMA İŞLEMİ\n");
            Console.Write("Durak adını giriniz:");
            string aranan =Console.ReadLine();
            TreeNode degisken=durakAgacı.DurakArama(aranan);

            Kiralama(degisken);

            degisken.DisplayNode();
            Console.WriteLine("---------------------------------------------------------------------------------------------");

            Console.WriteLine("Hash Tablosu");

            Hashtable hashtable = new Hashtable();
            foreach (Durak item in tumDurak)
            {
                hashtable.Add(item.durakAdı,item);
            }
            

            ArrayList al = new ArrayList(hashtable.Keys);
            

            for (int i = 0; i < hashtable.Count; i++)
                Console.WriteLine(hashtable[al[i]].ToString());

            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("5’er tane normal bisiklet ekleyerek Hash Tablosu");
            foreach (Durak item in hashtable.Values)
            {
                if (item.bosPark>5)
                {
                    item.bosPark = item.bosPark - 5;
                    item.normalSayi = item.normalSayi + 5;
                }
            }
            for (int i = 0; i < hashtable.Count; i++)
                Console.WriteLine(hashtable[al[i]].ToString());

            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("Heap Yapısı");
            Heap theHeap = new Heap(duraklar.Length);
            foreach (Durak item in tumDurak)
            {
                theHeap.insert(item);
            }
            for (int i = 0; i < duraklar.Length; i++)
            {
                Console.WriteLine(theHeap.heapList[i].ToString());
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("En fazla Normal Bisiklet olan üç İstasyonu ");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(theHeap.remove());
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("Selection Sort algoritması");

            int maxSize = 100;
            SelectionSort arr;
            arr = new SelectionSort(maxSize);
            arr.insert(64);
            arr.insert(98);
            arr.insert(41);
            arr.insert(26);
            arr.insert(75);
            arr.insert(32);
            arr.insert(9);
            arr.insert(0);
            arr.insert(85);
            arr.insert(18);
            arr.display(); 
            arr.selectionSort(); 
            arr.display();

            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("Quick Sort algoritması");
            int maxSize1 = 10; 
            QuickSort arr1;
            Random rnd = new Random();
            arr1 = new QuickSort(maxSize1);
            for (int j = 0; j < maxSize1; j++)
            {
                int n = rnd.Next(0, 100);
                arr1.insert(n);
            }
            arr1.display(); 
            arr1.quickSort(); 
            arr1.display();

            Console.ReadLine();
        }

        public static void Kiralama(TreeNode root)
        {
            if (root.data.normalSayi > 0)
            {
                Console.Write("Yeni Kira için Musteri Id giriniz:");
                int kullaniciId = Convert.ToInt32(Console.ReadLine());
                Musteri yeniMusteri = new Musteri();
                yeniMusteri.musteriId = kullaniciId;

                root.data.musteriler.Add(yeniMusteri);
                root.data.bosPark++;
                root.data.normalSayi--;
                root.data.musteriSayi++;
            }
            else
            {
                Console.WriteLine("Bu durakta bisiklet kalmadı!!!!!!!");
            }    
        }
    }
}
