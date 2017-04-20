using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.Domain
{
    public interface IDatabaseRepository
    {
        DataTable GetCategories();

        DataTable GetPosts();

        bool isPostExists(string title);

        bool isCategoryExists(string title);

        int Save();
    }
}
