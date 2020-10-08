using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    public class RegularForms
    {
        public bool CheckValidSection(string str)
        {
            Regex myReg = new Regex(@"^\[\w+\]+$");
            return myReg.IsMatch(str);
        }
        
        public bool CheckValidValue(string str)
        {
            Regex myReg = new Regex(@"^[\w\.\/]+$");
            return myReg.IsMatch(str);
        }
        public bool CheckValidKey(string str)
        {
            Regex myReg = new Regex(@"^\w+$");
            return myReg.IsMatch(str);
        }
    }
}