using Library.Server.Models.Entity;
using Library.Server.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.DBContexts
{
    public class DBInitializer
    {
        private readonly ModelBuilder _builder;

        public DBInitializer(ModelBuilder builder)
        {
            this._builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<AppRole>().HasData(
                new AppRole() 
                { 
                    Id = 1, 
                    Name = "Librarian", 
                    NormalizedName = "LIBRARIAN" 
                },
                new AppRole() 
                { 
                    Id = 2,
                    Name = "Customer", 
                    NormalizedName = "CUSTOMER" }
            );

            _builder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Title = "Be Ready When the Luck Happens",
                    Author = "Ina Garten",
                    Description = "Here, for the first time, Ina Garten presents an intimate, entertaining, and inspiring account of her remarkable journey. Ina's gift is to make everything look easy, yet all her accomplishments have been the result of hard work, audacious choices, and exquisite attention to detail. In her unmistakable voice (no one tells a story like Ina), she brings her past and her process to life in a high-spirited and no-holds-barred memoir that chronicles decades of personal challenges, adventures (and misadventures) and unexpected career twists, all delivered with her signature combination of playfulness and purpose. From a difficult childhood to meeting the love of her life, Jeffrey, and marrying him while still in college, from a boring bureaucratic job in Washington, D.C., to answering an ad for a specialty food store in the Hamptons, from the owner of one Barefoot Contessa shop to author of bestselling cookbooks and celebrated television host, Ina has blazed her own trail and, in the meantime, taught millions of people how to cook and entertain. Now, she invites them to come closer to experience her story in vivid detail and to share the important life lessons she learned along the way: do what you love because if you love it you'll be really good at it, swing for the fences, and always Be Ready When the Luck Happens.",
                    Publisher = "Crown Publishing Group (NY)",
                    PublicationDate = new DateTime(2024, 10, 1),
                    Category = "Autobiographies",
                    ISBN = "9780593799895",
                    PageCount = 320,
                    CoverImagePath = "1.png",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "admin"
                },
                new Book()
                {
                    Id = 2,
                    Title = "Pumpkin spice & everything nice",
                    Author = "Cicatelli-Kuc, Katie",
                    Description = "sixteen-year-old Lucy Kane hates the uber-popular PSL. She finds it overrated -- especially when you consider the fact that there isn't even pumpkin in it! -- which is bad because she works at Cup o' Jo, the local coffee shop her mom owns. Business at Cup o' Jo hasn't been great in the off-season, but that's okay because it always picks up during the fall... Until Java Junction, a multinational coffee chain, opens across the street and makes things harder for the small shop. And to make matters worse, it turns out Jack Harper, the new kid in school and Lucy's secret crush, is the son of the owner.\"-- Provided by publisher.",
                    Publisher = "Scholastic Press",
                    PublicationDate = new DateTime(2024, 8, 1),
                    Category = "Fiction",
                    ISBN = "9781339030753",
                    PageCount = 336,
                    CoverImagePath = "2.png",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "admin"
                }, new Book()
                {
                    Id = 3,
                    Title = "Diary of a Wimpy Kid Hot Mess",
                    Author = "Jeff Kinney",
                    Description = "Greg Heffley is caught in the middle as the two halves of his extended family come together in a sidesplittingly relatable summer story! When the Heffleys agree to spend summer break with both Mom's and Dad's relatives at the same time, they have to figure out how to be in two places at once. With Greg caught in the middle, can the Heffleys pull off the ultimate scheme? Or will their vacation turn into a hilarious hot mess?",
                    Publisher = "Harry N. Abrams",
                    PublicationDate = new DateTime(2024, 10, 1),
                    Category = "Fiction",
                    ISBN = "9781419766954",
                    PageCount = 224,
                    CoverImagePath = "3.png",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "admin"
                }, new Book()
                {
                    Id = 4,
                    Title = "The Wild Robot",
                    Author = "Peter Brown",
                    Description = "Roz the robot discovers that she is alone on a remote, wild island with no memory of where she is from or why she is there, and her only hope of survival is to try to learn about her new environment from the island's hostile inhabitants.",
                    Publisher = "Little, Brown Books for Young Readers",
                    PublicationDate = new DateTime(2020, 4, 1),
                    Category = "Fiction",
                    ISBN = "9780316382007",
                    PageCount = 320,
                    CoverImagePath = "4.png",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "admin"
                }, new Book()
                {
                    Id = 5,
                    Title = "The Vegetarian",
                    Author = "Han Kang and Deborah Smith",
                    Description = "Before the nightmares began, Yeong-hye and her husband lived an ordinary, controlled life. But the dreams—invasive images of blood and brutality—torture her, driving Yeong-hye to purge her mind and renounce eating meat altogether. It’s a small act of independence, but it interrupts her marriage and sets into motion an increasingly grotesque chain of events at home. As her husband, her brother-in-law and sister each fight to reassert their control, Yeong-hye obsessively defends the choice that’s become sacred to her. Soon their attempts turn desperate, subjecting first her mind, and then her body, to ever more intrusive and perverse violations, sending Yeong-hye spiraling into a dangerous, bizarre estrangement, not only from those closest to her, but also from herself.   Celebrated by critics around the world, The Vegetarian From the Hardcover edition.",
                    Publisher = "Hogarth Press",
                    PublicationDate = new DateTime(2016, 8, 1),
                    Category = "Fiction",
                    ISBN = "9781101906118",
                    PageCount = 208,
                    CoverImagePath = "5.png",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "admin"
                }, new Book()
                {
                    Id = 6,
                    Title = "Doesn't Hurt to Ask : Using the Power of Questions to Communicate, Connect, and Persuade",
                    Author = "Trey Gowdy",
                    Description = "Former federal prosecutor and congressman for South Carolina breaks down the art of persuasion into a few shockingly simple, easy-to-follow, and proven steps that will help readers win arguments, gain support for their cause, and convey their message successfully",
                    Publisher = "Forum",
                    PublicationDate = new DateTime(2020, 8, 1),
                    Category = "Psychology",
                    ISBN = "9780593138915",
                    PageCount = 288,
                    CoverImagePath = "6.png",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "admin"
                }, new Book()
                {
                    Id = 7,
                    Title = "Sonny Boy : A Memoir",
                    Author = "Al Pacino",
                    Description = "\"From one of the most iconic actors in the history of film, an astonishingly revelatory account of a creative life in full To the wider world, Al Pacino exploded onto the scene like a supernova. He landed his first leading role in The Panic in Needle Park in 1971, and by 1975, he had starred in four movies-The Godfather and The Godfather: Part II, Serpico, and Dog Day Afternoon-that were not just successes but landmarks in the history of film. Those performances became legendary and changed his life forever. Not since Marlon Brando and James Dean in the late 1950s had an actor landed in the culture with such force. But Pacino was in his mid-thirties by then and had already lived several lives. A fixture of avant-garde theater in New York, he had led a bohemian existence, working odd jobs to support his craft. He was raised by a fiercely loving but mentally unwell mother and her parents after his father left them when Pacino was a boy. In a real sense he was raised by the streets of the South Bronx and by the troop of buccaneering young friends he ran with, whose spirits never left him. After a teacher recognized his acting promise and pushed him toward New York's fabled High School of Performing Arts, the die was cast. In good times and in bad, in poverty and in wealth, through pain and through joy, acting was his lifeline, its community his tribe. Sonny Boy is the memoir of a man who has nothing left to fear and nothing left to hide. All the great roles, the essential collaborations, and the important relationships are given their full due, as is the vexed marriage between creativity and commerce at the highest levels. The book's golden thread, however, is the spirit of love and purpose. Love can fail you, and you can be defeated in your ambitions-the same lights that shine bright can also dim. But Al Pacino was lucky enough to fall deeply in love with a craft before he had the foggiest idea of any of its earthly rewards, and he never fell out of love. That has made all the difference\"-- Provided by publisher.",
                    Publisher = "Penguin Random House",
                    PublicationDate = new DateTime(2024, 10, 1),
                    Category = "Biography",
                    ISBN = "9780593655115",
                    PageCount = 384,
                    CoverImagePath = "7.png",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "admin"
                }, new Book()
                {
                    Id = 8,
                    Title = "What It's Like to Be a Bird : From Flying to Nesting, Eating to Singing--What Birds Are Doing, and Why",
                    Author = "David Allen Sibley",
                    Description = "The bird book for birders and nonbirders alike that will excite and inspire by providing a new and deeper understanding of what common, mostly backyard, birds are doing--and why: \"Can birds smell?\"; \"Is this the same cardinal that was at my feeder last year?\"; \"Do robins 'hear' worms?\"\"The book's beauty mirrors the beauty of birds it describes so marvelously.\" --NPR In What It's Like to Be a Bird, David Sibley answers the most frequently asked questions about the birds we see most often. This special, large-format volume is geared as much to nonbirders as it is to the out-and-out obsessed, covering more than two hundred species and including more than 330 new illustrations by the author. While its focus is on familiar backyard birds--blue jays, nuthatches, chickadees--it also examines certain species that can be fairly easily observed, such as the seashore-dwelling Atlantic puffin. David Sibley's exacting artwork and wide-ranging expertise bring observed behaviors vividly to life. (For most species, the primary illustration is reproduced life-sized.) And while the text is aimed at adults--including fascinating new scientific research on the myriad ways birds have adapted to environmental changes--it is nontechnical, making it the perfect occasion for parents and grandparents to share their love of birds with young children, who will delight in the big, full-color illustrations of birds in action. Unlike any other book he has written, What It's Like to Be a Bird is poised to bring a whole new audience to David Sibley's world of birds.",
                    Publisher = "Knopf Publishing Group",
                    PublicationDate = new DateTime(2020, 4, 1),
                    Category = "Graphic",
                    ISBN = "9780307957894",
                    PageCount = 240,
                    CoverImagePath = "8.png",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "admin"
                }, new Book()
                {
                    Id = 9,
                    Title = "Dragon Ball Super, Vol. 21",
                    Author = "Akira Toriyama and Toyotarou",
                    Description = "\"In the wake of the commotion on Mt. Butterfly, Trunks decides to take a look into the data on the disc that he stole from Dr. Hedo's lab. However, the evil scientist intends to steal it back! And his genius plan is to create an android to infiltrate Trunks's school as a transfer student named Baytah. Meanwhile, the dastardly Red Ribbon Army is rising from the ashes and making new plans of their own.\"--Provided by publisher.",
                    Publisher = "Viz Media",
                    PublicationDate = new DateTime(2024, 5, 1),
                    Category = "Comics",
                    ISBN = "9781974746866",
                    PageCount = 192,
                    CoverImagePath = "9.png",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "admin"
                }, new Book()
                {
                    Id = 10,
                    Title = "The Art of Home : A Designer Guide to Creating an Elevated Yet Approachable Home",
                    Author = "Shea McGee",
                    Description = "The long-awaited design book from Shea McGee, beautifully showcasing all that is possible for every room of your home.\r\n",
                    Publisher = "Harper Horizon",
                    PublicationDate = new DateTime(2023, 9, 1),
                    Category = "Decoration",
                    ISBN = "9780785236832",
                    PageCount = 408,
                    CoverImagePath = "10.png",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "admin",
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "admin"
                }
            );
        }
    }
}
