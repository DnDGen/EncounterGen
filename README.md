EncounterGen
============

Generate random Dungeons & Dragons encounters

[![Build Status](https://travis-ci.org/DnDGen/EncounterGen.svg?branch=master)](https://travis-ci.org/DnDGen/EncounterGen)

### Use

To use EncounterGen, simply use the EncounterGenerator.  The environments are listed in the EnvironmentConstants.  Levels up to 20 are supported.

**There are currently no fully-working environments yet.  This is still in development**

```C#
var encounter = characterGenerator.GenerateWith(EnvironmentConstants.Dungeon, 15);
```

### Getting the Generators

You can obtain generators from the bootstrapper project.  Because the generators are very complex and are decorated in various ways, there is not a (recommended) way to build these generator manually.  Please use the Bootstrapper package.  **Note:** if using the EnounterGen bootstrapper, be sure to also load modules for RollGen, TreasureGen, and CharacterGen, as it is dependent on those modules

```C#
var kernel = new StandardKernel();
var rollGenModuleLoader = new RollGenModuleLoader();
var treasureGenModuleLoader = new TreasureGenModuleLoader();
var characterGenModuleLoader = new CharacterGenModuleLoader();
var encounterGenModuleLoader = new EncounterGenModuleLoader();

rollGenModuleLoader.LoadModules(kernel);
treasureGenModuleLoader.LoadModules(kernel);
characterGenModuleLoader.LoadModules(kernel);
encounterGenModuleLoader.LoadModules(kernel);
```

Your particular syntax for how the Ninject injection should work will depend on your project (class library, web site, etc.)

### Installing EncounterGen

The project is on [Nuget](https://www.nuget.org/packages/EncounterGen). Install via the NuGet Package Manager.

    PM > Install-Package EncounterGen

#### There's EncounterGen and EncounterGen.Bootstrap - which do I install?

That depends on your project.  If you are making a library that will only **reference** EncounterGen, but does not expressly implement it (such as the DungeonGen project), then you only need the EncounterGen package.  If you actually want to run and implement the dice (such as on the DnDGenSite or in the integration tests for EncounterGen), then you need EncounterGen.Bootstrap, which will install EncounterGen as a dependency.
