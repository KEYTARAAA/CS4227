﻿using CS4227.Characters.Enemies;
using CS4227.Characters.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Adapter
{
    class InfoAdapter : IInfo
    {
        private readonly string info;
        public InfoAdapter(Enemy enemy)
        {
            info = enemy.getPortrail()+"\nEnemy Info: " + enemy.getName() + ": Health: " + enemy.getHealth() + " Attack: " + enemy.getAttack();
        }

        public InfoAdapter(Item item)
        {
            info = "Item Info: " + item.getName();
        }

        public String getInfo()
        {
            return info;
        }
    }
}
