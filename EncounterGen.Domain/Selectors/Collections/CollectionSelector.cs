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

        public IEnumerable<string> Explode(string tableName, string name)
        {
            var explodedGroup = SelectFrom(tableName, name).ToList();
            var subgroupNames = explodedGroup.Where(i => IsGroup(tableName, i) && i != name).ToArray(); //INFO: Doing immediate execution because looping below fails otherwise (modifying the source collection)

            foreach (var subgroupName in subgroupNames)
            {
                var explodedSubgroup = Explode(tableName, subgroupName);
                explodedGroup.Remove(subgroupName);
                explodedGroup.AddRange(explodedSubgroup);
            }

            return explodedGroup.Distinct();
        }

        public IEnumerable<string> ExplodeInto(string tableName, string name, string intoTableName)
        {
            var explodedGroup = Explode(tableName, name);

            return explodedGroup.SelectMany(g => SelectFrom(intoTableName, g)).Distinct();
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
