using System;
using System.Collections.Generic;
using System.Text;

namespace EFInMemoryRootOwnedType.Model
{
    public class PersonNames
    {
        public int Id { get; set; }

        public TransliteratedString Value { get; set; }

        public Person Person { get; set; }

        public int PersonId { get; set; }
    }
}
