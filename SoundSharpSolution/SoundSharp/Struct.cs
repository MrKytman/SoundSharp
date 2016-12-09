using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundSharp;

namespace SoundSharp
{
    public struct MPlayer
    {
        public int Player_id;
        public int Player_stock;
        public string Player_make;
        public string Player_model;
        public float Player_MB;
        public float Player_price;

        public MPlayer(int p_Player_id, int p_Player_stock, string p_Player_make, string p_Player_model, float p_Player_MB, float p_Player_price)
        {
            this.Player_id = p_Player_id;
            this.Player_stock = p_Player_stock;
            this.Player_make = p_Player_make;
            this.Player_model = p_Player_model;
            this.Player_MB = p_Player_MB;
            this.Player_price = p_Player_price;
        }
    }
}