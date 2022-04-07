using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje_3
{
    class HeapNode
    {
        private Durak iData; 
        public HeapNode(Durak key) 
        { iData = key; }
        
        public int getKey()
        { 
            return iData.normalSayi; 
        }
        public override string ToString()
        {
            return "Durak Adı:" + iData.durakAdı + "  Boş Park:" + iData.bosPark + "  Tandem:" + iData.tandemSayi + "  Normal:" + iData.normalSayi;
        } 
    } 
    class TreeNode
    {
        public Durak data;
        public TreeNode leftChild;
        public TreeNode rightChild;   

        public void DisplayNode()
        {
            Console.WriteLine(data);
            foreach (Musteri item in data.musteriler)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Müşteri sayısı:" + data.musteriSayi);
        }
    }
    class BinaryTree
    {
        private TreeNode root;
        public int totalDepth;
        public int maxDepth;

        public BinaryTree()
        {
            root = null;
        }
        public TreeNode GetRoot()
        {
            return root;
        }   
        public void InOrder(TreeNode localRoot)
        {
            if (localRoot != null)
            {
                InOrder(localRoot.leftChild);
                localRoot.DisplayNode();
                Console.WriteLine(" ");
                InOrder(localRoot.rightChild);
            }
        }

        // Agaca bir dügüm eklemeyi saglayan metot
        public void Insert(Durak newdata)
        {
            TreeNode newNode = new TreeNode();
            newNode.data = newdata;
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                TreeNode current = root;
                TreeNode parent;

                while (true)
                {
                    int donusDegeri = string.Compare(newdata.durakAdı, current.data.durakAdı);
                    parent = current;
                    if (donusDegeri == -1)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }
        private void traverseTreeForInfo(TreeNode node, int depth)
        {
            if (node != null)
            {
                depth++;
                if (depth > maxDepth)
                    maxDepth = depth; 

                totalDepth += depth;
                traverseTreeForInfo(node.leftChild, depth); 
                traverseTreeForInfo(node.rightChild, depth); 
            }
        }
        public void findAndWriteTreeInfo(TreeNode rootNode)
        {
            traverseTreeForInfo(rootNode, -1);
            Console.WriteLine("Ağacın derinliği: " + maxDepth);
        }
        public void MusteriArama(TreeNode localRoot, int kullanici)
        {
            if (localRoot != null)
            {
                MusteriArama(localRoot.leftChild, kullanici);
                foreach (Musteri item in localRoot.data.musteriler)
                {
                    if (kullanici == item.musteriId)
                    {
                        Console.WriteLine(localRoot.data.durakAdı + " " + item);
                    }
                }
                MusteriArama(localRoot.rightChild, kullanici);
            }
        }  
        public TreeNode DurakArama(string aranan)
        {
            TreeNode etkin = root;
            while (etkin.data.durakAdı.Equals(aranan)==false)
            {
                if (string.Compare(aranan, etkin.data.durakAdı) ==-1)
                    etkin = etkin.leftChild;
                else
                    etkin = etkin.rightChild;
                if (etkin == null)
                {
                    Console.WriteLine("Böyle bir durak bulunamadı!");
                } 
            }
            return etkin;
        }  
    }
}
