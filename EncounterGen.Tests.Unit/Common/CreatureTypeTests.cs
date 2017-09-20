using EncounterGen.Common;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class CreatureTypeTests
    {
        private CreatureType creatureType;
        private const int RecursiveCount = 42;

        [SetUp]
        public void Setup()
        {
            creatureType = new CreatureType();
        }

        [Test]
        public void CreatureTypeInitialized()
        {
            Assert.That(creatureType.Name, Is.Empty);
            Assert.That(creatureType.Description, Is.Empty);
            Assert.That(creatureType.SubType, Is.Null);
        }

        [Test]
        public void CreateSubtype()
        {
            creatureType.SubType = new CreatureType();
            Assert.That(creatureType.SubType.Name, Is.Empty);
            Assert.That(creatureType.SubType.Description, Is.Empty);
            Assert.That(creatureType.SubType.SubType, Is.Null);
        }

        [Test]
        public void AreEqualIfBothTypesAreNull()
        {
            var areEqual = CreatureType.AreEqual(null, null);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfSourceIsNull()
        {
            var target = new CreatureType();
            var areEqual = CreatureType.AreEqual(null, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfTargetIsNull()
        {
            var source = new CreatureType();
            var areEqual = CreatureType.AreEqual(source, null);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfNamesDiffer()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            target.Name = "other name";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfNamesDifferAndDescriptionsAreTheSame()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            target.Name = "other name";
            target.Description = "description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfNamesAreTheSame()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            target.Name = "name";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfDescriptionsDiffer()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "other description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfDescriptionsAreTheSame()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreEqualIfBothSubtypesAreNull()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfSourceSubtypeIsNull()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";
            target.SubType = new CreatureType();

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfTargetSubtypeIsNull()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            source.SubType = new CreatureType();
            target.Name = "name";
            target.Description = "description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfSubtypeNamesDiffer()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            source.SubType = new CreatureType();
            source.SubType.Name = "subtype name";
            target.Name = "name";
            target.Description = "description";
            target.SubType = new CreatureType();
            target.SubType.Name = "other subtype name";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfSubtypeNamesDifferAndSubtypeDescriptionsAreTheSame()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            source.SubType = new CreatureType();
            source.SubType.Name = "subtype name";
            source.SubType.Description = "subtype description";
            target.Name = "name";
            target.Description = "description";
            target.SubType = new CreatureType();
            target.SubType.Name = "other subtype name";
            target.SubType.Description = "subtype description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfSubtypeNamesAreTheSame()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            source.SubType = new CreatureType();
            source.SubType.Name = "subtype name";
            target.Name = "name";
            target.Description = "description";
            target.SubType = new CreatureType();
            target.SubType.Name = "subtype name";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfSubtypeDescriptionsDiffer()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            source.SubType = new CreatureType();
            source.SubType.Name = "subtype name";
            source.SubType.Description = "subtype description";
            target.Name = "name";
            target.Description = "description";
            target.SubType = new CreatureType();
            target.SubType.Name = "subtype name";
            target.SubType.Description = "other subtype description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfSubtypeDescriptionsAreTheSame()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            source.SubType = new CreatureType();
            source.SubType.Name = "subtype name";
            source.SubType.Description = "subtype description";
            target.Name = "name";
            target.Description = "description";
            target.SubType = new CreatureType();
            target.SubType.Name = "subtype name";
            target.SubType.Description = "subtype description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreEqualIfBothRecursiveSubtypesAreNull()
        {
            var source = new CreatureType();
            var target = new CreatureType();

            source.Name = "name";
            source.Description = "description";
            target.Name = "name";
            target.Description = "description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfRecursiveSourceSubtypeIsNull()
        {
            var source = new CreatureType();
            var target = new CreatureType();

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

                sourcePointer.SubType = new CreatureType();
                sourcePointer.SubType.Name = name;
                sourcePointer.SubType.Description = description;

                targetPointer.SubType = new CreatureType();
                targetPointer.SubType.Name = name;
                targetPointer.SubType.Description = description;

                sourcePointer = sourcePointer.SubType;
                targetPointer = targetPointer.SubType;
            }

            targetPointer.SubType = new CreatureType();

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfRecursiveTargetSubtypeIsNull()
        {
            var source = new CreatureType();
            var target = new CreatureType();

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

                sourcePointer.SubType = new CreatureType();
                sourcePointer.SubType.Name = name;
                sourcePointer.SubType.Description = description;

                targetPointer.SubType = new CreatureType();
                targetPointer.SubType.Name = name;
                targetPointer.SubType.Description = description;

                sourcePointer = sourcePointer.SubType;
                targetPointer = targetPointer.SubType;
            }

            sourcePointer.SubType = new CreatureType();

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfRecursiveSubtypeNamesDiffer()
        {
            var source = new CreatureType();
            var target = new CreatureType();

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

                sourcePointer.SubType = new CreatureType();
                sourcePointer.SubType.Name = name;
                sourcePointer.SubType.Description = description;

                targetPointer.SubType = new CreatureType();
                targetPointer.SubType.Name = name;
                targetPointer.SubType.Description = description;

                sourcePointer = sourcePointer.SubType;
                targetPointer = targetPointer.SubType;
            }

            sourcePointer.Name = "subtype name";
            targetPointer.Name = "other subtype name";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreNotEqualIfRecursiveSubtypeNamesDifferAndSubtypeDescriptionsAreTheSame()
        {
            var source = new CreatureType();
            var target = new CreatureType();

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

                sourcePointer.SubType = new CreatureType();
                sourcePointer.SubType.Name = name;
                sourcePointer.SubType.Description = description;

                targetPointer.SubType = new CreatureType();
                targetPointer.SubType.Name = name;
                targetPointer.SubType.Description = description;

                sourcePointer = sourcePointer.SubType;
                targetPointer = targetPointer.SubType;
            }

            sourcePointer.Name = "subtype name";
            sourcePointer.Description = "subtype description";
            targetPointer.Name = "other subtype name";
            targetPointer.Description = "subtype description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfRecursiveSubtypeNamesAreTheSame()
        {
            var source = new CreatureType();
            var target = new CreatureType();

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

                sourcePointer.SubType = new CreatureType();
                sourcePointer.SubType.Name = name;
                sourcePointer.SubType.Description = description;

                targetPointer.SubType = new CreatureType();
                targetPointer.SubType.Name = name;
                targetPointer.SubType.Description = description;

                sourcePointer = sourcePointer.SubType;
                targetPointer = targetPointer.SubType;
            }

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }

        [Test]
        public void AreNotEqualIfRecursiveSubtypeDescriptionsDiffer()
        {
            var source = new CreatureType();
            var target = new CreatureType();

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

                sourcePointer.SubType = new CreatureType();
                sourcePointer.SubType.Name = name;
                sourcePointer.SubType.Description = description;

                targetPointer.SubType = new CreatureType();
                targetPointer.SubType.Name = name;
                targetPointer.SubType.Description = description;

                sourcePointer = sourcePointer.SubType;
                targetPointer = targetPointer.SubType;
            }

            sourcePointer.Name = "subtype name";
            sourcePointer.Description = "subtype description";
            targetPointer.Name = "subtype name";
            targetPointer.Description = "other subtype description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.False);
        }

        [Test]
        public void AreEqualIfRecursiveSubtypeDescriptionsAreTheSame()
        {
            var source = new CreatureType();
            var target = new CreatureType();

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

                sourcePointer.SubType = new CreatureType();
                sourcePointer.SubType.Name = name;
                sourcePointer.SubType.Description = description;

                targetPointer.SubType = new CreatureType();
                targetPointer.SubType.Name = name;
                targetPointer.SubType.Description = description;

                sourcePointer = sourcePointer.SubType;
                targetPointer = targetPointer.SubType;
            }

            sourcePointer.Name = "subtype name";
            sourcePointer.Description = "subtype description";
            targetPointer.Name = "subtype name";
            targetPointer.Description = "subtype description";

            var areEqual = CreatureType.AreEqual(source, target);
            Assert.That(areEqual, Is.True);
        }
    }
}
