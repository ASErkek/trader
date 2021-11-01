using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using YatirimDefteri.Models;

namespace YatirimDefteri.Data
{
    
    public class DBService
    {
        static object locker = new object();
        SQLiteConnection database;

        public DBService()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Kullanici>();
        }

        public Kullanici GetUser()
        {
            lock (locker)
            {
                if (database.Table<Kullanici>().Count() == 0)
                {
                    return null;

                }
                else
                {
                    Kullanici[] users = database.Table<Kullanici>().ToArray();
                    return users[users.Length - 1];
                }
            }
        }
        public int SaveUser(Kullanici user)
        {
            lock (locker)
            {
                Kullanici userRow = null;
                try
                {
                    userRow = database.Get<Kullanici>(user.id);
                }
                catch (Exception) { }

                if (userRow != null)
                {

                    database.Update(user);
                    return user.id;

                }
                else
                {
                    return database.Insert(user);
                }
            }
        }
        public int DeleteUser()
        {
            lock (locker)
            {
                Kullanici[] users = database.Table<Kullanici>().ToArray();
                Kullanici user =  users[users.Length - 1];
                return database.Delete<Kullanici>(user.id);
            }
        }
    }

}
