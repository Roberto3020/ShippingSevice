﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranversal.Model.Request;
using Tranversal.Model;

namespace DataAccess.Abstract
{
    public interface IDireccionRepository
    {
        Task<ResponseCreate> CrearDireccion(DireccionRequest request);
    }
}
