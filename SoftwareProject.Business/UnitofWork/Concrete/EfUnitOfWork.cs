using Microsoft.EntityFrameworkCore;
using SoftwareProject.Business.UnitofWork.Abstract;
using SoftwareProject.DataAccess.Context;
using SoftwareProject.DataAccess.Repository.Abstract;
using SoftwareProject.DataAccess.Repository.Concrete;
using SoftwareProject.Kernel.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace SoftwareProject.Business.UnitofWork.Concrete
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public EfUnitOfWork(ApplicationDbContext db)
        {
            this._db = db ?? throw new ArgumentNullException("db can't be null");//ApplicationDbContext _db,parametre olarak gönderdiğim db'ye eşit mi diye soruyor. 
            //ArgumentNullException:Bir yöntem çağrıldığında ve geçilen bağımsız değişkenlerden en az biri null, ancak hiçbir zaman null olmaması durumunda ArgumentNullException bir özel durum oluşur.
        }

        private IPostRepository _postRepository;
        public IPostRepository Post
        {
            get { return _postRepository ?? (_postRepository = new EfPostRepository(_db)); }
        }

        private ICommentRepository _commentRepository;
        public ICommentRepository Comment
        {
            get { return _commentRepository ?? (_commentRepository = new EfCommentRepository(_db)); }
        }

        private ILikeRepository _likeRepository;
        public ILikeRepository Like
        {
            get { return _likeRepository ?? (_likeRepository = new EfLikeRepository(_db)); }
        }


        private IAppUserRepository _userRepository;
        public IAppUserRepository User
        {
            get { return _userRepository ?? (_userRepository = new EfAppUserRepository(_db)); }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChange()
        {
            var modifiedEntities = _db.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();//entitydeki değişiklikleri kontrol edicek.
            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            string ipAdress = "127.0.0.1";
            DateTime date = DateTime.Now;//varsayılan değer olarak now'u atıyoruz.
            foreach (var item in modifiedEntities)//oluşturduğum enttylerin içinde dolaşıyoruz.
            {
                KernelEntity entity = item.Entity as KernelEntity;

                if (item != null)
                {
                    switch (item.State)//bütün case'leri kendisi otomatik olarak yapıcak.
                    {

                        case EntityState.Modified:
                            entity.ModifiedComputerName = computerName;
                            entity.ModifiedIp = ipAdress;
                            entity.ModifiedBy = identity;
                            entity.ModifiedDate = date;
                            entity.Status = Kernel.Enums.Status.Modified;
                            break;

                        case EntityState.Added:
                            entity.CreatedComputerName = computerName;
                            entity.CreatedIp = ipAdress;
                            entity.CreatedBy = identity;
                            entity.CreateDate = date;
                            entity.Status = Kernel.Enums.Status.Active;
                            break;

                    }
                }
            }
            try
            {
                using (var transaction = _db.Database.BeginTransaction())
                {
                    try
                    {
                        _db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
