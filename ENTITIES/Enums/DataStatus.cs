using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Enums
{
    public enum DataStatus
    {
        Inserted = 1,
        Updated = 2,
        Deleted = 3,
    }
}

/*
 enum oluşturuldu. entitylerin durumunu temsil edecek. 3 farklı durum. 
 veriler hiç bir zaman remove olmadıkça veritabanından silinmeyecek. durumu değiştirilecek.
 */