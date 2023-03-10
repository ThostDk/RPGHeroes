

namespace RPGHeroes
{
    public static class RenderAscii
    {
        /// <summary>
        /// Method for displaying all the menus in the game
        /// </summary>
        /// <param name="title">The Title in the top of the Console Menu</param>
        /// <param name="playerActions">the list of string actions that should be displayed in the menu </param>
        /// <param name="index">the index for the '--> selection' </param>
        /// <param name="shouldClearConsole">should the menu clear the console before being run?</param>
        public static void RenderPlayerActionsMenu(string title, List<string> playerActions, int index, bool shouldClearConsole)
        {

            if (shouldClearConsole)
            {
                Console.Clear();
            }
            string titleFillerRight = "|######################";
            titleFillerRight = titleFillerRight.PadRight(52 - title.Length, '#');
            Console.WriteLine($"######################################|{title}{titleFillerRight}");
            Console.WriteLine("###########################################################################################");

            for (int i = 0; i < playerActions.Count; i++)
            {
                string fillerRight = "||######################";
                fillerRight = fillerRight.PadLeft(55 - playerActions[i].Length, ' ');
                if (i == index)
                {
                    Console.Write($"######################|| "); Console.ForegroundColor = ConsoleColor.Green; Console.Write($"-> Option: {playerActions[i]}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{fillerRight}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"######################||    Option: {playerActions[i]}{fillerRight}");
                }
            }
            Console.WriteLine("###########################################################################################");

        }
        public static void RenderStartGameText()
        {
            Console.WriteLine(" ¤============================================================================================================================¤ ");
            Console.WriteLine("{|##########################################||       Please Go FullScreen =)     ||###########################################|}");
            Console.WriteLine("{|##########################################|| -> Press any key to Start Game <- ||###########################################|}");
            Console.WriteLine("{|##########################################||                                   ||###########################################|}");
            Console.WriteLine(" ¤============================================================================================================================¤ ");
            Console.ReadKey();
            Console.Clear();
        }
        public static void RenderChooseClass()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ¤============================================================================================================================¤ ");
            Console.WriteLine("{|##########################################||       Lets choose a class         ||###########################################|}");
            Console.WriteLine("{|##########################################|| -> Press any key to continue <-   ||###########################################|}");
            Console.WriteLine("{|##########################################||                                   ||###########################################|}");
            Console.WriteLine(" ¤============================================================================================================================¤ ");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }
        #region AsciiImageRenderMethods

