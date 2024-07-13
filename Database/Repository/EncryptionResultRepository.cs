using Database.Context;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class EncryptionResultRepository : Repository<EncryptionResultModel>
    {
        public EncryptionResultRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
