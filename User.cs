using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Security.Cryptography;



namespace WindowsFormsApp1
{
    public class usersList
    {
        const bool DefaultPassSecure = false;
        public struct user
        {
            public string name;
            public string password;
            public bool passComplexity;
            public bool blocking;
        }

        private Dictionary<string, user> Users = new Dictionary<string, user>();
        private user curUser = new user();

        public void AddUsersToDict()
        {

            //Users = new Dictionary<string, user>();
            string str;
            int space1, space2, space3;
            int spaceCount;
            bool admPass = false;
            int strCount = File.ReadAllLines("Info.txt").Length;

            FileStream file = new FileStream("Info.txt", FileMode.Open);
            StreamReader fnew = new StreamReader(file);
            for (int t = 0; t < strCount; t++)
            {
                spaceCount = 0;
                space1 = 0;
                space2 = 0;
                space3 = 0;
                str = fnew.ReadLine();

                for (int i = 0; i < str.Length - 1; i++)
                {
                    if (str[i] == ' ')
                    {
                        if ((str[i + 1] == ' ') && str.Substring(0, 5) == "admin")
                        {
                            admPass = true;
                            space1 = i;
                            spaceCount++;
                        }
                        else
                        {
                            switch (spaceCount)
                            {
                                case 0:
                                    {
                                        space1 = i;
                                        spaceCount++;
                                        break;
                                    }

                                case 1:
                                    {
                                        space2 = i;
                                        spaceCount++;
                                        break;
                                    }
                                case 2:
                                    {
                                        space3 = i;
                                        spaceCount++;
                                        break;
                                    }
                            }
                        }
                    }
                }

                curUser.name = str.Substring(0, space1);
                if (admPass)
                {
                    curUser.password = "";
                    admPass = false;
                }

                else
                    curUser.password = str.Substring(space1 + 1, space2 - space1 - 1);
                if (str.Substring(space2 + 1, 1) == "0")
                    curUser.passComplexity = false;
                else
                   curUser.passComplexity = true;
                if (str.Substring(space3 + 1, 1) == "0")
                    curUser.blocking = false;
                else
                    curUser.blocking = true;
                if (!(MainForm.users.isUsExist(curUser.name)))
                {
                    Users.Add(curUser.name, curUser);
                }

            }
            fnew.Close();
        }





        public List<string> getUsersList()
        {
            List<string> lst = new List<string>();
            foreach (string name in MainForm.users.Users.Keys)
            {
                lst.Add(name);
            }
            return lst;
        }

        public bool passCheck(string name, string pass)
        {
            if (name != "" && Users.ContainsKey(name) && Users[name].password == pass)
            {
                return true;
            }
            return false;
        }


        public bool isPassComplexity(string name)
        {
            if (name != "" && Users.ContainsKey(name))
            {
                return Users[name].passComplexity;
            }
            else return false;
        }

        public bool isUsBlocked(string name)
        {
            if (name != "" && Users.ContainsKey(name))
            {
                return Users[name].blocking;
            }
            else return false;
        }

        public bool isUsExist(string name)
        {
            return Users.ContainsKey(name);
        }

        public void changePass(string name, string pass)
        {
            if (name != "" && Users.ContainsKey(name))
            {
                curUser = Users[name];
                curUser.password = pass;
                Users[name] = curUser;
            }
        }

        public void passComplexityChange(string name, bool cmp)
        {
            if (name != "" && Users.ContainsKey(name))
            {
                curUser = Users[name];
                curUser.passComplexity = cmp;
                Users[name] = curUser;
            }
        }

        public void blockingChange(string Name, bool block)
        {
            if (Name != "" && Users.ContainsKey(Name))
            {
                curUser = Users[Name];
                curUser.blocking = block;
                Users[Name] = curUser;
            }
        }

        public void saveToFile()
        {
            int buf1, buf2;
            FileStream file2 = new FileStream("Info.txt", FileMode.Create);
            StreamWriter fnew2 = new StreamWriter(file2);
            foreach (KeyValuePair<string, user> keyValue in Users)
            {
                if (keyValue.Value.passComplexity) buf1 = 1;
                else buf1 = 0;
                if (keyValue.Value.blocking) buf2 = 1;
                else buf2 = 0; fnew2.WriteLine(keyValue.Key + ' ' + keyValue.Value.password + ' ' + buf1 + ' ' + buf2);
            }

            fnew2.Close();
        }
        public bool passComplexityCheck(string pass)
        {
            bool arifmCheck = false;
            bool letCheck = false;
            bool upLetCheck = false;
            bool digCheck = false;
            //char[] signs = { '.',',','-',':',';','!','?','(',')','”' };
            char[] arifm = { '+', '-', '*', '/', '%' };
            char[] dig = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

            for (int i = 0; i < pass.Length; i++)
            {
                if ((pass[i] >= 'A') && (pass[i] <= 'Z')) upLetCheck = true;
                if ((pass[i] >= 'a') && (pass[i] <= 'z')) letCheck = true;
                if (arifm.Contains(pass[i])) arifmCheck = true;
                if (dig.Contains(pass[i])) digCheck = true;
            }

            return letCheck && upLetCheck && arifmCheck && digCheck;
        }

        public string getHash(string name, string pass)
        {
            string key = "", newpass = "";
            int sum = 0;
            foreach (char c in pass)
            {
                sum += (int)c;

            }
            sum = sum % 256;
            Random rnd = new Random(sum);
            for (int ctr = 0; ctr <= 4; ctr++)
                key = key + "" + rnd.Next();
            for (int i = 0; i < pass.Length; i++)
            {
                /*char a = pass[i];
                int b = (int)(pass[i]);
                int c = key[i];
                int d = (int)(pass[i]) + key[i];
                int e = d % 256;
                char f = (char)e;*/
                newpass += (char) (((int)(pass[i]) + (int)key[i % 256]) % 256);
            }

            return newpass;
        }
        public string getMD5Hash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
    }
}