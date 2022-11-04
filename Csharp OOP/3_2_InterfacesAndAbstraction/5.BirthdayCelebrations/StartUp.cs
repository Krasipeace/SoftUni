namespace BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BorderControl.Core;
    using BorderControl.Core.Interfaces;
    using Models;
    using Models.Interfaces;
    
    public class StartUp
    {       
        static void Main()
        {
            IEngine engine = new BirthdayCheck();

            engine.RunEngine();
        }       
    }
}