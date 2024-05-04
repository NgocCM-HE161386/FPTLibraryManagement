using LibraryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Management
{
    internal class PublisherManagement
    {
        private static PublisherManagement instance = null;
        private static readonly object instanceLock = new object();
        private PublisherManagement() { }
        public static PublisherManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PublisherManagement();
                    }
                    return instance;
                }
            }
        }
        public Publisher GetPublisherByID(string publisherId)
        {
            Publisher publisher = null;
            try
            {
                var myLibrary = new LibraryManagementContext();
                publisher = myLibrary.Publishers.SingleOrDefault(publisher => publisher.PublisherId == publisherId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return publisher;
        }
        public IEnumerable<Publisher> GetPublisherList()
        {
            List<Publisher> publishers;
            try
            {
                var myLibrary = new LibraryManagementContext();
                publishers = myLibrary.Publishers.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return publishers;
        }
    }
}