        public static void RenderBackground()
        {
            Console.WriteLine
                ("                                       .                                                          ...    ...                                \r\n                                     ..*                                                         ,(@&\\*(%@(,. .,*\\\\\\.                       \r\n                                                                        ,((\\            ..\\\\((\\\\##(,.****%&#&@%%##&#.                       \r\n                               ..   ,  .#    ##*.                        ,*(,          .&&@@@&,.                .\\@&@*                      \r\n                             ...    .,.#*  .(.,\\*               .,*.  , *,\\*.           .(@@@\\,.                 .,%*%.                     \r\n                  .,,,        . .., (  ((%,*...\\,,.       .     \\,,.   *,%\\...,,,,. .     *&&.      ,,(.,           .#*                     \r\n                *,    .           #,. #(\\(*%  ..,        ,,.   . ..**\\*,....\\,\\*(\\(*      .&%       ,*(*\\          (\\                       \r\n                    .\\*                       ,.,(,      .   , .,.\\%#,,,., .,,(*,*\\\\      .\\&        ,,*,        ,#\\.                       \r\n                   *..(%.                  .,,,  ***     ,.    .\\.,\\,,,..,.....\\\\*\\\\       .(      ..%(%\\\\#,.,*((,.                         \r\n                   . (\\#              ,.  .*\\***, ,\\  ..  . ,. .    \\,...,.*, ..*.**       , \\    \\.  , ..... .                             \r\n .                .*.,\\               ....  ..* , . *,,*..,      ., #. , ...\\, ,\\.           \\    *,.,,,..                                  \r\n  .           *,  .  ., .       .           ...     .,**\\.,,.          ( ...,,              ,\\,.\\ .,,**.                                    \r\n                 \\\\* .......           **.. ,,,*.      .,        \\     *     ...             **,. ,.**(.                ,#\\*,               \r\n     .         ..,.   .,,,,,,..*     ,  %     ...                      ..  ......            .,   ,   ..              . *,..*,              \r\n               .,(.  ...,,..  .. (   . ,  ,  ,,.                      , ...  ...*,.          .,. . , . .       .%&\\....,.    .. ..  .       \r\n        .      *\\  . ,,,,.  .     *   .     .....                    ..       ,,,,*           .,*,    \\.    %@* ,...,...,*..**\\**..*..      \r\n               .#  ..,,,,.         ,         ,,..                    *.  .     *,,,           ,. .,,,..*,,(,(,..    . ...\\,..  ,.  *,,,     \r\n           .    \\  *.,....\\ . .. .       .                           ,.                        .,,...  ,. *    ,*\\##%&&@@@@%#(\\,.*.,,,,*    \r\n                *, *,.....*  .....                               .  , .    .    ..,.           ...  .  ,,.             .,.     , .,*\\\\**\\.  \r\n                  . * ....**         .  ..   .    .                 ...  .*.     .,..         ...      .,.             . ..  .  ..,,,***(#* \r\n                . ...... . ,.        .            ..               ...* .\\\\,.    ...           ...      ,,.           .,..   ..  .. .,**#%. \r\n                 . .,  . ,,.         . .\\        .                   *,,**,*\\     .           ....      ,,.        .\\...        .......,,*\\ \r\n               *.,.,    ,,..            . .      ..                 .. #%\\(%\\.    ..          ,.        .,    (. &\\\\*,.           *  ....,  \r\n                * .*,    . ,           ,,        ,              ,...#&\\&(\\#&#\\\\   ,..    .   .,. ..      *    , ,...   ..     .       ,,,,, \r\n                 ,.,  ,    .           .                 .       *,*,,,*&&%&@&\\   .. ...     .,   .      ,   *.,...          ...            \r\n                 \\     ..  ,,          .        ,         . ..,,**\\(*\\(&&%@&&%%#,  ,,.,\\,   .     .                          ...            \r\n                *,       *  \\         *            \\          ..*\\(%\\ .*&#&&&(#. .                        .                   ,. ,          \r\n                *.        , *         .,.                      *               ...  ...         .              .              ., ...        \r\n                \\           *.                          . .....,.......              .  ,  . . . .   .     ..   .            .   . .        \r\n                *            .                    .  ... ......     ..,,..                .  ... **          ...               , ..         \r\n                              ..                  ...                  ., . . ...  .. .  . . ..              %*                .,           \r\n              ..                                           .     .   .. .  .  .   .....  .       .   , .      .                             \r\n                                                                                  .                                                         ");
        }
        public static void RenderNameBook()
        {
            Console.WriteLine
                ("                                                                               &@@@@                                                         \r\n                                                                      .@@.....,,,,,,,,,(@@@@@\\                                              \r\n                                                   @@@@@\\..,,,.,@@  (@........,,\\*,*,\\,,,*,,,,,,.,,,,,..@@                                  \r\n                            @,..,#@@@@@@@####.................*,**#@..........\\,.\\,,(,,,,\\,,,,,,.,.......,@**                               \r\n                         @,.@............,*.,\\...*.............,*\\%@%,..........,(*..*.,.,,,,.,,.,.........@***@                            \r\n                      &@,,.@.......**,*,.,*,.*.................,**%@@,........,*,,*,....,.,,.,,,...,........@@**,@,                         \r\n                     &,,,.@.....,,.\\.,.,,*..,..........*,...\\..,**%@@......,,*,.,*,.,*\\,..,...,,....,........@@****%&                       \r\n                   %&,,,@\\.......,.....,.,..*.*,..,............,,*#@@..#...*.,..,.(\\....*.,,.,,,.,,*,**.......@&@****&(                     \r\n                  &..,,@........(.,\\\\.*.,**........\\...........,,*(@@........*,..,..,...*........,..,.*,,,*\\....@@,*@**&                    \r\n                .&.,,.@..............#((........*..,............,,\\@@...........,*...*,.......,..\\.,.....*.......@@,,,,,&@                  \r\n               &%,,,@@.........,**...(,. \\*.................**..,,\\@@.......*,*\\,*,,,....(..........,.............@*@,,,*,@(                \r\n              &.,,,@*......*.*.(.*.%.. ...............* ***,,...,,*&@...,\\,#*,(...............\\.\\.\\*.*.*..,,**......@@,,,@,&@               \r\n            @&.,,(@.......................,,......,,.,,*....,*(.,,,&@..,\\.,*,.\\.**......,,...(.*\\......\\,*..,***,,...,@@,,,\\,@@             \r\n           &(,,,&@..*...,.*,*..*,...,,,**.,.,,..,,* *,...,,..(,,*,,%@...*,,**,*,.,,,...,......,.\\,...*,.,.*,*,,***,....@@(,,,,\\@\\           \r\n         &&.,.,@*..,....,\\#,......*....**..\\.,*.*,.,.,.......\\.*,,,#@....**\\..........\\@@@*            .................@@@,,,,,&@          \r\n        @&.,.#@   #*.(*,\\....*, .,.........(.,,..,..**,.....\\#.,*,,(@.,*....@@@,*,,,,,*,,,,,,,,,(@@@@@@@@@(##@@@@@@.  ....,.@@*,,.@@        \r\n      %@...,.@   (\\, ..######...,@@@@@.... *,.. .  . . .,,,. .....,,\\@....@***,*,***,,,,,,,,,,,,,,,,.,,,,,,...................,,@@,,&@.      \r\n     @@..,..@@@@@@@@&.         . ...... . #@@%&@@@@*****\\*\\\\\\\\@@@..*@. @\\*********%@@%*,,,,,,@%,,,,,,,,,,,,,,.,...,..,.,......,..#@.,@@     \r\n    @&....@@,,,,,,,,,,,,,,,,,*,*,,************\\******@@@@@\\\\\\\\\\\\\\\\\\\\@@&@*****@*,****,,,@@@@@,,,,,,,,,,,&@.,,,,,,,,,...,.............\\@..@@   \r\n  @&,.*@@*,,,,,,,,,,,,,,,,,*,*,*************************\\***\\*\\\\*\\\\\\@(\\****@**@******,**,,***,,,,,*@@,,,,,,,,,,,,,.,,,,,.............&@.%@@ \r\n @@.@@,,,,,,,,,,,,,,,,,,,,,,,,,********@*********@@@(*,......@@\\\\(&@@#%(\\&((%(***.%@@@@@@@@@##%#(((\\\\***,**,***,*,,,,,,,,,,,,,,,,,,,,,.(@,&&\r\n  @@@@@@@@@@@&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&&@@&@@@ ,,        @@@@@                     .&@@@&%&&&#&&@@@&&@@@@@@@%\\.         \r\n                                                                                                                                            \r\n                                                                                                                                            \r\n                                                                                                                                            \r\n                                                                                                                                            \r\n                                                                                                                                            \r\n                                                                                                                                            \r\n                                                                                                                                            \r\n                                                                                                                                            \r\n                                                                                                                                            \r\n                                                                                                                                            \r\n");
        }
        public static void RenderMage()
        {
            Console.Clear();
            Console.WriteLine
                ("                                        \r\n     .                                  \r\n    # (%%                               \r\n      @%@%                              \r\n       #&@#                             \r\n       @@@@*             &&(            \r\n       @@&%            @%&%%#%          \r\n         @&@          %#&\\#%(%@         \r\n          @&@          @#(#%@@@         \r\n           @&%@      %&%%&@@&@%         \r\n             %&.   &&%%(\\##%(#(%%%@*    \r\n              .%   @@&%,**#&@%@@#&#     \r\n               #&@@@%#%%#%##%&@%%@(     \r\n                %&@@@@&@@@@@@@@%&%,     \r\n                ##@@  ##%##@@@%#%@      \r\n                   &&@%%@&&@@#%@@       \r\n                    &@@@&@&%%%@&,       \r\n                   .&%&@&@&&&@@@&%      \r\n                  %@&@&(##%@@@@@@%&     \r\n                  &@(#%@@@@@@@@@&@@     \r\n                 @(#%@@@&&@@@@@@%%@     \r\n                 ((#%@@@&&&@@@@@@%@\\    \r\n                 (#%@@@@%&&&@@@#%%@&    \r\n                 (#&@@@@&&&&&@@#&%@     \r\n                 #&@@   &&&&@&@@@&(     \r\n                %#&&@@    %   &%@@&     \r\n                #&&@@         \\%#@@%    \r\n                &&@@,          @@%@     \r\n               .@@@            ,@@&     \r\n               #@@&             &&%%    \r\n              (&&@.             &%% ,   \r\n           %&%&@@@*             %%%%    ");

        }

