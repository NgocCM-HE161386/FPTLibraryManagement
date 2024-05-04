using LibraryManagement.DataAccess;
using LibraryManagement.IRepository;
using LibraryManagement.Management;
using System.Collections.Generic;

namespace LibraryManagement.Repository
{
    internal class PublisherRepository : IPublisherRepository
    {
        public Publisher GetPublisherByID(string publisher) => PublisherManagement.Instance.GetPublisherByID(publisher);

        public IEnumerable<Publisher> GetPublishers() => PublisherManagement.Instance.GetPublisherList();
    }
}
