using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EFDataFirstCRUDIslemleri
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Metodların Sırasıyla Çağırılışları

            #region ISeansBilgisiManager inrerface metodları

            //ISeansBilgisiManager sbm = new SinemaManager();
            //sbm.Select().ForEach(x => Console.WriteLine("Seans Id : {0}  -  Seans Saat : {1}", x.SeansId, x.SeansSaat));
            //sbm.Select(2).ForEach(x => Console.WriteLine("Seans Id : {0}  -  Seans Saat : {1}", x.SeansId, x.SeansSaat));
            //if (sbm.update(5, "11:00-13:00"))
            //{
            //    Console.WriteLine("Seans Güncellendi");
            //}
            //if (sbm.delete(3))
            //{
            //    Console.WriteLine("Seans Silindi");
            //}
            //if (sbm.insert(3, "13:00-15:00"))
            //{
            //    Console.WriteLine("Seans Eklendi");
            //}

            #endregion

            #region IFilmBilgisiManager interface metodları

            //IFilmBilgisiManager ifm = new SinemaManager();
            //ifm.Select().ForEach(x => Console.WriteLine("Film Id : {0}  -  Film Adı: {1}  -  FilmSeans Id : {2}" + "" +
            //                                            "  -  Ucret Id : {3}", x.FilmId, x.FilmAdı, x.FilmSeansId, x.UcretId));
            //ifm.Select(1).ForEach(x => Console.WriteLine("Film Id : {0}  -  Film Adı: {1}  -  FilmSeans Id : {2}" + "" +
            //                                            "  -  Ucret Id : {3}", x.FilmId, x.FilmAdı, x.FilmSeansId, x.UcretId));

            //if (ifm.insert(3, "Harry Potter Felsefe sırrı", 3, 1))
            //{
            //    Console.WriteLine("Film Eklendi");
            //}

            //if (ifm.update(3, "Harry Potter Felsefe Taşı", 3, 1))
            //{
            //    Console.WriteLine("Film Güncellendi");
            //}

            //if (ifm.delete(7))
            //{
            //    Console.Write("Film Silindi");
            //}


            #endregion

            #region IUcretManager interface metodları

            //IUcretManager um = new SinemaManager();

            //um.Select().ForEach(x => Console.WriteLine("Ucret Id : {0}  -  Ucret : {1} TL", x.UcretId, x.Ucret1));
            //um.Select(3).ForEach(x => Console.WriteLine("Ucret Id : {0}  -  Ucret : {1} TL", x.UcretId, x.Ucret1));

            //if (um.insert(6, 27.5))
            //{
            //    Console.WriteLine("Ucret Eklendi");
            //}
            //if (um.update(7,25))
            //{
            //    Console.WriteLine("Ucret Güncellendi");
            //}
            #endregion

            #endregion


            //Entity Framework Data First yöntemi ile veri tabanındaki verilerin kullanılması
            #region Çalışan Kod

            int secim, secim2, selectParameter, seansId, filmId, ucretId;
            string seansSaat, filmAdi;
            double ucret;
            while (true)
            {
                Console.WriteLine("\n Seans İşlemleri için 1 / Film İşlemleri için 2 / " +
                    "\n Ucret İşlemleri için 3 giriniz." +
                            "Çıkış için 0 giriniz.\n");
                secim = Convert.ToInt32(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        #region Seans İşlemleri
                        ISeansBilgisiManager sbm = new SinemaManager();
                        Console.WriteLine("\nTüm Seans Bilgilerini Sorgulamak için 1 \n" +
                            "İstediğiniz Id değerine ait Seans Bilgisini Sorgulamak için 2 \n" +
                            "Seans Eklemek için 3\n" +
                            "Seans Güncellemek için 4\n" +
                            "Seans Silmek için 5 giriniz.\n"+ 
                            "Çıkış için 0 giriniz.\n");
                        secim2 = Convert.ToInt32(Console.ReadLine());

                        switch (secim2)
                        {
                            case 1:
                                sbm.Select().ForEach(x => Console.WriteLine("Seans Id : {0}  -  Seans Saat : {1}", x.SeansId, x.SeansSaat));
                                break;
                            case 2:
                                Console.WriteLine("\nHangi Id değerine sahip Seans ögesini görmek istiyorsunuz?");
                                selectParameter = Convert.ToInt32(Console.ReadLine());
                                sbm.Select(selectParameter).ForEach(x => Console.WriteLine("Seans Id : {0}  -  Seans Saat : {1}", x.SeansId, x.SeansSaat));
                                break;
                            case 3:
                                Console.WriteLine("\nSeans Id değerini giriniz.");
                                seansId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\nSeans Saat değerini giriniz.");
                                seansSaat = Console.ReadLine();
                                if (sbm.insert(seansId, seansSaat))
                                {
                                    Console.WriteLine("\nSeans Eklendi");
                                }
                                break;
                            case 4:
                                Console.WriteLine("\nSeans Id değerini giriniz.");
                                seansId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\nSeans Saat değerini giriniz.");
                                seansSaat = Console.ReadLine();
                                if (sbm.update(seansId, seansSaat))
                                {
                                    Console.WriteLine("\nSeans Güncellendi");
                                }
                                break;
                            case 5:
                                Console.WriteLine("\nSilmek istediğiniz seansın id değerini giriniz");
                                seansId = Convert.ToInt32(Console.ReadLine());
                                if (sbm.delete(seansId))
                                {
                                    Console.WriteLine("\nSeans Silindi");
                                }
                                break;
                            case 0:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Yanlış seçim yaptınız tekrar deneyiniz");
                                break;

                        }
                        #endregion
                        break;
                    case 2:
                        #region Film İşlemleri

                        IFilmBilgisiManager fbm = new SinemaManager();
                        Console.WriteLine("\nTüm Film Bilgilerini Sorgulamak için 1 \n" +
                            "İstediğiniz Id değerine ait Film Bilgisini Sorgulamak için 2 \n" +
                            "Film Eklemek için 3\n" +
                            "Film Güncellemek için 4\n" +
                            "Film Silmek için 5 giriniz.\n" +
                            "Çıkış için 0 giriniz.\n");
                        secim2 = Convert.ToInt32(Console.ReadLine());

                        switch (secim2)
                        {
                            case 1:
                                fbm.Select().ForEach(x => Console.WriteLine("Film Id : {0}  -  Film Adı: {1}  -  FilmSeans Id : {2}" + "" +
                                                        "  -  Ucret Id : {3}", x.FilmId, x.FilmAdı, x.FilmSeansId, x.UcretId));
                                break;
                            case 2:
                                Console.WriteLine("\nHangi Id değerine sahip Seans ögesini görmek istiyorsunuz?");
                                selectParameter = Convert.ToInt32(Console.ReadLine());
                                fbm.Select(selectParameter).ForEach(x => Console.WriteLine("Film Id : {0}  -  Film Adı: {1}  -  FilmSeans Id : {2}" + "" +
                                                                            "  -  Ucret Id : {3}", x.FilmId, x.FilmAdı, x.FilmSeansId, x.UcretId));
                                break;
                            case 3:
                                Console.WriteLine("\n Film Id değerini giriniz.");
                                filmId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n Film Adı giriniz.");
                                filmAdi = Console.ReadLine();
                                Console.WriteLine("\n Film Seans Id değerinigiriniz.");
                                seansId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n Film Ucret Id değerinigiriniz.");
                                ucretId = Convert.ToInt32(Console.ReadLine());
                                if (fbm.insert(filmId, filmAdi, seansId, ucretId))
                                {
                                    Console.WriteLine("Film Eklendi");
                                }
                                break;
                            case 4:
                                Console.WriteLine("\n Film Id değerini giriniz.");
                                filmId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n Film Adı giriniz.");
                                filmAdi = Console.ReadLine();
                                Console.WriteLine("\n Film Seans Id değerinigiriniz.");
                                seansId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n Film Ucret Id değerinigiriniz.");
                                ucretId = Convert.ToInt32(Console.ReadLine());
                                if (fbm.update(filmId, filmAdi, seansId, ucretId))
                                {
                                    Console.WriteLine("\nSeans Güncellendi");
                                }
                                break;
                            case 5:
                                Console.WriteLine("\nSilmek istediğiniz filmin id değerini giriniz");
                                filmId = Convert.ToInt32(Console.ReadLine());
                                if (fbm.delete(filmId))
                                {
                                    Console.WriteLine("\n Film Silindi");
                                }
                                break;
                            case 0:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Yanlış seçim yaptınız tekrar deneyiniz");
                                break;
                        }
                        #endregion
                        break;
                    case 3:
                        #region Film İşlemleri

                        IUcretManager um = new SinemaManager();
                        Console.WriteLine("\nTüm Ucret Bilgilerini Sorgulamak için 1 \n" +
                            "İstediğiniz Id değerine ait Ucret Bilgisini Sorgulamak için 2 \n" +
                            "Ucret Eklemek için 3\n" +
                            "Ucret Güncellemek için 4\n" +
                            "Ucret Silmek için 5 giriniz.\n" +
                            "Çıkış için 0 giriniz.\n");
                        secim2 = Convert.ToInt32(Console.ReadLine());

                        switch (secim2)
                        {
                            case 1:
                                um.Select().ForEach(x => Console.WriteLine("Ucret Id : {0}  -  Ucret : {1} TL", x.UcretId, x.Ucret1));
                                break;
                            case 2:
                                Console.WriteLine("\nHangi Id değerine sahip Seans ögesini görmek istiyorsunuz?");
                                selectParameter = Convert.ToInt32(Console.ReadLine());
                                um.Select(selectParameter).ForEach(x => Console.WriteLine("Ucret Id : {0}  -  Ucret : {1} TL", x.UcretId, x.Ucret1));
                                break;
                            case 3:
                                Console.WriteLine("\n Ucret Id değerini giriniz.");
                                ucretId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n Ucret giriniz.");
                                ucret = Convert.ToDouble(Console.ReadLine());

                                if (um.insert(ucretId, ucret))
                                {
                                    Console.WriteLine("Ucret Eklendi");
                                }
                                break;
                            case 4:
                                Console.WriteLine("\n Ucret Id değerini giriniz.");
                                ucretId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n Ucret giriniz.");
                                ucret = Convert.ToDouble(Console.ReadLine());
                                if (um.update(ucretId, ucret))
                                {
                                    Console.WriteLine("\n Ucret Güncellendi");
                                }
                                break;
                            case 5:
                                Console.WriteLine("\n Silmek istediğiniz Ucretin id değerini giriniz");
                                ucretId = Convert.ToInt32(Console.ReadLine());
                                if (um.delete(ucretId))
                                {
                                    Console.WriteLine("\n Ucret Silindi");
                                }
                                break;
                            case 0:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Yanlış seçim yaptınız tekrar deneyiniz");
                                break;
                        }
                        #endregion
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim yaptınız tekrar deneyiniz");
                        break;
                }
            }
            #endregion
        }
    }
}