        public static void RenderRanger()
        {
            Console.Clear();
            Console.WriteLine
                ("                                        \r\n                 %##(                   \r\n                (@@#,                   \r\n                ######\\                 \r\n                #%(\\%(,                 \r\n                 (%(%%#                 \r\n                 ((&&&  @               \r\n            %%##%%#(%&&##(#(,           \r\n            \\*&%(((##(#%(%%###*         \r\n%          (#%%@%(%%%#\\(%%%&%           \r\n (         %%&@&##%&&&%%&&%@&           \r\n (  (     \\\\#.(&%%@@%%%&@@@@&           \r\n (      %\\(#@  ,%#%&&@@@@&@@@@          \r\n .\\     %##%   %(#&##%%%&&@@@#&         \r\n  #*    %%%%  #&#(#%&&&&&&&@#%(         \r\n   (%   &(&  %#%(#(#%%%#%#%@(&(@        \r\n      &*##   %&(@(@###%#&@@&  @\\,       \r\n       \\\\\\(  (\\\\\\(#%%#%#%@(%  (%%       \r\n         @#  &#\\%%#%%%%%%@%&   &\\       \r\n           %%(%##%&%%#%%%%%%            \r\n             &###&@  %&@@&##            \r\n              &&@#@   %@(##             \r\n             (#%&@@ @@@%##%%.           \r\n             (%&@&    ##%&&@            \r\n            %%%&@@    #&&&(%            \r\n            %%(&&     @@#@%*            \r\n            %&%@&      @@@@             \r\n            #&&@       %(%@.            \r\n            %&&&        ##%             \r\n            ##%%        (%(\\            \r\n            #\\#@        (#\\#(           \r\n           (\\\\\\#         %#&##&         ");
        }
        public static void RenderBarbarian()
        {
            Console.Clear();
            Console.WriteLine
                ("                                        \r\n                  (#(                   \r\n                ((\\#\\\\\\                 \r\n               ((\\&%((\\                 \r\n              \\#(#(%(#*                 \r\n         *%%&%\\\\(#&((%@@%(              \r\n      #%%#%%%&&%*\\##%@@@#%%#*\\          \r\n     \\\\#&%&%&%&#\\#((\\(%#%(%%%%%         \r\n     \\(((#@&&##%\\#\\#((%%@%##&@%&        \r\n    \\\\##%&@#(\\(%%%#@%@%(%\\#@%#((        \r\n   \\\\\\\\(%%&(\\****@@%&@%%((@@&#\\.        \r\n   *((%&& @\\\\(&#&@%%&#(\\(( &@@%%*       \r\n  \\\\\\&&   %&@@##(#%%&@&&&&@ @@@@&%      \r\n #%@%%%   @&%%@@@&&%@%#@@&&%@@@@#\\      \r\n &##&&@@@%&@%%&&@@%@@@@&@&&@@@@@@(\\     \r\n *&&@@@@@&%(%@&&@@@@@&@@&@@&&&&@@&%     \r\n  %#&@@@@&%#(%%&@@&@@@#%%@@@@##.@&\\*    \r\n %%#\\(( #%&@%@#&@@@&@&@@@@@@&@& @%#@    \r\n  (\\@(%&@&&%&@&@@@@@@@&%&@@%&@ (@   @(\\ \r\n  (%(&%\\@&%&&%%&&@@@@&@&&@&%@@  @@     &\r\n        %&%&@@&@&&&@@%&&&%%%#\\   @@(  &&\r\n        &%&&&@@&&@&@@ @&@&%&,    @@%&&&&\r\n         %&(%&#  %    &@@@@%,     .&&&%&\r\n         \\(%#%.        &@@@&(       .&%&\r\n        \\\\(###        &@@@@&(           \r\n      &&%(####@      @@@@@@@@&          \r\n      %%#@@&%&@      @@@@@@@\\@%         \r\n      %#@@@@&&&        @@@@@@           \r\n       %%@@&@           @@@@#           \r\n        &&&&            @@@@@(          \r\n       %%&&&           @@@&%%%#%        \r\n     &###&@@&            * @%%#%%#      ");
        }
        public static void RenderRogue()
        {
            Console.Clear();
            Console.WriteLine
                ("                                        \r\n                  %&&&%                 \r\n                 &@**\\(%                \r\n                 **#&(@\\                \r\n                  ,(\\&#                 \r\n               (* #(@&,@@               \r\n         &\\*,.,\\(#(\\%#&&@%\\\\\\,          \r\n            @@@@(\\#&\\(#((%%@            \r\n           (##&%%#\\\\\\(#**\\%&%           \r\n            \\%@%&&&@@@&&@@@@            \r\n           ,\\%@ &&@@@@@@@@@@(           \r\n          #(%&  *(&@@@%&@@%@#(          \r\n          (#%@  *%%&@@@@@&&@@@(         \r\n          \\@@  ,%\\%&%&&\\##& @@@         \r\n          \\&@  %%&@@&@%%&@%@ @@@        \r\n#%###    \\(&   %%%&&@&&&@@@@  %##  *####\r\n     ###(#@@   &%%%%@@&&&&@#  @@@(#%(   \r\n       ( &*.##  #%&&&&&@&&@       *     \r\n                 %#&%&@@@@@             \r\n                  #&@@@@&@              \r\n                  %&%&&@@&              \r\n                  %&#%&@(@              \r\n                   #&&@%@               \r\n                  &#@#@@&%              \r\n                 &&%@#@&&#              \r\n                 #&@@@#@#(              \r\n                 &&@& .%%%              \r\n                #%@@    &&\\             \r\n                %%@@    %%#@            \r\n               &@%\\%@    @(&&           \r\n                 .%&&%#  \\%@##          \r\n                          &%#(          ");
        }

        #endregion

    }
}
