using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    [Table("EncryptionResults")]
    public class EncryptionResultModel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("EncryptedText")]
        public string EncryptedText { get; set; }

        [Column("DecryptedText")]
        public string DecryptedText { get; set; }

        [Column("Key")]
        public string Key { get; set; }

        [Column("Created")]
        public DateTime Created { get; set; }
    }
}
