using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureCrypt
{
    internal class Crypt
    {
        //private Crypt _password;
        private string spacer = "#";

        public string encrypt(string target)
        {
            int index = 0;

            string encryptedItem = ""; //Build upon

            string singleLetter; //Selects each letter out of the string

            while(index < target.Length)
            {
                singleLetter = (target[index]).ToString();
                
                switch (singleLetter){
                    //============================================= ALPHABET KEYS =============================================//
                    case "A":
                        encryptedItem += "QAhyTT";
                    break;

                    case "a":
                        encryptedItem += "aOEnTs";
                    break;

                    case "B":
                        encryptedItem += "pifEyO";
                    break;

                    case "b":
                        encryptedItem += "GvRxqU";
                    break;

                    case "C":
                        encryptedItem += "adVWzd";
                    break;

                    case "c":
                        encryptedItem += "xNsNAq";
                    break;

                    case "D":
                        encryptedItem += "TVgYss";
                    break;

                    case "d":
                        encryptedItem += "LNiTFW";
                    break;

                    case "E":
                        encryptedItem += "xowjOf";
                    break;

                    case "e":
                        encryptedItem += "MGfgUW";
                    break;

                    case "F":
                        encryptedItem += "etwzyA";
                    break;

                    case "f":
                        encryptedItem += "rGmYOv";
                    break;

                    case "G":
                        encryptedItem += "sYfQIg";
                    break;

                    case "g":
                        encryptedItem += "ZMQMyb";
                    break;

                    case "H":
                        encryptedItem += "Tibaar";
                    break;

                    case "h":
                        encryptedItem += "cofjCT";
                    break;

                    case "I":
                        encryptedItem += "yNSUjZ";
                    break;

                    case "i":
                        encryptedItem += "ruJbqJ";
                    break;

                    case "J":
                        encryptedItem += "ZTluoD";
                    break;

                    case "j":
                        encryptedItem += "iDtKtc";
                    break;

                    case "K":
                        encryptedItem += "IRIOKk";
                    break;

                    case "k":
                        encryptedItem += "eeOvLV";
                    break;

                    case "L":
                        encryptedItem += "WWoYMI";
                    break;

                    case "l":
                        encryptedItem += "rclHUk";
                    break;

                    case "M":
                        encryptedItem += "vDvRKi";
                    break;

                    case "m":
                        encryptedItem += "cLdshX";
                    break;

                    case "N":
                        encryptedItem += "VMgmDf";
                    break;

                    case "n":
                        encryptedItem += "ZMYDdH";
                    break;

                    case "O":
                        encryptedItem += "dtDpsr";
                    break;

                    case "o":
                        encryptedItem += "NlkpMx";
                    break;

                    case "P":
                        encryptedItem += "OXTIwZ";
                    break;

                    case "p":
                        encryptedItem += "TlcwsU";
                    break;

                    case "Q":
                        encryptedItem += "ibJNqN";
                    break;

                    case "q":
                        encryptedItem += "rVNXgi";
                    break;

                    case "R":
                        encryptedItem += "nblzBN";
                    break;

                    case "r":
                        encryptedItem += "xlsHeL";
                    break;

                    case "S":
                        encryptedItem += "zeOujr";
                    break;

                    case "s":
                        encryptedItem += "OkVoWw";
                    break;

                    case "T":
                        encryptedItem += "hClECG";
                    break;

                    case "t":
                        encryptedItem += "qNYBqr";
                    break;

                    case "U":
                        encryptedItem += "tuxxZi";
                    break;

                    case "u":
                        encryptedItem += "bqsrbi";
                    break;

                    case "V":
                        encryptedItem += "qPbEbU";
                    break;

                    case "v":
                        encryptedItem += "awLYwg";
                    break;

                    case "W":
                        encryptedItem += "mLEuzY";
                    break;

                    case "w":
                        encryptedItem += "LKcqfy";
                    break;

                    case "X":
                        encryptedItem += "bkryiK";
                    break;

                    case "x":
                        encryptedItem += "Qgpdma";
                    break;

                    case "Y":
                        encryptedItem += "ORRAkN";
                    break;

                    case "y":
                        encryptedItem += "xnyxdX";
                    break;

                    case "Z":
                        encryptedItem += "msdmds";
                    break;

                    case "z":
                        encryptedItem += "yxEnLm";
                    break;
                    //=========================================================================================================//

                    //============================================= SPECIAL KEYS =============================================//

                    case " ":
                        encryptedItem += "wGURTP";
                    break;

                    case "!":
                        encryptedItem += "reYKUy";
                    break;

                    case "\"":
                        encryptedItem += "uIjefp";
                    break;

                    case "#":
                        encryptedItem += "pwglbm";
                    break;

                    case "$":
                        encryptedItem += "tTebuM";
                    break;

                    case "%":
                        encryptedItem += "hjtJSq";
                    break;

                    case "&":
                        encryptedItem += "dneGQx";
                    break;

                    case "'":
                        encryptedItem += "xBHoLY";
                    break;

                    case "(":
                        encryptedItem += "vNVbRf";
                    break;

                    case ")":
                        encryptedItem += "bdEKZY";
                    break;

                    case "*":
                        encryptedItem += "BVwVdZ";
                    break;

                    case "+":
                        encryptedItem += "rqzRiZ";
                    break;

                    case ",":
                        encryptedItem += "wpsghE";
                    break;

                    case "-":
                        encryptedItem += "LGJdIf";
                    break;

                    case ".":
                        encryptedItem += "uhNTqV";
                    break;

                    case "/":
                        encryptedItem += "pRJksO";
                    break;

                    case ":":
                        encryptedItem += "MhTUEb";
                    break;

                    case ";":
                        encryptedItem += "qwLDcc";
                    break;

                    case "<":
                        encryptedItem += "YsOKhX";
                    break;

                    case "=":
                        encryptedItem += "beDmDp";
                    break;

                    case ">":
                        encryptedItem += "ErYQYQ";
                    break;

                    case "?":
                        encryptedItem += "SYcAGu";
                    break;

                    case "@":
                        encryptedItem += "PwAnTo";
                    break;

                    case "[":
                        encryptedItem += "zYmnWe";
                    break;

                    case "\\":
                        encryptedItem += "ZrdGlb";
                    break;

                    case "]":
                        encryptedItem += "wdvYWn";
                    break;

                    case "^":
                        encryptedItem += "SbThUU";
                    break;

                    case "_":
                        encryptedItem += "wdGQjs";
                    break;

                    case "`":
                        encryptedItem += "dbMYPX";
                    break;

                    case "{":
                        encryptedItem += "pNWbHZ";
                    break;

                    case "|":
                        encryptedItem += "IWIzdz";
                    break;

                    case "}":
                        encryptedItem += "RlcifF";
                    break;

                    case "~":
                        encryptedItem += "xpdwuR";
                    break;

                    //=========================================================================================================//

                    //============================================= NUMERICAL =============================================//

                    case "0":
                        encryptedItem += "xhhbhi";
                    break;

                    case "1":
                        encryptedItem += "ItxHiu";
                    break;

                    case "2":
                        encryptedItem += "fCWTvl";
                    break;

                    case "3":
                        encryptedItem += "xEyEaQ";
                    break;

                    case "4":
                        encryptedItem += "UTPBUQ";
                    break;

                    case "5":
                        encryptedItem += "WkEeFn";
                    break;

                    case "6":
                        encryptedItem += "WGBhXk";
                    break;

                    case "7":
                        encryptedItem += "KbZopA";
                    break;

                    case "8":
                        encryptedItem += "pcWMRr";
                    break;

                    case "9":
                        encryptedItem += "XxNubD";
                    break;

                    //=========================================================================================================//

                    //============================================= UNKOWN CHARACTER =============================================//

                    default:
                        encryptedItem += "-_-";
                    break;

                    //=========================================================================================================//
                }

                encryptedItem += spacer;

                index++;
            }

            return encryptedItem;
        }




        public string decrypt(string target)
        {
            string[] items = target.Split(this.spacer);

            string decryptedItem = ""; //Build upon

            for (int i = 0; i < items.Length - 1; i++)
            {
                switch (items[i])
                {
                    //============================================= ALPHABET KEYS =============================================//
                    case "QAhyTT":
                        decryptedItem += "A";
                        break;

                    case "aOEnTs":
                        decryptedItem += "a";
                        break;

                    case "pifEyO":
                        decryptedItem += "B";
                        break;

                    case "GvRxqU":
                        decryptedItem += "b";
                        break;

                    case "adVWzd":
                        decryptedItem += "C";
                        break;

                    case "xNsNAq":
                        decryptedItem += "c";
                        break;

                    case "TVgYss":
                        decryptedItem += "D";
                        break;

                    case "LNiTFW":
                        decryptedItem += "d";
                        break;

                    case "xowjOf":
                        decryptedItem += "E";
                        break;

                    case "MGfgUW":
                        decryptedItem += "e";
                        break;

                    case "etwzyA":
                        decryptedItem += "F";
                        break;

                    case "rGmYOv":
                        decryptedItem += "f";
                        break;

                    case "sYfQIg":
                        decryptedItem += "G";
                        break;

                    case "ZMQMyb":
                        decryptedItem += "g";
                        break;

                    case "Tibaar":
                        decryptedItem += "H";
                        break;

                    case "cofjCT":
                        decryptedItem += "h";
                        break;

                    case "yNSUjZ":
                        decryptedItem += "I";
                        break;

                    case "ruJbqJ":
                        decryptedItem += "i";
                        break;

                    case "ZTluoD":
                        decryptedItem += "J";
                        break;

                    case "iDtKtc":
                        decryptedItem += "j";
                        break;

                    case "IRIOKk":
                        decryptedItem += "K";
                        break;

                    case "eeOvLV":
                        decryptedItem += "k";
                        break;

                    case "WWoYMI":
                        decryptedItem += "L";
                        break;

                    case "rclHUk":
                        decryptedItem += "l";
                        break;

                    case "vDvRKi":
                        decryptedItem += "M";
                        break;

                    case "cLdshX":
                        decryptedItem += "m";
                        break;

                    case "VMgmDf":
                        decryptedItem += "N";
                        break;

                    case "ZMYDdH":
                        decryptedItem += "n";
                        break;

                    case "dtDpsr":
                        decryptedItem += "O";
                        break;

                    case "NlkpMx":
                        decryptedItem += "o";
                        break;

                    case "OXTIwZ":
                        decryptedItem += "P";
                        break;

                    case "TlcwsU":
                        decryptedItem += "p";
                        break;

                    case "ibJNqN":
                        decryptedItem += "Q";
                        break;

                    case "rVNXgi":
                        decryptedItem += "q";
                        break;

                    case "nblzBN":
                        decryptedItem += "R";
                        break;

                    case "xlsHeL":
                        decryptedItem += "r";
                        break;

                    case "zeOujr":
                        decryptedItem += "S";
                        break;

                    case "OkVoWw":
                        decryptedItem += "s";
                        break;

                    case "hClECG":
                        decryptedItem += "T";
                        break;

                    case "qNYBqr":
                        decryptedItem += "t";
                        break;

                    case "tuxxZi":
                        decryptedItem += "U";
                        break;

                    case "bqsrbi":
                        decryptedItem += "u";
                        break;

                    case "qPbEbU":
                        decryptedItem += "V";
                        break;

                    case "awLYwg":
                        decryptedItem += "v";
                        break;

                    case "mLEuzY":
                        decryptedItem += "W";
                        break;

                    case "LKcqfy":
                        decryptedItem += "w";
                        break;

                    case "bkryiK":
                        decryptedItem += "X";
                        break;

                    case "Qgpdma":
                        decryptedItem += "x";
                        break;

                    case "ORRAkN":
                        decryptedItem += "Y";
                        break;

                    case "xnyxdX":
                        decryptedItem += "y";
                        break;

                    case "msdmds":
                        decryptedItem += "Z";
                        break;

                    case "yxEnLm":
                        decryptedItem += "z";
                        break;
                    //=========================================================================================================//

                    //============================================= SPECIAL KEYS =============================================//

                    case "wGURTP":
                        decryptedItem += " ";
                        break;

                    case "reYKUy":
                        decryptedItem += "!";
                        break;

                    case "uIjefp":
                        decryptedItem += "\"";
                        break;

                    case "pwglbm":
                        decryptedItem += "#";
                        break;

                    case "tTebuM":
                        decryptedItem += "$";
                        break;

                    case "hjtJSq":
                        decryptedItem += "%";
                        break;

                    case "dneGQx":
                        decryptedItem += "&";
                        break;

                    case "xBHoLY":
                        decryptedItem += "'";
                        break;

                    case "vNVbRf":
                        decryptedItem += "(";
                        break;

                    case "bdEKZY":
                        decryptedItem += ")";
                        break;

                    case "BVwVdZ":
                        decryptedItem += "*";
                        break;

                    case "rqzRiZ":
                        decryptedItem += "+";
                        break;

                    case "wpsghE":
                        decryptedItem += ",";
                        break;

                    case "LGJdIf":
                        decryptedItem += "-";
                        break;

                    case "uhNTqV":
                        decryptedItem += ".";
                        break;

                    case "pRJksO":
                        decryptedItem += "/";
                        break;

                    case "MhTUEb":
                        decryptedItem += ":";
                        break;

                    case "qwLDcc":
                        decryptedItem += ";";
                        break;

                    case "YsOKhX":
                        decryptedItem += "<";
                        break;

                    case "beDmDp":
                        decryptedItem += "=";
                        break;

                    case "ErYQYQ":
                        decryptedItem += ">";
                        break;

                    case "SYcAGu":
                        decryptedItem += "?";
                        break;

                    case "PwAnTo":
                        decryptedItem += "@";
                        break;

                    case "zYmnWe":
                        decryptedItem += "[";
                        break;

                    case "ZrdGlb":
                        decryptedItem += "\\";
                        break;

                    case "wdvYWn":
                        decryptedItem += "]";
                        break;

                    case "SbThUU":
                        decryptedItem += "^";
                        break;

                    case "wdGQjs":
                        decryptedItem += "_";
                        break;

                    case "dbMYPX":
                        decryptedItem += "`";
                        break;

                    case "pNWbHZ":
                        decryptedItem += "{";
                        break;

                    case "IWIzdz":
                        decryptedItem += "|";
                        break;

                    case "RlcifF":
                        decryptedItem += "}";
                        break;

                    case "xpdwuR":
                        decryptedItem += "~";
                        break;

                    //=========================================================================================================//

                    //============================================= NUMERICAL =============================================//

                    case "xhhbhi":
                        decryptedItem += "0";
                        break;

                    case "ItxHiu":
                        decryptedItem += "1";
                        break;

                    case "fCWTvl":
                        decryptedItem += "2";
                        break;

                    case "xEyEaQ":
                        decryptedItem += "3";
                        break;

                    case "UTPBUQ":
                        decryptedItem += "4";
                        break;

                    case "WkEeFn":
                        decryptedItem += "5";
                        break;

                    case "WGBhXk":
                        decryptedItem += "6";
                        break;

                    case "KbZopA":
                        decryptedItem += "7";
                        break;

                    case "pcWMRr":
                        decryptedItem += "8";
                        break;

                    case "XxNubD":
                        decryptedItem += "9";
                        break;

                    //=========================================================================================================//

                    //============================================= UNKOWN CHARACTER =============================================//

                    default:
                        decryptedItem += "-_-";
                        break;

                        //=========================================================================================================//
                }
            }

            return decryptedItem;
        }
    }
}
