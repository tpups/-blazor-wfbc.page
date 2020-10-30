﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wfbc.page.Shared.Models;
using wfbc.page.Server.Interface;
using MongoDB.Driver;

namespace wfbc.page.Server.DataAccess
{
    public class ManagerDataAccessLayer : IManager
    {
        private WfbcDBContext db;
        public ManagerDataAccessLayer(WfbcDBContext _db)
        {
            db = _db;
        }

        // Get all managers
        public List<Manager> GetAllManagers()
        {
            try
            {
                return db.Managers.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }
        // Add a manager
        public void AddManager(Manager manager)
        {
            try
            {
                db.Managers.InsertOne(manager);
            }
            catch
            {
                throw;
            }
        }
        // Update a manager
        public void UpdateManager(Manager manager)
        {
            try
            {
                db.Managers.ReplaceOne(filter: m => m.Id == manager.Id, replacement: manager);
            }
            catch
            {
                throw;
            }
        }
        // Delete a manager
        public void DeleteManager(string id)
        {
            try
            {
                FilterDefinition<Manager> managerData = Builders<Manager>.Filter.Eq("Id", id);
                db.Managers.DeleteOne(managerData);
            }
            catch
            {
                throw;
            }
        }
    }
}