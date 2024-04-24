using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana_3___Actividad_Grupal_1
{
    class DialogueOption
    {
        public string Text { get; set; }
        public int RequiredStrength { get; set; }
        public int RequiredDexterity { get; set; }
        public int HealthChange { get; set; }

        public DialogueOption(string text, int requiredStrength, int requiredDexterity, int healthChange)
        {
            Text = text;
            RequiredStrength = requiredStrength;
            RequiredDexterity = requiredDexterity;
            HealthChange = healthChange;
        }
    }
}
