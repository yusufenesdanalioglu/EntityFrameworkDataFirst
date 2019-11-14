using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataFirstCRUDIslemleri
{
    interface IUcretManager
    {
        List<Ucret> Select();
        List<Ucret> Select(int ucretId);
        bool insert(int ucretId, double ucret);
        bool update(int ucretId, double ucret);
        bool delete(int ucretId);
    }
}
