using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ChaosTriggerShatteredRealityMenus
{
    class cursedSkullAttackAnimation
    {
        public Texture2D CursedSkullRight1 { get; set; }
        public Texture2D CursedSkullRight2 { get; set; }
        public Texture2D CursedSkullFlameRight { get; set;}
        public Texture2D CursedSkullLeft1 { get; set; }
        public Texture2D CursedSkullLeft2 { get; set; }
        public Texture2D CursedSkullFlameLeft { get; set; }
        public Texture2D TextureCur { get; set; }


        public cursedSkullAttackAnimation(Texture2D cursedSkullRight1, Texture2D cursedSkullRight2, Texture2D cursedSkullFlameRight, Texture2D cursedSkullLeft1, Texture2D cursedSkullLeft2, Texture2D cursedSkullFlameLeft)
        {
            CursedSkullRight1 = cursedSkullRight1;
            CursedSkullRight2 = cursedSkullRight2;
            CursedSkullFlameRight = cursedSkullFlameRight;
            CursedSkullLeft1 = cursedSkullLeft1;
            CursedSkullLeft2 = cursedSkullLeft2;
            CursedSkullFlameLeft = cursedSkullFlameLeft;

            TextureCur = CursedSkullRight1;
        }

        public void ChangeCurrentTexture(int timer, int timer2, bool facingRight, bool facingLeft)
        {
            if (timer == 8)
            {
                if (facingRight == true && facingLeft == false)
                {
                    TextureCur = CursedSkullRight2;
                }
                else if (facingLeft == true && facingRight == false)
                {
                    TextureCur = CursedSkullLeft2;
                }

                if (timer2 == 4)
                {
                    if (facingRight == true && facingLeft == false)
                    {
                        TextureCur = CursedSkullFlameRight;
                    }
                    else if (facingLeft == true && facingRight == false)
                    {
                        ;
                    }
                }
            }
            else{
                if (facingRight == true && facingLeft == false)
                {
                    TextureCur = CursedSkullRight1;
                }
                else if (facingLeft == true && facingRight == false)
                {
                    TextureCur = CursedSkullLeft1;
                }
            }
        }
    }
}
