using DnDGen.EncounterGen.Models;
using NUnit.Framework;
using System;

namespace DnDGen.EncounterGen.Tests.Unit.Models
{
    [TestFixture]
    public class CreatureTypeTests
    {
        private EncounterCreature creatureType;
        private const int RecursiveCount = 42;

        [SetUp]
        public void Setup()
        {
            creatureType = new EncounterCreature();
        }

        [Test]
        public void CreatureTypeInitialized()
        {
            Assert.That(creatureType.Name, Is.Empty);
            Assert.That(creatureType.Description, Is.Empty);
            Assert.That(creatureType.SubCreature, Is.Null);
        }

        [Test]
        public void CreateSubtype()
        {
            creatureType.SubCreature = new EncounterCreature();
            Assert.That(creatureType.SubCreature.Name, Is.Empty);
            Assert.That(creatureType.SubCreature.Description, Is.Empty);
            Assert.That(creatureType.SubCreature.SubCreature, Is.Null);
        }

        [Test]
        public void AreEqualIfBothTypesAreNull()
        {
            var areEqual = EncounterCreature.AreEqual(null, null);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfSourceIsNull()
        {
            var target = new EncounterCreature();
            var areEqual = EncounterCreature.AreEqual(null, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfTargetIsNull()
        {
            var source = new EncounterCreature();
            var areEqual = EncounterCreature.AreEqual(source, null);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfNamesDiffer()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            target.Name = "other name";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfNamesDifferAndDescriptionsAreTheSame()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "other name";
            target.Description = "description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfNamesAreTheSame()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            target.Name = "name";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfDescriptionsDiffer()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "other description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfDescriptionsAreTheSame()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreEqualIfBothSubtypesAreNull()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfSourceSubtypeIsNull()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new EncounterCreature();

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfTargetSubtypeIsNull()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new EncounterCreature();
            target.Name = "name";
            target.Description = "description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfSubtypeNamesDiffer()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new EncounterCreature();
            source.SubCreature.Name = "subtype name";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new EncounterCreature();
            target.SubCreature.Name = "other subtype name";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfSubtypeNamesDifferAndSubtypeDescriptionsAreTheSame()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new EncounterCreature();
            source.SubCreature.Name = "subtype name";
            source.SubCreature.Description = "subtype description";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new EncounterCreature();
            target.SubCreature.Name = "other subtype name";
            target.SubCreature.Description = "subtype description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfSubtypeNamesAreTheSame()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new EncounterCreature();
            source.SubCreature.Name = "subtype name";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new EncounterCreature();
            target.SubCreature.Name = "subtype name";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfSubtypeDescriptionsDiffer()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new EncounterCreature();
            source.SubCreature.Name = "subtype name";
            source.SubCreature.Description = "subtype description";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new EncounterCreature();
            target.SubCreature.Name = "subtype name";
            target.SubCreature.Description = "other subtype description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfSubtypeDescriptionsAreTheSame()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            source.SubCreature = new EncounterCreature();
            source.SubCreature.Name = "subtype name";
            source.SubCreature.Description = "subtype description";
            target.Name = "name";
            target.Description = "description";
            target.SubCreature = new EncounterCreature();
            target.SubCreature.Name = "subtype name";
            target.SubCreature.Description = "subtype description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreEqualIfBothRecursiveSubtypesAreNull()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfRecursiveSourceSubtypeIsNull()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

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

                sourcePointer.SubCreature = new EncounterCreature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new EncounterCreature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            targetPointer.SubCreature = new EncounterCreature();

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfRecursiveTargetSubtypeIsNull()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

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

                sourcePointer.SubCreature = new EncounterCreature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new EncounterCreature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            sourcePointer.SubCreature = new EncounterCreature();

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfRecursiveSubtypeNamesDiffer()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

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

                sourcePointer.SubCreature = new EncounterCreature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new EncounterCreature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            sourcePointer.Name = "subtype name";
            targetPointer.Name = "other subtype name";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfRecursiveSubtypeNamesDifferAndSubtypeDescriptionsAreTheSame()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

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

                sourcePointer.SubCreature = new EncounterCreature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new EncounterCreature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            sourcePointer.Name = "subtype name";
            sourcePointer.Description = "subtype description";
            targetPointer.Name = "other subtype name";
            targetPointer.Description = "subtype description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfRecursiveSubtypeNamesAreTheSame()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

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

                sourcePointer.SubCreature = new EncounterCreature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new EncounterCreature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfRecursiveSubtypeDescriptionsDiffer()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

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

                sourcePointer.SubCreature = new EncounterCreature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new EncounterCreature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            sourcePointer.Name = "subtype name";
            sourcePointer.Description = "subtype description";
            targetPointer.Name = "subtype name";
            targetPointer.Description = "other subtype description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfRecursiveSubtypeDescriptionsAreTheSame()
        {
            var source = new EncounterCreature();
            var target = new EncounterCreature();

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

                sourcePointer.SubCreature = new EncounterCreature();
                sourcePointer.SubCreature.Name = name;
                sourcePointer.SubCreature.Description = description;

                targetPointer.SubCreature = new EncounterCreature();
                targetPointer.SubCreature.Name = name;
                targetPointer.SubCreature.Description = description;

                sourcePointer = sourcePointer.SubCreature;
                targetPointer = targetPointer.SubCreature;
            }

            sourcePointer.Name = "subtype name";
            sourcePointer.Description = "subtype description";
            targetPointer.Name = "subtype name";
            targetPointer.Description = "subtype description";

            var areEqual = EncounterCreature.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }
    }
}
