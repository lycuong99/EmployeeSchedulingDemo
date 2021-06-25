using EmployeeSchedulingDemo.data;
using Google.OrTools.Sat;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeSchedulingDemo
{
    class Program
    {

        /// <summary>
        /// C# equivalent of Python range (start, stop)
        /// </summary>
        /// <param name="start">The inclusive start.</param>
        /// <param name="stop">The exclusive stop.</param>
        /// <returns>A sequence of integers.</returns>
        static IEnumerable<int> Range(int start, int stop)
        {
            foreach (var i in Enumerable.Range(start, stop - start))
                yield return i;
        }

        /// <summary>
        /// C# equivalent of Python range (stop)
        /// </summary>
        /// <param name="stop">The exclusive stop.</param>
        /// <returns>A sequence of integers.</returns>
        static IEnumerable<int> Range(int stop)
        {
            return Range(0, stop);
        }

        static ILiteral[] NegatedBoundedSpan(IntVar[] works, int start, int length)
        {
            var sequence = new List<ILiteral>();

            if (start > 0)
                sequence.Add(works[start - 1]);

            foreach (var i in Range(length))
                sequence.Add(works[start + i].Not());

            if (start + length < works.Length)
                sequence.Add(works[start + length]);

            return sequence.ToArray();
        }

        static void Main(string[] args)
        {
            Skill bartender = new Skill()
            {
                Id = 0,
                Name = "Bartender"
            };
            Skill bartender1 = new Skill()
            {
                Id = 1,
                Name = "Bartender"
            };

            Skill waiter = new Skill()
            {
                Id = 1,
                Name = "Waiter"
            };

            Skill cashier = new Skill()
            {
                Id = 2,
                Name = "Cashier"
            };

            List<Skill> skills = new List<Skill>()
            {
                bartender,waiter,cashier
            };

            Staff ft0 = new()
            {
                Id = 0,
                Name = "An",
                Skills = new Skill[] { bartender },
                Availables = new AvailableTime[]
               {
                    new AvailableTime()
                    {
                        Day = 0,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 1,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 2,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                   new AvailableTime()
                    {
                        Day = 3,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },                    
/*                   new AvailableTime()
                    {
                        Day = 4,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },*/
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    }
               }
            };
            Staff ft1 = new()
            {
                Id = 1,
                Name = "Binh",
                Skills = new Skill[] { bartender },
                Availables = new AvailableTime[]
               {
                    new AvailableTime()
                    {
                        Day = 0,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 1,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 2,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                   new AvailableTime()
                    {
                        Day = 3,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                   new AvailableTime()
                    {
                        Day = 4,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    }
               }
            };
            Staff ft2 = new()
            {
                Id = 2,
                Name = "Cuong",
                Skills = new Skill[] { waiter, cashier },
                Availables = new AvailableTime[]
               {
                    new AvailableTime()
                    {
                        Day = 0,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 1,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
/*                    new AvailableTime()
                    {
                        Day = 2,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },*/
                   new AvailableTime()
                    {
                        Day = 3,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                   new AvailableTime()
                    {
                        Day = 4,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    }
               }
            };
            Staff ft3 = new()
            {
                Id = 3,
                Name = "Mai",
                Skills = new Skill[] { waiter, cashier },
                Availables = new AvailableTime[]
               {
                    new AvailableTime()
                    {
                        Day = 0,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 1,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 2,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                   new AvailableTime()
                    {
                        Day = 3,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                   new AvailableTime()
                    {
                        Day = 4,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    }
               }
            };

            Staff ft4 = new()
            {
                Id = 4,
                Name = "Dao",
                Skills = new Skill[] { bartender, waiter, cashier },
                Availables = new AvailableTime[]
                    {
                    new AvailableTime()
                    {
                        Day = 0,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 1,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 2,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                   new AvailableTime()
                    {
                        Day = 3,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                   new AvailableTime()
                    {
                        Day = 4,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 0, End = 23}
                        }
                    }
                    }
            };

            List<Staff> ftStaff = new()
            {
                ft0,
                ft1,
                ft2,
                ft3,
                ft4
            };

            Staff pt0 = new()
            {
                Id = 0,
                Name = "Linh",
                Skills = new Skill[] { bartender },
                Availables = new AvailableTime[]
               {
                    new AvailableTime()
                    {
                        Day = 1,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 6, End = 11}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 3,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 6, End = 12}
                        }
                    },
                   new AvailableTime()
                    {
                        Day = 4,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 17}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 6, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 6, End = 16}
                        }
                    }
               }
            };
            Staff pt1 = new()
            {
                Id = 0,
                Name = "Thuy",
                Skills = new Skill[] { waiter, cashier },
                Availables = new AvailableTime[]
               {
                    new AvailableTime()
                    {
                        Day = 1,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 11, End = 22}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 3,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 11, End = 22}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 4,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 17}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 11, End = 17}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 11, End = 23}
                        }
                    },
               }
            };
            Staff pt2 = new()
            {
                Id = 0,
                Name = "Tien",
                Skills = new Skill[] { waiter, cashier },
                Availables = new AvailableTime[]
               {
                    new AvailableTime()
                    {
                        Day = 0,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 11, End = 22}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 2,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 17}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 3,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 17}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 17, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 17, End = 23}
                        }
                    },
               }
            };
            Staff pt3 = new()
            {
                Id = 0,
                Name = "Tuyen",
                Skills = new Skill[] { waiter, cashier },
                Availables = new AvailableTime[]
               {
                    new AvailableTime()
                    {
                        Day = 0,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 17, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 2,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 17, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 4,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 14, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 14, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 16, End = 23}
                        }
                    },
               },
            };
            Staff pt4 = new()
            {
                Id = 0,
                Name = "Van",
                Skills = new Skill[] { waiter, cashier },
                Availables = new AvailableTime[]
            {
                    new AvailableTime()
                    {
                        Day = 0,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 12}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 2,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 17, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 3,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 11, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 12}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 4,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 18, End = 23}
                        }
                    },

            }
            };
            Staff pt5 = new()
            {
                Id = 0,
                Name = "Tong",
                Skills = new Skill[] { bartender },
                Availables = new AvailableTime[]
                {
                    new AvailableTime()
                    {
                        Day = 0,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 17, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 1,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 11, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 4,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 17, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 17, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 17, End = 23}
                        }
                    },
                }
            };
            Staff pt6 = new()
            {
                Id = 0,
                Name = "Hung",
                Skills = new Skill[] { bartender },
                Availables = new AvailableTime[]
                {
                    new AvailableTime()
                    {
                        Day = 0,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 17}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 1,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 18, End = 22}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 2,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 11}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 4,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 11}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 17, End = 23}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 18, End = 23}
                        }
                    },
                 }
            };
            Staff pt7 = new()
            {
                Id = 0,
                Name = "Kha",
                Skills = new Skill[] { bartender, waiter, cashier },
                Availables = new AvailableTime[]
               {
                   new AvailableTime()
                    {
                        Day = 1,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 17}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 2,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 11}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 3,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 11}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 5,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 11, End = 17}
                        }
                    },
                    new AvailableTime()
                    {
                        Day = 6,
                        Sessions = new Session[]
                        {
                            new Session{ Start = 7, End = 17}
                        }
                    },
               }
            };
            List<Staff> ptStaff = new()
            {
                pt0,
                pt1,
                pt2,
                pt3,
                pt4,
                pt5,
                pt6,
                pt7
            };


            DemandByDay[] demands = new DemandByDay[]
            {
                new DemandByDay()
                {
                    Day = 0,
                    DemandBySkills = new DemandBySkill[]
                    {
                        new DemandBySkill()
                        {
                            Skill = bartender,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 11},
                                    Quantity = 2
                                },
                                 new Demand()
                                {
                                    Session = new Session(){Start = 12, End = 14},
                                    Quantity = 1
                                },
                                  new Demand()
                                {
                                    Session = new Session(){Start = 15, End = 22},
                                    Quantity = 2
                                }
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = cashier,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = waiter,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                    }
                },
                new DemandByDay()
                {
                    Day = 1,
                    DemandBySkills = new DemandBySkill[]
                    {
                        new DemandBySkill()
                        {
                            Skill = bartender,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 11},
                                    Quantity = 2
                                },
                                 new Demand()
                                {
                                    Session = new Session(){Start = 12, End = 14},
                                    Quantity = 1
                                },
                                  new Demand()
                                {
                                    Session = new Session(){Start = 15, End = 22},
                                    Quantity = 2
                                }
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = cashier,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = waiter,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                    }
                },
                new DemandByDay()
                {
                    Day = 2,
                    DemandBySkills = new DemandBySkill[]
                    {
                        new DemandBySkill()
                        {
                            Skill = bartender,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 11},
                                    Quantity = 2
                                },
                                 new Demand()
                                {
                                    Session = new Session(){Start = 12, End = 14},
                                    Quantity = 1
                                },
                                  new Demand()
                                {
                                    Session = new Session(){Start = 15, End = 22},
                                    Quantity = 2
                                }
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = cashier,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = waiter,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                    }
                },
                new DemandByDay()
                {
                    Day = 3,
                    DemandBySkills = new DemandBySkill[]
                    {
                        new DemandBySkill()
                        {
                            Skill = bartender,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 11},
                                    Quantity = 2
                                },
                                 new Demand()
                                {
                                    Session = new Session(){Start = 12, End = 14},
                                    Quantity = 1
                                },
                                  new Demand()
                                {
                                    Session = new Session(){Start = 15, End = 22},
                                    Quantity = 2
                                }
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = cashier,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = waiter,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                    }
                },
                new DemandByDay()
                {
                    Day = 4,
                    DemandBySkills = new DemandBySkill[]
                    {
                        new DemandBySkill()
                        {
                            Skill = bartender,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 11},
                                    Quantity = 2
                                },
                                 new Demand()
                                {
                                    Session = new Session(){Start = 12, End = 14},
                                    Quantity = 1
                                },
                                  new Demand()
                                {
                                    Session = new Session(){Start = 15, End = 22},
                                    Quantity = 2
                                }
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = cashier,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = waiter,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                    }
                },
                new DemandByDay()
                {
                    Day = 5,
                    DemandBySkills = new DemandBySkill[]
                    {
                        new DemandBySkill()
                        {
                            Skill = bartender,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 14},
                                    Quantity = 2
                                },
                                 new Demand()
                                {
                                    Session = new Session(){Start = 15, End = 17},
                                    Quantity = 3
                                },
                                  new Demand()
                                {
                                    Session = new Session(){Start = 18, End = 22},
                                    Quantity = 4
                                }
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = cashier,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = waiter,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 17},
                                    Quantity = 1
                                },
                                 new Demand()
                                {
                                    Session = new Session(){Start = 18, End = 22},
                                    Quantity = 2
                                },
                            }
                        },
                    }
                },
                new DemandByDay()
                {
                    Day = 6,
                    DemandBySkills = new DemandBySkill[]
                    {
                        new DemandBySkill()
                        {
                            Skill = bartender,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 14},
                                    Quantity = 2
                                },
                                 new Demand()
                                {
                                    Session = new Session(){Start = 15, End = 17},
                                    Quantity = 3
                                },
                                  new Demand()
                                {
                                    Session = new Session(){Start = 18, End = 22},
                                    Quantity = 4
                                }
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = cashier,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 22},
                                    Quantity = 1
                                },
                            }
                        },
                        new DemandBySkill()
                        {
                            Skill = waiter,
                            Demands = new Demand[]
                            {
                                new Demand()
                                {
                                    Session = new Session(){Start = 7, End = 17},
                                    Quantity = 1
                                },
                                 new Demand()
                                {
                                    Session = new Session(){Start = 18, End = 22},
                                    Quantity = 2
                                },
                            }
                        },
                    }
                },

            };

            SchedulingHandle schedulingHandle = new()
            {
                DataInput = new()
                {
                    Demand = demands,
                    NumDay = 7,
                    Skills = skills,
                    NumTimeFrame = 24,
                    StaffDic = new Dictionary<TypeStaff, List<Staff>>()
                    {
                        [TypeStaff.FULL_TIME] = ftStaff,
                        [TypeStaff.PART_TIME] = ptStaff
                    }
                },
                ConstraintData = new()
                {
                    MaxDayOff = 3,
                    MinDayOff = 1,

                    MaxFTWorkingTimeOnWeek = 58,
                    MinFTWorkingTimeOnWeek = 40,

                    MaxPTWorkOnWeek = 58,
                    MinPTWorkOnWeek = 20,

                    MaxFTWorkingTimeInDay = 12,
                    MaxPTWorkingTimeInDay = 8,

                    MaxNormalHour = 8,

                    MaxFTSessionDuration = 12,
                    MinFTSessionDuration = 8,

                    MaxPTSessionDuration = 8,
                    MinPTSessionDuration = 5,

                    MaxShiftInDay = 2,

                    TimeStart = 7,
                    TimeEnd = 22
                }
            };

            schedulingHandle.Solve("D:\\STS\\outGopNew5.csv", 120);


        }
        static void SolveShiftScheduling()
        {
            Console.WriteLine("Hello World!");

            int num_nurses = 4;
            int num_shifts = 3;
            int num_days = 3;

            var shifts_str = new[] { "A", "B", "C" };

            var all_nurses = Enumerable.Range(0, num_nurses).ToArray();
            var all_shifts = Enumerable.Range(0, num_shifts).ToArray();
            var all_days = Enumerable.Range(0, num_days).ToArray();
            Console.WriteLine(all_nurses);

            IntVar[,,] shifts = new IntVar[num_nurses, num_days, num_shifts];
            var model = new CpModel();
            foreach (int n in all_nurses)
            {
                foreach (int d in all_days)
                {
                    foreach (int s in all_shifts)
                    {
                        shifts[n, d, s] = model.NewBoolVar($"shift_n{n}_d{d}_s{s}");
                    }
                }
            }

            foreach (int d in all_days)
            {
                foreach (int s in all_shifts)
                {
                    var temp = new IntVar[num_nurses];
                    foreach (int n in all_nurses)
                    {
                        temp[n] = shifts[n, d, s];
                    }

                    model.Add(LinearExpr.Sum(temp) == 1);
                }
            }

            foreach (int n in all_nurses)
            {
                foreach (int d in all_days)
                {
                    var temp = new IntVar[num_shifts];
                    foreach (int s in all_shifts)
                    {
                        temp[s] = shifts[n, d, s];
                    }

                    model.Add(LinearExpr.Sum(temp) <= 1);
                }
            }

            // Try to distribute the shifts evenly, so that each nurse works
            // min_shifts_per_nurse shifts. If this is not possible, because the total
            // number of shifts is not divisible by the number of nurses, some nurses will
            // be assigned one more shift.
            var min_shifts_per_nurse = (num_shifts * num_days) / num_nurses;
            var max_shifts_per_nurse = 0;
            if ((num_shifts * num_days) % num_nurses == 0)
            {
                max_shifts_per_nurse = min_shifts_per_nurse;
            }
            else
            {
                max_shifts_per_nurse = min_shifts_per_nurse + 1;
                foreach (int n in all_nurses)
                {
                    /*var num_shifts_worked = 0;*/
                    var num_shifts_worked = new IntVar[num_days * num_shifts];
                    int num = 0;
                    foreach (int d in all_days)
                    {
                        foreach (int s in all_shifts)
                        {
                            num_shifts_worked[d * num_days + s] = shifts[n, d, s];
                            // num += shifts[n, d, s];
                        }
                    }
                    model.Add(LinearExpr.Sum(num_shifts_worked) >= min_shifts_per_nurse);
                    model.Add(LinearExpr.Sum(num_shifts_worked) <= max_shifts_per_nurse);
                }
            }


            var a_few_solutions = Enumerable.Range(0, 5);
            CpSolver solver = new CpSolver();

            CpSolverStatus status = solver.Solve(model);
            Console.WriteLine(status);

            NursesPartialSolutionPrinter cb = new NursesPartialSolutionPrinter(shifts, num_nurses,
                                                    num_days, num_shifts,
                                                    a_few_solutions);
            solver.SearchAllSolutions(model, cb);

            Console.WriteLine(String.Format("Number of solutions found: {0}", cb.SolutionCount()));


            /*           solver.StringParameters = "num_search_workers:4, log_search_progress: true, max_time_in_seconds:30";

                       var status = solver.Solve(model);

                       if (status == CpSolverStatus.Optimal || status == CpSolverStatus.Feasible)
                       {
                           Console.WriteLine();
                           var header = "          ";
                           Console.WriteLine(header);

                           foreach (int n in all_nurses)
                           {
                               var schedule = "";
                               foreach (int d in all_days)
                               {

                                   foreach (int s in all_shifts)
                                   {
                                       if (solver.BooleanValue(shifts[n, d, s]))
                                       {
                                           schedule += shifts_str[s] + " ";
                                       }
                                   }


                               }
                               Console.WriteLine($"worker {n}: {schedule}");
                               Console.WriteLine();
                           }
                       }*/

        }
    }

    public class VarArraySolutionPrinter : CpSolverSolutionCallback
    {
        public VarArraySolutionPrinter(IntVar[] variables)
        {
            variables_ = variables;
        }

        public override void OnSolutionCallback()
        {
            {
                Console.WriteLine(String.Format("Solution #{0}: time = {1:F2} s", solution_count_, WallTime()));

                foreach (IntVar v in variables_)
                {
                    Console.WriteLine(String.Format("  {0} = {1}", v.ShortString(), Value(v)));
                }
                solution_count_++;
            }
        }

        public int SolutionCount()
        {
            return solution_count_;
        }

        private int solution_count_;
        private IntVar[] variables_;
        private IntVar count_;
    }


    class NursesPartialSolutionPrinter : CpSolverSolutionCallback
    {

        private IntVar[,,] shifts_;
        private IEnumerable<int> _sols;
        private int num_days_;
        private int num_nurses_;
        private int num_shifts;


        public NursesPartialSolutionPrinter(IntVar[,,] shifts, int num_nurses, int num_days, int num_shifts, IEnumerable<int> sols)
        {
            this.shifts_ = shifts;
            this.num_nurses_ = num_nurses;
            this.num_days_ = num_days;
            this.num_shifts = num_shifts;
            this._sols = sols;

        }

        public override void OnSolutionCallback()
        {

            if (_sols.Contains(solution_count_))
            {
                Console.WriteLine($"Solution {solution_count_}");

                foreach (int d in Enumerable.Range(0, num_days_).ToArray())
                {
                    Console.WriteLine($"Day {d}");
                    foreach (int n in Enumerable.Range(0, num_nurses_).ToArray())
                    {
                        bool is_working = false;
                        foreach (int s in Enumerable.Range(0, num_shifts).ToArray())
                        {
                            if (Value(shifts_[n, d, s]) == 1)
                            {
                                is_working = true;
                                Console.WriteLine($"Nurse {n} works shift {s}");

                            }

                            /*foreach (IntVar v in shifts_)
                            {
                              
                              *//*  Console.WriteLine(String.Format("  {0} = {1}", v.ShortString(), Value(v)));*//*
                            }*/

                        }
                        if (!is_working)
                        {
                            Console.WriteLine($"Nurse {n} does not work");
                        }

                    }
                    Console.WriteLine();
                }
                solution_count_++;
            }

        }

        private int solution_count_;
        public int SolutionCount()
        {
            return solution_count_;
        }
    }

}



