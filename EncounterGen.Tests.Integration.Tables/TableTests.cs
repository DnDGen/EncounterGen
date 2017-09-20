using DnDGen.Core.IoC;
using EventGen;
using Ninject;
using NUnit.Framework;
using System;
using System.Linq;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture, Table]
    public abstract class TableTests : IntegrationTests
    {
        [Inject]
        public ClientIDManager ClientIdManager { get; set; }
        [Inject]
        public GenEventQueue EventQueue { get; set; }

        protected abstract string tableName { get; }

        private Guid clientId;

        [OneTimeSetUp]
        public void TableOneTimeSetup()
        {
            var coreLoader = new CoreModuleLoader();
            coreLoader.ReplaceAssemblyLoaderWith<EncounterGenAssemblyLoader>(kernel);
        }

        [SetUp]
        public void TableSetup()
        {
            clientId = Guid.NewGuid();
            ClientIdManager.SetClientID(clientId);
        }

        [TearDown]
        public void TableTearDown()
        {
            WriteEventSummary();
        }

        private void WriteEventSummary()
        {
            var events = EventQueue.DequeueAll(clientId);

            //INFO: Get the 10 most recent events for EncounterGen.  We assume the events are ordered chronologically already
            events = events.Where(e => e.Source == "EncounterGen");
            events = events.Reverse();
            events = events.Take(10);
            events = events.Reverse();

            foreach (var genEvent in events)
                Console.WriteLine(GetEventMessage(genEvent));
        }

        private string GetEventMessage(GenEvent genEvent)
        {
            return $"[{genEvent.When.ToLongTimeString()}] {genEvent.Source}: {genEvent.Message}";
        }
    }
}
