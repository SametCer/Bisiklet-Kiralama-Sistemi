using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje_3
{
    class Musteri
    {
        public int musteriId;
        public string kiralamaSaati;
        static Random rnd = new Random();
        public Musteri()
        {
            int rastgeleSayi = rnd.Next(1, 21);
            musteriId = rastgeleSayi;
            int saat = rnd.Next(0, 24);
            int dakika = rnd.Next(0, 60);
            kiralamaSaati = saat + ":" + dakika;
        }
        public override string ToString()
        {
            return "MusteriId:"+musteriId+"   Kiralama Saati:"+kiralamaSaati;
        }
    }
}
