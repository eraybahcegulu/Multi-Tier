using DAL.Context;
using DAL.Repositories.Abstracts;
using ENTITIES.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {

        /*
         IRepository Arayüzünü uygulama ve CRUD işlemlerini gerçekleştirme
        Veritabanı bağlantısı yönetimi için DbContext (_db) örneği.

        Repository Pattern
        Veritabanı işlemlerini soyutlamak ve genelleştirmek için kullanım.

        Arayüz(IRepository) ve somut sınıf(BaseRepository) kullanılarak soyutlama ve
        bağımlılıkları yönetme sağlandı. Bu yapı Dependency Injection gibi prensiplere uygunluk sağlar.

        IRepository veritabanı işlemlerini soyutlar ve kontrat sağlar. BaseRepository
        bu kontratı uygular ve somut veritabanı işlemlerini gerçekleştirir.
        Bu sayede proje IRepository arayüzüne bağımlı hale getirilir. İşlemler ise BaseRepositoryden yapılır.
        Yönetilebilirlik sağlanır.

         */

        /*
         ICategoryRepository ve CategoryRepository
        Category entity için özel bir veritabanı işlemleri katmanı oluşturmak için kullanılıyor.
        ICategoryRepository arayüzü IRepository arayüzünü dahil edip bir de Category türüne özel işlemler eklenebilir.

        CategoryRepository BaseRepository<Category> sınıfını genişletip ICategoryRepository arayüzünü uyguluyor.
         */

        MyContext _db;
        public BaseRepository(MyContext db)
        {
            _db = db;
        }
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            _db.SaveChanges();
        }



        public async Task AddAsync(T item)
        {
            await _db.Set<T>().AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange();
            _db.SaveChanges();
        }

        public async Task AddRangeAsync(List<T> list)
        {
            await _db.Set<T>().AddRangeAsync();
            await _db.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().AnyAsync(exp);
        }


        public void Delete(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            _db.SaveChanges();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list) Delete(item);
        }

        public void Destroy(T item)
        {

            _db.Set<T>().Remove(item);
            _db.SaveChanges();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            _db.SaveChanges();
        }

        public async Task<T> FindAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(exp);
        }

        public IQueryable<T> GetActives()
        {
            return Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().AsQueryable();
        }

        public IQueryable<T> GetModifieds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated);
        }

        public IQueryable<T> GetPassives()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _db.Set<T>().Select(exp);
        }

        public async Task Update(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            T original = await FindAsync(item.ID);
            _db.Entry(original).CurrentValues.SetValues(item);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateRange(List<T> list)
        {
            foreach (T item in list) await Update(item);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp);
        }

        void IRepository<T>.Add(T item)
        {
            _db.Set<T>().Add(item);
            _db.SaveChanges();
        }
    }
}