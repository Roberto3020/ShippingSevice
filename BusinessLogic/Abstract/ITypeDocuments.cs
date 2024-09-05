using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model;

namespace BusinessLogic.Abstract
{
    public interface ITypeDocuments
    {
        Task<ServiceResponse<IEnumerable<TypeDocuments>?>> GetAllTypeDocuments();
    }
}
