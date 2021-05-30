label com1:

    #Initial Background
    scene bg_temp

    #Show Zeus
    show z_temp at pos_left

    #Show Farmer
    show f_temp at pos_right

    j "Hey come over here. It looks like a few people actually commented on the post."
    z "Where are these people? I do not see any other mortals around."
    j "No, on the phone. Come over here and look."

    p "Steve77: nice"

    z "Yes, Steve77, this phone drawing of me is exceptionally fine."
    j "You know they can't hear you right?"
    z "What are you taking about they have ears don't they?"
    j "That's not how this works. If you want to talk them you are going to have to type it out."
    j "Look do you see that reply button, press it and you can type out a message for them."

    menu:
        p "Reply?"
        "Yes Steve77 this phone drawing of me is exceptionally fine.":
            $ follow_count += 1

    j "Also is called a picture by the way"

    p "The_HatEnthusiast: Nice hat. Looks like some fine quality leather. Where did you pick it up?"
    p "JuiceMan: What are you some kind of cowboy get with the times"

    menu:
        p "Reply?"

        "I am neither part beast or part human! I am a God!":
            $ follow_count += 1
        "Since when have mortals mixed with cattle? Horses were much more fitting.":
            $ follow_count += 3
        "Ignore it":
            $ follow_count += 2
            return

    j "You don't know what a cowboy is do you?"
    z "Of course I do, some weird modern centaur or satyr."
    j "No they are like farmer workers that ride on horses and stuff. Used to be popular back in the day."
    z "Where does the cow come from in any of this? You humans have lost all common sense. Why not a horseboy or farmerboy instead."
    j "*Sign*"

    return
