using System;
using System.Collections.Generic;
using System.Text;

namespace EFInMemoryRootOwnedType.Model
{
    public class Person
    {
        public int Id { get; set; }

        public TransliteratedString Comment { get; set; }

        public List<PersonNames> Names { get; set; }
    }
}
