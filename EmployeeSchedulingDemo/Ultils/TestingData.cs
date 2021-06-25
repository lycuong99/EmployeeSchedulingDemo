using System;
using System.Collections.Generic;
using EmployeeSchedulingDemo.data;

namespace EmployeeSchedulingDemo.Ultils
{
    public class TestingData
    {
        public TestingData()
        {
        }


        public static DataInput SampleDataInput1()
        {
            Skill bartender = new Skill()
            {
                Id = 0,
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

            List<Skill> skills = new()
            {
                bartender,
                waiter,
                cashier
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

            return new DataInput
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
            };
        }


        public static ConstraintData SampleConstraintData1()
        {
            return new ConstraintData
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
            };
        }
    }
}
