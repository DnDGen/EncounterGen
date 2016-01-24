﻿using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class CreatureConstantsTests
    {
        [TestCase(CreatureConstants.Allip, "Allip")]
        [TestCase(CreatureConstants.Androsphinx, "Androsphinx")]
        [TestCase(CreatureConstants.AnimatedObject_Gargantuan, "Gargantuan animated object")]
        [TestCase(CreatureConstants.AnimatedObject_Medium, "Medium animated object")]
        [TestCase(CreatureConstants.AnimatedObject_Small, "Small animated object")]
        [TestCase(CreatureConstants.AnimatedObject_Tiny, "Tiny animated object")]
        [TestCase(CreatureConstants.Ankheg, "Ankheg")]
        [TestCase(CreatureConstants.Annis, "Annis (hag)")]
        [TestCase(CreatureConstants.Ant_Giant_Soldier, "Giant soldier ant")]
        [TestCase(CreatureConstants.Ant_Giant_Worker, "Giant worker ant")]
        [TestCase(CreatureConstants.Ape, "Ape")]
        [TestCase(CreatureConstants.Ape_Dire, "Dire ape")]
        [TestCase(CreatureConstants.Aranea, "Aranea")]
        [TestCase(CreatureConstants.Arrowhawk_Adult, "Adult arrowhawk")]
        [TestCase(CreatureConstants.Arrowhawk_Elder, "Elder arrowhawk")]
        [TestCase(CreatureConstants.Arrowhawk_Juvenile, "Juvenile arrowhawk")]
        [TestCase(CreatureConstants.AssassinVine, "Assassin vine")]
        [TestCase(CreatureConstants.AstralDeva, "Astral deva (celestial)")]
        [TestCase(CreatureConstants.Athach, "Athach")]
        [TestCase(CreatureConstants.Avoral, "Avoral")]
        [TestCase(CreatureConstants.Azer, "Azer")]
        [TestCase(CreatureConstants.Baboon, "Baboon")]
        [TestCase(CreatureConstants.Badger, "Badger")]
        [TestCase(CreatureConstants.Badger_Dire, "Dire badger")]
        [TestCase(CreatureConstants.Balor, "Balor (demon)")]
        [TestCase(CreatureConstants.Barbazu, "Barbazu (devil)")]
        [TestCase(CreatureConstants.Barghest, "Barghest")]
        [TestCase(CreatureConstants.Barghest_Greater, "Greater barghest")]
        [TestCase(CreatureConstants.Basilisk, "Basilisk")]
        [TestCase(CreatureConstants.Bat, "Bat")]
        [TestCase(CreatureConstants.Bat_Dire, "Dire bat")]
        [TestCase(CreatureConstants.Bear_Black, "Black bear")]
        [TestCase(CreatureConstants.Bear_Brown, "Brown bear")]
        [TestCase(CreatureConstants.Bear_Dire, "Dire bear")]
        [TestCase(CreatureConstants.Bear_Polar, "Polar bear")]
        [TestCase(CreatureConstants.Bee_Giant, "Giant bee")]
        [TestCase(CreatureConstants.Behir, "Behir")]
        [TestCase(CreatureConstants.Beholder, "Beholder")]
        [TestCase(CreatureConstants.Belker, "Belker")]
        [TestCase(CreatureConstants.Bison, "Bison")]
        [TestCase(CreatureConstants.BlinkDog, "Blink dog")]
        [TestCase(CreatureConstants.Boar, "Boar")]
        [TestCase(CreatureConstants.Boar_Dire, "Dire boar")]
        [TestCase(CreatureConstants.Bodak, "Bodak")]
        [TestCase(CreatureConstants.BombardierBeetle_Giant, "Giant bombardier beetle")]
        [TestCase(CreatureConstants.Bugbear, "Bugbear")]
        [TestCase(CreatureConstants.Bulette, "Bulette")]
        [TestCase(CreatureConstants.Camel, "Camel")]
        [TestCase(CreatureConstants.CarrionCrawler, "Carrion crawler")]
        [TestCase(CreatureConstants.Cat, "Cat")]
        [TestCase(CreatureConstants.CelestialCreature, "Celestial creature")]
        [TestCase(CreatureConstants.Centaur, "Centaur")]
        [TestCase(CreatureConstants.Centipede_Monstrous_Colossal, "Colossal monstrous centipede")]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan, "Gargantuan monstrous centipede")]
        [TestCase(CreatureConstants.Centipede_Monstrous_Huge, "Huge monstrous centipede")]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large, "Large monstrous centipede")]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium, "Medium monstrous centipede")]
        [TestCase(CreatureConstants.Centipede_Monstrous_Small, "Small monstrous centipede")]
        [TestCase(CreatureConstants.Centipede_Monstrous_Tiny, "Tiny monstrous centipede")]
        [TestCase(CreatureConstants.ChaosBeast, "Chaos beast")]
        [TestCase(CreatureConstants.Character, "Character")]
        [TestCase(CreatureConstants.Cheetah, "Cheetah")]
        [TestCase(CreatureConstants.Chimera, "Chimera")]
        [TestCase(CreatureConstants.Choker, "Choker")]
        [TestCase(CreatureConstants.Chuul, "Chuul")]
        [TestCase(CreatureConstants.Cloaker, "Cloaker")]
        [TestCase(CreatureConstants.Cockatrice, "Cockatrice")]
        [TestCase(CreatureConstants.Commoner_Farmer, "Commoner (Farmer)")]
        [TestCase(CreatureConstants.Commoner_Herder, "Commoner (Herder)")]
        [TestCase(CreatureConstants.Commoner_Hunter, "Commoner (Hunter)")]
        [TestCase(CreatureConstants.Commoner_Merchant, "Commoner (Merchant)")]
        [TestCase(CreatureConstants.Commoner_Minstrel, "Commoner (Minstrel)")]
        [TestCase(CreatureConstants.Commoner_Pilgrim, "Commoner (Pilgrim)")]
        [TestCase(CreatureConstants.Cornugon, "Cornugon (devil)")]
        [TestCase(CreatureConstants.Criosphinx, "Criosphinx")]
        [TestCase(CreatureConstants.Crocodile, "Crocodile")]
        [TestCase(CreatureConstants.Crocodile_Giant, "Giant crocodile")]
        [TestCase(CreatureConstants.Cryohydra, "Cryohydra")]
        [TestCase(CreatureConstants.Cryohydra_5Heads, "Cryohydra (5 heads)")]
        [TestCase(CreatureConstants.Cryohydra_6Heads, "Cryohydra (6 heads)")]
        [TestCase(CreatureConstants.Cryohydra_7Heads, "Cryohydra (7 heads)")]
        [TestCase(CreatureConstants.Cryohydra_8Heads, "Cryohydra (8 heads)")]
        [TestCase(CreatureConstants.Cryohydra_9Heads, "Cryohydra (9 heads)")]
        [TestCase(CreatureConstants.Cryohydra_10Heads, "Cryohydra (10 heads)")]
        [TestCase(CreatureConstants.Cryohydra_11Heads, "Cryohydra (11 heads)")]
        [TestCase(CreatureConstants.Cryohydra_12Heads, "Cryohydra (12 heads)")]
        [TestCase(CreatureConstants.Darkmantle, "Darkmantle")]
        [TestCase(CreatureConstants.Deinonychus, "Deinonychus")]
        [TestCase(CreatureConstants.Derro, "Derro")]
        [TestCase(CreatureConstants.Destrachan, "Destrachan")]
        [TestCase(CreatureConstants.Devourer, "Devourer")]
        [TestCase(CreatureConstants.Delver, "Delver")]
        [TestCase(CreatureConstants.Digester, "Digester")]
        [TestCase(CreatureConstants.Djinn, "Djinn")]
        [TestCase(CreatureConstants.Djinn_Noble, "Noble djinn")]
        [TestCase(CreatureConstants.Dog, "Dog")]
        [TestCase(CreatureConstants.Donkey, "Donkey")]
        [TestCase(CreatureConstants.Doppelganger, "Doppelganger")]
        [TestCase(CreatureConstants.Dragon, "Dragon")]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling, "Wyrmling black dragon")]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung, "Very young black dragon")]
        [TestCase(CreatureConstants.Dragon_Black_Young, "Young black dragon")]
        [TestCase(CreatureConstants.Dragon_Black_Juvenile, "Juvenile black dragon")]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult, "Young adult black dragon")]
        [TestCase(CreatureConstants.Dragon_Black_Adult, "Adult black dragon")]
        [TestCase(CreatureConstants.Dragon_Black_MatureAdult, "Mature adult black dragon")]
        [TestCase(CreatureConstants.Dragon_Black_Old, "Old black dragon")]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld, "Very old black dragon")]
        [TestCase(CreatureConstants.Dragon_Black_Ancient, "Ancient black dragon")]
        [TestCase(CreatureConstants.Dragon_Black_Wyrm, "Wyrm black dragon")]
        [TestCase(CreatureConstants.Dragon_Black_GreatWyrm, "Great wyrm black dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling, "Wyrmling blue dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung, "Very young blue dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_Young, "Young blue dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile, "Juvenile blue dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult, "Young adult blue dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_Adult, "Adult blue dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_MatureAdult, "Mature adult blue dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_Old, "Old blue dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_VeryOld, "Very old blue dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_Ancient, "Ancient blue dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrm, "Wyrm blue dragon")]
        [TestCase(CreatureConstants.Dragon_Blue_GreatWyrm, "Great wyrm blue dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling, "Wyrmling brass dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung, "Very young brass dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_Young, "Young brass dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile, "Juvenile brass dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult, "Young adult brass dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_Adult, "Adult brass dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_MatureAdult, "Mature adult brass dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_Old, "Old brass dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_VeryOld, "Very old brass dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_Ancient, "Ancient brass dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrm, "Wyrm brass dragon")]
        [TestCase(CreatureConstants.Dragon_Brass_GreatWyrm, "Great wyrm brass dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling, "Wyrmling bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung, "Very young bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_Young, "Young bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile, "Juvenile bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult, "Young adult bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_Adult, "Adult bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_MatureAdult, "Mature adult bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_Old, "Old bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryOld, "Very old bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_Ancient, "Ancient bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrm, "Wyrm bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Bronze_GreatWyrm, "Great wyrm bronze dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling, "Wyrmling copper dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung, "Very young copper dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_Young, "Young copper dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile, "Juvenile copper dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult, "Young adult copper dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_Adult, "Adult copper dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_MatureAdult, "Mature adult copper dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_Old, "Old copper dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_VeryOld, "Very old copper dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_Ancient, "Ancient copper dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrm, "Wyrm copper dragon")]
        [TestCase(CreatureConstants.Dragon_Copper_GreatWyrm, "Great wyrm copper dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling, "Wyrmling gold dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung, "Very young gold dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_Young, "Young gold dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile, "Juvenile gold dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult, "Young adult gold dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_Adult, "Adult gold dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult, "Mature adult gold dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_Old, "Old gold dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_VeryOld, "Very old gold dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_Ancient, "Ancient gold dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrm, "Wyrm gold dragon")]
        [TestCase(CreatureConstants.Dragon_Gold_GreatWyrm, "Great wyrm gold dragon")]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling, "Wyrmling green dragon")]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung, "Very young green dragon")]
        [TestCase(CreatureConstants.Dragon_Green_Young, "Young green dragon")]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile, "Juvenile green dragon")]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult, "Young adult green dragon")]
        [TestCase(CreatureConstants.Dragon_Green_Adult, "Adult green dragon")]
        [TestCase(CreatureConstants.Dragon_Green_MatureAdult, "Mature adult green dragon")]
        [TestCase(CreatureConstants.Dragon_Green_Old, "Old green dragon")]
        [TestCase(CreatureConstants.Dragon_Green_VeryOld, "Very old green dragon")]
        [TestCase(CreatureConstants.Dragon_Green_Ancient, "Ancient green dragon")]
        [TestCase(CreatureConstants.Dragon_Green_Wyrm, "Wyrm green dragon")]
        [TestCase(CreatureConstants.Dragon_Green_GreatWyrm, "Great wyrm green dragon")]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling, "Wyrmling red dragon")]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung, "Very young red dragon")]
        [TestCase(CreatureConstants.Dragon_Red_Young, "Young red dragon")]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile, "Juvenile red dragon")]
        [TestCase(CreatureConstants.Dragon_Red_YoungAdult, "Young adult red dragon")]
        [TestCase(CreatureConstants.Dragon_Red_Adult, "Adult red dragon")]
        [TestCase(CreatureConstants.Dragon_Red_MatureAdult, "Mature adult red dragon")]
        [TestCase(CreatureConstants.Dragon_Red_Old, "Old red dragon")]
        [TestCase(CreatureConstants.Dragon_Red_VeryOld, "Very old red dragon")]
        [TestCase(CreatureConstants.Dragon_Red_Ancient, "Ancient red dragon")]
        [TestCase(CreatureConstants.Dragon_Red_Wyrm, "Wyrm red dragon")]
        [TestCase(CreatureConstants.Dragon_Red_GreatWyrm, "Great wyrm red dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling, "Wyrmling silver dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung, "Very young silver dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_Young, "Young silver dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile, "Juvenile silver dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult, "Young adult silver dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_Adult, "Adult silver dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_MatureAdult, "Mature adult silver dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_Old, "Old silver dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_VeryOld, "Very old silver dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_Ancient, "Ancient silver dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrm, "Wyrm silver dragon")]
        [TestCase(CreatureConstants.Dragon_Silver_GreatWyrm, "Great wyrm silver dragon")]
        [TestCase(CreatureConstants.Dragon_White_Wyrmling, "Wyrmling white dragon")]
        [TestCase(CreatureConstants.Dragon_White_VeryYoung, "Very young white dragon")]
        [TestCase(CreatureConstants.Dragon_White_Young, "Young white dragon")]
        [TestCase(CreatureConstants.Dragon_White_Juvenile, "Juvenile white dragon")]
        [TestCase(CreatureConstants.Dragon_White_YoungAdult, "Young adult white dragon")]
        [TestCase(CreatureConstants.Dragon_White_Adult, "Adult white dragon")]
        [TestCase(CreatureConstants.Dragon_White_MatureAdult, "Mature adult white dragon")]
        [TestCase(CreatureConstants.Dragon_White_Old, "Old white dragon")]
        [TestCase(CreatureConstants.Dragon_White_VeryOld, "Very old white dragon")]
        [TestCase(CreatureConstants.Dragon_White_Ancient, "Ancient white dragon")]
        [TestCase(CreatureConstants.Dragon_White_Wyrm, "Wyrm white dragon")]
        [TestCase(CreatureConstants.Dragon_White_GreatWyrm, "Great wyrm white dragon")]
        [TestCase(CreatureConstants.Dragonne, "Dragonne")]
        [TestCase(CreatureConstants.Dretch, "Dretch (demon)")]
        [TestCase(CreatureConstants.Drider, "Drider")]
        [TestCase(CreatureConstants.Dryad, "Dryad")]
        [TestCase(CreatureConstants.Dwarf, "Dwarf")]
        [TestCase(CreatureConstants.DwarfWarrior, "Dwarf warrior")]
        [TestCase(CreatureConstants.Eagle, "Eagle")]
        [TestCase(CreatureConstants.Eagle_Giant, "Giant eagle")]
        [TestCase(CreatureConstants.Efreet, "Efreet")]
        [TestCase(CreatureConstants.Elemental_Air_Elder, "Elder air elemental")]
        [TestCase(CreatureConstants.Elemental_Air_Greater, "Greater air elemental")]
        [TestCase(CreatureConstants.Elemental_Air_Huge, "Huge air elemental")]
        [TestCase(CreatureConstants.Elemental_Air_Small, "Small air elemental")]
        [TestCase(CreatureConstants.Elemental_Earth_Elder, "Elder earth elemental")]
        [TestCase(CreatureConstants.Elemental_Earth_Greater, "Greater earth elemental")]
        [TestCase(CreatureConstants.Elemental_Earth_Small, "Small earth elemental")]
        [TestCase(CreatureConstants.Elemental_Earth_Huge, "Huge earth elemental")]
        [TestCase(CreatureConstants.Elemental_Fire_Elder, "Elder fire elemental")]
        [TestCase(CreatureConstants.Elemental_Fire_Greater, "Greater fire elemental")]
        [TestCase(CreatureConstants.Elemental_Fire_Huge, "Huge fire elemental")]
        [TestCase(CreatureConstants.Elemental_Fire_Small, "Small fire elemental")]
        [TestCase(CreatureConstants.Elemental_Water_Elder, "Elder water elemental")]
        [TestCase(CreatureConstants.Elemental_Water_Greater, "Greater water elemental")]
        [TestCase(CreatureConstants.Elemental_Water_Huge, "Huge water elemental")]
        [TestCase(CreatureConstants.Elemental_Water_Small, "Small water elemental")]
        [TestCase(CreatureConstants.Elephant, "Elephant")]
        [TestCase(CreatureConstants.Elf, "Elf")]
        [TestCase(CreatureConstants.ElfWarrior, "Elf warrior")]
        [TestCase(CreatureConstants.Erinyes, "Erinyes (devil)")]
        [TestCase(CreatureConstants.EtherealMarauder, "Ethereal marauder")]
        [TestCase(CreatureConstants.Ettercap, "Ettercap")]
        [TestCase(CreatureConstants.Ettin, "Ettin")]
        [TestCase(CreatureConstants.Expert_Merchant, "Expert (Merchant)")]
        [TestCase(CreatureConstants.Expert_Minstrel, "Expert (Minstrel)")]
        [TestCase(CreatureConstants.FiendishCreature, "Fiendish creature")]
        [TestCase(CreatureConstants.FireBeetle_Giant, "Giant fire beetle")]
        [TestCase(CreatureConstants.FormianTaskmaster, "Formian taskmaster")]
        [TestCase(CreatureConstants.FormianWarrior, "Formian warrior")]
        [TestCase(CreatureConstants.FormianWorker, "Formian worker")]
        [TestCase(CreatureConstants.FrostWorm, "Frost worm")]
        [TestCase(CreatureConstants.Gargoyle, "Gargoyle")]
        [TestCase(CreatureConstants.Gelugon, "Gelugon (devil)")]
        [TestCase(CreatureConstants.Ghaele, "Ghaele (celestial)")]
        [TestCase(CreatureConstants.Ghast, "Ghast")]
        [TestCase(CreatureConstants.Ghost, "Ghost")]
        [TestCase(CreatureConstants.Ghoul, "Ghoul")]
        [TestCase(CreatureConstants.Giant_Cloud, "Cloud giant")]
        [TestCase(CreatureConstants.Giant_Fire, "Fire giant")]
        [TestCase(CreatureConstants.Giant_Frost, "Frost giant")]
        [TestCase(CreatureConstants.Giant_Hill, "Hill giant")]
        [TestCase(CreatureConstants.Giant_Stone, "Stone giant")]
        [TestCase(CreatureConstants.Giant_Storm, "Storm giant")]
        [TestCase(CreatureConstants.GibberingMouther, "Gibbering mouther")]
        [TestCase(CreatureConstants.Girallon, "Girallon")]
        [TestCase(CreatureConstants.Glabrezu, "Glabrezu (demon)")]
        [TestCase(CreatureConstants.Gnoll, "Gnoll")]
        [TestCase(CreatureConstants.Gnome, "Gnome")]
        [TestCase(CreatureConstants.Goblin, "Goblin")]
        [TestCase(CreatureConstants.Golem_Flesh, "Flesh golem")]
        [TestCase(CreatureConstants.Golem_Stone, "Stone golem")]
        [TestCase(CreatureConstants.Golem_Stone_Greater, "Greater stone golem")]
        [TestCase(CreatureConstants.Gorgon, "Gorgon")]
        [TestCase(CreatureConstants.GrayRender, "Gray render")]
        [TestCase(CreatureConstants.GreenHag, "Green hag (hag)")]
        [TestCase(CreatureConstants.Grick, "Grick")]
        [TestCase(CreatureConstants.Griffon, "Griffon")]
        [TestCase(CreatureConstants.Grig, "Grig")]
        [TestCase(CreatureConstants.Grimlock, "Grimlock")]
        [TestCase(CreatureConstants.Gynosphinx, "Gynosphinx")]
        [TestCase(CreatureConstants.Halfling, "Halfling")]
        [TestCase(CreatureConstants.Hamatula, "Hamatula (devil)")]
        [TestCase(CreatureConstants.Harpy, "Harpy")]
        [TestCase(CreatureConstants.Hawk, "Hawk")]
        [TestCase(CreatureConstants.Hellcat, "Hellcat")]
        [TestCase(CreatureConstants.HellHound, "Hell hound")]
        [TestCase(CreatureConstants.Hezrou, "Hezrou (demon)")]
        [TestCase(CreatureConstants.Hieracosphinx, "Hieracosphinx")]
        [TestCase(CreatureConstants.Hippogriff, "Hippogriff")]
        [TestCase(CreatureConstants.Hobgoblin, "Hobgoblin")]
        [TestCase(CreatureConstants.Homunculus, "Homunculus")]
        [TestCase(CreatureConstants.Horse_Heavy, "Heavy horse")]
        [TestCase(CreatureConstants.Horse_Heavy_War, "Heavy warhorse")]
        [TestCase(CreatureConstants.Horse_Light, "Light horse")]
        [TestCase(CreatureConstants.Horse_Light_War, "Light warhorse")]
        [TestCase(CreatureConstants.HoundArchon, "Hound archon")]
        [TestCase(CreatureConstants.Howler, "Howler")]
        [TestCase(CreatureConstants.Human, "Human")]
        [TestCase(CreatureConstants.Hydra, "Hydra")]
        [TestCase(CreatureConstants.Hydra_5Heads, "Hydra (5 heads)")]
        [TestCase(CreatureConstants.Hydra_6Heads, "Hydra (6 heads)")]
        [TestCase(CreatureConstants.Hydra_7Heads, "Hydra (7 heads)")]
        [TestCase(CreatureConstants.Hydra_8Heads, "Hydra (8 heads)")]
        [TestCase(CreatureConstants.Hydra_9Heads, "Hydra (9 heads)")]
        [TestCase(CreatureConstants.Hydra_10Heads, "Hydra (10 heads)")]
        [TestCase(CreatureConstants.Hydra_11Heads, "Hydra (11 heads)")]
        [TestCase(CreatureConstants.Hydra_12Heads, "Hydra (12 heads)")]
        [TestCase(CreatureConstants.Hyena, "Hyena")]
        [TestCase(CreatureConstants.Imp, "Imp (devil)")]
        [TestCase(CreatureConstants.Janni, "Janni")]
        [TestCase(CreatureConstants.Kobold, "Kobold")]
        [TestCase(CreatureConstants.Krenshar, "Krenshar")]
        [TestCase(CreatureConstants.Kyton, "Kyton (devil)")]
        [TestCase(CreatureConstants.Lamia, "Lamia")]
        [TestCase(CreatureConstants.Lammasu, "Lammasu")]
        [TestCase(CreatureConstants.LanternArchon, "Lantern archon (celestial)")]
        [TestCase(CreatureConstants.Lemure, "Lemure (devil)")]
        [TestCase(CreatureConstants.Leopard, "Leopard")]
        [TestCase(CreatureConstants.Lich, "Lich")]
        [TestCase(CreatureConstants.Lillend, "Lillend")]
        [TestCase(CreatureConstants.Lion, "Lion")]
        [TestCase(CreatureConstants.Lion_Dire, "Dire lion")]
        [TestCase(CreatureConstants.Livestock, "Livestock")]
        [TestCase(CreatureConstants.Lizard, "Lizard")]
        [TestCase(CreatureConstants.Lizard_Monitor, "Monitor lizard")]
        [TestCase(CreatureConstants.Lizardfolk, "Lizardfolk")]
        [TestCase(CreatureConstants.Magmin, "Magmin")]
        [TestCase(CreatureConstants.Manticore, "Manticore")]
        [TestCase(CreatureConstants.Marilith, "Marilith (demon)")]
        [TestCase(CreatureConstants.Medusa, "Medusa")]
        [TestCase(CreatureConstants.Megaraptor, "Megaraptor")]
        [TestCase(CreatureConstants.Mephit, "Mephit")]
        [TestCase(CreatureConstants.Mephit_Air, "Air mephit")]
        [TestCase(CreatureConstants.Mephit_Dust, "Dust mephit")]
        [TestCase(CreatureConstants.Mephit_Earth, "Earth mephit")]
        [TestCase(CreatureConstants.Mephit_Fire, "Fire mephit")]
        [TestCase(CreatureConstants.Mephit_Ice, "Ice mephit")]
        [TestCase(CreatureConstants.Mephit_Magma, "Magma mephit")]
        [TestCase(CreatureConstants.Mephit_Ooze, "Ooze mephit")]
        [TestCase(CreatureConstants.Mephit_Salt, "Salt mephit")]
        [TestCase(CreatureConstants.Mephit_Steam, "Steam mephit")]
        [TestCase(CreatureConstants.Mephit_Water, "Water mephit")]
        [TestCase(CreatureConstants.Mimic, "Mimic")]
        [TestCase(CreatureConstants.MindFlayer, "Mind flayer")]
        [TestCase(CreatureConstants.Minotaur, "Minotaur")]
        [TestCase(CreatureConstants.Mohrg, "Mohrg")]
        [TestCase(CreatureConstants.Monkey, "Monkey")]
        [TestCase(CreatureConstants.Mule, "Mule")]
        [TestCase(CreatureConstants.Mummy, "Mummy")]
        [TestCase(CreatureConstants.Naga_Dark, "Dark naga")]
        [TestCase(CreatureConstants.Naga_Guardian, "Guardian naga")]
        [TestCase(CreatureConstants.Naga_Spirit, "Spirit naga")]
        [TestCase(CreatureConstants.Nalfeshnee, "Nalfeshnee (demon)")]
        [TestCase(CreatureConstants.NessianWarhound, "Nessian warhound")]
        [TestCase(CreatureConstants.Nightcrawler, "Nightcrawler (nightshade)")]
        [TestCase(CreatureConstants.NightHag, "Night hag")]
        [TestCase(CreatureConstants.Nightmare, "Nightmare")]
        [TestCase(CreatureConstants.Nightwalker, "Nightwalker (nightshade)")]
        [TestCase(CreatureConstants.Nightwing, "Nightwing (nightshade)")]
        [TestCase(CreatureConstants.NPC, "NPC")]
        [TestCase(CreatureConstants.NPC_Traveler, "NPC (Traveler)")]
        [TestCase(CreatureConstants.Nymph, "Nymph")]
        [TestCase(CreatureConstants.Ogre, "Ogre")]
        [TestCase(CreatureConstants.OgreMage, "Ogre mage")]
        [TestCase(CreatureConstants.Ooze_Gray, "Gray ooze")]
        [TestCase(CreatureConstants.Ooze_OchreJelly, "Ochre jelly")]
        [TestCase(CreatureConstants.Orc, "Orc")]
        [TestCase(CreatureConstants.Osyluth, "Osyluth (devil)")]
        [TestCase(CreatureConstants.Otyugh, "Otyugh")]
        [TestCase(CreatureConstants.Owl, "Owl")]
        [TestCase(CreatureConstants.Owl_Giant, "Giant owl")]
        [TestCase(CreatureConstants.Owlbear, "Owlbear")]
        [TestCase(CreatureConstants.Pegasus, "Pegasus")]
        [TestCase(CreatureConstants.PhantomFungus, "Phantom fungus")]
        [TestCase(CreatureConstants.PhaseSpider, "Phase spider")]
        [TestCase(CreatureConstants.Phasm, "Phasm")]
        [TestCase(CreatureConstants.PitFiend, "Pit fiend (devil)")]
        [TestCase(CreatureConstants.Pixie, "Pixie")]
        [TestCase(CreatureConstants.Planetar, "Planetar (celestial)")]
        [TestCase(CreatureConstants.Pony, "Pony")]
        [TestCase(CreatureConstants.Pony_War, "Warpony")]
        [TestCase(CreatureConstants.PrayingMantis_Giant, "Giant praying mantis")]
        [TestCase(CreatureConstants.Pseudodragon, "Pseudodragon")]
        [TestCase(CreatureConstants.PurpleWorm, "Purple worm")]
        [TestCase(CreatureConstants.Pyrohydra, "Pyrohydra")]
        [TestCase(CreatureConstants.Pyrohydra_5Heads, "Pyrohydra (5 heads)")]
        [TestCase(CreatureConstants.Pyrohydra_6Heads, "Pyrohydra (6 heads)")]
        [TestCase(CreatureConstants.Pyrohydra_7Heads, "Pyrohydra (7 heads)")]
        [TestCase(CreatureConstants.Pyrohydra_8Heads, "Pyrohydra (8 heads)")]
        [TestCase(CreatureConstants.Pyrohydra_9Heads, "Pyrohydra (9 heads)")]
        [TestCase(CreatureConstants.Pyrohydra_10Heads, "Pyrohydra (10 heads)")]
        [TestCase(CreatureConstants.Pyrohydra_11Heads, "Pyrohydra (11 heads)")]
        [TestCase(CreatureConstants.Pyrohydra_12Heads, "Pyrohydra (12 heads)")]
        [TestCase(CreatureConstants.Quasit, "Quasit (demon)")]
        [TestCase(CreatureConstants.Rat, "Rat")]
        [TestCase(CreatureConstants.Rat_Dire, "Dire rat")]
        [TestCase(CreatureConstants.Raven, "Raven")]
        [TestCase(CreatureConstants.RazorBoar, "Razor boar")]
        [TestCase(CreatureConstants.Remorhaz, "Remorhaz")]
        [TestCase(CreatureConstants.Rhinoceras, "Rhinoceras")]
        [TestCase(CreatureConstants.Roc, "Roc")]
        [TestCase(CreatureConstants.Roper, "Roper")]
        [TestCase(CreatureConstants.RustMonster, "Rust monster")]
        [TestCase(CreatureConstants.Salamander_Average, "Average salamander")]
        [TestCase(CreatureConstants.Salamander_Flamebrother, "Flamebrother salamander")]
        [TestCase(CreatureConstants.Salamander_Noble, "Noble salamander")]
        [TestCase(CreatureConstants.Satyr, "Satyr")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny, "Tiny monstrous scorpion")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal, "Colossal monstrous scorpion")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan, "Gargantuan monstrous scorpion")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge, "Huge monstrous scorpion")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large, "Large monstrous scorpion")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium, "Medium monstrous scorpion")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small, "Small monstrous scorpion")]
        [TestCase(CreatureConstants.Scorpionfolk, "Scorpionfolk")]
        [TestCase(CreatureConstants.SeaHag, "Sea hag (hag)")]
        [TestCase(CreatureConstants.Shadow, "Shadow")]
        [TestCase(CreatureConstants.ShadowMastiff, "Shadow mastiff")]
        [TestCase(CreatureConstants.ShamblingMound, "Shambling mound")]
        [TestCase(CreatureConstants.ShockerLizard, "Shocker lizard")]
        [TestCase(CreatureConstants.Shrieker, "Shrieker")]
        [TestCase(CreatureConstants.Skeleton, "Skeleton")]
        [TestCase(CreatureConstants.Skeleton_Giant, "Giant skeleton")]
        [TestCase(CreatureConstants.Skeleton_HumanWarrior, "Human warrior skeleton")]
        [TestCase(CreatureConstants.Slaad_Blue, "Blue slaad")]
        [TestCase(CreatureConstants.Slaad_Death, "Death slaad")]
        [TestCase(CreatureConstants.Slaad_Gray, "Gray slaad")]
        [TestCase(CreatureConstants.Slaad_Green, "Green slaad")]
        [TestCase(CreatureConstants.Slaad_Red, "Red slaad")]
        [TestCase(CreatureConstants.Snake_Constrictor, "Constrictor snake")]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant, "Giant constrictor snake")]
        [TestCase(CreatureConstants.Snake_Viper_Huge, "Huge viper snake")]
        [TestCase(CreatureConstants.Snake_Viper_Large, "Large viper snake")]
        [TestCase(CreatureConstants.Snake_Viper_Small, "Small viper snake")]
        [TestCase(CreatureConstants.Snake_Viper_Medium, "Medium viper snake")]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, "Tiny viper snake")]
        [TestCase(CreatureConstants.Solar, "Solar (celestial)")]
        [TestCase(CreatureConstants.Spectre, "Spectre")]
        [TestCase(CreatureConstants.Spider_Monstrous_Colossal, "Colossal monstrous spider")]
        [TestCase(CreatureConstants.Spider_Monstrous_Gargantuan, "Gargantuan monstrous spider")]
        [TestCase(CreatureConstants.Spider_Monstrous_Huge, "Huge monstrous spider")]
        [TestCase(CreatureConstants.Spider_Monstrous_Large, "Large monstrous spider")]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium, "Medium monstrous spider")]
        [TestCase(CreatureConstants.Spider_Monstrous_Small, "Small monstrous spider")]
        [TestCase(CreatureConstants.Spider_Monstrous_Tiny, "Tiny monstrous spider")]
        [TestCase(CreatureConstants.SpiderEater, "Spider eater")]
        [TestCase(CreatureConstants.StagBeetle_Giant, "Giant stag beetle")]
        [TestCase(CreatureConstants.Stirge, "Stirge")]
        [TestCase(CreatureConstants.Succubus, "Succubus (demon)")]
        [TestCase(CreatureConstants.Tarrasque, "Tarrasque")]
        [TestCase(CreatureConstants.Tendriculos, "Tendriculos")]
        [TestCase(CreatureConstants.Thoqqua, "Thoqqua")]
        [TestCase(CreatureConstants.Tiger, "Tiger")]
        [TestCase(CreatureConstants.Tiger_Dire, "Dire tiger")]
        [TestCase(CreatureConstants.Toad, "Toad")]
        [TestCase(CreatureConstants.Treant, "Treant")]
        [TestCase(CreatureConstants.Triceratops, "Triceratops")]
        [TestCase(CreatureConstants.Troglodyte, "Troglodyte")]
        [TestCase(CreatureConstants.Troll, "Troll")]
        [TestCase(CreatureConstants.TrumpetArchon, "Trumpet archon")]
        [TestCase(CreatureConstants.Tyrannosaurus, "Tyrannosaurus")]
        [TestCase(CreatureConstants.Unicorn, "Unicorn")]
        [TestCase(CreatureConstants.Vampire, "Vampire")]
        [TestCase(CreatureConstants.VampireSpawn, "Vampire spawn")]
        [TestCase(CreatureConstants.Vargouille, "Vargouille")]
        [TestCase(CreatureConstants.VioletFungus, "Violet fungus")]
        [TestCase(CreatureConstants.Vrock, "Vrock (demon)")]
        [TestCase(CreatureConstants.Warrior_Bandit, "Warrior (Bandit)")]
        [TestCase(CreatureConstants.Warrior_BanditLeader, "Warrior (Bandit Leader)")]
        [TestCase(CreatureConstants.Warrior_Captain, "Warrior (Captain)")]
        [TestCase(CreatureConstants.Warrior_Guard, "Warrior (Guard)")]
        [TestCase(CreatureConstants.Warrior_Hunter, "Warrior (Hunter)")]
        [TestCase(CreatureConstants.Warrior_Patrol, "Warrior (Patrol)")]
        [TestCase(CreatureConstants.Wasp_Giant, "Giant wasp")]
        [TestCase(CreatureConstants.Weasel, "Weasel")]
        [TestCase(CreatureConstants.Weasel_Dire, "Dire weasel")]
        [TestCase(CreatureConstants.Werebear, "Werebear")]
        [TestCase(CreatureConstants.Wereboar, "Wereboar")]
        [TestCase(CreatureConstants.Wererat, "Wererat")]
        [TestCase(CreatureConstants.Weretiger, "Weretiger")]
        [TestCase(CreatureConstants.Werewolf, "Werewolf")]
        [TestCase(CreatureConstants.Wight, "Wight")]
        [TestCase(CreatureConstants.WillOWisp, "Will-O'-Wisp")]
        [TestCase(CreatureConstants.WinterWolf, "Winter wolf")]
        [TestCase(CreatureConstants.Wolf, "Wolf")]
        [TestCase(CreatureConstants.Wolf_Dire, "Dire wolf")]
        [TestCase(CreatureConstants.Wolverine, "Wolverine")]
        [TestCase(CreatureConstants.Wolverine_Dire, "Dire wolverine")]
        [TestCase(CreatureConstants.Worg, "Worg")]
        [TestCase(CreatureConstants.Wraith, "Wraith")]
        [TestCase(CreatureConstants.Wraith_Dread, "Dread wraith")]
        [TestCase(CreatureConstants.Wyvern, "Wyvern")]
        [TestCase(CreatureConstants.Xill, "Xill")]
        [TestCase(CreatureConstants.Xorn_Average, "Average xorn")]
        [TestCase(CreatureConstants.Xorn_Elder, "Elder xorn")]
        [TestCase(CreatureConstants.Xorn_Minor, "Minor xorn")]
        [TestCase(CreatureConstants.YethHound, "Yeth hound")]
        [TestCase(CreatureConstants.Yrthak, "Yrthak")]
        [TestCase(CreatureConstants.Zombie, "Zombie")]
        [TestCase(CreatureConstants.Zombie_HumanCommoner, "Human commoner zombie")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
