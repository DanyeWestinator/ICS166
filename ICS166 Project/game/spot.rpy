define t1 = Character("Teen 1")
define t2 = Character("Teen 2")

label spot:
    #Change to our mall bg
    scene bg_temp
    #Show Zeus
    show z_temp at pos_left
    #Show Farmer
    show f_temp at pos_right

    f "Here, let me go pick up that shovel I needed real quick and then we can grab the frozen stuff on our way out."
    z "These markets really do have everything these days."

    hide z_temp
    hide f_temp

    #Show img for the teens

    t1 "Wait do see that?"
    t2 "See what?"
    t1 "Over there look."
    t1 "Its that guy from ###Do we have a name for the social media###."
    # If we are doing this after the fight change this but I thought we were doing it before that
    t2 "O, the dude that can power lightbulbs just be holding them."
    t1 "Ya that one."

    #hide img for the teens
    #Show Zeus
    show z_temp at pos_left
    #Show Farmer
    show f_temp at pos_right

    f "Hey do you hear that?"
    f "It sounds like you've got some fans over there."
    f "Maybe you should go over there and say hi to them. I am sure they would appreciate it."

    menu:
        "Approach the teens?"

        "Yes":
            "Zeus walks over to the two teens."

            #Zeus talks to them a bit, prob shows a bit of his power and feels stronger since he has more worship.

        "No":
            z "Why would that?"
            z "There is no need for a god to interact with all of his followers."
            z "Do you have any idea how busy I would be if I greeted every mortal that worshipped me?"
            f "I don't disagree, it sounds like a lot of work, but it would be nice gesture."


    f "We should be getting back home soon before it gets too dark out."

    return
