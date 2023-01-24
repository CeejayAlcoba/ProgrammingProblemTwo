﻿using DataAccessEFCore;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEFCore.Repositories
{
    public class CredentialRepository : GenericRepository<Credential>, ICredentialRepository
    {
        public CredentialRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
