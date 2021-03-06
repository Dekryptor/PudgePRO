﻿using Ensage.Common.Menu;

namespace PudgePRO
{
    internal class Options : Variables
    {
        public static void MenuInit()
        {
            heroName = "npc_dota_hero_pudge";
            Menu = new Menu(AssemblyName, AssemblyName, true, heroName, true);
            comboType = new MenuItem("comboType", "Combo Type").SetValue(new StringList(new[] { "Aggr", "Deff", "Norm" }, 2)).SetTooltip("Aggr: Initiate with Blink/Dismember/etc. Deff: Hook first from a distance (no blink). Norm: Original.");
            comboKey = new MenuItem("comboKey", "Combo Key").SetValue(new KeyBind(70, KeyBindType.Press)).SetTooltip("Full combo in logical order.");
            comboToggleKey = new MenuItem("comboToggleKey", "Combo Toggle Key").SetValue(new KeyBind(72, KeyBindType.Toggle)).SetTooltip("Full combo in logical order. (Always combo while key toggled on.)");
            allyHookKey = new MenuItem("allyHookKey", "Ally Hook Key").SetValue(new KeyBind(75, KeyBindType.Press)).SetTooltip("Save closest to mouse ally with hook (no targeting particles dislplayed).");
            useBlink = new MenuItem("useBlink", "Use Blink Dagger").SetValue(true).SetTooltip("Will auto blink (with logic) while combo key is held down.");
            killSteal = new MenuItem("killSteal", "Kill Steal").SetValue(false).SetTooltip("Will kill steal with 'nuke' abilities. (Only hook currently supported)");
            soulRing = new MenuItem("soulRing", "Soulring").SetValue(true).SetTooltip("Will use soul ring before combo.");
            hookPredict = new MenuItem("hookPredict", "Auto Hook Prediction").SetValue(true).SetTooltip("Will auto predict target location for EZ hooks.");
            hookPredictRad = new MenuItem("hookPredictRad", "Display Prediction Circle").SetValue(false).SetTooltip("Draws a circle showing where you should hook (will not show if hook is blocked/out of range).");
            badHook = new MenuItem("badHook", "Bad Hook Check").SetValue(true).SetTooltip("Will auto cancel a POSSIBLE bad hook. TESTING: Use sliders below to set the timings to your liking.");
            newHookCheck = new MenuItem("newHookCheck", "Fast Hook Check").SetValue(true).SetTooltip("TESTING NEW CANCEL HOOK METHOD (Should be faster, but sometimes less accurate).");            
            comboSleep = new MenuItem("comboSleep", "Combo Sleep Timer").SetValue(new Slider(100, 0, 1000)).SetTooltip("TESTING: Sleep time before trying another hook. DEFAULT: 100");
            stopWait = new MenuItem("stopWait", "Rotate Chance Timer").SetValue(new Slider(100, 0, 1000)).SetTooltip("TESTING: How long to wait before checking if target rotated (after hook casted). DEFAULT: 100");
            rotationTolerance = new MenuItem("rotationTolerance", "Rotation Tolerancy").SetValue(new Slider(2, 0, 10)).SetTooltip("TESTING: How much can the target rotate before it's a POSSIBLE bad hook. DEFAULT: 2");
            safeForce = new MenuItem("forcePredict", "Safe Force Staff").SetValue(true).SetTooltip("Will only forcestaff if you're facing the target.");
            itemRange = new MenuItem("itemRange", "Def. Item Use Range").SetValue(new Slider(1000, 1, 2000)).SetTooltip("The range at whitch to use defensive items (ex. glimmer, pipe, etc.");
            //toggleHookTime = new MenuItem("toggleHookTime", "Bad Hook STOP").SetValue(new Slider(100, 200, 280)).SetTooltip("TESTING: Prevent fail hooks.");
            //badHook = new MenuItem("badHook", "Fail Hook Ticks").SetValue(new Slider(70, 1, 75)).SetTooltip("TESTING: Will STOP action within selected ticks to prevent POSSIBLE bad hooks.");
            //fountainBottle = new MenuItem("fountainBottle", "Bottle at Fountain").SetValue(true).SetTooltip("Will auto use bottle while at fountain.");            
            //bladeMail = new MenuItem("bladeMail", "Check for BladeMail").SetValue(false).SetTooltip("Will not combo if target used blademail.");
            drawTarget = new MenuItem("drawTarget", "Target indicator").SetValue(true).SetTooltip("Shows red circle around your target.");
            moveMode = new MenuItem("moveMode", "Orbwalk").SetValue(false).SetTooltip("Will orbwalk to mouse while combo key is held down.");
            blockedHookMove = new MenuItem("blockedHookMove", "Blocked Hook Move").SetValue(true).SetTooltip("Move to mouse position if something is blocking the hook path.");
            ClosestToMouseRange = new MenuItem("ClosestToMouseRange", "Closest to mouse range").SetValue(new Slider(1500, 1, 2000)).SetTooltip("Will look for enemy in selected range around your mouse pointer.");
            //SafeBlinkRange = new MenuItem("SafeBlinkRange", "Safe Blink Range").SetValue(new Slider(400, 0, 1000)).SetTooltip("Will NOT blink closer to enemy than selected range.");



            items = new Menu("Items", "Items");
            abilities = new Menu("Abilities", "Abilities");
            targetOptions = new Menu("Target Options", "Target Options");
            hookPredictions = new Menu("Hook Predictions", "Hook Predictions");

            Menu.AddItem(comboType);
            Menu.AddItem(comboKey);
            Menu.AddItem(comboToggleKey);
            Menu.AddItem(allyHookKey);

            Menu.AddSubMenu(items);
            Menu.AddSubMenu(abilities);
            Menu.AddSubMenu(targetOptions);
            abilities.AddSubMenu(hookPredictions);

            items.AddItem(new MenuItem("itemsDmg", "Damage Items").SetValue(new AbilityToggler(itemsDictionaryDamage)));
            items.AddItem(new MenuItem("itemsCon", "Control Items").SetValue(new AbilityToggler(itemsDictionaryControl)));
            items.AddItem(new MenuItem("itemsHD", "Healing/Def Items").SetValue(new AbilityToggler(itemsDictionaryHealingDef)));
            items.AddItem(useBlink);
            items.AddItem(safeForce);
            //items.AddItem(SafeBlinkRange);
            items.AddItem(soulRing);
            items.AddItem(itemRange);
            //items.AddItem(fountainBottle);
            //items.AddItem(bladeMail);            
            hookPredictions.AddItem(hookPredict);
            hookPredictions.AddItem(hookPredictRad);
            hookPredictions.AddItem(newHookCheck);
            hookPredictions.AddItem(badHook);
            hookPredictions.AddItem(comboSleep);
            hookPredictions.AddItem(stopWait);
            hookPredictions.AddItem(rotationTolerance);
            abilities.AddItem(new MenuItem("abilities", "Abilities").SetValue(new AbilityToggler(abilitiesDictionary)));
            abilities.AddItem(killSteal);
            targetOptions.AddItem(moveMode);
            targetOptions.AddItem(blockedHookMove);
            targetOptions.AddItem(ClosestToMouseRange);
            targetOptions.AddItem(drawTarget);
            //targetOptions.AddItem(badHook);
            //targetOptions.AddItem(toggleHookTime);

            Menu.AddToMainMenu();
        }

    }
}