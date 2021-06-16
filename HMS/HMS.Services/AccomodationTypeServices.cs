using HMS.Data;
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
    }
}
