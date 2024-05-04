using LibraryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Management
{
    internal class AuthorManagement
    {
        private static AuthorManagement instance = null;
        private static readonly object instanceLock = new object();
        private AuthorManagement() { }
        public static AuthorManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AuthorManagement();
                    }
                    return instance;
                }
            }
        }
        public Author GetAuthorByID(string authorId)
        {
            Author author = null;
            try
            {
                var myLibrary = new LibraryManagementContext();
                author = myLibrary.Authors.SingleOrDefault(author => author.AuthorId == authorId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return author;
        }
        public IEnumerable<Author> GetAuthorList()
        {
            List<Author> authors;
            try
            {
                var myLibrary = new LibraryManagementContext();
                authors = myLibrary.Authors.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return authors;
        }
    }
}
