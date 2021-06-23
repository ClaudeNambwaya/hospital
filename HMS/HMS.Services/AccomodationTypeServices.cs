﻿using HMS.Data;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class  AccomodationTypeService
    {
        public IEnumerable<AccomodationType> GetAllAccomodationType()
        {
            var context = new HMSContext();

            return context.AccomodationTypes.ToList();
        }

        public AccomodationType GetAccomodationTypeByID(int ID)
        {
            var context = new HMSContext();

            return context.AccomodationTypes.Find(ID);
        }

        public bool SaveAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.AccomodationTypes.Add(accomodationType);

            return context.SaveChanges() > 0;
        }

        public bool UpdateAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

            context.Entry(accomodationType).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteAccomodationType(AccomodationType accomodationType)
        {
            var context = new HMSContext();

             context.Entry(accomodationType).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
