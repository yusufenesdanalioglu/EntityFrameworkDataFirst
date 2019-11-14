using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataFirstCRUDIslemleri
{
    interface IFilmBilgisiManager
    {
        List<FilmBilgisi> Select();
        List<FilmBilgisi> Select(int filmId);
        bool insert(int filmId, string filmAdi, int filmSeansId, int UcretId);
        bool update(int filmId, string filmAdi, int filmSeansId, int UcretId);
        bool delete(int filmId);
    }
}
