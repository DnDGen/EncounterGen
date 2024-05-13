using DnDGen.EncounterGen.Models;
using NUnit.Framework;
using System;

namespace DnDGen.EncounterGen.Tests.Unit.Models
{
    [TestFixture]
    public class CreatureTests
    {
        private Creature creature;
        private const int RecursiveCount = 42;

        [SetUp]
        public void Setup()
        {
            creature = new Creature();
        }

        [Test]
        public void CreatureInitialized()
        {
            Assert.That(creature.Name, Is.Empty);
            Assert.That(creature.Description, Is.Empty);
            Assert.That(creature.SubCreature, Is.Null);
        }

        [Test]
        public void CreateSubcreature()
        {
            creature.SubCreature = new Creature();
            Assert.That(creature.SubCreature.Name, Is.Empty);
            Assert.That(creature.SubCreature.Description, Is.Empty);
            Assert.That(creature.SubCreature.SubCreature, Is.Null);
        }

        [Test]
        public void AreEqualIfBothCreaturesAreNull()
        {
            var areEqual = Creature.AreEqual(null, null);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfSourceIsNull()
        {
            var target = new Creature();
            var areEqual = Creature.AreEqual(null, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfTargetIsNull()
        {
            var source = new Creature();
            var areEqual = Creature.AreEqual(source, null);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfNamesDiffer()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            target.Name = "other name";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfNamesDifferAndDescriptionsAreTheSame()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "other name";
            target.Description = "description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfNamesAreTheSame()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            target.Name = "name";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfDescriptionsDiffer()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "other description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfDescriptionsAreTheSame()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreEqualIfBothSubcreaturesAreNull()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfSourceSubcreatureIsNull()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new Creature();

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfTargetSubcreatureIsNull()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new Creature();
            target.Name = "name";
            target.Description = "description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfSubcreatureNamesDiffer()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new Creature();
            source.SubCreature.Name = "subtype name";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new Creature();
            target.SubCreature.Name = "other subtype name";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfSubcreatureNamesDifferAndSubcreatureDescriptionsAreTheSame()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new Creature();
            source.SubCreature.Name = "subtype name";
            source.SubCreature.Description = "subtype description";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new Creature();
            target.SubCreature.Name = "other subtype name";
            target.SubCreature.Description = "subtype description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfSubcreatureNamesAreTheSame()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new Creature();
            source.SubCreature.Name = "subtype name";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new Creature();
            target.SubCreature.Name = "subtype name";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfSubcreatureDescriptionsDiffer()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new Creature();
            source.SubCreature.Name = "subtype name";
            source.SubCreature.Description = "subtype description";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new Creature();
            target.SubCreature.Name = "subtype name";
            target.SubCreature.Description = "other subtype description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfSubcreatureDescriptionsAreTheSame()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new Creature();
            source.SubCreature.Name = "subtype name";
            source.SubCreature.Description = "subtype description";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new Creature();
            target.SubCreature.Name = "subtype name";
            target.SubCreature.Description = "subtype description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreEqualIfBothRecursiveSubcreaturesAreNull()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfRecursiveSourceSubcreatureIsNull()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var sourcePointer = source;
            var targetPointer = target;
            var count = 0;

            while (count++ < RecursiveCount)
            {
                var name = Guid.NewGuid().ToString();
                var description = Guid.NewGuid().ToString();

                sourcePointer.SubCreature = new Creature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new Creature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            targetPointer.SubCreature = new Creature();

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfRecursiveTargetSubcreatureIsNull()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var sourcePointer = source;
            var targetPointer = target;
            var count = 0;

            while (count++ < RecursiveCount)
            {
                var name = Guid.NewGuid().ToString();
                var description = Guid.NewGuid().ToString();

                sourcePointer.SubCreature = new Creature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new Creature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            sourcePointer.SubCreature = new Creature();

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfRecursiveSubcreatureNamesDiffer()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var sourcePointer = source;
            var targetPointer = target;
            var count = 0;

            while (count++ < RecursiveCount)
            {
                var name = Guid.NewGuid().ToString();
                var description = Guid.NewGuid().ToString();

                sourcePointer.SubCreature = new Creature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new Creature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            sourcePointer.Name = "subtype name";
            targetPointer.Name = "other subtype name";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfRecursiveSubcreatureNamesDifferAndSubcreatureDescriptionsAreTheSame()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var sourcePointer = source;
            var targetPointer = target;
            var count = 0;

            while (count++ < RecursiveCount)
            {
                var name = Guid.NewGuid().ToString();
                var description = Guid.NewGuid().ToString();

                sourcePointer.SubCreature = new Creature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new Creature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            sourcePointer.Name = "subtype name";
            sourcePointer.Description = "subtype description";
            targetPointer.Name = "other subtype name";
            targetPointer.Description = "subtype description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfRecursiveSubcreatureNamesAreTheSame()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var sourcePointer = source;
            var targetPointer = target;
            var count = 0;

            while (count++ < RecursiveCount)
            {
                var name = Guid.NewGuid().ToString();
                var description = Guid.NewGuid().ToString();

                sourcePointer.SubCreature = new Creature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new Creature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfRecursiveSubcreatureDescriptionsDiffer()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var sourcePointer = source;
            var targetPointer = target;
            var count = 0;

            while (count++ < RecursiveCount)
            {
                var name = Guid.NewGuid().ToString();
                var description = Guid.NewGuid().ToString();

                sourcePointer.SubCreature = new Creature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new Creature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            sourcePointer.Name = "subtype name";
            sourcePointer.Description = "subtype description";
            targetPointer.Name = "subtype name";
            targetPointer.Description = "other subtype description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfRecursiveSubcreatureDescriptionsAreTheSame()
        {
            var source = new Creature();
            var target = new Creature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var sourcePointer = source;
            var targetPointer = target;
            var count = 0;

            while (count++ < RecursiveCount)
            {
                var name = Guid.NewGuid().ToString();
                var description = Guid.NewGuid().ToString();

                sourcePointer.SubCreature = new Creature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new Creature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            sourcePointer.Name = "subtype name";
            sourcePointer.Description = "subtype description";
            targetPointer.Name = "subtype name";
            targetPointer.Description = "subtype description";

            var areEqual = Creature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }
    }
}
