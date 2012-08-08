using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gifted.Entities
{
    public class Gift
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rank { get; set; }
        public string UserId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
