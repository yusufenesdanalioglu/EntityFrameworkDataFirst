using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataFirstCRUDIslemleri
{
    interface ISeansBilgisiManager
    {
        List<SeansBilgisi> Select();
        List<SeansBilgisi> Select(int seansId);
        bool insert(int seansId, string seansSaat);
        bool update(int seansId, string seansSaat);
        bool delete(int seansId);
    }
}
