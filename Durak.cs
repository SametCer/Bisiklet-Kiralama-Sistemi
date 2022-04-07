using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje_3
{
    class Durak
    {
        public string durakAdı;
        public int bosPark;
        public int tandemSayi;
        public int normalSayi;
        public List<Musteri> musteriler;
        public int musteriSayi;

        static Random rnd = new Random();
        public Durak(string durakAdı,int bosPark,int tandemSayi,int normalSayi)
        {
            this.durakAdı = durakAdı;
            this.bosPark = bosPark;
            this.tandemSayi = tandemSayi;
            this.normalSayi = normalSayi;

            int rastgeleSayi = rnd.Next(1, 11);
            while (rastgeleSayi > normalSayi)
            {
                rastgeleSayi = rnd.Next(1, 11);
            }
            musteriler = new List<Musteri>();
            for (int i = 0; i < rastgeleSayi; i++)
            {
                Musteri musteri = new Musteri();
                musteriSayi++;
                this.normalSayi--;
                this.bosPark++;
                musteriler.Add(musteri);  
            }
        }
        public override string ToString()
        {
            return  "Durak Adı:"+durakAdı +"  Boş Park:"+ bosPark +"  Tandem:"+ tandemSayi +"  Normal:"+normalSayi;
        }
    }
}
