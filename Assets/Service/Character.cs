using System.Collections;

namespace Assets.Service
{
    public class Character
    {
        public string Raridade { get; set; }
        public string Nome { get; set; }
        public string Arquivo { get; set; }

        public static Character fromText(string line)
        {
            string[] values = line.Split(';');
            Character character = new Character
            {
                Raridade = values[0],
                Nome = values[1],
                Arquivo = values[2]
            };
            return character;
        }
    }
}