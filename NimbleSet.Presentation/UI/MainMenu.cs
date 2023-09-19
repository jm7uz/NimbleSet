using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbleSet.Presentation.UI
{
    public class MainMenu
    {

        public void Banner()
        {
            Console.WriteLine(@"
##    ## #### ##     ## ########  ##       ########     ######  ######## ######## 
###   ##  ##  ###   ### ##     ## ##       ##          ##    ## ##          ##    
####  ##  ##  #### #### ##     ## ##       ##          ##       ##          ##    
## ## ##  ##  ## ### ## ########  ##       ######       ######  ######      ##    
##  ####  ##  ##     ## ##     ## ##       ##                ## ##          ##    
##   ###  ##  ##     ## ##     ## ##       ##          ##    ## ##          ##    
##    ## #### ##     ## ########  ######## ########     ######  ########    ##    
");
        }

        public void PrintProgressBar(int progress)
        {
            Console.Write("💢");
            int completedBars = progress / 10;
            for (int i = 0; i < 10; i++)
            {
                if (i < completedBars)
                    Console.Write("💀");

                else
                    Console.Write(" ");
            }
            Console.Write("💢");
        }

        public void Menu()
        {
            Console.WriteLine("\n1. User\t\t2.Admin\t\tSuper Admin\nInput your role:");
        }
    }
}
