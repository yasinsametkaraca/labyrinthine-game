using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YasinSamet_Labirent
{
    class Program
    {
        static void LabirentYazdir(string[,] labirent,int satir,int sutun)
        {
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    Console.Write(" | "+labirent[i, j]);
                }
                Console.Write("\n------------------------------------------\n");
            }
        }
        static void YolOlustur(string[,] labirent,int satir, int sutun, int[] girisler,int[,] bomba)
        {
            Random rastgele = new Random();
            int adet = 0;
            for (int i= satir-1; i >=0; i--)
            {
                for (int j = 0; j< sutun; j++)
                {
                    int bombakoy = rastgele.Next(0, 2);
                    if (labirent[i,j]=="1"|| labirent[i, j] == "2")
                    {
                        if (i - 1 >= 0)
                        {
                            int yon = rastgele.Next(0, 3);
                            if (yon == 0 && j - 1 > 0)
                            {
                                if (i == sutun-1)
                                {
                                    j--;
                                }
                                else
                                {
                                    labirent[i, j - 1] = "1";
                                    j--;
                                }
                            }
                            else if (yon == 1 && j + 1 < labirent.GetLength(1))
                            {
                                if (i == sutun - 1)
                                {
                                    j--;
                                }
                                else
                                    labirent[i, j + 1] = "1";
                            }
                            else
                            {
                                if (bombakoy==0&&adet<2&&i<7)
                                {
                                    labirent[i - 1, j] = "2";
                                    bomba[adet, 0] = i-1;
                                    bomba[adet, 1] = j; 
                                    adet++;
                                }
                                else
                                {
                                    labirent[i - 1, j] = "1";
                                }
                            }
                        }
                    }
            }
            }
        }
        static void bombaGoster(string[,] labirent,int satir, int sutun,bool goster,int[,] bomba)
        {
           
            if (!goster)
            {
                labirent[bomba[0, 0], bomba[0, 1]] = "2";
                labirent[bomba[1, 0], bomba[1, 1]] = "2";
            }
            else
            {
                for (int i = 0; i < satir; i++)
                {
                    for (int j = 0; j < sutun; j++)
                    {
                        if (labirent[i, j] == "2")
                        {
                            labirent[i, j] = "1";
                        }

                    }
                }
            }
        }
        static int hareketEt(string[,] labirent,int satir,int sutun,int[] konum,string yon,int puan)
        {
            labirent[konum[0], konum[1]] = "1";
            int x = konum[0], y = konum[1];
            switch (yon)
            {
                case "w":
                    if (x-1>=0)
                    {
                        if (labirent[x - 1, y] == "0")
                        {
                            puan--;
                            Console.WriteLine("Geçersiz Hamle.");
                        }
                        else
                        {
                            puan += 5;
                            x--;
                            konum[0] = x;
                        }
                    }
                    else
                    {
                        puan--;
                        Console.WriteLine("Geçersiz Hamle.");
                    }
                    break;
                case "s":
                    if (x+1<satir)
                    {
                        if (labirent[x + 1, y] == "0")
                        {
                            puan--;
                            Console.WriteLine("Geçersiz Hamle.");
                        }
                        else
                        {
                            puan += 5;
                            x++;
                            konum[0] = x;
                        }
                    }
                    break;
                case "a":
                    if (y-1>=0)
                    {
                        if (labirent[x, y - 1] == "0")
                        {
                            puan--;
                            Console.WriteLine("Geçersiz Hamle.");
                        }
                        else
                        {
                            puan += 5;
                            y--;
                            konum[1] = y;
                        }
                    }
                    else
                    {
                        puan--;
                        Console.WriteLine("Geçersiz Hamle.");
                    }
                    break;
                case "d":
                    if (y+1<sutun)
                    {
                        if (labirent[x, y + 1] == "0")
                        {
                            puan--;
                            Console.WriteLine("Geçersiz Hamle.");
                        }
                        else
                        {
                            puan += 5;
                            y++;
                            konum[1] = y;
                        }
                    }
                    else
                    {
                        puan--;
                        Console.WriteLine("Geçersiz Hamle.");
                    }
                    break;
                default:
                    puan--;
                    Console.WriteLine("Geçersiz Hamle.");
                    break;
            }
            labirent[konum[0], konum[1]] = "K";
            return puan;
        }
        static bool bombaKontrol(int[] konum,int[,] bomba)
        {
            int x = konum[0], y = konum[1];
            if (x == bomba[0, 0] && y == bomba[0, 1])
            {
                return true;
            }
            else if (x == bomba[1, 0] && y == bomba[1, 1])
            {
                return true;
            }
            else return false;
        }
        static bool bitisKontrol(int[] konum)
        {
            if (konum[0] == 0)
            {
                return true;
            }
            else return false;
        }
        static void Main(string[] args)
        {
            int satir = 10, sutun = 10;
            int puan = 0;
            int[] konum = new int[2];
            konum[0] = satir-1;
            string[,] labirent = new string[satir, sutun];
            int[,] bombalar = new int[2, 2];
            Random rastgele = new Random();
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    labirent[i, j] = "0";
                }
            }
            int[] girisler = new int[3];
            do
            {
                girisler[0] = rastgele.Next(0, sutun);
                girisler[1] = rastgele.Next(0, sutun);
                girisler[2] = rastgele.Next(0, sutun);
            } while (girisler[0]==girisler[1]||girisler[1]==girisler[2]);
            Array.Sort(girisler);
            labirent[satir - 1, girisler[0]] = "1";
            labirent[satir - 1, girisler[1]] = "1";
            labirent[satir - 1, girisler[2]] = "1";
            YolOlustur(labirent, satir, sutun, girisler,bombalar);
            LabirentYazdir(labirent,satir,sutun);
            string giris;
            bool goster = false;
            while (true)
            {
                if (konum[0] == satir-1)
                {
                    try
                    {
                        Console.Write("Başlangıç konumu(1,2,3) seçiniz: ");
                        if (konum[1]!=0)
                        {
                            labirent[konum[0], konum[1]] = "1";
                        }
                        int secim = Convert.ToInt32(Console.ReadLine());
                        secim--;
                        konum[1] = girisler[secim];
                        labirent[konum[0], konum[1]] = "K";
                        LabirentYazdir(labirent, satir, sutun);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Hatalı giriş.");
                        konum[1] = girisler[0];
                    }
                }
                Console.WriteLine("Hangi Yöne hareket edeceksiniz? (w,a,s,d)");
                giris = Console.ReadLine();
                if (giris=="G"||giris=="g")
                {
                    goster = !goster;
                    bombaGoster(labirent, satir, sutun, goster, bombalar);
                    Console.WriteLine("Bomba görünürlüğü güncellendi.");
                }
                else
                {
                    puan=hareketEt(labirent, satir, sutun, konum, giris, puan);
                    if (bombaKontrol(konum,bombalar))
                    {
                        Console.WriteLine("Bir bombaya çarptınız! Kaybettiniz. Puanınız: {0}", puan);
                        break;
                    }
                    if (bitisKontrol(konum))
                    {
                        Console.WriteLine("Tebrikler! Labirenti tamamladınız. Puanınız: {0}",puan);
                        break;
                    }
                }
                LabirentYazdir(labirent, satir, sutun);
            }
            Console.ReadKey();
        }
    }
}
