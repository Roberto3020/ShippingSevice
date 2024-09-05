using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model;
using Tranversal.ProcedureMaps;

namespace DataAccess.Implements
{
    public class TypeDocumentRepository: ITypeDocumentsRepository
    {
        private readonly DapperContext context;

        public TypeDocumentRepository(DapperContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<TypeDocuments>> GetAllTypeTypeDocuments()
        {

            var result = await context.QuerySPAsync<TypeDocuments>(Procedure.GetAllTypeDocuments);
            return result;
        }
    }
}
