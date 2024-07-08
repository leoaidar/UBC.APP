using Flunt.Notifications;
using UBC.Students.Domain.Domain.Entities;
using UBC.Students.Domain.Repositories;

namespace UBC.Students.Domain.Handlers
{
    public abstract class Handler : Notifiable<Notification>
    {       

        public Handler() { }

        protected bool INVALIDATE_ONE_CACHE
        {
            get
            {
                
                return false;
            }
            set
            {
                value = true;
            }
        }
        
        protected bool INVALIDATE_ALL_CACHE
        {
            get
            {
                return false;
            }
            set
            {
                value = true;
            }
        }

        protected List<T> InitializingCollection<T>(T obj, List<T> objectsList)
        {
            if (obj == null || objectsList.Count() == 0)
                objectsList = new List<T>() { obj };
            else
                objectsList.Add(obj);

            return objectsList;
        }

    }
}
