using ENTITIES.Enums;
using ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Models
{
    public abstract class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}

/*
  BaseEntity soyut sınfı tanımlandı. Bu sınıf IEntity arayüzünü uygulayar ve arayüzün özelliklerini alır.

  BaseEntity türetildiğinde (Category,Product gibi sınıflara)
  veri durumu insterted olarak atanacak, oluşturulma tarihide atanacak

  Category,Product gibi sınıflar BaseEntityden türetileceği için 
  bu sınıflar bu özelliklere ulaşacak

  Category,Product gibi sınıflara özel özellik tanımlaması yapılması isttenirse Category.cs içinde oluşturulabilir
  (CategoryName) veya Product.cs içinde (ProductName)

  -Temiz ve düzenli kod
  -Kod tekrarı azaltıldı
  -Entityler yönetilebilir oldu
  -Kod genişletilebilirliği

 */