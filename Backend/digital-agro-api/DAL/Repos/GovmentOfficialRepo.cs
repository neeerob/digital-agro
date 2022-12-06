﻿using DAL.EF_Code_First.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class GovmentOfficialRepo : Idb, IRepo<GovmentOfficial, int, GovmentOfficial>
    {
        public GovmentOfficial Add(GovmentOfficial obj)
        {
            if (obj != null)
            {
                db.GovmentOfficial.Add(obj);
                if (db.SaveChanges() > 0)
                    return obj;
                else
                    return null;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            var find = db.GovmentOfficial.Find(id);
            if (find != null)
            {
                db.GovmentOfficial.Remove(find);
                return db.SaveChanges() > 0;
            }
            else
                return false;
        }

        public List<GovmentOfficial> Get()
        {
            return db.GovmentOfficial.ToList();
        }

        public GovmentOfficial Get(int id)
        {
            if (id != 0)
            {
                return db.GovmentOfficial.Find(id);
            }
            else
                return null;
        }

        public GovmentOfficial Update(GovmentOfficial obj)
        {
            var ext = Get(obj.Id);
            if (ext != null)
            {
                db.Entry(ext).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return obj;
            }
            else
                return null;
        }
    }
}