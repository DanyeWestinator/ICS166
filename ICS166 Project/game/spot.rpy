define mt1 = Character("Mall Teen 1")
define mt2 = Character("Mall Teen 2")

label spot:
    scene mall
    #Show Zeus
    show z_temp at pos_left
    #Show Farmer
    show f_temp at pos_right

    "Later that day during a trip to the store for some food."
    j "Here, let me go pick up that shovel I needed real quick and then we can grab the frozen stuff on our way out."
    z "These markets really do have everything in such a small space these days."
    j "Yep, they make picking up stuff you need pretty convenient."
    z "The agora of Greece spanned large parts of the cities but now everything is just steps away."
    z "Tell me farmer, how does one shop produce such a large quantity of goods."
    j "They don't actually make all this stuff, they just buy stuff from a bunch of other places."

    "Not far off in the store."

    hide z_temp
    hide f_temp

    #Show img for the teens

    mt1 "Wait do see that?"
    mt2 "See what?"
    mt1 "Over there look."
    mt1 "Its that guy from InstaBlab."
    # If we are doing this after the fight change this but I thought we were doing it before that
    mt2 "O, the dude that can power lightbulbs just be holding them."
    mt1 "Ya that one."

    #hide img for the teens
    #Show Zeus
    show z_temp at pos_left
    #Show Farmer
    show f_temp at pos_right

    j "Hey do you hear that? It sounds like you've got some fans over there."
    j "Maybe you should go over there and say hi to them. I am sure they would appreciate it."

    menu:
        "Approach the teens?"

        "Yes":
            "Zeus walks over to the two teens."
            z "Greetings mortals"

            #Zeus talks to them a bit, prob shows a bit of his power and feels stronger since he has more worship.

        "No":
            z "Why would I do that? There is no need for a god to interact with all of his followers."
            z "Do you have any idea how busy I would be if I greeted every mortal that worshipped me?"
            j "I don't disagree, but that teenager was right. You have to make people feel like they matter."
            z "You have much to learn about being a god. You need to reserve your appearances for the right moments. They are more impactful that way."
            j "How can you ever gain followers if they never see you?"
            z "I have been doing this for centuries so trust me farmer, there are benefits to being elusive."
            j "I guess if that is what works."


    j "Well anyways, we should be getting back home soon before it gets too dark out."

    return
