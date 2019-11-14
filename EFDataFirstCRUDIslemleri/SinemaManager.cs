using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EFDataFirstCRUDIslemleri
{
    class SinemaManager : IFilmBilgisiManager, IUcretManager, ISeansBilgisiManager
    {
        SinemaEntities se = new SinemaEntities();

        //ISeansBilgisiManager interfacesinden implemente edilen metodlar
        #region ISeansBilgisiManager interface metodları

        List<SeansBilgisi> ISeansBilgisiManager.Select()
        {
            return se.SeansBilgisi.ToList();
        }
        List<SeansBilgisi> ISeansBilgisiManager.Select(int seansId)
        {
            return se.SeansBilgisi.Where(x => x.SeansId == seansId).ToList();
        }
        public bool insert(int seansId, string seansSaat)
        {
            try
            {
                SeansBilgisi sb = new SeansBilgisi
                {
                    SeansId = seansId,
                    SeansSaat = seansSaat
                };
                se.SeansBilgisi.Add(sb);
                se.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata : " + ex.Message);
                return false;
            }

        }
        public bool update(int seansId, string seansSaat)
        {
            try
            {
                SeansBilgisi sb = se.SeansBilgisi.Single(x => x.SeansId == seansId);
                sb.SeansId = seansId;
                sb.SeansSaat = seansSaat;
                se.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Hata : " + ex.Message);
                return false;
            }
        }
        bool ISeansBilgisiManager.delete(int seansId)
        {
            try
            {
                if (se.SeansBilgisi.SingleOrDefault(x => x.SeansId == seansId) != null)
                {
                    se.SeansBilgisi.Remove(se.SeansBilgisi.Single(x => x.SeansId == seansId));
                    se.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine(seansId + " id değerine sahip bir Seans ögesine rastlanmadı");
                    return false;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata : " + ex.Message);
                return false;
            }

        }

        #endregion

        //IUcretManager interfacesinden implemente edilen metodlar
        #region IUcretManager interface metodları

        List<Ucret> IUcretManager.Select(int ucretId)
        {
            return se.Ucret.Where(x => x.UcretId == ucretId).ToList();
        }
        List<Ucret> IUcretManager.Select()
        {
            return se.Ucret.ToList();
        }
        public bool insert(int ucretId, double ucret)
        {
            try
            {
                if (se.Ucret.SingleOrDefault(x => x.UcretId == ucretId) == null)
                {
                    Ucret uc = new Ucret
                    {
                        UcretId = ucretId,
                        Ucret1 = ucret
                    };
                    se.Ucret.Add(uc);
                    se.SaveChanges();
                    return true;
                }
                else
                {
                    IUcretManager um = new SinemaManager();
                    um.update(ucretId, ucret);
                    se.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata : " + ex.Message);
                return false;
            }
        }
        public bool update(int ucretId, double ucret)
        {
            try
            {
                    Ucret fb = new Ucret
                    {
                        UcretId = ucretId,
                        Ucret1 = ucret
                    };

                    se.Ucret.AddOrUpdate(fb);
                    se.SaveChanges();
                    return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata : "+ex.Message);
                return false;
            }

        }
        bool IUcretManager.delete(int ucretId)
        {
            try
            {
                if (se.Ucret.SingleOrDefault(x=>x.UcretId==ucretId)!=null)
                {
                    se.Ucret.Remove(se.Ucret.Single(x => x.UcretId == ucretId));
                    se.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine(ucretId+" id değerine sahip Ucret ögesine rastlanamadı.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata : "+ex.Message);
                return false;
            }
        }

        #endregion

        //IFilmBilgisiManager interfacesinden implemente edilen metodlar
        #region IFilmBilgisiManager interface metodları

        List<FilmBilgisi> IFilmBilgisiManager.Select(int filmId)
        {
            return se.FilmBilgisi.Where(x => x.FilmId == filmId).ToList();
        }
        List<FilmBilgisi> IFilmBilgisiManager.Select()
        {
            return se.FilmBilgisi.ToList();
        }
        public bool insert(int filmId, string filmAdi, int filmSeansId, int UcretId)
        {
            try
            {
                if (se.FilmBilgisi.SingleOrDefault(x => x.FilmId == filmId) == null)
                {
                    FilmBilgisi fb = new FilmBilgisi
                    {
                        FilmId = filmId,
                        FilmAdı = filmAdi,
                        FilmSeansId = filmSeansId,
                        UcretId = UcretId
                    };

                    se.FilmBilgisi.Add(fb);
                    se.SaveChanges();
                    return true;
                }
                else
                {
                    IFilmBilgisiManager ifbm = new SinemaManager();
                    ifbm.update(filmId, filmAdi, filmSeansId, UcretId);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata : " + ex.Message);
                return false;
            }

        }
        public bool update(int filmId, string filmAdi, int filmSeansId, int UcretId)
        {
            try
            {
                FilmBilgisi fb = se.FilmBilgisi.Single(x => x.FilmId == filmId);
                fb.FilmId = filmId;
                fb.FilmAdı = filmAdi;
                fb.FilmSeansId = filmSeansId;
                fb.UcretId = UcretId;
                se.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Hata : " + ex.Message);
                return false;
            }
        }
        bool IFilmBilgisiManager.delete(int filmId)
        {
            try
            {
                if (se.FilmBilgisi.SingleOrDefault(x => x.FilmId == filmId) != null)
                {
                    se.FilmBilgisi.Remove(se.FilmBilgisi.Single(x => x.FilmId == filmId));
                    se.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine(filmId + " id değerine sahip film ögesine rastlanılamadı.");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata : " + ex.Message);
                return false;
            }
        }

        #endregion

    }
}
