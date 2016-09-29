using EncounterGen.Domain.Mappers.Collections;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal class CollectionSelector : ICollectionSelector
    {
        private CollectionMapper mapper;
        private Dice dice;

        public CollectionSelector(CollectionMapper mapper, Dice dice)
        {
            this.mapper = mapper;
            this.dice = dice;
        }

        public IEnumerable<string> SelectFrom(string tableName, string name)
        {
            if (!IsGroup(tableName, name))
                throw new ArgumentException($"{name} is not a valid entry in the table {tableName}");

            var table = mapper.Map(tableName);
            return table[name];
        }

        private bool IsSubgroup(string tableName, string name, string intoTableName)
        {
            return IsGroup(tableName, name) && !IsGroup(intoTableName, name);
        }

        public IEnumerable<string> ExplodeInto(string tableName, string name, string intoTableName)
        {
            var group = SelectFrom(tableName, name);
            var subgroups = group.Where(c => IsSubgroup(tableName, c, intoTableName));

            while (subgroups.Any())
            {
                var subgroup = subgroups.SelectMany(g => SelectFrom(tableName, g));
                group = group.Union(subgroup).Except(subgroups);
                subgroups = group.Where(c => IsSubgroup(tableName, c, intoTableName));
            }

            return group.SelectMany(g => SelectFrom(intoTableName, g));
        }

        public T SelectRandomFrom<T>(IEnumerable<T> collection)
        {
            if (collection.Any() == false)
                throw new ArgumentException("Cannot select random from empty collection");

            var index = dice.Roll().d(collection.Count()).AsSum() - 1;
            return collection.ElementAt(index);
        }

        public bool IsGroup(string tableName, string name)
        {
            var table = mapper.Map(tableName);
            return table.ContainsKey(name);
        }
    }
}
