Random random = new Random();

        while (true)
        {
            // Main menu
            Console.WriteLine("Hello Darling, my beautiful senpai we need you to play hang man eek! >.<");
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("Please pick a category darling");
            Console.WriteLine("1) Anime");
            Console.WriteLine("2) Video Games");
            Console.WriteLine("3) Japanese Culture");
            Console.Write(">>> ");

            // Typecasting input to integer
            int category = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("---------------------------------------------------------------------------------");

            string chosenWord = "";

            // Your categories/word banks (arrays)
            switch (category)
            {
                case 1:
                    string[] animeWords = { "Konosuba", "Tensura", "Naruto", "Kimetsu No Yaiba", "One Piece", "Dandadan", "Solo Leveling", "Kimi no koto ga Dai Dai Dai Dai Dai Daisuki na 100-nin no kanoji", "Mashle", "Mushoku Tensei", "Tsukimichi", "Arifureta", "Darling in the Franxx", "Shangri-La Frontier", "Sword Art Online" };                    chosenWord = animeWords[random.Next(animeWords.Length)];
                    Console.WriteLine("You chose my beautiful animes senpai!");
                    break;

                case 2:
                    string[] videogameWords = { "Valorant", "Overwatch", "Silksong", "Marvel Rivals", "Minecraft", "Clash Royal", "Rocket League", "Rainbow six Seige", "Super Smash Bros", "Roblox", "Fortnite", "Five Nights at Freddys", "Lethal Company", "Genshin Impact", "Doki Doki Literature Club" };
                    chosenWord = videogameWords[random.Next(videogameWords.Length)];
                    Console.WriteLine("You chose my favorite video games eek you otaku!");
                    break;

                case 3:
                    string[] japanesecultureWords = { "Kimono", "Yukata", "Yakuza", "Kawaii", "Baka", "Senpai", "Kami", "Hanami", "Samurai", "Katana", "Shogun", "Kunai", "Anime", "Manga", "Sushi" };
                    chosenWord = japanesecultureWords[random.Next(japanesecultureWords.Length)];
                    Console.WriteLine("You're doing my beautiful culture Darling >///<");
                    break;

                default:
                    Console.WriteLine("That is not a category!");
                    break; // back to menu
            }

            Console.WriteLine("");

            int wordSize = chosenWord.Length;
            int livesRemaining = 7;

            // Build hidden word as a string of underscores/spaces
            string display = "";
            for (int i = 0; i < wordSize; i++)
            {
                if (chosenWord[i] == ' ')
                    display += " ";   // keep spaces
                else
                    display += "_";   // hide letters
            }

            // Main game loop
            while (livesRemaining > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Lives left: " + livesRemaining);
                Console.WriteLine("Word: " + display);
                Console.Write("Guess a letter OR the full word: ");

                string input = Console.ReadLine();

                // validate: must type something
                if (input == "")
                {
                    Console.WriteLine("Please type something, darling >.<");
                    break;
                }

                // ----- Full-word guess path -----
                if (input.Length > 1)
                {
                    // Compare case-insensitively
                    if (input.ToLower() == chosenWord.ToLower())
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Yatta~ You guessed the whole word! ✨");
                        Console.WriteLine("The word was: " + chosenWord);
                        break; // win
                    }
                    else
                    {
                        livesRemaining--; // wrong full-word guess costs a life
                        Console.WriteLine("Not quite! -1 life 💔");
                        // do not reveal anything on wrong full-word guess
                    }
                }
                // ----- Single-letter guess path -----
                else
                {
                    char guess = char.ToLower(input[0]);

                    bool found = false;
                    string newDisplay = "";

                    // Reveal any match positions; keep already revealed letters/spaces
                    for (int i = 0; i < wordSize; i++)
                    {
                        if (char.ToLower(chosenWord[i]) == guess)
                        {
                            newDisplay += chosenWord[i]; // reveal this letter
                            found = true;
                        }
                        else if (display[i] != '_')
                        {
                            newDisplay += display[i];    // keep revealed/space
                        }
                        else
                        {
                            newDisplay += "_";           // still hidden
                        }
                    }

                    display = newDisplay;

                    if (!found)
                    {
                        livesRemaining--;
                        Console.WriteLine("Nuu~ wrong letter! -1 life 💔");
                    }
                    else
                    {
                        Console.WriteLine("Ooh nice guess, senpai! You revealed a letter~");
                    }
                }

                // Check win condition: no underscores left
                bool allRevealed = true;
                for (int i = 0; i < wordSize; i++)
                {
                    if (display[i] == '_')
                    {
                        allRevealed = false;
                        break;
                    }
                }

                if (allRevealed)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You revealed the whole word!! You win, senpai! ✨");
                    Console.WriteLine("The word was: " + chosenWord);
                    break;
                }
            }

            // Lose condition
            if (livesRemaining == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Oh nooo you lost, darling T_T The word was: " + chosenWord);
            }

            // Replay
            Console.WriteLine("\nDo you want to play again? (y/n)");
            string playAgain = Console.ReadLine().ToLower();
            if (playAgain != "y")
                break;
        }