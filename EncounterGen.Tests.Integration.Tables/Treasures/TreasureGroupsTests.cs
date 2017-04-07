using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace EncounterGen.Tests.Integration.Tables.Treasures
{
    [TestFixture]
    public class TreasureGroupsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.TreasureGroups;
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var allCreatures = GetAllCreaturesFromEncounters();
            var useSubtypeForTreasure = CollectionSelector.Explode(TableNameConstants.CreatureGroups, GroupConstants.UseSubtypeForTreasure);
            allCreatures = allCreatures.Except(useSubtypeForTreasure);

            AssertEntriesAreComplete(allCreatures);
        }

        [TestCase(CreatureConstants.Aboleth)]
        [TestCase(CreatureConstants.Aboleth_Mage)]
        [TestCase(CreatureConstants.Achaierai)]
        [TestCase(CreatureConstants.Allip)]
        [TestCase(CreatureConstants.Androsphinx)]
        [TestCase(CreatureConstants.AnimatedObject_Colossal)]
        [TestCase(CreatureConstants.AnimatedObject_Gargantuan)]
        [TestCase(CreatureConstants.AnimatedObject_Huge)]
        [TestCase(CreatureConstants.AnimatedObject_Large)]
        [TestCase(CreatureConstants.AnimatedObject_Medium)]
        [TestCase(CreatureConstants.AnimatedObject_Small)]
        [TestCase(CreatureConstants.AnimatedObject_Tiny)]
        [TestCase(CreatureConstants.Ankheg)]
        [TestCase(CreatureConstants.Annis)]
        [TestCase(CreatureConstants.SeaHag)]
        [TestCase(CreatureConstants.Ant_Giant_Soldier)]
        [TestCase(CreatureConstants.Ant_Giant_Worker)]
        [TestCase(CreatureConstants.Ant_Giant_Queen)]
        [TestCase(CreatureConstants.Ape)]
        [TestCase(CreatureConstants.Ape_Dire)]
        [TestCase(CreatureConstants.Aranea)]
        [TestCase(CreatureConstants.Arrowhawk_Adult)]
        [TestCase(CreatureConstants.Arrowhawk_Elder)]
        [TestCase(CreatureConstants.Arrowhawk_Juvenile)]
        [TestCase(CreatureConstants.AssassinVine)]
        [TestCase(CreatureConstants.Avoral)]
        [TestCase(CreatureConstants.Babau)]
        [TestCase(CreatureConstants.Baboon)]
        [TestCase(CreatureConstants.Badger)]
        [TestCase(CreatureConstants.Badger_Dire)]
        [TestCase(CreatureConstants.Badger_Celestial)]
        [TestCase(CreatureConstants.Barghest)]
        [TestCase(CreatureConstants.Barghest_Greater)]
        [TestCase(CreatureConstants.Basilisk)]
        [TestCase(CreatureConstants.Basilisk_AbyssalGreater)]
        [TestCase(CreatureConstants.Bat)]
        [TestCase(CreatureConstants.Bat_Dire)]
        [TestCase(CreatureConstants.Bat_Swarm)]
        [TestCase(CreatureConstants.Bear_Black)]
        [TestCase(CreatureConstants.Bear_Brown)]
        [TestCase(CreatureConstants.Bear_Dire)]
        [TestCase(CreatureConstants.Bear_Polar)]
        [TestCase(CreatureConstants.Bebilith)]
        [TestCase(CreatureConstants.Bee_Giant)]
        [TestCase(CreatureConstants.Behir)]
        [TestCase(CreatureConstants.Beholder)]
        [TestCase(CreatureConstants.Belker)]
        [TestCase(CreatureConstants.Bison)]
        [TestCase(CreatureConstants.BlackPudding)]
        [TestCase(CreatureConstants.BlackPudding_Elder)]
        [TestCase(CreatureConstants.BlinkDog)]
        [TestCase(CreatureConstants.Boar)]
        [TestCase(CreatureConstants.Boar_Dire)]
        [TestCase(CreatureConstants.Bodak)]
        [TestCase(CreatureConstants.BombardierBeetle_Giant)]
        [TestCase(CreatureConstants.Bulette)]
        [TestCase(CreatureConstants.Camel)]
        [TestCase(CreatureConstants.CarrionCrawler)]
        [TestCase(CreatureConstants.Cat)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Colossal)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Huge)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Small)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Tiny)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Colossal)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Gargantuan)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Huge)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Large)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Medium)]
        [TestCase(CreatureConstants.Centipede_Swarm)]
        [TestCase(CreatureConstants.ChaosBeast)]
        [TestCase(CreatureConstants.Cheetah)]
        [TestCase(CreatureConstants.Chimera)]
        [TestCase(CreatureConstants.Choker)]
        [TestCase(CreatureConstants.Chuul)]
        [TestCase(CreatureConstants.Cloaker)]
        [TestCase(CreatureConstants.Cockatrice)]
        [TestCase(CreatureConstants.Couatl)]
        [TestCase(CreatureConstants.Criosphinx)]
        [TestCase(CreatureConstants.Crocodile)]
        [TestCase(CreatureConstants.Crocodile_Giant)]
        [TestCase(CreatureConstants.Cryohydra_10Heads)]
        [TestCase(CreatureConstants.Cryohydra_11Heads)]
        [TestCase(CreatureConstants.Cryohydra_12Heads)]
        [TestCase(CreatureConstants.Cryohydra_5Heads)]
        [TestCase(CreatureConstants.Cryohydra_6Heads)]
        [TestCase(CreatureConstants.Cryohydra_7Heads)]
        [TestCase(CreatureConstants.Cryohydra_8Heads)]
        [TestCase(CreatureConstants.Cryohydra_9Heads)]
        [TestCase(CreatureConstants.Darkmantle)]
        [TestCase(CreatureConstants.Deinonychus)]
        [TestCase(CreatureConstants.Delver)]
        [TestCase(CreatureConstants.Destrachan)]
        [TestCase(CreatureConstants.Devourer)]
        [TestCase(CreatureConstants.Digester)]
        [TestCase(CreatureConstants.DisplacerBeast)]
        [TestCase(CreatureConstants.DisplacerBeast_PackLord)]
        [TestCase(CreatureConstants.Djinni)]
        [TestCase(CreatureConstants.Djinni_Noble)]
        [TestCase(CreatureConstants.Dog)]
        [TestCase(CreatureConstants.Dog_Celestial)]
        [TestCase(CreatureConstants.Dog_Riding)]
        [TestCase(CreatureConstants.Donkey)]
        [TestCase(CreatureConstants.Doppelganger)]
        [TestCase(CreatureConstants.Dragon_Black_Adult)]
        [TestCase(CreatureConstants.Dragon_Black_Ancient)]
        [TestCase(CreatureConstants.Dragon_Black_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Black_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Black_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Black_Old)]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Black_Young)]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Blue_Adult)]
        [TestCase(CreatureConstants.Dragon_Blue_Ancient)]
        [TestCase(CreatureConstants.Dragon_Blue_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Blue_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Blue_Old)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Blue_Young)]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Green_Adult)]
        [TestCase(CreatureConstants.Dragon_Green_Ancient)]
        [TestCase(CreatureConstants.Dragon_Green_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Green_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Green_Old)]
        [TestCase(CreatureConstants.Dragon_Green_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Green_Young)]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Red_Adult)]
        [TestCase(CreatureConstants.Dragon_Red_Ancient)]
        [TestCase(CreatureConstants.Dragon_Red_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Red_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Red_Old)]
        [TestCase(CreatureConstants.Dragon_Red_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Red_Young)]
        [TestCase(CreatureConstants.Dragon_Red_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_White_Adult)]
        [TestCase(CreatureConstants.Dragon_White_Ancient)]
        [TestCase(CreatureConstants.Dragon_White_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_White_Juvenile)]
        [TestCase(CreatureConstants.Dragon_White_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_White_Old)]
        [TestCase(CreatureConstants.Dragon_White_VeryOld)]
        [TestCase(CreatureConstants.Dragon_White_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_White_Wyrm)]
        [TestCase(CreatureConstants.Dragon_White_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_White_Young)]
        [TestCase(CreatureConstants.Dragon_White_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Bronze_Adult)]
        [TestCase(CreatureConstants.Dragon_Bronze_Ancient)]
        [TestCase(CreatureConstants.Dragon_Bronze_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Bronze_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Bronze_Old)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Bronze_Young)]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Copper_Adult)]
        [TestCase(CreatureConstants.Dragon_Copper_Ancient)]
        [TestCase(CreatureConstants.Dragon_Copper_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Copper_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Copper_Old)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Copper_Young)]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Silver_Adult)]
        [TestCase(CreatureConstants.Dragon_Silver_Ancient)]
        [TestCase(CreatureConstants.Dragon_Silver_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Silver_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Silver_Old)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Silver_Young)]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Gold_Adult)]
        [TestCase(CreatureConstants.Dragon_Gold_Ancient)]
        [TestCase(CreatureConstants.Dragon_Gold_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Gold_Old)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Gold_Young)]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Brass_Adult)]
        [TestCase(CreatureConstants.Dragon_Brass_Ancient)]
        [TestCase(CreatureConstants.Dragon_Brass_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Brass_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Brass_Old)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Brass_Young)]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult)]
        [TestCase(CreatureConstants.DragonTurtle)]
        [TestCase(CreatureConstants.Dragonne)]
        [TestCase(CreatureConstants.Dretch)]
        [TestCase(CreatureConstants.Eagle)]
        [TestCase(CreatureConstants.Eagle_Giant)]
        [TestCase(CreatureConstants.Efreeti)]
        [TestCase(CreatureConstants.Elasmosaurus)]
        [TestCase(CreatureConstants.Elephant)]
        [TestCase(CreatureConstants.Elemental_Air_Elder)]
        [TestCase(CreatureConstants.Elemental_Air_Greater)]
        [TestCase(CreatureConstants.Elemental_Air_Huge)]
        [TestCase(CreatureConstants.Elemental_Air_Large)]
        [TestCase(CreatureConstants.Elemental_Air_Medium)]
        [TestCase(CreatureConstants.Elemental_Air_Small)]
        [TestCase(CreatureConstants.Elemental_Earth_Elder)]
        [TestCase(CreatureConstants.Elemental_Earth_Greater)]
        [TestCase(CreatureConstants.Elemental_Earth_Huge)]
        [TestCase(CreatureConstants.Elemental_Earth_Large)]
        [TestCase(CreatureConstants.Elemental_Earth_Medium)]
        [TestCase(CreatureConstants.Elemental_Earth_Small)]
        [TestCase(CreatureConstants.Elemental_Fire_Elder)]
        [TestCase(CreatureConstants.Elemental_Fire_Greater)]
        [TestCase(CreatureConstants.Elemental_Fire_Huge)]
        [TestCase(CreatureConstants.Elemental_Fire_Large)]
        [TestCase(CreatureConstants.Elemental_Fire_Medium)]
        [TestCase(CreatureConstants.Elemental_Fire_Small)]
        [TestCase(CreatureConstants.Elemental_Water_Elder)]
        [TestCase(CreatureConstants.Elemental_Water_Greater)]
        [TestCase(CreatureConstants.Elemental_Water_Huge)]
        [TestCase(CreatureConstants.Elemental_Water_Large)]
        [TestCase(CreatureConstants.Elemental_Water_Medium)]
        [TestCase(CreatureConstants.Elemental_Water_Small)]
        [TestCase(CreatureConstants.EtherealFilcher)]
        [TestCase(CreatureConstants.EtherealMarauder)]
        [TestCase(CreatureConstants.Ettercap)]
        [TestCase(CreatureConstants.FireBeetle_Giant)]
        [TestCase(CreatureConstants.FireBeetle_Giant_Celestial)]
        [TestCase(CreatureConstants.FormianQueen)]
        [TestCase(CreatureConstants.FormianTaskmaster)]
        [TestCase(CreatureConstants.FormianWarrior)]
        [TestCase(CreatureConstants.FormianWorker)]
        [TestCase(CreatureConstants.FrostWorm)]
        [TestCase(CreatureConstants.Gargoyle)]
        [TestCase(CreatureConstants.Gargoyle_Kapoacinth)]
        [TestCase(CreatureConstants.GelatinousCube)]//Stone and metal only
        [TestCase(CreatureConstants.Ghoul)]
        [TestCase(CreatureConstants.Ghoul_Lacedon)]
        [TestCase(CreatureConstants.Ghoul_Ghast)]
        [TestCase(CreatureConstants.GibberingMouther)]
        [TestCase(CreatureConstants.Girallon)]
        [TestCase(CreatureConstants.Glabrezu)]
        [TestCase(CreatureConstants.Golem_Clay)]
        [TestCase(CreatureConstants.Golem_Flesh)]
        [TestCase(CreatureConstants.Golem_Iron)]
        [TestCase(CreatureConstants.Golem_Stone)]
        [TestCase(CreatureConstants.Golem_Stone_Greater)]
        [TestCase(CreatureConstants.Gorgon)]
        [TestCase(CreatureConstants.GrayRender)]
        [TestCase(CreatureConstants.GreenHag)]
        [TestCase(CreatureConstants.Grick)]
        [TestCase(CreatureConstants.Griffon)]
        [TestCase(CreatureConstants.Gynosphinx)]
        [TestCase(CreatureConstants.BarbedDevil_Hamatula)]
        [TestCase(CreatureConstants.Hawk)]
        [TestCase(CreatureConstants.Hellcat_Bezekira)]
        [TestCase(CreatureConstants.HellHound)]
        [TestCase(CreatureConstants.Hellwasp_Swarm)]
        [TestCase(CreatureConstants.Hezrou)]
        [TestCase(CreatureConstants.Hieracosphinx)]
        [TestCase(CreatureConstants.Hippogriff)]
        [TestCase(CreatureConstants.Homunculus)]
        [TestCase(CreatureConstants.Horse_Heavy)]
        [TestCase(CreatureConstants.Horse_Heavy_War)]
        [TestCase(CreatureConstants.Horse_Light)]
        [TestCase(CreatureConstants.Horse_Light_War)]
        [TestCase(CreatureConstants.Howler)]
        [TestCase(CreatureConstants.Hydra_10Heads)]
        [TestCase(CreatureConstants.Hydra_11Heads)]
        [TestCase(CreatureConstants.Hydra_12Heads)]
        [TestCase(CreatureConstants.Hydra_5Heads)]
        [TestCase(CreatureConstants.Hydra_6Heads)]
        [TestCase(CreatureConstants.Hydra_7Heads)]
        [TestCase(CreatureConstants.Hydra_8Heads)]
        [TestCase(CreatureConstants.Hydra_9Heads)]
        [TestCase(CreatureConstants.Hyena)]
        [TestCase(CreatureConstants.Imp)]
        [TestCase(CreatureConstants.InvisibleStalker)]
        [TestCase(CreatureConstants.Kraken)]
        [TestCase(CreatureConstants.Krenshar)]
        [TestCase(CreatureConstants.Lammasu)]
        [TestCase(CreatureConstants.Lammasu_GoldenProtector)]
        [TestCase(CreatureConstants.LanternArchon)]
        [TestCase(CreatureConstants.Lemure)]
        [TestCase(CreatureConstants.Leonal)]
        [TestCase(CreatureConstants.Leopard)]
        [TestCase(CreatureConstants.Lion)]
        [TestCase(CreatureConstants.Lion_Dire)]
        [TestCase(CreatureConstants.Lizard)]
        [TestCase(CreatureConstants.Lizard_Monitor)]
        [TestCase(CreatureConstants.Locust_Swarm)]
        [TestCase(CreatureConstants.Magmin)] //Nonflammable
        [TestCase(CreatureConstants.MantaRay)]
        [TestCase(CreatureConstants.Manticore)]
        [TestCase(CreatureConstants.Marut)]
        [TestCase(CreatureConstants.Megaraptor)]
        [TestCase(CreatureConstants.Mephit_CR3)]
        [TestCase(CreatureConstants.Mephit_Air)]
        [TestCase(CreatureConstants.Mephit_Dust)]
        [TestCase(CreatureConstants.Mephit_Earth)]
        [TestCase(CreatureConstants.Mephit_Fire)]
        [TestCase(CreatureConstants.Mephit_Ice)]
        [TestCase(CreatureConstants.Mephit_Magma)]
        [TestCase(CreatureConstants.Mephit_Ooze)]
        [TestCase(CreatureConstants.Mephit_Salt)]
        [TestCase(CreatureConstants.Mephit_Steam)]
        [TestCase(CreatureConstants.Mephit_Water)]
        [TestCase(CreatureConstants.Mimic)]
        [TestCase(CreatureConstants.MindFlayer)]
        [TestCase(CreatureConstants.Mohrg)]
        [TestCase(CreatureConstants.Monkey)]
        [TestCase(CreatureConstants.Monkey_Celestial)]
        [TestCase(CreatureConstants.Mule)]
        [TestCase(CreatureConstants.Mummy)]
        [TestCase(CreatureConstants.Naga_Dark)]
        [TestCase(CreatureConstants.Naga_Guardian)]
        [TestCase(CreatureConstants.Naga_Spirit)]
        [TestCase(CreatureConstants.Naga_Water)]
        [TestCase(CreatureConstants.Nalfeshnee)]
        [TestCase(CreatureConstants.NightHag)]
        [TestCase(CreatureConstants.Nightcrawler)]
        [TestCase(CreatureConstants.Nightmare)]
        [TestCase(CreatureConstants.Nightmare_Cauchemar)]
        [TestCase(CreatureConstants.Nightwalker)]
        [TestCase(CreatureConstants.Nightwing)]
        [TestCase(CreatureConstants.Octopus)]
        [TestCase(CreatureConstants.Octopus_Giant)]
        [TestCase(CreatureConstants.Ooze_Gray)]
        [TestCase(CreatureConstants.Ooze_OchreJelly)]
        [TestCase(CreatureConstants.Otyugh)]
        [TestCase(CreatureConstants.BoneDevil_Osyluth)]
        [TestCase(CreatureConstants.Owl)]
        [TestCase(CreatureConstants.Owl_Giant)]
        [TestCase(CreatureConstants.Owl_Celestial)]
        [TestCase(CreatureConstants.Owlbear)]
        [TestCase(CreatureConstants.Pegasus)]
        [TestCase(CreatureConstants.PhantomFungus)]
        [TestCase(CreatureConstants.PhaseSpider)]
        [TestCase(CreatureConstants.Phasm)]
        [TestCase(CreatureConstants.PitFiend)]
        [TestCase(CreatureConstants.Pony)]
        [TestCase(CreatureConstants.Pony_War)]
        [TestCase(CreatureConstants.Porpoise)]
        [TestCase(CreatureConstants.Porpoise_Celestial)]
        [TestCase(CreatureConstants.PrayingMantis_Giant)]
        [TestCase(CreatureConstants.Pseudodragon)]
        [TestCase(CreatureConstants.PurpleWorm)]//Only stone goods
        [TestCase(CreatureConstants.Pyrohydra_10Heads)]
        [TestCase(CreatureConstants.Pyrohydra_11Heads)]
        [TestCase(CreatureConstants.Pyrohydra_12Heads)]
        [TestCase(CreatureConstants.Pyrohydra_5Heads)]
        [TestCase(CreatureConstants.Pyrohydra_6Heads)]
        [TestCase(CreatureConstants.Pyrohydra_7Heads)]
        [TestCase(CreatureConstants.Pyrohydra_8Heads)]
        [TestCase(CreatureConstants.Pyrohydra_9Heads)]
        [TestCase(CreatureConstants.Quasit)]
        [TestCase(CreatureConstants.Rakshasa)]
        [TestCase(CreatureConstants.Rast)]
        [TestCase(CreatureConstants.Rat)]
        [TestCase(CreatureConstants.Rat_Dire)]
        [TestCase(CreatureConstants.Rat_Dire_Fiendish)]
        [TestCase(CreatureConstants.Rat_Swarm)]
        [TestCase(CreatureConstants.Raven)]
        [TestCase(CreatureConstants.Raven_Fiendish)]
        [TestCase(CreatureConstants.Ravid)]
        [TestCase(CreatureConstants.RazorBoar)]
        [TestCase(CreatureConstants.Remorhaz)]
        [TestCase(CreatureConstants.Retriever)]
        [TestCase(CreatureConstants.Rhinoceras)]
        [TestCase(CreatureConstants.Roc)]
        [TestCase(CreatureConstants.Roper)]//only stone goods
        [TestCase(CreatureConstants.RustMonster)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny)]
        [TestCase(CreatureConstants.SeaCat)]
        [TestCase(CreatureConstants.Shadow)]
        [TestCase(CreatureConstants.Shadow_Greater)]
        [TestCase(CreatureConstants.ShadowMastiff)]
        [TestCase(CreatureConstants.ShamblingMound)]
        [TestCase(CreatureConstants.Shark_Dire)]
        [TestCase(CreatureConstants.Shark_Huge)]
        [TestCase(CreatureConstants.Shark_Large)]
        [TestCase(CreatureConstants.Shark_Medium)]
        [TestCase(CreatureConstants.ShieldGuardian)]
        [TestCase(CreatureConstants.ShockerLizard)]
        [TestCase(CreatureConstants.Shrieker)]
        [TestCase(CreatureConstants.Skeleton_Chimera)]
        [TestCase(CreatureConstants.Skeleton_Dragon_Red_YoungAdult)]
        [TestCase(CreatureConstants.Skeleton_Ettin)]
        [TestCase(CreatureConstants.Skeleton_Giant_Cloud)]
        [TestCase(CreatureConstants.Skeleton_Human)]
        [TestCase(CreatureConstants.Skeleton_Megaraptor)]
        [TestCase(CreatureConstants.Skeleton_Owlbear)]
        [TestCase(CreatureConstants.Skeleton_Troll)]
        [TestCase(CreatureConstants.Skeleton_Wolf)]
        [TestCase(CreatureConstants.Skum)]
        [TestCase(CreatureConstants.Slaad_Blue)]
        [TestCase(CreatureConstants.Slaad_Death)]
        [TestCase(CreatureConstants.Slaad_Gray)]
        [TestCase(CreatureConstants.Slaad_Green)]
        [TestCase(CreatureConstants.Slaad_Red)]
        [TestCase(CreatureConstants.Snake_Constrictor)]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant)]
        [TestCase(CreatureConstants.Snake_Viper_Huge)]
        [TestCase(CreatureConstants.Snake_Viper_Large)]
        [TestCase(CreatureConstants.Snake_Viper_Medium)]
        [TestCase(CreatureConstants.Snake_Viper_Small)]
        [TestCase(CreatureConstants.Snake_Viper_Tiny)]
        [TestCase(CreatureConstants.Spectre)]
        [TestCase(CreatureConstants.Spider_Monstrous_Colossal)]
        [TestCase(CreatureConstants.Spider_Monstrous_Gargantuan)]
        [TestCase(CreatureConstants.Spider_Monstrous_Huge)]
        [TestCase(CreatureConstants.Spider_Monstrous_Large)]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium)]
        [TestCase(CreatureConstants.Spider_Monstrous_Small)]
        [TestCase(CreatureConstants.Spider_Monstrous_Tiny)]
        [TestCase(CreatureConstants.Spider_Swarm)]
        [TestCase(CreatureConstants.SpiderEater)]
        [TestCase(CreatureConstants.Squid)]
        [TestCase(CreatureConstants.Squid_Giant)]
        [TestCase(CreatureConstants.StagBeetle_Giant)]
        [TestCase(CreatureConstants.Stirge)]
        [TestCase(CreatureConstants.Succubus)]
        [TestCase(CreatureConstants.Tarrasque)]
        [TestCase(CreatureConstants.Tendriculos)]
        [TestCase(CreatureConstants.Thoqqua)]
        [TestCase(CreatureConstants.Tiger)]
        [TestCase(CreatureConstants.Tiger_Dire)]
        [TestCase(CreatureConstants.Toad)]
        [TestCase(CreatureConstants.Tojanida_Adult)]
        [TestCase(CreatureConstants.Tojanida_Elder)]
        [TestCase(CreatureConstants.Tojanida_Juvenile)]
        [TestCase(CreatureConstants.Treant)]
        [TestCase(CreatureConstants.Triceratops)]
        [TestCase(CreatureConstants.Troll)]
        [TestCase(CreatureConstants.Troll_Scrag)]
        [TestCase(CreatureConstants.Tyrannosaurus)]
        [TestCase(CreatureConstants.UmberHulk)]
        [TestCase(CreatureConstants.UmberHulk_TrulyHorrid)]
        [TestCase(CreatureConstants.Unicorn)]
        [TestCase(CreatureConstants.Unicorn_CelestialCharger)]
        [TestCase(CreatureConstants.VampireSpawn)]
        [TestCase(CreatureConstants.Vargouille)]
        [TestCase(CreatureConstants.VioletFungus)]
        [TestCase(CreatureConstants.Vrock)]
        [TestCase(CreatureConstants.Wasp_Giant)]
        [TestCase(CreatureConstants.Weasel)]
        [TestCase(CreatureConstants.Weasel_Dire)]
        [TestCase(CreatureConstants.Whale_Baleen)]
        [TestCase(CreatureConstants.Whale_Cachalot)]
        [TestCase(CreatureConstants.Whale_Orca)]
        [TestCase(CreatureConstants.Wight)]
        [TestCase(CreatureConstants.WillOWisp)]
        [TestCase(CreatureConstants.WinterWolf)]
        [TestCase(CreatureConstants.Wolf)]
        [TestCase(CreatureConstants.Wolf_Dire)]
        [TestCase(CreatureConstants.Wolverine)]
        [TestCase(CreatureConstants.Wolverine_Dire)]
        [TestCase(CreatureConstants.Worg)]
        [TestCase(CreatureConstants.Wraith)]
        [TestCase(CreatureConstants.Wraith_Dread)]
        [TestCase(CreatureConstants.Wyvern)]
        [TestCase(CreatureConstants.Xill)]
        [TestCase(CreatureConstants.Xorn_Average)]
        [TestCase(CreatureConstants.Xorn_Elder)]
        [TestCase(CreatureConstants.Xorn_Minor)]
        [TestCase(CreatureConstants.YethHound)]
        [TestCase(CreatureConstants.Yrthak)]
        [TestCase(CreatureConstants.Zombie_Bugbear)]
        [TestCase(CreatureConstants.Zombie_GrayRender)]
        [TestCase(CreatureConstants.Zombie_Human)]
        [TestCase(CreatureConstants.Zombie_Kobold)]
        [TestCase(CreatureConstants.Zombie_Minotaur)]
        [TestCase(CreatureConstants.Zombie_Ogre)]
        [TestCase(CreatureConstants.Zombie_Troglodyte)]
        [TestCase(CreatureConstants.Zombie_Wyvern)]
        public void TreasureGroupIsEmpty(string entry)
        {
            base.DistinctCollection(entry);
        }

        [TestCase(CreatureConstants.AstralDeva, WeaponConstants.HeavyMace, ItemTypeConstants.Weapon, 3, SpecialAbilityConstants.Disruption)]
        [TestCase(CreatureConstants.BeardedDevil_Barbazu, WeaponConstants.Glaive, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)]
        [TestCase(CreatureConstants.ChainDevil_Kyton, WeaponConstants.SpikedChain, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)]
        [TestCase(CreatureConstants.FormianMyrmarch, WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Ghaele, WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 4, SpecialAbilityConstants.Holy)]
        [TestCase(CreatureConstants.Giant_Cloud, WeaponConstants.Morningstar, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Gargantuan)]
        [TestCase(CreatureConstants.Giant_Fire, WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Giant_Stone, WeaponConstants.Greatclub, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Giant_Stone_Elder, WeaponConstants.Greatclub, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Grimlock, WeaponConstants.Battleaxe, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)] //only gems, no art objects
        [TestCase(CreatureConstants.Harpy, WeaponConstants.Club, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)]
        [TestCase(CreatureConstants.HornedDevil_Cornugon, WeaponConstants.SpikedChain, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.HoundArchon, WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)]
        [TestCase(CreatureConstants.IceDevil_Gelugon, WeaponConstants.Longspear, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Kolyarut, WeaponConstants.Longsword, ItemTypeConstants.Weapon, 2, "")]
        [TestCase(CreatureConstants.Lamia, WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Lillend, WeaponConstants.ShortSword, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Minotaur, WeaponConstants.Greataxe, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.NessianWarhound, ArmorConstants.ChainShirt, ItemTypeConstants.Armor, 2, "", "Barding")]
        [TestCase(CreatureConstants.Nymph, WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)]
        [TestCase(CreatureConstants.Planetar, WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 3, "")]
        [TestCase(CreatureConstants.Salamander_Average, WeaponConstants.Shortspear, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)] //Non-flammable
        [TestCase(CreatureConstants.Salamander_Flamebrother, WeaponConstants.Shortspear, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Small)]//Non-flammable
        [TestCase(CreatureConstants.Salamander_Noble, WeaponConstants.Longspear, ItemTypeConstants.Weapon, 3, "")]//Non-flammable
        [TestCase(CreatureConstants.Scorpionfolk, WeaponConstants.Lance, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.TrumpetArchon, WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 4, "")]
        public void TreasureGroupOfOnePresetItem(string entry, string itemName, string itemType, int itemBonus, string abilityName, params string[] traits)
        {
            var setItem = FormatSetItem(itemName, itemType, itemBonus, abilityName, false, traits);
            base.DistinctCollection(entry, new[] { setItem });
        }

        private string FormatSetItem(string itemName, string itemType, int itemBonus = 0, string abilityName = "", bool isMagic = false, params string[] traits)
        {
            var setItem = $"{itemName}[{itemType}]";

            if (traits.Any())
                setItem += $"#{string.Join(",", traits)}#";

            if (itemBonus > 0)
                setItem += $"({itemBonus})";

            if (string.IsNullOrEmpty(abilityName) == false)
                setItem += $"{{{abilityName}}}";

            if (isMagic)
                setItem += $"@{isMagic}@";

            return setItem;
        }

        [Test]
        public void AthachItems()
        {
            var morningstar = FormatSetItem(WeaponConstants.Morningstar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Huge);

            base.Collection(CreatureConstants.Athach, new[] { morningstar, morningstar, morningstar });
        }

        [Test]
        public void AzerItems()
        {
            var warhammer = FormatSetItem(WeaponConstants.Warhammer, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var spear = FormatSetItem(WeaponConstants.Shortspear, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Azer, new[] { warhammer, spear });
        }

        [Test]
        public void BalorItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 1, SpecialAbilityConstants.Vorpal);
            var whip = FormatSetItem(WeaponConstants.Whip, ItemTypeConstants.Weapon, 1, SpecialAbilityConstants.Flaming);

            base.DistinctCollection(CreatureConstants.Balor, new[] { longsword, whip });
        }

        [Test]
        public void BralaniItems()
        {
            var scimitar = FormatSetItem(WeaponConstants.Scimitar, ItemTypeConstants.Weapon, 1, SpecialAbilityConstants.Holy);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 1, SpecialAbilityConstants.Holy, false, "+4 Strength bonus");
            base.DistinctCollection(CreatureConstants.Bralani, new[] { scimitar, longbow });
        }

        [Test]
        public void BugbearItems()
        {
            var morningstar = FormatSetItem(WeaponConstants.Morningstar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Bugbear, new[] { morningstar, javelin });
        }

        [Test]
        public void CentaurItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large, "+4 Strength bonus");

            base.DistinctCollection(CreatureConstants.Centaur, new[] { longsword, longbow });
        }

        [Test]
        public void DerroItems()
        {
            var shortSword = FormatSetItem(WeaponConstants.ShortSword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var crossbow = FormatSetItem(WeaponConstants.LightRepeatingCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            base.DistinctCollection(CreatureConstants.Derro, new[] { shortSword, crossbow });
        }

        [Test]
        public void DriderItems()
        {
            var dagger = FormatSetItem(WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var shortbow = FormatSetItem(WeaponConstants.Shortbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);

            base.Collection(CreatureConstants.Drider, new[] { dagger, dagger, shortbow });
        }

        [Test]
        public void DryadItems()
        {
            var dagger = FormatSetItem(WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium, TraitConstants.Masterwork);

            base.DistinctCollection(CreatureConstants.Dryad, new[] { dagger, longbow });
        }

        [Test]
        public void ErinyesItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 1, SpecialAbilityConstants.Flaming, false, "+5 Strength bonus");
            var rope = FormatSetItem("Rope, 50 ft.", ItemTypeConstants.Tool);

            base.DistinctCollection(CreatureConstants.Erinyes, new[] { longsword, longbow, rope });
        }

        [Test]
        public void EttinItems()
        {
            var morningstar = FormatSetItem(WeaponConstants.Morningstar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);

            base.DistinctCollection(CreatureConstants.Ettin, new[] { morningstar, javelin });
        }

        [Test]
        public void FrostGiantItems()
        {
            var greataxe = FormatSetItem(WeaponConstants.Greataxe, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var armor = FormatSetItem(ArmorConstants.ChainShirt, ItemTypeConstants.Armor, 0, string.Empty, false, TraitConstants.Sizes.Large);

            base.DistinctCollection(CreatureConstants.Giant_Frost, new[] { greataxe, armor });
        }

        [Test]
        public void HillGiantItems()
        {
            var greatclub = FormatSetItem(WeaponConstants.Greatclub, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var armor = FormatSetItem(ArmorConstants.HideArmor, ItemTypeConstants.Armor, 0, string.Empty, false, TraitConstants.Sizes.Large);

            base.DistinctCollection(CreatureConstants.Giant_Hill, new[] { greatclub, armor });
        }

        [Test]
        public void GnollItems()
        {
            var battleaxe = FormatSetItem(WeaponConstants.Battleaxe, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var shortbow = FormatSetItem(WeaponConstants.Shortbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Gnoll, new[] { battleaxe, shortbow });
        }

        [Test]
        public void GrigItems()
        {
            var shortSword = FormatSetItem(WeaponConstants.ShortSword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Tiny);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Tiny);

            base.DistinctCollection(CreatureConstants.Grig, new[] { shortSword, longbow });
        }

        [Test]
        public void JanniItems()
        {
            var scimitar = FormatSetItem(WeaponConstants.Scimitar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Janni, new[] { scimitar, longbow });
        }

        [Test]
        public void LizardfolkItems()
        {
            var club = FormatSetItem(WeaponConstants.Club, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Lizardfolk, new[] { club, javelin });
        }

        [Test]
        public void MarilithItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);

            base.Collection(CreatureConstants.Marilith, new[] { longsword, longsword, longsword, longsword, longsword, longsword });
        }

        [Test]
        public void MedusaItems()
        {
            var dagger = FormatSetItem(WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var shortbow = FormatSetItem(WeaponConstants.Shortbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Medusa, new[] { dagger, shortbow });
        }

        [Test]
        public void NixieItems()
        {
            var shortSword = FormatSetItem(WeaponConstants.ShortSword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var crossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);

            base.DistinctCollection(CreatureConstants.Nixie, new[] { shortSword, crossbow });
        }

        [Test]
        public void OgreItems()
        {
            var greatclub = FormatSetItem(WeaponConstants.Greatclub, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);

            base.DistinctCollection(CreatureConstants.Ogre, new[] { greatclub, javelin });
        }

        [Test]
        public void OgreMerrowItems()
        {
            var longspear = FormatSetItem(WeaponConstants.Longspear, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);

            base.DistinctCollection(CreatureConstants.Ogre_Merrow, new[] { longspear, javelin });
        }

        [Test]
        public void OgreMageItems()
        {
            var greatsword = FormatSetItem(WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);

            base.DistinctCollection(CreatureConstants.OgreMage, new[] { greatsword, longbow });
        }

        [Test]
        public void PixieItems()
        {
            var shortSword = FormatSetItem(WeaponConstants.ShortSword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);

            base.DistinctCollection(CreatureConstants.Pixie, new[] { shortSword, longbow });
        }

        [Test]
        public void PixieWithIrresistableDanceItems()
        {
            var shortSword = FormatSetItem(WeaponConstants.ShortSword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);

            base.DistinctCollection(CreatureConstants.Pixie_WithIrresistableDance, new[] { shortSword, longbow });
        }

        [Test]
        public void SahuaginItems()
        {
            var trident = FormatSetItem(WeaponConstants.Trident, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var crossbow = FormatSetItem(WeaponConstants.HeavyCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Sahuagin, new[] { trident, crossbow });
        }

        [Test]
        public void SatyrItems()
        {
            var dagger = FormatSetItem(WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var shortbow = FormatSetItem(WeaponConstants.Shortbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Satyr, new[] { dagger, shortbow });
        }

        [Test]
        public void SatyrWithPipesItems()
        {
            var dagger = FormatSetItem(WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var shortbow = FormatSetItem(WeaponConstants.Shortbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var pipes = FormatSetItem("Pipes", ItemTypeConstants.Tool);

            base.DistinctCollection(CreatureConstants.Satyr_WithPipes, new[] { dagger, shortbow, pipes });
        }

        [Test]
        public void SolarItems()
        {
            var greatsword = FormatSetItem(WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 5, SpecialAbilityConstants.Dancing);
            //HACK: The slaying arrow trait should really be a special ability, but TreasureGen does not support custom special abilities.
            //This is because it does not know how to compute the bonus equivalent of such an ability, which would factor into intelligence ego.
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 2, string.Empty, false, "+5 Strength bonus", "Creates slaying arrows keyed to any creature type or subtype");

            base.DistinctCollection(CreatureConstants.Solar, new[] { greatsword, longbow });
        }

        [Test]
        public void StormGiantItems()
        {
            var greatsword = FormatSetItem(WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Huge);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Huge, "+14 Strength bonus");

            base.DistinctCollection(CreatureConstants.Giant_Storm, new[] { greatsword, longbow });
        }

        [Test]
        public void TitanItems()
        {
            var warhammer = FormatSetItem(WeaponConstants.Warhammer, ItemTypeConstants.Weapon, 3, string.Empty, false, TraitConstants.Sizes.Gargantuan, TraitConstants.SpecialMaterials.Adamantine);
            var armor = FormatSetItem(ArmorConstants.HalfPlate, ItemTypeConstants.Armor, 4);

            base.DistinctCollection(CreatureConstants.Titan, new[] { warhammer, armor });
        }

        [Test]
        public void TritonItems()
        {
            var trident = FormatSetItem(WeaponConstants.Trident, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var crossbow = FormatSetItem(WeaponConstants.HeavyCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Triton, new[] { trident, crossbow });
        }

        [Test]
        public void TroglodyteItems()
        {
            var club = FormatSetItem(WeaponConstants.Club, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Troglodyte, new[] { club, javelin });
        }

        [Test]
        public void WerebearItems()
        {
            var greataxe = FormatSetItem(WeaponConstants.Greataxe, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var throwingAxe = FormatSetItem(WeaponConstants.ThrowingAxe, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Werebear, new[] { greataxe, throwingAxe });
        }

        [Test]
        public void WereboarItems()
        {
            var battleaxe = FormatSetItem(WeaponConstants.Battleaxe, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var armor = FormatSetItem(ArmorConstants.ScaleMail, ItemTypeConstants.Armor, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var shield = FormatSetItem(ArmorConstants.HeavyWoodenShield, ItemTypeConstants.Armor, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Wereboar, new[] { battleaxe, javelin, armor, shield });
        }

        [Test]
        public void HillGiantDireWereboarItems()
        {
            var greatclub = FormatSetItem(WeaponConstants.Greatclub, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var armor = FormatSetItem(ArmorConstants.HideArmor, ItemTypeConstants.Armor, 0, string.Empty, false, TraitConstants.Sizes.Large);
            base.DistinctCollection(CreatureConstants.Wereboar_HillGiantDire, new[] { greatclub, armor });
        }

        [Test]
        public void WereratItems()
        {
            var rapier = FormatSetItem(WeaponConstants.Rapier, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var lightCrossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Wererat, new[] { rapier, lightCrossbow });
        }

        [Test]
        public void WeretigerItems()
        {
            var glaive = FormatSetItem(WeaponConstants.Glaive, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium, "+1 Strength bonus");

            base.DistinctCollection(CreatureConstants.Weretiger, new[] { glaive, longbow });
        }

        [Test]
        public void WerewolfItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var lightCrossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.Werewolf, new[] { longsword, lightCrossbow });
        }

        [Test]
        public void YuanTiPurebloodItems()
        {
            var scimitar = FormatSetItem(WeaponConstants.Scimitar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);

            base.DistinctCollection(CreatureConstants.YuanTi_Pureblood, new[] { scimitar, longbow });
        }

        [Test]
        public void YuanTiHalfbloodItems()
        {
            var scimitar = FormatSetItem(WeaponConstants.Scimitar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium, "+2 Strength bonus");

            base.DistinctCollection(CreatureConstants.YuanTi_Halfblood, new[] { scimitar, longbow });
        }

        [Test]
        public void YuanTiAbominationItems()
        {
            var scimitar = FormatSetItem(WeaponConstants.Scimitar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large, "+4 Strength bonus");

            base.DistinctCollection(CreatureConstants.YuanTi_Abomination, new[] { scimitar, longbow });
        }

        [Test]
        public void ZelekhutItems()
        {
            var chain = FormatSetItem(WeaponConstants.SpikedChain, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);

            base.Collection(CreatureConstants.Zelekhut, new[] { chain, chain });
        }

        [Test]
        public void CharactersDoNotHaveSetItems()
        {
            var entries = GetEntries();
            var characters = entries.Where(e => e.Contains(CreatureConstants.Character));

            foreach (var character in characters)
            {
                DistinctCollection(character);
            }
        }

        [Test]
        public void NoncombatantsDoNotHaveSetItems()
        {
            var entries = GetEntries();
            var noncombatants = entries.Where(e => e.Contains(CreatureConstants.Noncombatant));

            foreach (var noncombatant in noncombatants)
            {
                DistinctCollection(noncombatant);
            }
        }
    }
}
