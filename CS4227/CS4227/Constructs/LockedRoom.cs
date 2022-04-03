using System;
using System.Collections.Generic;
using System.Text;

namespace CS4227.Constructs
{
    class LockedRoom: Room
    {
        bool isLocked = true;
        string keyName;
        public LockedRoom(int row, int col, string name, string mapName, string keyName) : base(row, col, name, mapName)
        {
            this.keyName = keyName;
        }
        public bool getLsLocked()
        {
            return isLocked;
        }

        public string getKey()
        {
            return keyName;
        }

        public void Unlock()
        {
            isLocked = false;
        }
        public void Lock()
        {
            isLocked = true;
        }
    }
}
