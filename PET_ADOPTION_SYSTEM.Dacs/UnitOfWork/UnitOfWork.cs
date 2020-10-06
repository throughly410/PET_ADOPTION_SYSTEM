using Microsoft.Extensions.Options;
using PET_ADOPTION_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace PET_ADOPTION_SYSTEM.Dacs
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection connection;
        public TransactionScope transaction;
        public IAnimalImageDac animalImageDac { get; set; }
        public IAnimalPostDac animalPostDac { get; set; }
        public IMemberDac memberDac { get; set; }
        private SettingModel setting { get;}
        public UnitOfWork
            (
                IOptions<SettingModel> setting,
                IAnimalImageDac animalImageDac,
                IAnimalPostDac animalPostDac,
                IMemberDac memberDac
            )
        {
            this.setting = setting.Value;
            connection = new SqlConnection(this.setting.ConnectionString);
            this.animalImageDac = animalImageDac;
            this.animalPostDac = animalPostDac;
            this.memberDac = memberDac;
            this.animalImageDac.conn = connection;
            this.animalPostDac.conn = connection;
            this.memberDac.conn = connection;
        }

        public void Open()
        {
            connection.Open();
        }
        public void Begin()
        {
            transaction = new TransactionScope(TransactionScopeOption.RequiresNew);
        }

        public void Commit()
        {
            try
            {
                transaction.Complete();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DisposeConn();
            }
        }

        public void DisposeConn()
        {
            if (transaction != null)
            {
                transaction.Dispose();
            }
            if (connection != null)
            {
                connection.Dispose();
            }
        }
    }
}
