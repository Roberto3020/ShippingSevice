using BusinessLogic.Abstract;
using BusinessLogic.Model;
using BusinessLogic.Service.Helpers;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.DTO;
using Tranversal.Model;

namespace BusinessLogic.Implements
{
    public class TypeDocumentService: ITypeDocuments
    {
        private readonly ITypeDocumentsRepository repository;

        public TypeDocumentService(ITypeDocumentsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ServiceResponse<IEnumerable<TypeDocuments>?>> GetAllTypeDocuments()
        {
            try
            {
                var result = await repository.GetAllTypeTypeDocuments();
                return BuildResponse.List(result);

            }
            catch (Exception e)
            {
                return BuildResponse.Error<IEnumerable<TypeDocuments>>(message: e.Message);
            }
        }
    }
}
