using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using SheltersApp.Models;
using System.Collections.Generic;

namespace SheltersApp.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Stephen (IsAdmin)
            var stephen = await userManager.FindByNameAsync("something@someone.com");
            if (stephen == null)
            {
                // create user
                stephen = new ApplicationUser
                {
                    UserName = "something@someone.com",
                    Email = "something@someone.com"
                };
                await userManager.CreateAsync(stephen, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(stephen, new Claim("IsAdmin", "true"));
            }

            // Ensure Mike (not IsAdmin)
            var mike = await userManager.FindByNameAsync("Mike@CoderCamps.com");
            if (mike == null)
            {
                // create user
                mike = new ApplicationUser
                {
                    UserName = "Mike@CoderCamps.com",
                    Email = "Mike@CoderCamps.com"
                };
                await userManager.CreateAsync(mike, "Secret123!");
            }

            var db = serviceProvider.GetService<ApplicationDbContext>();

            if (!db.Categories.Any())
            {
                db.Categories.AddRange(
                    new Category
                    {
                        AnimalType = "Dogs",
                        Animal = new List<Animal>
                        {
                            new Animal {Breed="Doberman Pincher",
                                        Name = "Hickory",
                                        Bio = "Hickory is a fine Doberman Pincher. He was abandoned in an old farm house            before rescuerers found him",
                                        Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/European_Dobermann.jpg/220px-European_Dobermann.jpg"
                        },
                            new Animal
                            {
                                Breed ="Border Collie",
                                        Name = "Dynamite",
                                        Bio = "Dynamite is a Border Collie who's owner was said to be a fireman. After             the fireman was deceased, Dynamite was later turned in to the shelter",
                                        Image = "http://cdn1-www.dogtime.com/assets/uploads/gallery/border-collie-dog-breed-pictures/1-facethreequarters.jpg"
                        },
                            new Animal
                            {
                                Breed="Siberian Husky",
                                Name="Max",
                                Bio="Max is a Siberian Husky who has been with the shelter since he was a puppy. Not much is known about his owners.",
                                Image="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d2/Siberian_Husky_with_Blue_Eyes.jpg/220px-Siberian_Husky_with_Blue_Eyes.jpg"
                            },
                            new Animal
                            {
                                Breed="Pug",
                                Name="Molly",
                                Bio="Molly is a Pug with a very weak heart, but will love to jump and play around with other dogs",
                                Image="http://cdn3-www.dogtime.com/assets/uploads/2011/01/file_23124_pug-460x290.jpg"
                            },
                             new Animal
                            {
                                Breed="German Shepherd",
                                Name="Gizmo",
                                Bio="Gizmo is a German Shepherd who use to be a seeing eye dog, but was turned in to the shelter after his owner passed away.",
                                Image="http://cdn2-www.dogtime.com/assets/uploads/gallery/german-shepherd-dog-breed-pictures/standing-7.jpg"
                            }
                        }

                    },
                    new Category
                    {
                        AnimalType = "Cats",
                        Animal = new List<Animal>
                        {
                            new Animal {Breed="Bengal Cat",
                                        Name = "Striker",
                                        Bio = "Striker is a tiger striped, Bengal Cat that use to be a stray.",
                                        Image = "https://www.google.com/imgres?imgurl=https://upload.wikimedia.org/wikipedia/en/3/3a/Freddie4.jpg&imgrefurl=https://en.wikipedia.org/wiki/Bengal_cat&h=1972&w=1963&tbnid=LZdPHqXzDtzIpM:&tbnh=186&tbnw=185&usg=__ruzZ0pQyf_TxBftDY0OYOdTM1oc=&vet=10ahUKEwja14e1-vnSAhXGSSYKHakaD5EQ_B0IjAIwCg..i&docid=D7k0K-CBkJJKgM&itg=1&sa=X&ved=0ahUKEwja14e1-vnSAhXGSSYKHakaD5EQ_B0IjAIwCg&ei=fbzaWJqlHsaTmQGptbyICQ#h=1972&imgrc=LZdPHqXzDtzIpM:&tbnh=186&tbnw=185&vet=10ahUKEwja14e1-vnSAhXGSSYKHakaD5EQ_B0IjAIwCg..i&w=1963"},
                            new Animal {Breed="Russian Blue",
                                        Name = "Grey",
                                        Bio = "Dont let the name fool you. Grey is actually a Russian Blue cat who was              resued from a tree.",
                                        Image = "https://upload.wikimedia.org/wikipedia/en/e/ee/Russian_blue_head_sm.jpg"
                                    },
                            new Animal
                            {
                                Breed="British Shorthair",
                                Name="Kip",
                                Bio="Kip is a British Shorthair who was found with an injured leg in a local alley, but was nursed backed to health.",
                                Image="http://cdn2-www.cattime.com/assets/uploads/gallery/british-shorthair-cats-and-kittens/british-shorthair-cats-and-kittens-1.jpg"
                            },
                            new Animal
                            {
                                Breed="American Shorthair",
                                Name="Leo",
                                Bio="Leo is an American Shorthair. Not much is known about Leo, he was left in a basket on our front door.",
                                Image="http://cdn1-www.cattime.com/assets/uploads/gallery/american-shorthair-cats-and-kittens/american-shorthair-cats-kittens-3.jpg"
                            },
                            new Animal
                            {
                                Breed="Ragdoll",
                                Name="Ragdoll",
                                Bio="Yes ironic. Ragdoll is cat who is also named Ragdoll. Ragdoll has a very curious spirit like all cats naturally have.",
                                Image="https://upload.wikimedia.org/wikipedia/commons/6/64/Ragdoll_from_Gatil_Ragbelas.jpg"
                            }
                        }

                    },
                    new Category
                    {
                        AnimalType = "Birds",
                        Animal = new List<Animal>
                        {
                            new Animal {Breed="Cockatoo",
                                        Name = "Chip",
                                        Bio = "Chip here is a beautiful Cockatoo that loves to dance around at the sound                of music. Sadly, Chips owner could no longer provide for him so they later                  turned him in.",
                                        Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/61/Cacatua_galerita_-perching_on_branch_-crest-8a-2c.jpg/220px-Cacatua_galerita_-perching_on_branch_-crest-8a-2c.jpg"
 },
                            new Animal {Breed= "Parakeet",
                                        Name = "Buzzer",
                                        Bio = "Buzzer is an American Parakeet. He was found in a park one morning with an                   injuried wing and hes been in our care ever since. He got his name,                     because he loves saying Buzzer.",
                                        Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1a/Melopsittacus_undulatus_-Atlanta_Zoo%2C_Georgia%2C_USA-8a-2c.jpg/220px-Melopsittacus_undulatus_-Atlanta_Zoo%2C_Georgia%2C_USA-8a-2c.jpg"
 },
                            new Animal
                            {
                                Breed="African Grey Parrot",
                                Name="Terry",
                                Bio="Terry is a rare African Grey Parrot who was rescued from a smuggler who was trying to sell him to the black market.",
                                Image="https://upload.wikimedia.org/wikipedia/commons/thumb/2/28/Psittacus_erithacus_-perching_on_tray-8d.jpg/220px-Psittacus_erithacus_-perching_on_tray-8d.jpg"
                            },
                            new Animal
                            {
                                Breed="Lovebird",
                                Name="Lovey",
                                Bio="Lovey is a Lovebird who got her name, because of her being a Lovebird.",
                                Image="http://cf.ltkcdn.net/small-pets/images/std/172469-281x425-Normal-peachface-lovebird.jpg"
                            },
                            new Animal
                            {
                                Breed="Amazon Parrot",
                                Name="Lucky",
                                Bio="Lucky is an Amazon Parrot who mysteriously appeared on our door step. ",
                                Image="https://upload.wikimedia.org/wikipedia/commons/f/fb/Amazona_amazonica_2c.jpg"
                            }
                        }
                    },
                    new Category
                    {
                        AnimalType= "Bunnies",
                        Animal = new List<Animal>
                        {
                            new Animal
                            {
                                Breed="Harlequin rabbit",
                                Name="Bandit",
                                Bio="Bandit is a Harlequin rabbit with a unique black and white pattern like a robber would. Which is why we call him Bandit",
                                Image="https://upload.wikimedia.org/wikipedia/commons/thumb/9/90/Lapin_Japonais.jpg/220px-Lapin_Japonais.jpg"
                            },
                            new Animal
                        {
                            Breed = "French Lop",
                            Name = "Ears",
                            Bio = "Ears is a French Lop with, you guessed it, huge ears.",
                            Image = "https://s-media-cache-ak0.pinimg.com/736x/6d/59/1f/6d591fd3484bddd9a8ba52b536374e0b.jpg"
                        },
                            new Animal
                            {
                                Breed="Havana",
                                Name="Hannah",
                                Bio="Hannah is a Havana rabit that was given to us by a kind gentlemen who captured her running around his neighborhood",
                                Image="https://www.google.com/imgres?imgurl=http://petguide.com.vsassets.com/wp-content/uploads/2016/05/havana-rabbit.jpg&imgrefurl=http://www.petguide.com/breeds/rabbit/havana-rabbit/&h=421&w=637&tbnid=xnCehnAmjUKkkM:&tbnh=132&tbnw=200&usg=__Fg5dLFm3M5ob-w2ut-dEZBvm_CA=&vet=10ahUKEwi2_q6RqpHTAhWrqlQKHXwWBEgQ_B0IigIwCg..i&docid=x0s2GpTI8saWXM&itg=1&sa=X&ved=0ahUKEwi2_q6RqpHTAhWrqlQKHXwWBEgQ_B0IigIwCg&ei=if3mWPaVIKvV0gL8rJDABA"
                            },
                            new Animal
                            {
                                Breed="Palomino Rabit",
                                Name="Chuck",
                                Bio="Chuck is a Palomino Rabit who loves to eat carrots and lettuce",
                                Image="http://rabbitbreeders.us/wp-content/uploads/Palomino-Rabbit-Breed.jpg"
                            },
                            new Animal
                            {
                                Breed="Flemish Giant Rabbit",
                                Name="Big Guy",
                                Bio="Big Guy is a Flemish Giant Rabbit. He weighs 30 pounds and is one of the largest animals in the world.",
                                Image="http://flemish-giant.com/wp-content/uploads/2015/10/Flemish-Giant-Rabbit-Light-Grey.jpg"
                            }
                      },
                        
                    }
                );
                db.SaveChanges();
            }
        }
    }
}
