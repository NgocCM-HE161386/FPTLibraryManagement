using LibraryManagement.DataAccess;
using LibraryManagement.IRepository;
using LibraryManagement.Management;
using System.Collections.Generic;

namespace LibraryManagement.Repository
{
    internal class AuthorRepository : IAuthorRepository
    {
        public Author GetAuthorByID(string authorId) => AuthorManagement.Instance.GetAuthorByID(authorId);

        public IEnumerable<Author> GetAuthors() => AuthorManagement.Instance.GetAuthorList();
    }
}
