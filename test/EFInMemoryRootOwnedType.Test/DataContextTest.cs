using System;
using System.Collections.Generic;
using EFInMemoryRootOwnedType.Data;
using EFInMemoryRootOwnedType.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;

namespace EFInMemoryRootOwnedType.Test
{
    public class DataContextTest
    {
        [Fact]
        public void ShouldSaveWithRoot()
        {
            // Given
            var root = new InMemoryDatabaseRoot();

            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString(), root)
                                                                    .Options;

            // When
            using (var context = new DataContext(options))
            {
                context.Add(new Person
                {
                    Comment = new TransliteratedString("Comment"),
                    Names = new List<PersonNames>
                    {
                        new PersonNames { Value = new TransliteratedString("Name") }
                    }
                });

                context.SaveChanges();
            }

            // Then
            using (var context = new DataContext(options))
            {
                Assert.Single(context.Set<Person>());
                Assert.Single(context.Set<PersonNames>());
            }
        }

        [Fact]
        public void ShouldSaveWithoutRoot()
        {
            // Given
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                                                                    .Options;

            // When
            using (var context = new DataContext(options))
            {
                context.Add(new Person
                {
                    Comment = new TransliteratedString("Comment"),
                    Names = new List<PersonNames>
                    {
                        new PersonNames { Value = new TransliteratedString("Name") }
                    }
                });

                context.SaveChanges();
            }

            // Then
            using (var context = new DataContext(options))
            {
                Assert.Single(context.Set<Person>());
                Assert.Single(context.Set<PersonNames>());
            }
        }
    }
}