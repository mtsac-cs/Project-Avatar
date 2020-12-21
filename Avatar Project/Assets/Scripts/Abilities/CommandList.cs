using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Abilities
{
    public static class CommandList
    {
        private static Dictionary<string, ICommand> commandDict;
        public static ICommand GetInstance(string key)
        {
            return commandDict[key];
        }


        static void CommandListInitializerScript()
        {
            // commandDict = new Dictionary<string, ICommand>() {

            // { "SwordSpin", new CommandRef<SwordSpin>() },

            // { "BellyRub", new CommandRef<BellyRub>() },

            // { "StickyShield", new CommandRef<StickyShield>() },

            // // Add more commands here
        }
    }
    internal class CommandRef<T> where T : ICommand, new()
    {
        public ICommand GetNew()
        {
            return new T();
        }
    }

}

